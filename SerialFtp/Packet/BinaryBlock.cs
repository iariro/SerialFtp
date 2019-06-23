using System;
using System.Text;

namespace SerialFtp.Packet
{
	/// <summary>
	///
	/// </summary>
	class BinaryBlock
	{
		public byte [] data;

		/// <summary>
		///
		/// </summary>
		/// <param name="data"></param>
		public BinaryBlock(byte [] data)
		{
			this.data = data;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="data"></param>
		/// <param name="offset"></param>
		/// <param name="length"></param>
		public BinaryBlock(byte[] data, int offset, int length)
		{
			this.data = new byte[length];
			Array.Copy(data, offset, this.data, 0, length);
		}

		/// <summary>
		///
		/// </summary>
		public BinaryBlock()
		{
		}

		/// <summary>
		///
		/// </summary>
		/// <returns></returns>
		public short GetAsShort()
		{
			return (short)(
				(data[0] <<  0) +
				(data[1] <<  8));
		}

		/// <summary>
		///
		/// </summary>
		/// <returns></returns>
		public bool GetAsBool()
		{
			return data[0] > 0;
		}
	}

	/// <summary>
	///
	/// </summary>
	class StringBinaryBlock
		: BinaryBlock
	{
		/// <summary>
		///
		/// </summary>
		/// <param name="text"></param>
		public StringBinaryBlock(string text)
			: base(new ASCIIEncoding().GetBytes(text))
		{
		}
	}

	/// <summary>
	///
	/// </summary>
	class ShortBinaryBlock
		: BinaryBlock
	{
		public const int Length = 2;

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		public ShortBinaryBlock(short value)
		{
			data = new byte [Length];
			data[0] = (byte)((value >> 0) & 0xff);
            data[1] = (byte)((value >> 8) & 0xff);
        }
	}
}
