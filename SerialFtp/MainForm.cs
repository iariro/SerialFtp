using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace SerialFtp
{
	/// <summary>
	/// Serial FTP���C�����
	/// </summary>
	public partial class MainForm
		: Form
	{
        private string portName;
		private SerialPort serialPort;

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public MainForm()
		{
			InitializeComponent();
		}

        /// <summary>
        /// ����������
        /// �ݒ�l�ǂݍ��݂ƃ|�[�g�̃I�[�v��
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
        /// ���j���[�u�I���v
        /// </summary>
        private void �I��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// ���j���[�u�ݒ�v
        /// </summary>
        private void �ݒ�ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm(portName);
            if (settingForm.ShowDialog() == DialogResult.OK)
            {
                this.portName = settingForm.portName;
                Properties.Settings.Default.Save();
            }
        }

		/// <summary>
		/// ��ʃN���[�Y
		/// </summary>
		private void IToolStripMenuItem_Click(object sender, EventArgs e)
		{
			serialPort.Close();
			Close();
		}

		/// <summary>
		/// �G�N�X�v���[�����烊�X�g�r���[�ցA���Ȃ킿���[�J�����烊���[�g�փh
		/// ���b�O�A���h�h���b�v�B
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
		/// �G�N�X�v���[�����烊�X�g�r���[�ցA���Ȃ킿���[�J�����烊���[�g�փh
		/// ���b�O�A���h�h���b�v�B
		/// </summary>
		private void listViewRemote_DragEnter(object sender, DragEventArgs e)
		{
			if(e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				// �t�@�C���̃h���b�v�ł���B

				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				// ����ȊO�B

				e.Effect = DragDropEffects.None;
			}
		}

		/// <summary>
		/// ���X�g�r���[����G�N�X�v���[���ցA���Ȃ킿�����[�g���烍�[�J���փh
		/// ���b�O�A���h�h���b�v�B
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
        /// ���X�g�擾
        /// </summary>
        private void ���X�g�擾ToolStripMenuItem_Click
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
