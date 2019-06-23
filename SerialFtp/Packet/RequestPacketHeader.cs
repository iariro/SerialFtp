
namespace SerialFtp.Packet
{
	/// <summary>
	///
	/// </summary>
	class RequestPacketHeader
		: PacketHeader
	{
		/// <summary>
		///
		/// </summary>
		/// <param name="code"></param>
		/// <param name="body"></param>
		public RequestPacketHeader(RequestCode code, RequestPacketBody body)
			: base(code, body.Length)
		{
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="code"></param>
		public RequestPacketHeader(RequestCode code)
			: base(code, 0)
		{
		}
	}
}
