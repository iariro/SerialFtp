
namespace SerialFtp.Packet
{
	/// <summary>
	/// 
	/// </summary>
	class RequestPacketBody
		: PacketBody
	{
		/// <summary>
		/// 
		/// </summary>
		public int Length
		{
			get
			{
				int ret;

				ret = 0;
				foreach(BinaryBlock block in this)
				{
					ret += ShortBinaryBlock.Length;
					ret += block.data.Length;
				}

				return ret;
			}
		}
	}
}
