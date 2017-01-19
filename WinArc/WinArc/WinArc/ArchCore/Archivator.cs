using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinArc.ArchCore
{
	public class Archivator
	{
		public void AddFile(string file)
		{
			using (ZipFile zip = new ZipFile())
			{
				zip.AddFile(file, "");
				string direct = Path.GetDirectoryName(file);
				string fileName = Path.GetFileNameWithoutExtension(file);
				zip.Save(direct + "\\" + fileName + ".zip");
			}
		}

		public void AddFolder(string path)
		{
			using (ZipFile zip = new ZipFile())
			{
				string currentPath = Path.GetDirectoryName(path);
				zip.AddDirectory(path);
				string direct = Path.GetDirectoryName(path);
				zip.Save(currentPath + ".zip");
			}
		}

		public void ExtractFiles(string file)
		{
			string direct = Path.GetDirectoryName(file);
			using (ZipFile zip = ZipFile.Read(file))
			{
				foreach (ZipEntry e in zip)
				{
					e.Extract(direct, ExtractExistingFileAction.OverwriteSilently);
				}
			}
		}

		public void ExtractFilesTo(string file, string outputDirectory)
		{
			ZipFile zip = ZipFile.Read(file);
			Directory.CreateDirectory(outputDirectory);
			foreach (ZipEntry e in zip)
			{
				e.Extract(outputDirectory, ExtractExistingFileAction.OverwriteSilently);
			}
		}
	}
}
