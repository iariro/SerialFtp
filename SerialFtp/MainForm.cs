using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace SerialFtp
{
	/// <summary>
	///
	/// </summary>
	public partial class MainForm
		: Form
	{
		private readonly SerialPort port;

		/// <summary>
		///
		/// </summary>
		public MainForm()
		{
			InitializeComponent();

			port = new SerialPort("COM1");
			port.Open();
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void IToolStripMenuItem_Click(object sender, EventArgs e)
		{
			port.Close();
			Close();
		}

		/// <summary>
		/// エクスプローラからリストビューへ、すなわちローカルからリモートへド
		/// ラッグアンドドロップ。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void listViewRemote_DragDrop(object sender, DragEventArgs e)
		{
			string [] files;

			System.Diagnostics.Debug.WriteLine("DragDrop");

			if(e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				files = (string [])e.Data.GetData(DataFormats.FileDrop);

				foreach(string file in files)
				{
					new PutFileWorker(
						port,
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
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void listViewRemote_DragEnter(object sender, DragEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("DragEnter");

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
		/// <param name="sender"></param>
		/// <param name="e"></param>
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
					port,
					filePath,
					fileName,
					listViewRemote,
					toolStripPrgressBarRequest,
					toolStripProgressBarResponse).RunWorkerAsync();
			}
		}

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void リスト取得ToolStripMenuItem_Click
        	(object sender, EventArgs e)
        {
			new GetFilesWorker(
				port,
				listViewRemote,
				toolStripPrgressBarRequest,
				toolStripProgressBarResponse).RunWorkerAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
	}
}
