using System;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace DeviceManagerApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopulateDevices();
        }

        private void PopulateDevices()
        {
            listBoxDevices.Items.Clear();
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity");

            foreach (ManagementObject device in searcher.Get())
            {
                if (device["Name"] != null && device["DeviceID"] != null)
                {
                    listBoxDevices.Items.Add(new DeviceItem
                    {
                        Name = device["Name"].ToString(),
                        DeviceID = device["DeviceID"].ToString()
                    });
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateDevices();
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            var selectedDevice = listBoxDevices.SelectedItem as DeviceItem;
            if (selectedDevice != null)
            {
                var confirmResult = MessageBox.Show("Вы уверены, что хотите отключить это устройство?",
                                                     "Подтверждение отключения",
                                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    ToggleDevice(selectedDevice.DeviceID, false);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите устройство для отключения.");
            }
        }

        private void listBoxDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedDevice = listBoxDevices.SelectedItem as DeviceItem;
            if (selectedDevice != null)
            {
                GetDeviceInfo(selectedDevice.DeviceID);
            }
        }

        private void GetDeviceInfo(string deviceId)
        {
            deviceId = deviceId.Replace("\\", "\\\\").Replace("'", "''");

            var searcher = new ManagementObjectSearcher($"SELECT * FROM Win32_PnPEntity WHERE DeviceID = '{deviceId}'");

            try
            {
                var devices = searcher.Get().Cast<ManagementObject>().ToArray();

                if (devices.Length > 0)
                {
                    foreach (ManagementObject device in devices)
                    {
                        richTextBoxInfo.Text = $"Устройство: {Convert.ToString(device["Name"])}\n" +
                                               $"Статус: {device["Status"]}\n" +
                                               $"Тип: {device["DeviceID"]}\n";
                    }
                }
                else
                {
                    richTextBoxInfo.Text = "Устройство не найдено.";
                }
            }
            catch (Exception ex)
            {
                richTextBoxInfo.Text = $"Ошибка: {ex.Message}";
            }
        }

        private void ToggleDevice(string deviceId, bool enable)
        {
            var deviceSearcher = new ManagementObjectSearcher($"SELECT * FROM Win32_PnPEntity WHERE DeviceID = '{deviceId}'");
            var devices = deviceSearcher.Get().Cast<ManagementObject>().ToArray();
            foreach (ManagementObject device in devices)
            {
                try
                { 
                    var method = enable ? "Enable" : "Disable";
                    var result = device.InvokeMethod(method, null);
                    if (result != null)
                    {
                        MessageBox.Show($"{(enable ? "Включено" : "Отключено")}: {device["Name"]}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при отключении устройства: {ex.Message}");
                }
            }
        }
    }

    public class DeviceItem
    {
        public string Name { get; set; }
        public string DeviceID { get; set; }

        public override string ToString()
        {
            return Name; 
        }
    }
}
