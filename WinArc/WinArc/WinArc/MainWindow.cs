using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WinArc.ArchCore;
using Ionic.Zip;

namespace WinArc
{
	public partial class MainWindow : Form
	{
		private string path;
		private string fileName;
		private int initialFormWidth;
		private int initialFormHeight;
		private int files = 0;
		private int totalFiles = 0;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void MainWindow_Load(object sender, EventArgs e)
		{
			ViewMethods.GetDrives(folderTree);
			
			//TODO: 5.Remove logic from constractor
			int numberOfComumns = folderView.Columns.Count;
			for (int i = 0; i < numberOfComumns; i++)
			{
				folderView.Columns[i].Width = folderView.Width/numberOfComumns;
			}
		}

		//TODO: 6. Remove unnecessary commets
		private void folderTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)//DisplayTreeView
		{        
			if (e.Node.Nodes.Count > 0)
			{
				if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes[0].Tag == null)
				{
					e.Node.Nodes.Clear();

					//get the list of sub direcotires
					string[] dirs = Directory.GetDirectories(e.Node.Tag.ToString());

					//add files of rootdirectory                    
					DirectoryInfo rootDir = new DirectoryInfo(e.Node.Tag.ToString());
					foreach (var file in rootDir.GetFiles())
					{
						TreeNode n = new TreeNode(file.Name, 7, 7);//TODO: 7.1 change numbers for variables.
						e.Node.Nodes.Add(n);
					}

					foreach (string dir in dirs)
					{
						DirectoryInfo di = new DirectoryInfo(dir); //TODO: 8. Rename "di".
						TreeNode node = new TreeNode(di.Name, 0, 1); //TODO: 7.2 change numbers for variables.

						try
						{
							//keep the directory's full path in the tag for use later
							node.Tag = dir;

							//if the directory has sub directories add the place holder
							if (di.GetDirectories().Count() > 0)
								node.Nodes.Add(null, "...", 0, 0); //TODO: 7.3 change numbers for variables.

							foreach (var file in di.GetFiles())
							{
								TreeNode n = new TreeNode(file.Name, 7, 7); //TODO: 7.4 change numbers for variables.
								node.Nodes.Add(n);
							}

						}
						catch (UnauthorizedAccessException)
						{
							//display a locked folder icon
							node.ImageIndex = 6;
							node.SelectedImageIndex = 6;
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message, "DirectoryLister", //TODO 8.1  Write correct error message for user.
								MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
						finally
						{
							e.Node.Nodes.Add(node);
						}
					}
				}
			}
		}             	

		private void folderTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
		   try
			{
				TreeNode newSelected = e.Node;
				path = newSelected.FullPath;

				if (path.Length == 1)
				{
					path = path.Insert(1, @":\");
				}
				else
				{
					path = path.Insert(1, ":");
				}
				pathBox.Text = path;

				DirectoryInfo nodeDirInfo = new DirectoryInfo(path);
				ViewMethods.DisplayFolderContent(nodeDirInfo, folderView);
			}
			catch (Exception ex)
			{
			   MessageBox.Show("Problem!!!!\n" + ex.Message);  //TODO 8.2  Write correct error message for user.
			}

		}

		private void pathBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				path = pathBox.Text;

