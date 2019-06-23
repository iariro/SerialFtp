
namespace SerialFtp.Packet
{
	/// <summary>
	///
	/// </summary>
	class PacketHeader
	{
		public const int Length = 4;

		public RequestCode code;
		public int length;

		/// <summary>
		///
		/// </summary>
		/// <param name="code"></param>
		/// <param name="length"></param>
		public PacketHeader(RequestCode code, int length)
		{
			this.code = code;
			this.length = length;
		}

		/// <summary>
		///
		/// </summary>
		public PacketHeader()
		{
		}
	}
}
