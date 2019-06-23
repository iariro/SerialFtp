using NUnit.Framework;

namespace SerialFtp.Test
{
	[TestFixture]
	public class RemoteFileNameTest
	{
		[Test]
		public void Test01()
		{
			Assert.AreEqual(
				"abc   .txt",
				new RemoteFileName("abc.txt").ToString());
		}

		[Test]
		public void Test02()
		{
			Assert.AreEqual(
				"abcdef.txt",
				new RemoteFileName("abcdefgh.txt").ToString());
		}

		[Test]
		public void Test03()
		{
			Assert.AreEqual(
				"abcdef.ghi",
				new RemoteFileName("abcdefghi").ToString());
		}

		[Test]
		public void Test04()
		{
			Assert.AreEqual(
				"abc   .   ",
				new RemoteFileName("abc").ToString());
		}

		[Test]
		public void Test05()
		{
			Assert.AreEqual(
				"abcdef.txt",
				new RemoteFileName("abcdef.txtx").ToString());
		}

		[Test]
		public void Test06()
		{
			byte [] data =
				new byte []
					{0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x74, 0x78, 0x74};

			Assert.AreEqual(
				"abcdef.txt",
				new RemoteFileName(data).ToString());
		}
	}
}
