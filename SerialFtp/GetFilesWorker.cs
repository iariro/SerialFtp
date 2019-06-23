using SerialFtp.Packet;
using System.ComponentModel;
using System.IO.Ports;
using System.Windows.Forms;

namespace SerialFtp
{
	/// <summary>
	///
	/// </summary>
	class GetFilesWorker
		: BackgroundSendReceiver
	{
		private readonly ListView listViewRemote;

		/// <summary>
		///
		/// </summary>
		/// <param name="port"></param>
		/// <param name="listViewRemote"></param>
		/// <param name="progressbarRequest"></param>
		/// <param name="progressResponse"></param>
		public GetFilesWorker(SerialPort port, ListView listViewRemote,
			ToolStripProgressBar progressbarRequest,
			ToolStripProgressBar progressResponse)
			: base(port, progressbarRequest, progressResponse)
		{
			this.listViewRemote = listViewRemote;

			listViewRemote.Items.Clear();
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override void SendAndReceive(object sender, DoWorkEventArgs e)
		{
			RequestPacket request;
			ResponsePacket response;
			RemoteFileInformation[] ret;

			request = new RequestPacket(RequestCode.GetFiles);

			response = SendAndReceive(request);

			ret = new RemoteFileInformation[response.body.Count];
			for (int i = 0; i < response.body.Count; i++)
			{
				ret[i] = new RemoteFileInformation(response.body[i].data);
			}

			e.Result = ret;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="result"></param>
		protected override void Completed(object result)
		{
			RemoteFileInformation [] files;

			files = (RemoteFileInformation [])result;
			foreach(RemoteFileInformation file in files)
			{
				listViewRemote.Items.Add(
					new ListViewItem(
						new string[] {
							file.FileName,
							file.ã@äBåÍ ? "Åõ" : string.Empty,
							file.èëçûã÷é~ ? "Åõ" : string.Empty,
							file.ï“èWã÷é~ ? "Åõ" : string.Empty,
							file.èëÇ´çûÇ›ämîF ? "Åõ" : string.Empty,
							file.Ascii ? "Åõ" : string.Empty}));
			}
		}
	}
}
