using Ionic.Zip;
using System;
using System.IO;

namespace WinArc.ArchCore
{
	public class Archivator
	{
		private EventHandler<SaveProgressEventArgs> saveProgress;
		private EventHandler<ExtractProgressEventArgs> extractProgress;

		public Archivator(EventHandler<SaveProgressEventArgs> saveProgress)
		{
			this.saveProgress = saveProgress;
		}

		public Archivator(EventHandler<ExtractProgressEventArgs> extractProgress)
		{
			this.extractProgress = extractProgress;
		}

		public void AddFile(string path)
		{
			if (path != null)
			{
				using (ZipFile zip = new ZipFile())
				{
					zip.AddFile(path, "");
					zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
					zip.SaveProgress += saveProgress;
					string direct = Path.GetDirectoryName(path);
					string fileName = Path.GetFileNameWithoutExtension(path);
					zip.Save(direct + "\\" + fileName + ".zip");
				}
			}
			else
			{
				throw new ArgumentNullException("Wrong path to file");
			}
		}

		public void AddFolder(string path)
		{
			if (path != null)
			{
				using (ZipFile zip = new ZipFile())
				{
					string currentPath = Path.GetDirectoryName(path);
					zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
					zip.SaveProgress += saveProgress;
					zip.AddDirectory(path);
					string direct = Path.GetDirectoryName(path);
					zip.Save(currentPath  + ".zip");
				}
			}
			else
			{
				throw new ArgumentNullException("Wrong path to file");
			}
		}

		public void ExtractFiles(string path)
		{
			if (path != null)
			{
				string direct = Path.GetDirectoryName(path);
				string fileName = Path.GetFileNameWithoutExtension(path) + "\\";
				string extractPath = direct + "\\" + fileName;

				if (!Directory.Exists(extractPath))
				{
					Directory.CreateDirectory(extractPath);
				}
				using (ZipFile zip = ZipFile.Read(path))
				{
					zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
					zip.ExtractProgress += extractProgress;
					foreach (ZipEntry e in zip)
					{
						e.Extract(extractPath, ExtractExistingFileAction.OverwriteSilently);
					}
				}
			}
			else
			{
				throw new ArgumentNullException("Wrong path to file");
			}
		}

	}
}
