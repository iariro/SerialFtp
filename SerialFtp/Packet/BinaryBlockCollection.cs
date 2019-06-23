using System;
using System.Collections.Generic;

namespace SerialFtp.Packet
{
	/// <summary>
	///
	/// </summary>
	class BinaryBlockCollection
		: List<byte []>
	{
		/// <summary>
		///
		/// </summary>
		/// <returns></returns>
		public byte [] GetBytes()
		{
			int length, offset;
			byte [] ret;

			// �g�[�^���T�C�Y�擾�B
			length = 0;
			foreach(byte [] block in this)
			{
				length += block.Length;
			}

			// �A���B
			ret = new byte [length];
			offset = 0;
			foreach(byte [] block in this)
			{
				Array.Copy(block, 0, ret, offset, block.Length);
				offset += block.Length;
			}

			return ret;
		}
	}
}
