
namespace SerialFtp.Packet
{
	/// <summary>
	///
	/// </summary>
	class RequestPacket
	{
		public RequestPacketHeader header;
		public RequestPacketBody body;

		/// <summary>
		///
		/// </summary>
		/// <param name="code"></param>
		public RequestPacket(RequestCode code)
		{
			this.header = new RequestPacketHeader(code);
			this.body = null;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="code"></param>
		/// <param name="body"></param>
		public RequestPacket(RequestCode code, RequestPacketBody body)
		{
			this.header = new RequestPacketHeader(code, body);
			this.body = body;
		}

		/// <summary>
		///
		/// </summary>
		/// <returns></returns>
		public byte [] GetBytes()
		{
			BinaryBlockCollection blocks;

			blocks = new BinaryBlockCollection();

			// �w�b�_���ǉ��B
			blocks.Add(new ShortBinaryBlock((short)header.code).data);
            blocks.Add(new ShortBinaryBlock((short)header.length).data);

			if(body != null)
			{
				// �{�f�B���͂���B

				// �{�f�B���ǉ��B
				foreach(BinaryBlock parameter in body)
				{
                    blocks.Add(new ShortBinaryBlock((short)parameter.data.Length).data);
					blocks.Add(parameter.data);
				}
			}

			return blocks.GetBytes();
		}
	}
}
