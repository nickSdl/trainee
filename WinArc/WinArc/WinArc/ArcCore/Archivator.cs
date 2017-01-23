using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinArc.ArcCore;

namespace WinArc.ArchCore
{
	public class Archivator
	{
		private EventHandler<SaveProgressEventArgs> saveProgress;

		public Archivator(EventHandler<SaveProgressEventArgs> saveProgress)
		{
			this.saveProgress = saveProgress;
		}

		public void AddFile(string file)
		{
			using (ZipFile zip = new ZipFile())
			{
				zip.AddFile(file, "");
				zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
				zip.SaveProgress += saveProgress;
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
				zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
				zip.SaveProgress += saveProgress;
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
				zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
				zip.SaveProgress += saveProgress;
				foreach (ZipEntry e in zip)
				{
					e.Extract(direct, ExtractExistingFileAction.OverwriteSilently);
				}
			}
		}

	}
}
