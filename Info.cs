using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoBluetoothManager
{
    public partial class Info : Form
    {
        bool isArduinoCode = false;
        public Info(bool isArduinoCode)
        {
            InitializeComponent();
            this.isArduinoCode = isArduinoCode;
        }

        void ShowArduinoCode()
        {
            panel_ardcode.Visible = true;
            panel_ardcode.Dock = DockStyle.Fill;
            string arduinoCode = @"
                #include <SoftwareSerial.h>
                SoftwareSerial mySerial(0, 1); 

                #define Lamp1 2
                #define Lamp2 3
                #define Lamp3 4
                #define Lamp4 5
                #define Lamp5 6
                #define Lamp6 7
                #define Lamp7 8
                #define Lamp8 9

                void setup() {
                  pinMode(Lamp1, OUTPUT);
                  pinMode(Lamp2, OUTPUT);
                  pinMode(Lamp3, OUTPUT);
                  pinMode(Lamp4, OUTPUT);
                  pinMode(Lamp5, OUTPUT);
                  pinMode(Lamp6, OUTPUT);
                  pinMode(Lamp7, OUTPUT);
                  pinMode(Lamp8, OUTPUT);
                  mySerial.begin(9600);
                  Serial.begin(9600);
                }

                char val;
                void loop() {
                if( mySerial.available() > 0 ) {
                  val = mySerial.read();
                  Serial.println(val); 
                }
                //Lamp is on
                if( val == '1') {
                  digitalWrite(Lamp1,HIGH);}
                else if( val == '2') {
                  digitalWrite(Lamp2,HIGH);}
                else if( val == '3') {
                  digitalWrite(Lamp3,HIGH);}
                else if( val == '4') {
                  digitalWrite(Lamp4,HIGH);}
                else if( val == '5') {
                  digitalWrite(Lamp5,HIGH);}
                else if( val == '6') {
                  digitalWrite(Lamp6,HIGH);}
                else if( val == '7') {
                  digitalWrite(Lamp7,HIGH);}
                else if( val == '8') {
                  digitalWrite(Lamp8,HIGH);}
                else if( val == '9'){
                  digitalWrite(Lamp1,HIGH);
                  digitalWrite(Lamp2,HIGH);
                  digitalWrite(Lamp3,HIGH);
                  digitalWrite(Lamp4,HIGH);
                  digitalWrite(Lamp5,HIGH);
                  digitalWrite(Lamp6,HIGH);
                  digitalWrite(Lamp7,HIGH);
                  digitalWrite(Lamp8,HIGH);
                }
                //Lamp is off
                else if( val == 'A') {
                  digitalWrite(Lamp1,LOW);}
                else if( val == 'B') {
                  digitalWrite(Lamp2,LOW);}
                else if( val == 'C') {
                  digitalWrite(Lamp3,LOW);}
                else if( val == 'D') {
                  digitalWrite(Lamp4,LOW);}
                else if( val == 'E') {
                  digitalWrite(Lamp5,LOW);}
                else if( val == 'F') {
                  digitalWrite(Lamp6,LOW);}
                else if( val == 'G') {
                  digitalWrite(Lamp7,LOW);}
                else if( val == 'H') {
                  digitalWrite(Lamp8,LOW);}
                else if( val == 'I') {
                  digitalWrite(Lamp1,LOW);
                  digitalWrite(Lamp2,LOW);
                  digitalWrite(Lamp3,LOW);
                  digitalWrite(Lamp4,LOW);
                  digitalWrite(Lamp5,LOW);
                  digitalWrite(Lamp6,LOW);
                  digitalWrite(Lamp7,LOW);
                  digitalWrite(Lamp8,LOW);
                  }
                }

                ";
            rtb_code.Text = arduinoCode;
        }

        void ShowScheme()
        {
            panel_scheme.Visible = true;
            panel_scheme.Dock = DockStyle.Fill;
        }

        private void Info_Load(object sender, EventArgs e)
        {

            Action act = isArduinoCode ? (Action)ShowArduinoCode : ShowScheme;
            act.Invoke();
        }

        private void btn_copy_Click(object sender, EventArgs e)
        {
            var tool = "the code ";
            if (isArduinoCode)
            {
                Clipboard.SetText(rtb_code.Text);
            }
            else
            {
                tool = "the image ";
                Clipboard.SetImage(pb_scheme.Image);
            }
            lbl_status.Text = $"Copied {tool}to the clipboard!";
            timer_status.Start();
        }

        private void timer_status_Tick(object sender, EventArgs e)
        {
            if (lbl_status.Visible)
            {
                timer_status.Enabled = false;
                lbl_status.Text = "";
            }
        }

        void saveSuccess(string tool)
        {
            lbl_status.Text = $"Saved {tool}!";
            timer_status.Start();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                if (isArduinoCode)
                {
                    string dirName = "ArduinoBluetoothCode_For8Lamps";
                    sfd.FileName = dirName;
                    sfd.Title = "Save arduino code";
                    sfd.Filter = "Arduino IDE files (*.ino)|*.ino|Text files (*.txt)|*.txt";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = sfd.FileName;
                        string directoryPath = Path.GetDirectoryName(filePath);
                        string fileExtension = Path.GetExtension(filePath);
                        string finalFileName = Path.GetFileNameWithoutExtension(filePath);

                        if (!Directory.Exists($@"{directoryPath}\{dirName}"))
                            Directory.CreateDirectory($@"{directoryPath}\{dirName}");

                        string fullFilePath = $@"{directoryPath}\{dirName}\{finalFileName}{fileExtension}";

                        File.WriteAllText(fullFilePath, rtb_code.Text);

                        saveSuccess("Arduino code");
                    }
                }
                else
                {
                    sfd.FileName = "ArduinoBluetoothScheme_For8Lamps";
                    sfd.Title = "Save image";
                    sfd.Filter = "Portable Network Graphic (PNG) files (*.png)|*.png";

                    if (pb_scheme.Image != null && sfd.ShowDialog() == DialogResult.OK)
                    {
                        pb_scheme.Image.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        saveSuccess("Image");
                    }
                }
            }
            catch
            {

            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_copy_Click(sender, e);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_save_Click(sender, e);
        }
    }
}
