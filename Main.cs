using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System.Threading;
using ArduinoBluetoothManager.Properties;
using System.Drawing;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Xml.Linq;
using InTheHand.Net;

namespace ArduinoBluetoothManager
{
    public partial class Main : Form
    {

        IniFile ini;
        //BluetoothCache bluetoothCache;

        private BluetoothClient bluetoothClient;
        private BluetoothDeviceInfo selectedDevice;
        private BluetoothDeviceInfo[] discoveredDevices;
        private Stream bluetoothStream; // Maintain the stream at the class level

        Image onImage = Properties.Resources.offImage;
        Image offImage = Properties.Resources.onImage;

        bool isConnected = false;
        bool allowReConnect = false;

        public static string version = "1.3.2";
        private bool mouseDown;
        private Point lastLocation;

        void InitializeFiles()
        {
            try
            {
                if (!Directory.Exists("data"))
                    Directory.CreateDirectory("data");

                if (!File.Exists("data/abmdata.ini"))
                {
                    var file = File.Create("data/abmdata.ini");
                    file.Close();
                }

                if (!File.Exists("data/abmdata.ini"))
                {
                    var file = File.Create("data/bluetooth_cache.xml");
                    file.Close();
                }

                ini = new IniFile("data/abmdata.ini");
                //bluetoothCache = new BluetoothCache("data/bluetooth_cache.xml");
            }
            catch (Exception ex) { }
        }

        public Main()
        {
            InitializeComponent();
            //InitializeFiles();
            InitializeBluetooth();
            //ReadSettings();
        }

        private void InitializeBluetooth()
        {
            bluetoothClient = new BluetoothClient();

            //ReadBTCache();
            DiscoverDevices();
        }

        /*void ReadBTCache()
        {
            List<string> cachedNames = bluetoothCache.GetBluetoothNames();
            foreach (var name in cachedNames)
            {
                apcmb_devices.Items.Add(name);
                //discoveredDevices.Add(new BluetoothDeviceInfo(name));
            }
        }*/

