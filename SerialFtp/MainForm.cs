using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace SerialFtp
{
	/// <summary>
	/// Serial FTPメイン画面
	/// </summary>
	public partial class MainForm
		: Form
	{
        private string portName;
		private SerialPort serialPort;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MainForm()
		{
			InitializeComponent();
		}

        /// <summary>
        /// 初期化処理
        /// 設定値読み込みとポートのオープン
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            portName = Properties.Settings.Default.serialPort;

            serialPort = new SerialPort(portName);
            try
            {
                serialPort.Open();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// メニュー「終了」
        /// </summary>
        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// メニュー「設定」
        /// </summary>
        private void 設定ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm(portName);
            if (settingForm.ShowDialog() == DialogResult.OK)
            {
                this.portName = settingForm.portName;
                Properties.Settings.Default.Save();
            }
        }

		/// <summary>
		/// 画面クローズ
		/// </summary>
		private void IToolStripMenuItem_Click(object sender, EventArgs e)
		{
			serialPort.Close();
			Close();
		}

		/// <summary>
		/// エクスプローラからリストビューへ、すなわちローカルからリモートへド
		/// ラッグアンドドロップ。
		/// </summary>
		private void listViewRemote_DragDrop(object sender, DragEventArgs e)
		{
			string [] files;

			if(e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				files = (string [])e.Data.GetData(DataFormats.FileDrop);

				foreach(string file in files)
				{
					new PutFileWorker(
						serialPort,
						file,
						listViewRemote,
						toolStripPrgressBarRequest,
						toolStripProgressBarResponse).RunWorkerAsync();
				}
			}

			this.Invalidate();
		}

		/// <summary>
		/// エクスプローラからリストビューへ、すなわちローカルからリモートへド
		/// ラッグアンドドロップ。
		/// </summary>
		private void listViewRemote_DragEnter(object sender, DragEventArgs e)
		{
			if(e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				// ファイルのドロップである。

				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				// それ以外。

				e.Effect = DragDropEffects.None;
			}
		}

		/// <summary>
		/// リストビューからエクスプローラへ、すなわちリモートからローカルへド
		/// ラッグアンドドロップ。
		/// </summary>
		private void listViewRemote_ItemDrag(object sender, ItemDragEventArgs e)
		{
			string fileName, filePath;
			List<string> filesArray;

			filesArray = new List<string>();
			for(int i = 0 ; i < listViewRemote.SelectedItems.Count ; i++)
			{
				fileName = listViewRemote.SelectedItems[i].Text;
				filePath = Application.LocalUserAppDataPath + @"\" + fileName;
				filesArray.Add(filePath);

				new GetFileWorker(
					serialPort,
					filePath,
					fileName,
					listViewRemote,
					toolStripPrgressBarRequest,
					toolStripProgressBarResponse).RunWorkerAsync();
			}
		}

        /// <summary>
        /// リスト取得
        /// </summary>
        private void リスト取得ToolStripMenuItem_Click
        	(object sender, EventArgs e)
        {
			new GetFilesWorker(
				serialPort,
				listViewRemote,
				toolStripPrgressBarRequest,
				toolStripProgressBarResponse).RunWorkerAsync();
        }
	}
}
