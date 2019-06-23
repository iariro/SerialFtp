using System;
using System.Collections.Generic;
using System.Text;

namespace SerialFtp
{
	/// <summary>
	/// 
	/// </summary>
	class RemoteFileName
	{
		public string name;
		public string extension;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="buffer"></param>
		public RemoteFileName(byte [] buffer)
		{
			Encoding encoding;

			encoding = new ASCIIEncoding();
			name = encoding.GetString(buffer, 0, 6);
			extension = encoding.GetString(buffer, 6, 3);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="fileName"></param>
		public RemoteFileName(string fileName)
		{
			int periodPosition;

			periodPosition = fileName.IndexOf('.');
			if(periodPosition > 0)
			{
				// ピリオドあり。

				if(periodPosition <= 6)
				{
					// 名前は６文字以内。

					name = fileName.Substring(0, periodPosition);
				}
				else
				{
					// それ以上。

					name = fileName.Substring(0, 6);
				}

				if(fileName.Length - periodPosition - 1 <= 3)
				{
					// 拡張子は３文字以内。

					extension = fileName.Substring(periodPosition + 1);
				}
				else
				{
					// それ以上。

					extension = fileName.Substring(periodPosition + 1, 3);
				}
			}
			else
			{
				// ピリオドなし。

				if(fileName.Length >= 6)
				{
					// ６文字以上。

					name = fileName.Substring(0, 6);
					extension = fileName.Substring(6, 3);
				}
				else
				{
					// ６文字以内。

					name = fileName;
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("{0,-6}.{1,3}", name, extension);
		}
	}
}
