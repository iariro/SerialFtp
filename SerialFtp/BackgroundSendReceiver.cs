using SerialFtp.Packet;
using System;
using System.ComponentModel;
using System.IO.Ports;
using System.Windows.Forms;

namespace SerialFtp
{
	/// <summary>
	///
	/// </summary>
	abstract class BackgroundSendReceiver
		: BackgroundWorker
	{
		private readonly SerialPort port;
		private readonly ToolStripProgressBar progressbarRequest;
		private readonly ToolStripProgressBar progressbarResponse;
		private Timer timer;

		/// <summary>
		///
		/// </summary>
		/// <param name="port"></param>
		/// <param name="progressbarRequest"></param>
		/// <param name="progressbarResponse"></param>
		public BackgroundSendReceiver(
			SerialPort port,
			ToolStripProgressBar progressbarRequest,
			ToolStripProgressBar progressbarResponse)
		{
			this.port = port;
			this.progressbarRequest = progressbarRequest;
			this.progressbarResponse = progressbarResponse;

			this.WorkerReportsProgress = true;

			// �f���Q�[�g���d�|����B
			DoWork += new DoWorkEventHandler(SendAndReceive);
			ProgressChanged += new ProgressChangedEventHandler(ProgressChange);
			RunWorkerCompleted +=
				new RunWorkerCompletedEventHandler(CompletedCore);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected abstract void SendAndReceive
			(object sender, DoWorkEventArgs e);

		/// <summary>
		///
		/// </summary>
		/// <param name="result"></param>
		protected abstract void Completed(object result);

		/// <summary>
		/// ���N�G�X�g���M�Ɖ�����M�B
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public ResponsePacket SendAndReceive(RequestPacket request)
		{
			int received;
			byte [] requestBytes;
			byte [] receiveBuffer;
			ResponsePacketHeader responsePacketHeader;
			ResponsePacketBody responsePacketBody;

			// ���N�G�X�g���M�B
			requestBytes = request.GetBytes();
			ReportProgress(0, false);
			port.Write(requestBytes, 0, requestBytes.Length);
			ReportProgress(100, false);

			// �����w�b�_����M�B
			received = 0;
			receiveBuffer = new byte [PacketHeader.Length];
			ReportProgress(0, true);
			do
			{
				received +=
					port.Read(
						receiveBuffer,
						received,
						receiveBuffer.Length - received);

				ReportProgress(10 * received / PacketHeader.Length, true);
			}
			while(received < PacketHeader.Length);

			responsePacketHeader = new ResponsePacketHeader(receiveBuffer);

			// �����{�f�B����M�B
			received = 0;
			receiveBuffer = new byte [responsePacketHeader.length];
			do
			{
				received +=
					port.Read(
						receiveBuffer,
						received,
						receiveBuffer.Length - received);

				ReportProgress(
					10 + (90 * received) / responsePacketHeader.length, true);
			}
			while(received < responsePacketHeader.length);

			responsePacketBody =
				new ResponsePacketBody(responsePacketHeader, receiveBuffer);

			return new ResponsePacket(responsePacketHeader, responsePacketBody);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ProgressChange(object sender, ProgressChangedEventArgs e)
		{
			if(!(bool)e.UserState)
			{
				progressbarRequest.Value = e.ProgressPercentage;
			}
			else
			{
				progressbarResponse.Value = e.ProgressPercentage;
			}
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CompletedCore(object sender, RunWorkerCompletedEventArgs e)
		{
			Completed(e.Result);

			timer = new Timer();
			timer.Interval = 2000;
			timer.Tick += new EventHandler(ResetProgressBar);
			timer.Start();
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ResetProgressBar(object sender, EventArgs e)
		{
			timer.Stop();

			progressbarRequest.Value = 0;
			progressbarResponse.Value = 0;
		}
	}
}
