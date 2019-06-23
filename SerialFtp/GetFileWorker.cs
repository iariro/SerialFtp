using SerialFtp.Packet;
using System;
using System.ComponentModel;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace SerialFtp
{
	class GetFileWorker
		: BackgroundSendReceiver
	{
		private readonly string filePath;
		private readonly string fileName;
		private readonly ListView listViewRemote;

		/// <summary>
		///
		/// </summary>
		/// <param name="listViewRemote"></param>
		/// <param name="filePath"></param>
		/// <param name="fileName"></param>
		/// <param name="progresbarRequest"></param>
		/// <param name="progressbarResponse"></param>
		public GetFileWorker(SerialPort port, string filePath, string fileName,
			ListView listViewRemote, ToolStripProgressBar progresbarRequest,
			ToolStripProgressBar progressbarResponse)
			: base(port, progresbarRequest, progressbarResponse)
		{
			this.filePath = filePath;
			this.fileName = fileName;
			this.listViewRemote = listViewRemote;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override void SendAndReceive(object sender, DoWorkEventArgs e)
		{
			byte[] buffer;
			RequestPacket request;
			ResponsePacket response;
			RequestPacketBody requestPacketBody;

			// リクエスト作成。
			requestPacketBody = new RequestPacketBody();
			requestPacketBody.Add(new StringBinaryBlock(fileName));
			request =
				new RequestPacket(RequestCode.ReceiveFile, requestPacketBody);

			// リクエスト送信とその応答受信。
			response = SendAndReceive(request);

			// ファイル内容取得。
			buffer = response.body[0].data;

			e.Result = buffer;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="result"></param>
		protected override void Completed(object result)
		{
			byte [] buffer;
			FileStream stream;
			DragDropEffects dropEffect;

			buffer = (byte [])result;
			stream = new FileStream(filePath, FileMode.Create);
			stream.Write(buffer, 0, buffer.Length);
			stream.Close();

			// ドラッグアンドドロップの開始。
			dropEffect =
				listViewRemote.DoDragDrop(
					new DataObject(
						DataFormats.FileDrop,
						new string [] { filePath }),
					DragDropEffects.Move);
		}
	}
}
