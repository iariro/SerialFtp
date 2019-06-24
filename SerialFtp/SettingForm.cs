using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SerialFtp
{
    public partial class SettingForm : Form
    {
        public string serialPort;

        public SettingForm(string serialPort)
        {
            InitializeComponent();

            this.serialPort = serialPort;
            this.textBoxSerialPort.Text = serialPort;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.serialPort = textBoxSerialPort.Text;
        }
    }
}