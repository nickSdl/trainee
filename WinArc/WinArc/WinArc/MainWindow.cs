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

		public MainWindow()
		{
			InitializeComponent();
			//  this.Load += new EventHandler(treeView1_BeforeExpand);            
		}

		private void MainWindow_Load(object sender, EventArgs e)
		{
			ViewMethods.GetDrives(treeView1);

			for (int i = 0; i < 4; i++)
			{
				listView1.Columns[i].Width = listView1.Width/4;
			}
		}

		private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)//DisplayTreeView
		{
			if (e.Node.Nodes.Count > 0)
			{
				if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes[0].Tag == null)
				{
					e.Node.Nodes.Clear();

					//get the list of sub direcotires
					string[] dirs = Directory.GetDirectories(e.Node.Tag.ToString());

					foreach (string dir in dirs)
					{
						DirectoryInfo di = new DirectoryInfo(dir);
						TreeNode node = new TreeNode(di.Name, 0, 1);

						try
						{
							//keep the directory's full path in the tag for use later
							node.Tag = dir;

							//if the directory has sub directories add the place holder
							if (di.GetDirectories().Count() > 0)
								node.Nodes.Add(null, "...", 0, 0);

							foreach (var file in di.GetFiles())
							{
								TreeNode n = new TreeNode(file.Name, 13, 13);
								node.Nodes.Add(n);
							}

						}
						catch (UnauthorizedAccessException)
						{
							//display a locked folder icon
							node.ImageIndex = 12;
							node.SelectedImageIndex = 12;
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message, "DirectoryLister",
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

		private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
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
				textBox1.Text = path;

				DirectoryInfo nodeDirInfo = new DirectoryInfo(path);
				ViewMethods.DisplayFolderContent(nodeDirInfo, listView1);
			}
			catch (Exception ex)
			{
			   MessageBox.Show("Problem!!!!\n" + ex.Message);
			}

		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				path = textBox1.Text;

				//open entered directory on listView1                
				DirectoryInfo nodeDirInfo = new DirectoryInfo(path);
				ViewMethods.DisplayFolderContent(nodeDirInfo, listView1);
			}            
		}      		     	
			
		private void listView1_Click(object sender, EventArgs e)
		{
			//  listView1.SelectedItems[0].BackColor = Color.Aquamarine;

			/*	string itemName = listView1.SelectedItems[0].ToString().Replace("ListViewItem: {", "");
				itemName = itemName.Replace("}", "");*/

			fileName = listView1.SelectedItems[0].ToString().Replace("ListViewItem: {", "");
			fileName = fileName.Replace("}", "");

			if (!path[path.Length-1].Equals('\\'))
			{
				path = path + '\\';
			}
		//	path = path + filePath;
			textBox1.Text = path + fileName;
		}

		private void listView1_DoubleClick(object sender, EventArgs e)
		{
			//double click on item
			//- directory : open this directory on listView1
			//- file : open file

			path = textBox1.Text;            

		  if(path.Contains('.'))//remove from path part with name of file
			{
				int index = path.LastIndexOf(@"\");
				path = path.Remove(index);
			}

			fileName = listView1.SelectedItems[0].ToString().Replace("ListViewItem: {", "");
			fileName = fileName.Replace("}", "");

			ListViewItem selectedItem = listView1.SelectedItems[0];

			if (selectedItem.SubItems[1].Text == "File")
			{
				System.Diagnostics.Process.Start(path+ fileName);
			}
			if (selectedItem.SubItems[1].Text == "Directory")
			{
				DirectoryInfo nodeDirInfo = new DirectoryInfo(path);
				ViewMethods.DisplayFolderContent(nodeDirInfo, listView1);
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

			this.listView1.Height += stepHeight;
			this.listView1.Width += stepWidth*2/3;
			this.listView1.Left += stepWidth / 3;


			this.treeView1.Height += stepHeight;
			this.treeView1.Width += stepWidth/3;

			this.progressOfWork.Top += stepHeight;         
			this.progressOfWork.Width += stepWidth/3;

			textBox1.Width += stepWidth;

			buttonAbout.Left += stepWidth;           
			buttonExit.Left += stepWidth;

			for (int i = 0; i < 4; i++)
			{
				listView1.Columns[i].Width = listView1.Width / 4;
			}
		}      

		private void buttonCreate_Click(object sender, EventArgs e)
		{
			Archivator arc = new Archivator(SaveProgress);
			if (path != null)
			{
				ListViewItem selectedItem = listView1.SelectedItems[0];
				if (selectedItem.SubItems[1].Text == "File")
				{
					if (!path[path.Length - 1].Equals('\\'))
					{
						path = path + '\\';
					}

					arc.AddFile(path + fileName);
				}
				else if (selectedItem.SubItems[1].Text == "Directory")
				{
					arc.AddFolder(path + "\\");
				}
			}
			else
			{
				MessageBox.Show("Please choose file");
			}
		}

		private void buttonExtract_Click(object sender, EventArgs e)
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

		public void SaveProgress(object sender, SaveProgressEventArgs e)
		{
			if (e.EventType == ZipProgressEventType.Saving_Started)
			{
			//	MessageBox.Show("Begin Saving: " + e.ArchiveName);
			}
			else if (e.EventType == ZipProgressEventType.Saving_EntryBytesRead)
			{
				progressOfWork.Value = (int)((e.BytesTransferred * 100) / e.TotalBytesToTransfer);
			}
			else if (e.EventType == ZipProgressEventType.Saving_Completed)
			{
				MessageBox.Show("Done: " + e.ArchiveName);
				progressOfWork.Value = 0;
			}
		}

		public void ExtractProgress(object sender, ExtractProgressEventArgs e)
		{
			if (e.TotalBytesToTransfer > 0)
			{
				progressOfWork.Value = Convert.ToInt32(100 * e.BytesTransferred / e.TotalBytesToTransfer);
			}
			else if(e.EventType == ZipProgressEventType.Extracting_AfterExtractAll)
			{
				MessageBox.Show("Done: " + e.ArchiveName);
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

					textBox1.Text = refreshPath;

					DirectoryInfo nodeDirInfo = new DirectoryInfo(refreshPath);
					ViewMethods.DisplayFolderContent(nodeDirInfo, listView1);
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