				//TODO: 6.2 Remove unnecessary commets
				//open entered directory on folderView                
				DirectoryInfo nodeDirInfo = new DirectoryInfo(path);
				ViewMethods.DisplayFolderContent(nodeDirInfo, folderView);
			}            
		}      		     	
			
		private void folderView_Click(object sender, EventArgs e)
		{           
			fileName = folderView.SelectedItems[0].ToString().Replace("ListViewItem: {", "");
			fileName = fileName.Replace("}", "");

			if (!path[path.Length-1].Equals('\\'))
			{
				path = path + '\\';
			}
			pathBox.Text = path + fileName;
		}

		private void folderView_DoubleClick(object sender, EventArgs e)
		{
			//double click on item
			//- directory : open this directory on folderView
			//- file : open file
			try
			{
				path = pathBox.Text;             
				fileName = folderView.SelectedItems[0].ToString().Replace("ListViewItem: {", "");
				fileName = fileName.Replace("}", "");
				ListViewItem selectedItem = folderView.SelectedItems[0];
				if (selectedItem.SubItems[1].Text == "File")
				{
					System.Diagnostics.Process.Start(path);

					int index = path.LastIndexOf(@"\");
					path = path.Remove(index);
				}
				if (selectedItem.SubItems[1].Text == "Directory")
				{
					//remove from path part with name of file
					// if (path[path.Length - 4] == '.' || path[path.Length - 4] == '.')
					if ( File.Exists(path))
					{
						int index = path.LastIndexOf(@"\");
						path = path.Remove(index);
					}

					DirectoryInfo nodeDirInfo = new DirectoryInfo(path);
					ViewMethods.DisplayFolderContent(nodeDirInfo, folderView);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);  //TODO 8.3  Write correct error message for user.
			}
		}

		private void MainWindow_ResizeBegin(object sender, EventArgs e)
		{
			initialFormHeight = this.Height;
			initialFormWidth = this.Width;
		}

		private void MainWindow_ResizeEnd(object sender, EventArgs e)
		{
			int stepHeight = this.Height - initialFormHeight;
			int stepWidth = this.Width - initialFormWidth;

			this.folderView.Height += stepHeight;
			this.folderView.Width += stepWidth*2/3;//TODO: 7.4 change numbers for variables.
			this.folderView.Left += stepWidth / 3;


			this.folderTree.Height += stepHeight;
			this.folderTree.Width += stepWidth/3;

			this.progressOfWork.Top += stepHeight;         
			this.progressOfWork.Width += stepWidth/3;

			pathBox.Width += stepWidth;

			buttonAbout.Left += stepWidth;           
			buttonExit.Left += stepWidth;

			for (int i = 0; i < 4; i++)//TODO: 7.5 change numbers for variables.
			{
				folderView.Columns[i].Width = folderView.Width / 4;
			}
		}

		private void buttonCreate_Click(object sender, EventArgs e)
		{
			try
			{
				Archivator arc = new Archivator(AddToExistArc, SaveProgress);
				if (path != null)
				{
					totalFiles = folderView.SelectedItems.Count - 1; ;
					ListViewItem selectedItem = folderView.SelectedItems[0];
					string fullFileName = null;
					string pathToCreatedArc = null;
					for (int i = 0; i < folderView.SelectedItems.Count; i++)
					{
						if (i == 0)
						{
							if (selectedItem.SubItems[1].Text == "File")
							{
								if (!path[path.Length - 1].Equals('\\'))
								{
									path = path + '\\';
								}
								arc.AddFile(path + "\\" + fileName);
							}
							else if (selectedItem.SubItems[1].Text == "Directory")
							{
								arc.AddFolder(path + fileName + "\\");
							}
							fullFileName = Path.GetFileNameWithoutExtension(folderView.SelectedItems[i].SubItems[0].Text);
							pathToCreatedArc = path + fullFileName + ".zip";
						}
						else
						{
							arc.AddMultipleFiles(pathToCreatedArc, path + folderView.SelectedItems[i].SubItems[0].Text);
						}
					}
					files = 0;
				}
				else
				{
					MessageBox.Show("Please choose file");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Please choose file");
			}
		}

		private void buttonExtract_Click(object sender, EventArgs e)
		{
			try
			{ 
				if (path != null)
				{
					if (fileName.Contains(".zip"))
					{
						Archivator arc = new Archivator(ExtractProgress);
						arc.ExtractFiles(path + fileName);
					}
					else
					{
						MessageBox.Show("Please choose zip-file");
					}
				}
				else
				{
					MessageBox.Show("Please choose file");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public void SaveProgress(object sender, SaveProgressEventArgs e)
		{
			if (e.EventType == ZipProgressEventType.Saving_EntryBytesRead)
			{
				progressOfWork.Value = (int)((e.BytesTransferred * 100) / e.TotalBytesToTransfer);
			}
			else if (e.EventType == ZipProgressEventType.Saving_Completed)
			{
				MessageBox.Show("Saving Completed: " + e.ArchiveName);
				progressOfWork.Value = 0;
			}
		}

		public void ExtractProgress(object sender, ExtractProgressEventArgs e)
		{
			if (e.TotalBytesToTransfer > 0)
			{
				progressOfWork.Value = Convert.ToInt32(100 * e.BytesTransferred / e.TotalBytesToTransfer);
			}
			if (e.EventType == ZipProgressEventType.Extracting_AfterExtractAll)
			{
				MessageBox.Show("Extracting Completed: " + e.ArchiveName);
				progressOfWork.Value = 0;
			}
		}

		public void AddToExistArc(object sender, AddProgressEventArgs e)
		{
			if (e.EventType == ZipProgressEventType.Adding_AfterAddEntry)
			{
				string fileName = e.CurrentEntry.FileName;
				files++;
				if (this.progressOfWork != null)
				{
					this.progressOfWork.Value = Convert.ToInt32(files * 100 / totalFiles);
					this.progressOfWork.Update();
				}
			}
			if (files == totalFiles)
			{
				MessageBox.Show("Completed: " + e.ArchiveName);
				progressOfWork.Value = 0;
			}
		}

		private void buttonExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void buttonRefresh_Click(object sender, EventArgs e)
		{
			try
			{
				string refreshPath = path;

				if (!refreshPath.Equals("") || refreshPath != null)
				{
					//TODO: 6.3 Remove unnecessary commets
					/* if (refreshPath[3].Equals('\\'))
					 {
						 refreshPath = refreshPath.Remove(3, 1);
						 MessageBox.Show("refreshPath 1 " + refreshPath);
					 }*/

					if (refreshPath.Contains('.'))//remove from path part with name of file
					{
						int index = refreshPath.LastIndexOf('\\');
						refreshPath = refreshPath.Remove(index);
					}

					pathBox.Text = refreshPath;

					DirectoryInfo nodeDirInfo = new DirectoryInfo(refreshPath);
					ViewMethods.DisplayFolderContent(nodeDirInfo, folderView);
				}
			}
			catch (NullReferenceException ex)
			{
				MessageBox.Show("Specify the path");
			}                     
		}

		private void buttonAbout_Click(object sender, EventArgs e)
		{
			MessageBox.Show("WinArc v1.0.0\nAuthors: Kovalskiy Oleksandr and Luchkova Anhelina", "WinArc");
		}
	}
}
