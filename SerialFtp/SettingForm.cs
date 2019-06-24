using System;
using System.Windows.Forms;

namespace SerialFtp
{
    /// <summary>
    /// 設定画面
    /// </summary>
    public partial class SettingForm : Form
    {
        public string portName;

        /// <summary>
        /// 初期値割り当て
        /// </summary>
        /// <param name="portName">ポート番号</param>
        public SettingForm(string portName)
        {
            InitializeComponent();

            this.portName = portName;
            this.textBoxSerialPort.Text = portName;
        }

        /// <summary>
        /// OKボタン押下時
        /// </summary>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.portName = textBoxSerialPort.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Cancelボタン押下時
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}