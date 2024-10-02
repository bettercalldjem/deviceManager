namespace DeviceManagerApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            listBoxDevices = new ListBox();
            btnRefresh = new Button();
            btnDisable = new Button();
            richTextBoxInfo = new RichTextBox();
            SuspendLayout();
            // 
            // listBoxDevices
            // 
            listBoxDevices.FormattingEnabled = true;
            listBoxDevices.ItemHeight = 15;
            listBoxDevices.Location = new Point(14, 14);
            listBoxDevices.Margin = new Padding(4, 3, 4, 3);
            listBoxDevices.Name = "listBoxDevices";
            listBoxDevices.Size = new Size(419, 184);
            listBoxDevices.TabIndex = 0;
            listBoxDevices.SelectedIndexChanged += listBoxDevices_SelectedIndexChanged;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(14, 208);
            btnRefresh.Margin = new Padding(4, 3, 4, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(88, 27);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnDisable
            // 
            btnDisable.Location = new Point(346, 208);
            btnDisable.Margin = new Padding(4, 3, 4, 3);
            btnDisable.Name = "btnDisable";
            btnDisable.Size = new Size(88, 27);
            btnDisable.TabIndex = 2;
            btnDisable.Text = "Отключить";
            btnDisable.UseVisualStyleBackColor = true;
            btnDisable.Click += btnDisable_Click;
            // 
            // richTextBoxInfo
            // 
            richTextBoxInfo.Location = new Point(14, 242);
            richTextBoxInfo.Margin = new Padding(4, 3, 4, 3);
            richTextBoxInfo.Name = "richTextBoxInfo";
            richTextBoxInfo.Size = new Size(419, 115);
            richTextBoxInfo.TabIndex = 3;
            richTextBoxInfo.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = deviceManager.Properties.Resources.back;
            ClientSize = new Size(448, 370);
            Controls.Add(richTextBoxInfo);
            Controls.Add(btnDisable);
            Controls.Add(btnRefresh);
            Controls.Add(listBoxDevices);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Device Manager";
            ResumeLayout(false);
        }

        private System.Windows.Forms.ListBox listBoxDevices;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDisable;
        private System.Windows.Forms.RichTextBox richTextBoxInfo;
    }
}
