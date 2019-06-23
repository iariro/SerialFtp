using System;
using System.Collections.Generic;
using System.Text;

namespace SerialFtp
{
	/// <summary>
	///
	/// </summary>
	class RemoteFileInformation
	{
		RemoteFileName fileName;
		byte attribute;

		/// <summary>
		///
		/// </summary>
		/// <param name="data"></param>
		public RemoteFileInformation(byte [] data)
		{
			fileName = new RemoteFileName(data);
			attribute = data[9];
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="fileName"></param>
		public RemoteFileInformation(string fileName)
		{
			this.fileName = new RemoteFileName(fileName);
		}

        /// <summary>
        /// 
        /// </summary>
        public string FileName
        {
            get { return fileName.ToString(); }
        }

		/// <summary>
		///
		/// </summary>
		public bool ‹@ŠBŒê
		{
			get { return (attribute & 0x01) > 0; }
		}

        /// <summary>
        /// 
        /// </summary>
        public bool ‘ž‹ÖŽ~
        {
            get { return (attribute & 0x10) > 0; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool •ÒW‹ÖŽ~
        {
            get { return (attribute & 0x20) > 0; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool ‘‚«ž‚ÝŠm”F
        {
            get { return (attribute & 0x40) > 0; }
        }

		/// <summary>
		/// 
		/// </summary>
		public bool Ascii
		{
			get { return (attribute & 0x80) == 0; }
		}
	}
}
