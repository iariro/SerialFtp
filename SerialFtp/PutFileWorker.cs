using SerialFtp.Packet;
using System;
using System.ComponentModel;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace SerialFtp
{
	/// <summary>
	///
	/// </summary>
	class PutFileWorker
		: BackgroundSendReceiver
	{
		private readonly string filePath;
		private readonly ListView listViewRemote;

		/// <summary>
		///
		/// </summary>
		/// <param name="port"></param>
		/// <param name="filePath"></param>
		/// <param name="listViewRemote"></param>
		/// <param name="progressbarRequest"></param>
		/// <param name="progressResponse"></param>
		public PutFileWorker(SerialPort port, string filePath,
			ListView listViewRemote,
			ToolStripProgressBar progressbarRequest,
			ToolStripProgressBar progressResponse)
			: base(port, progressbarRequest, progressResponse)
		{
			this.filePath = filePath;
			this.listViewRemote = listViewRemote;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override void SendAndReceive(object sender, DoWorkEventArgs e)
		{
			int length, length2;
			byte[] buffer;
			string fileName;
			FileStream file;
			RequestPacket request;
			ResponsePacket response;
			RequestPacketBody requestPacketBody;

			// ���[�J���t�@�C����ǂݎ��B
			length = (int)new FileInfo(filePath).Length;
			buffer = new byte[length];
			file = new FileStream(filePath, FileMode.Open);
			length2 = file.Read(buffer, 0, length);
			file.Close();

			if (length2 < length)
			{
				throw
					new Exception("Windows�t�@�C���𐳂����ǂ߂܂���ł����B");
			}

			fileName = new FileInfo(filePath).Name;

			// ���N�G�X�g�쐬�B
			requestPacketBody = new RequestPacketBody();
			requestPacketBody.Add(
				new StringBinaryBlock(
					new RemoteFileName(fileName).ToString()));
			requestPacketBody.Add(new BinaryBlock(buffer));

			request =
				new RequestPacket(RequestCode.SendFile, requestPacketBody);

			// ���N�G�X�g���M�Ƃ��̉�����M�B
			response = SendAndReceive(request);

			e.Result = response.body[0].GetAsBool();
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="result"></param>
		protected override void Completed(object result)
		{
			if((bool)result)
			{
				listViewRemote.Items.Add(
					new RemoteFileInformation(
						new FileInfo(filePath).Name).FileName);
			}
		}
	}
}
