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
				// �s���I�h����B

				if(periodPosition <= 6)
				{
					// ���O�͂U�����ȓ��B

					name = fileName.Substring(0, periodPosition);
				}
				else
				{
					// ����ȏ�B

					name = fileName.Substring(0, 6);
				}

				if(fileName.Length - periodPosition - 1 <= 3)
				{
					// �g���q�͂R�����ȓ��B

					extension = fileName.Substring(periodPosition + 1);
				}
				else
				{
					// ����ȏ�B

					extension = fileName.Substring(periodPosition + 1, 3);
				}
			}
			else
			{
				// �s���I�h�Ȃ��B

				if(fileName.Length >= 6)
				{
					// �U�����ȏ�B

					name = fileName.Substring(0, 6);
					extension = fileName.Substring(6, 3);
				}
				else
				{
					// �U�����ȓ��B

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
