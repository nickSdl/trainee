using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;

namespace WinArc.ArchCore
{
	public class Archivator
	{
		private EventHandler<SaveProgressEventArgs> saveProgress;
		private EventHandler<ExtractProgressEventArgs> extractProgress;
		private EventHandler<AddProgressEventArgs> addProgress;

        //public Archivator(EventHandler<SaveProgressEventArgs> saveProgress)       //TODO: 1 delete unnecessary code
        //{
        //	this.saveProgress = saveProgress;
        //}

        public Archivator(EventHandler<ExtractProgressEventArgs> extractProgress)
		{
			this.extractProgress = extractProgress;
		}

		//public Archivator(EventHandler<AddProgressEventArgs> addProgress)         //TODO: 2 delete unnecessary code
        //{
		//{
		//	this.addProgress = addProgress;
		//}

		public Archivator(EventHandler<AddProgressEventArgs> addProgress, EventHandler<SaveProgressEventArgs> saveProgress)
		{
			this.addProgress = addProgress;
			this.saveProgress = saveProgress;
		}

		public void AddFile(string path)
		{
			if (path != null)
			{
				using (ZipFile zip = new ZipFile())
				{
					string direct = Path.GetDirectoryName(path);
					string fileName = Path.GetFileNameWithoutExtension(path);
					zip.AddFile(path, "");
					zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
					zip.SaveProgress += saveProgress;
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
					string folderName = Path.GetFileName(currentPath);
					zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
					zip.SaveProgress += saveProgress;
					zip.AddDirectory(path, folderName);
					zip.Save(currentPath  + ".zip");
				}
			}
			else
			{
				throw new ArgumentNullException("Wrong path to file"); 
            }
		}

		public void AddMultipleFiles(string path, string item)
		{
			if (path != null)
			{
				using (ZipFile zip = ZipFile.Read(path))
				{
					zip.AddProgress += addProgress;
					string itemName = Path.GetFileNameWithoutExtension(item);
					zip.UpdateItem(item, itemName);
					zip.Save();
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
					zip.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
                    //foreach (ZipEntry e in zip)
                    //{
                    //	e.Extract(extractPath, ExtractExistingFileAction.OverwriteSilently);        //TODO: 3 delete unnecessary code
                    //}
                }
            }
			else
			{
				throw new ArgumentNullException("Wrong path to file");
			}
		}

	}
}
