using System;

namespace SerialFtp.Packet
{
	/// <summary>
	///
	/// </summary>
	class ResponsePacketBody
		: PacketBody
	{
		/// <summary>
		///
		/// </summary>
		/// <param name="header"></param>
		/// <param name="buffer"></param>
		public ResponsePacketBody(PacketHeader header, byte [] buffer)
		{
			int length;
			byte [] data;

			for(int offset=0 ; offset<header.length ; )
			{
				// 長さ部分。
				length = new BinaryBlock(buffer, offset, 2).GetAsShort();
				offset += ShortBinaryBlock.Length;

				// 正味部分。
				data = new byte [length];
				Array.Copy(buffer, offset, data, 0, length);
				offset += length;

				Add(new BinaryBlock(data));
			}
		}
	}
}
