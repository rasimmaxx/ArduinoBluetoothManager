namespace ArduinoBluetoothManager
{
    partial class Info
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Info));
            this.panel_body = new System.Windows.Forms.Panel();
            this.panel_bottom = new System.Windows.Forms.Panel();
            this.lbl_status = new System.Windows.Forms.Label();
            this.btn_close = new RJCodeAdvance.RJControls.RJButton();
            this.btn_copy = new RJCodeAdvance.RJControls.RJButton();
            this.btn_save = new RJCodeAdvance.RJControls.RJButton();
            this.panel_scheme = new System.Windows.Forms.Panel();
            this.cms_save = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pb_scheme = new System.Windows.Forms.PictureBox();
            this.panel_ardcode = new System.Windows.Forms.Panel();
            this.rtb_code = new System.Windows.Forms.RichTextBox();
            this.timer_status = new System.Windows.Forms.Timer(this.components);
            this.panel_body.SuspendLayout();
            this.panel_bottom.SuspendLayout();
            this.panel_scheme.SuspendLayout();
            this.cms_save.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_scheme)).BeginInit();
            this.panel_ardcode.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_body
            // 
            this.panel_body.BackColor = System.Drawing.Color.DarkCyan;
            this.panel_body.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_body.Controls.Add(this.panel_scheme);
            this.panel_body.Controls.Add(this.panel_bottom);
            this.panel_body.Controls.Add(this.panel_ardcode);
            this.panel_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_body.Location = new System.Drawing.Point(0, 0);
            this.panel_body.Name = "panel_body";
            this.panel_body.Size = new System.Drawing.Size(685, 428);
            this.panel_body.TabIndex = 0;
            // 
            // panel_bottom
            // 
            this.panel_bottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_bottom.Controls.Add(this.lbl_status);
            this.panel_bottom.Controls.Add(this.btn_close);
            this.panel_bottom.Controls.Add(this.btn_copy);
            this.panel_bottom.Controls.Add(this.btn_save);
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bottom.Location = new System.Drawing.Point(0, 377);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Size = new System.Drawing.Size(683, 49);
            this.panel_bottom.TabIndex = 2;
            // 
            // lbl_status
            // 
            this.lbl_status.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_status.AutoSize = true;
            this.lbl_status.BackColor = System.Drawing.Color.Transparent;
            this.lbl_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_status.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_status.Location = new System.Drawing.Point(112, 27);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(179, 13);
            this.lbl_status.TabIndex = 26;
            this.lbl_status.Text = "                                           ";
            this.lbl_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_close.BackColor = System.Drawing.Color.Brown;
            this.btn_close.BackgroundColor = System.Drawing.Color.Brown;
            this.btn_close.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_close.BorderRadius = 3;
            this.btn_close.BorderSize = 0;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.ForeColor = System.Drawing.Color.White;
            this.btn_close.Location = new System.Drawing.Point(3, 4);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 40);
            this.btn_close.TabIndex = 2;
            this.btn_close.Text = "Close";
            this.btn_close.TextColor = System.Drawing.Color.White;
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_copy
            // 
            this.btn_copy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_copy.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_copy.BackgroundColor = System.Drawing.Color.SkyBlue;
            this.btn_copy.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_copy.BorderRadius = 3;
            this.btn_copy.BorderSize = 0;
            this.btn_copy.FlatAppearance.BorderSize = 0;
            this.btn_copy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_copy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_copy.ForeColor = System.Drawing.Color.White;
            this.btn_copy.Location = new System.Drawing.Point(371, 2);
            this.btn_copy.Name = "btn_copy";
            this.btn_copy.Size = new System.Drawing.Size(150, 40);
            this.btn_copy.TabIndex = 1;
            this.btn_copy.Text = "Copy to clipboard";
            this.btn_copy.TextColor = System.Drawing.Color.White;
            this.btn_copy.UseVisualStyleBackColor = false;
            this.btn_copy.Click += new System.EventHandler(this.btn_copy_Click);
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_save.BackgroundColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_save.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_save.BorderRadius = 3;
            this.btn_save.BorderSize = 0;
            this.btn_save.FlatAppearance.BorderSize = 0;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(527, 2);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(150, 40);
            this.btn_save.TabIndex = 0;
            this.btn_save.Text = "Save as";
            this.btn_save.TextColor = System.Drawing.Color.White;
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // panel_scheme
            // 
            this.panel_scheme.ContextMenuStrip = this.cms_save;
            this.panel_scheme.Controls.Add(this.pb_scheme);
            this.panel_scheme.Location = new System.Drawing.Point(329, 11);
            this.panel_scheme.Name = "panel_scheme";
            this.panel_scheme.Size = new System.Drawing.Size(302, 213);
            this.panel_scheme.TabIndex = 1;
            this.panel_scheme.Visible = false;
            // 
            // cms_save
            // 
            this.cms_save.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToClipboardToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.cms_save.Name = "cms_save";
            this.cms_save.Size = new System.Drawing.Size(170, 48);
            // 
            // copyToClipboardToolStripMenuItem
            // 
            this.copyToClipboardToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToClipboardToolStripMenuItem.Image")));
            this.copyToClipboardToolStripMenuItem.Name = "copyToClipboardToolStripMenuItem";
            this.copyToClipboardToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.copyToClipboardToolStripMenuItem.Text = "Copy to clipboard";
            this.copyToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyToClipboardToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // pb_scheme
            // 
            this.pb_scheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_scheme.Image = ((System.Drawing.Image)(resources.GetObject("pb_scheme.Image")));
            this.pb_scheme.Location = new System.Drawing.Point(0, 0);
            this.pb_scheme.Name = "pb_scheme";
            this.pb_scheme.Size = new System.Drawing.Size(302, 213);
            this.pb_scheme.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_scheme.TabIndex = 0;
            this.pb_scheme.TabStop = false;
            // 
            // panel_ardcode
            // 
            this.panel_ardcode.Controls.Add(this.rtb_code);
            this.panel_ardcode.Location = new System.Drawing.Point(11, 11);
            this.panel_ardcode.Name = "panel_ardcode";
            this.panel_ardcode.Size = new System.Drawing.Size(302, 215);
            this.panel_ardcode.TabIndex = 0;
            this.panel_ardcode.Visible = false;
            // 
            // rtb_code
            // 
            this.rtb_code.ContextMenuStrip = this.cms_save;
            this.rtb_code.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_code.Location = new System.Drawing.Point(0, 0);
            this.rtb_code.Name = "rtb_code";
            this.rtb_code.ReadOnly = true;
            this.rtb_code.Size = new System.Drawing.Size(302, 215);
            this.rtb_code.TabIndex = 0;
            this.rtb_code.Text = "";
            // 
            // timer_status
            // 
            this.timer_status.Interval = 3000;
            this.timer_status.Tick += new System.EventHandler(this.timer_status_Tick);
            // 
            // Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 428);
            this.Controls.Add(this.panel_body);
            this.MinimumSize = new System.Drawing.Size(700, 465);
            this.Name = "Info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Info";
            this.Load += new System.EventHandler(this.Info_Load);
            this.panel_body.ResumeLayout(false);
            this.panel_bottom.ResumeLayout(false);
            this.panel_bottom.PerformLayout();
            this.panel_scheme.ResumeLayout(false);
            this.cms_save.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_scheme)).EndInit();
            this.panel_ardcode.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_body;
        private System.Windows.Forms.Panel panel_scheme;
        private System.Windows.Forms.Panel panel_ardcode;
        private System.Windows.Forms.Panel panel_bottom;
        private System.Windows.Forms.PictureBox pb_scheme;
        private RJCodeAdvance.RJControls.RJButton btn_close;
        private RJCodeAdvance.RJControls.RJButton btn_copy;
        private RJCodeAdvance.RJControls.RJButton btn_save;
        private System.Windows.Forms.RichTextBox rtb_code;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Timer timer_status;
        private System.Windows.Forms.ContextMenuStrip cms_save;
        private System.Windows.Forms.ToolStripMenuItem copyToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    }
}