using System;
using System.Windows.Forms;

namespace SerialFtp
{
    /// <summary>
    /// �ݒ���
    /// </summary>
    public partial class SettingForm : Form
    {
        public string portName;

        /// <summary>
        /// �����l���蓖��
        /// </summary>
        /// <param name="portName">�|�[�g�ԍ�</param>
        public SettingForm(string portName)
        {
            InitializeComponent();

            this.portName = portName;
            this.textBoxSerialPort.Text = portName;
        }

        /// <summary>
        /// OK�{�^��������
        /// </summary>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.portName = textBoxSerialPort.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Cancel�{�^��������
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}