        private async void DiscoverDevices()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                discoveredDevices = null;
                discoveredDevices = await Task.Run(() => bluetoothClient.DiscoverDevices().ToArray());
                UpdateDeviceList();
                LoadingHandler(false);
            }
            catch
            {
                lbl_status.Text = "Failed to discover devices.";
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void UpdateDeviceList()
        {
            apcmb_devices.Invoke((MethodInvoker)delegate
            {
                apcmb_devices.Items.Clear();
                apcmb_devices.Items.Add("--- SELECT DEVICE ---");
                foreach (var device in discoveredDevices)
                {
                    apcmb_devices.Items.Add(device.DeviceName);
                    //bluetoothCache.AddBluetoothName(device.DeviceName);
                }
                apcmb_devices.SelectedIndex = 0;
            });
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            if (apcmb_devices.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a device to connect.", "Device not selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Ensure discoveredDevices is not null and the selected index is within bounds
            if (discoveredDevices == null /*|| apcmb_devices.SelectedIndex - 1 < 0 || apcmb_devices.SelectedIndex - 1 >= discoveredDevices.Length*/)
            {
                MessageBox.Show("Invalid selection or no devices discovered.");
                return;
            }

            selectedDevice = discoveredDevices[apcmb_devices.SelectedIndex - 1];
            if (selectedDevice == null)
            {
                MessageBox.Show("Selected device is not available.");
                return;
            }

            // Check if the device is available in the cache
            /*bool isCached = bluetoothCache.GetBluetoothNames().Contains(selectedDevice.DeviceName);

            if (!isCached)
            {
                // If not available in the cache, perform a new discovery and connect
                await DiscoverDevicesAsync();
                selectedDevice = discoveredDevices.FirstOrDefault(device => device.DeviceAddress == selectedDevice.DeviceAddress);

                if (selectedDevice == null)
                {
                    MessageBox.Show("Selected device is not available.");
                    return;
                }
            }*/

            if (isConnected)
            {
                if (MessageBox.Show("Do you want to disconnect ?", "Please confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //selectedDevice = null;
                    bluetoothClient.Close();
                    isConnected = false;
                    allowReConnect = true;
                    lbl_status.Text = "Disconnected";
                    btnConnect.Image = Properties.Resources.switchGray;
                    //discoveredDevices = null;
                    return;
                }
            }
            else
            {
                if (allowReConnect)
                {
                    lbl_status.Text = "Reconnecting";
                    bluetoothClient = new BluetoothClient();
                    bluetoothStream = bluetoothClient.GetStream();
                }

                await ConnectToDevice(selectedDevice);
            }
        }

        private async Task ConnectToDevice(BluetoothDeviceInfo device)
        {
            if (device == null)
            {
                lbl_status.Text = "No device selected or device is null.";
                return;
            }

            lbl_status.Text = "Connecting...";
            try
            {
                if (!device.Authenticated)
                {
                    bool paired = await Task.Run(() => BluetoothSecurity.PairRequest(device.DeviceAddress, "1234")); // Default PIN, change as needed
                    if (!paired)
                    {
                        lbl_status.Text = "Pairing failed.";
                        return;
                    }
                }

                isConnected = true;
                bluetoothClient.Connect(device.DeviceAddress, BluetoothService.SerialPort);
                lbl_status.Text = $"Connected to {device.DeviceName}";
                btnConnect.Image = Properties.Resources.btn_on;
            }
            catch (Exception ex)
            {
                isConnected = false;
                var failedMsg = "Connection failed";
                if (ex.Message.Length > 49)
                {
                    MessageBox.Show(ex.Message + "\n\nPlease make sure, the target device is one of these\n[HC-O6, HC-05]", failedMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lbl_status.Text = failedMsg;
                }
                else
                    lbl_status.Text = ex.Message;
            }
        }

        void LoadingHandler(bool show, string text = "Loading...")
        {
            // This method now uses a unified action to update the UI, ensuring consistency whether invoking is required or not.
            Action updateUI = () =>
            {
                lbl_wait.Text = text;
                panel_loading.Visible = show;
            };

            if (panel_loading.InvokeRequired)
            {
                // Invoke the action on the UI thread if required
                panel_loading.Invoke(updateUI);
            }
            else
            {
                // Execute the action directly if already on the UI thread
                updateUI();
            }
        }


        private string GetPINFromUser(string prompt, string title)
        {
            using (Form promptForm = new Form())
            using (Label lblPrompt = new Label())
            using (TextBox txtInput = new TextBox())
            using (Button btnOK = new Button())
            {
                promptForm.Text = title;
                lblPrompt.Text = prompt;
                btnOK.Text = "OK";
                btnOK.DialogResult = DialogResult.OK;

                promptForm.AcceptButton = btnOK;

                lblPrompt.SetBounds(9, 20, 372, 13);
                txtInput.SetBounds(12, 36, 372, 20);
                btnOK.SetBounds(309, 72, 75, 23);

                lblPrompt.AutoSize = true;

                promptForm.ClientSize = new System.Drawing.Size(396, 107);
                promptForm.Controls.AddRange(new Control[] { lblPrompt, txtInput, btnOK });
                promptForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                promptForm.StartPosition = FormStartPosition.CenterScreen;
                promptForm.MinimizeBox = false;
                promptForm.MaximizeBox = false;
                promptForm.ControlBox = false;

                if (promptForm.ShowDialog() == DialogResult.OK)
                {
                    return txtInput.Text;
                }
                else
                {
                    return null; // User canceled
                }
            }
        }

        private async Task<bool> SendDataAsync(string btnData)
        {
            if (selectedDevice == null || !selectedDevice.Authenticated)
            {
                MessageBox.Show("Please connect to a Bluetooth device first.", "Not connected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Ensure the client is connected and the stream is ready
            if (bluetoothClient.Connected)
            {
                if (bluetoothStream == null || !bluetoothStream.CanWrite)
                {
                    bluetoothStream = bluetoothClient.GetStream();
                }
            }
            else
            {
                MessageBox.Show("Bluetooth client is not connected.");
                return false;
            }

            if (bluetoothStream == null || !bluetoothStream.CanWrite)
            {
                MessageBox.Show("Stream is not available for writing.");
                return false;
            }

            try
            {
                //MessageBox.Show("Sending data: " + btnData);
                byte[] data = System.Text.Encoding.ASCII.GetBytes(btnData);
                await bluetoothStream.WriteAsync(data, 0, data.Length);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending data: " + ex.Message);
                return false;
            }
        }

        private void buttonClickHandler(object sender, EventArgs e)
        {
            PictureBox pbBtn = sender as PictureBox;
            if (pbBtn != null)
                DoProcess(pbBtn);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (apcmb_devices.Items.Count > 0)
                apcmb_devices.SelectedIndex = 0;
        }

        private async void DoProcess(PictureBox pb)
        {
            string tag = (string)pb.Tag;
            var name = pb.Name;
            var data = name.Split('_')[2];
            var dataInt = int.Parse(data);

            var nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var lets = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };

            if (tag == "on")
            {
                if (await SendDataAsync(lets[dataInt - 1]))
                {
                    pb.Invoke(new Action(() =>
                    {
                        pb.Image = Properties.Resources.offImage; // Assuming "onImage" means the device is off now
                        pb.Tag = "off";
                    }));
                }
            }
            else
            {
                if (await SendDataAsync(nums[dataInt - 1].ToString()))
                {
                    pb.Invoke(new Action(() =>
                    {
                        pb.Image = Properties.Resources.onImage; // Assuming "offImage" means the device is on now
                        pb.Tag = "on";
                    }));
                }
            }
        }

        private async void pb_lamp_I_Click(object sender, EventArgs e)
        {
            if (!await SendDataAsync("I")) return;
            pb_lamp_I.Image = Properties.Resources.onImage;
            pb_lamp_9.Image = Properties.Resources.offImage;
            foreach (Control c in panel_lamps.Controls)
                if (c is PictureBox)
                    (c as PictureBox).Image = Properties.Resources.offImage;
        }

        private async void pb_lamp_9_Click(object sender, EventArgs e)
        {
            if (!await SendDataAsync("9")) return;
            pb_lamp_9.Image = Properties.Resources.onImage;
            pb_lamp_I.Image = Properties.Resources.offImage;
            foreach (Control c in panel_lamps.Controls)
                if (c is PictureBox)
                    (c as PictureBox).Image = Properties.Resources.onImage;
        }

        private void pb_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_reload_Click(object sender, EventArgs e)
        {
            LoadingHandler(true, "Loading...");
            DiscoverDevices();
        }

        private void panel_header_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel_header_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point(
                    (Location.X - lastLocation.X) + e.X,
                    (Location.Y - lastLocation.Y) + e.Y);
            }
        }

        private void panel_header_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                MessageBox.Show($"Arduino Bluetooth Manager for 8 LAMP version {version}", "Arduino Bluetooth Manager");
        }

        private void pb_menu_Click(object sender, EventArgs e)
        {
            panel_info.Visible = !panel_info.Visible;
        }

        private void btn_info_Click(object sender, EventArgs e)
        {
            panel_info.Visible = !panel_info.Visible;
            string tag = (string)(sender as Button).Tag;
            Info i = new Info(tag == "ardcode");
            i.ShowDialog();
        }

        private void pb_menu_MouseEnter(object sender, EventArgs e)
        {
            pb_menu.Image = Properties.Resources.menu_hover;
        }

        private void pb_menu_MouseLeave(object sender, EventArgs e)
        {
            pb_menu.Image = Properties.Resources.menu;
        }

        private void pb_close_MouseEnter(object sender, EventArgs e)
        {
            pb_close.Image = Properties.Resources.close;
        }

        private void pb_close_MouseLeave(object sender, EventArgs e)
        {
            pb_close.Image = Properties.Resources.close_gray;
        }

        private void btnConnect_MouseEnter(object sender, EventArgs e)
        {
            btnConnect.Size = new Size(btnConnect.Width - 1, btnConnect.Height - 1);
        }

        private void btnConnect_MouseLeave(object sender, EventArgs e)
        {
            btnConnect.Size = new Size(btnConnect.Width + 1, btnConnect.Height + 1);
        }

        private void pb_lamp_1_MouseEnter(object sender, EventArgs e)
        {
            var pbBtn = (sender) as PictureBox;
            pbBtn.Size = new Size(pbBtn.Width - 1, pbBtn.Height - 1);
        }

        private void pb_lamp_1_MouseLeave(object sender, EventArgs e)
        {
            var pbBtn = (sender) as PictureBox;
            pbBtn.Size = new Size(pbBtn.Width + 1, pbBtn.Height + 1);
        }
    }
}
