
namespace SerialFtp.Packet
{
	/// <summary>
	///
	/// </summary>
	class ResponsePacketHeader
		: PacketHeader
	{
		/// <summary>
		///
		/// </summary>
		/// <param name="buffer"></param>
		public ResponsePacketHeader(byte [] buffer)
		{
			code = (RequestCode)new BinaryBlock(buffer, 0, 2).GetAsShort();
			length = new BinaryBlock(buffer, 2, 2).GetAsShort();
		}
	}
}
