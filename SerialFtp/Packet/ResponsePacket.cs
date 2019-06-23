
namespace SerialFtp.Packet
{
	/// <summary>
	///
	/// </summary>
	class ResponsePacket
	{
		public ResponsePacketHeader header;
		public ResponsePacketBody body;

		/// <summary>
		///
		/// </summary>
        /// <param name="header"></param>
        /// <param name="body"></param>
        public ResponsePacket(ResponsePacketHeader header, ResponsePacketBody body)
		{
            this.header = header;
            this.body = body;
		}
	}
}
