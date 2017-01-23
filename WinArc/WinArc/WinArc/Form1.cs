using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinArc.ArchCore;
using System.Diagnostics;
using Ionic.Zip;

namespace WinArc
{
	public partial class Form1 : Form
	{
		private string path;
		private int initialForm1Width;
		private int initialForm1Height;

		public Form1()
		{
			InitializeComponent();
			//  this.Load += new EventHandler(treeView1_BeforeExpand);            
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			GetDrives();

			for (int i = 0; i < 4; i++)
			{
				listView1.Columns[i].Width = listView1.Width/4;
			}
		}

		private void DisplayTreeView( )
		{
						
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
		  //  DisplayTreeView(treeView1);
		}             	

		private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
		   try
			{
				TreeNode newSelected = e.Node;
				path = newSelected.FullPath;
				
				if(path.Length == 1)
					path = path.Insert(1, @":\");
				else
				{
					path = path.Insert(1, ":");
				}
				textBox1.Text = path;

				DirectoryInfo nodeDirInfo = new DirectoryInfo(path);
				DisplayFolderContent(nodeDirInfo);
			}
			catch(Exception ex)
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
				DisplayFolderContent(nodeDirInfo);
			}            
		}      		     	
			
		private void listView1_Click(object sender, EventArgs e)
		{
		  //  listView1.SelectedItems[0].BackColor = Color.Aquamarine;

			string itemName = listView1.SelectedItems[0].ToString().Replace("ListViewItem: {", "");
			itemName = itemName.Replace("}", "");
			
			
			path = path + @"\" + itemName;
			textBox1.Text = path;
		}

		private void listView1_DoubleClick(object sender, EventArgs e)
		{
			//double click on item
			//- directory : open this directory on listView1
			//- file : open file

			path = textBox1.Text;

			ListViewItem selectedItem = listView1.SelectedItems[0];

			if (selectedItem.SubItems[1].Text == "File")
			{
				System.Diagnostics.Process.Start(path);
			}
			if (selectedItem.SubItems[1].Text == "Directory")
			{
				DirectoryInfo nodeDirInfo = new DirectoryInfo(path);
				DisplayFolderContent(nodeDirInfo);
			}
		}

		private void Form1_ResizeBegin(object sender, EventArgs e)
		{
			initialForm1Height = this.Height;
			initialForm1Width = this.Width;
		}

		private void Form1_ResizeEnd(object sender, EventArgs e)
		{
			int stepHeight = this.Height - initialForm1Height;
			int stepWidth = this.Width - initialForm1Width;

			this.listView1.Height += stepHeight;
			this.listView1.Width += stepWidth*2/3;
			this.listView1.Left += stepWidth / 3;


			this.treeView1.Height += stepHeight;
			this.treeView1.Width += stepWidth/3;

			this.progressBar1.Top += stepHeight;         
			this.progressBar1.Width += stepWidth/3;

			textBox1.Width += stepWidth;

			buttonHelp.Left += stepWidth;           
			buttonExit.Left += stepWidth;

			for (int i = 0; i < 4; i++)
			{
				listView1.Columns[i].Width = listView1.Width / 4;
			}
		}      

		private void buttonCreate_Click(object sender, EventArgs e)
		{
			Archivator arc = new Archivator(SaveProgress);
			ListViewItem selectedItem = listView1.SelectedItems[0];
			if (selectedItem.SubItems[1].Text == "File")
			{
				arc.AddFile(path);
			}
			else if (selectedItem.SubItems[1].Text == "Directory")
			{
				arc.AddFolder(path + "\\");
			}
		}

		public void SaveProgress(object sender, SaveProgressEventArgs e)
		{
			if (e.EventType == ZipProgressEventType.Saving_Started)
			{
				MessageBox.Show("Begin Saving: " + e.ArchiveName);
			}
			else if (e.EventType == ZipProgressEventType.Saving_EntryBytesRead)
			{
				progressBar1.Value = (int)((e.BytesTransferred * 100) / e.TotalBytesToTransfer);
			}
			else if (e.EventType == ZipProgressEventType.Saving_Completed)
			{
				MessageBox.Show("Done: " + e.ArchiveName);
			}
		}

		private void buttonExtract_Click(object sender, EventArgs e)
		{
			Archivator arc = new Archivator(SaveProgress);
			arc.ExtractFiles(path);

		}

		private void buttonExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void buttonRefresh_Click(object sender, EventArgs e)
		{
		  //  button3.PerformClick();
			path = textBox1.Text;
			if (path.Length!=0)
			{
				DirectoryInfo nodeDirInfo = new DirectoryInfo(path);
				DisplayFolderContent(nodeDirInfo);
			}
			//treeView1_BeforeExpand  button3_Click(this,e);

			//treeView1.BeforeExpand();
			// treeView1_BeforeExpand(this, e);
			// listView1.RedrawItems(0, listView1.Items.Count, false);

		  //  this += new EventHandler(treeView1_BeforeExpand);


		}

		//-----------------------------------------------------------------------------------------------------------------------------------------------------------


		private void GetDrives()
		{
			try
			{                
				//get a list of the drives
				string[] drives = Environment.GetLogicalDrives();

				foreach (string drive in drives)
				{
					DriveInfo di = new DriveInfo(drive);
					int driveImage;

					switch (di.DriveType)    //set the drive's icon
					{
						case DriveType.CDRom:
							driveImage = 3;
							break;
						case DriveType.Network:
							driveImage = 6;
							break;
						case DriveType.NoRootDirectory:
							driveImage = 8;
							break;
						case DriveType.Unknown:
							driveImage = 8;
							break;
						default:
							driveImage = 2;
							break;
					}

					TreeNode node = new TreeNode(drive.Substring(0, 1), driveImage, driveImage);
					node.Tag = drive;

					if (di.IsReady == true)
						node.Nodes.Add("...");

					treeView1.Nodes.Add(node);
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void GetDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
		{           
			TreeNode aNode;
			DirectoryInfo[] subSubDirs;
			foreach (DirectoryInfo subDir in subDirs)
			{
				aNode = new TreeNode(subDir.Name, 0, 0);
				aNode.Tag = subDir;
				aNode.ImageKey = "folder";
				subSubDirs = subDir.GetDirectories();
				if (subSubDirs.Length != 0)
				{
					GetDirectories(subSubDirs, aNode);
				}
				nodeToAddTo.Nodes.Add(aNode);
			}
		}
  //----------------------------------------------------------------------------------------------------------------------

		private void DisplayFolderContent(DirectoryInfo nodeDirInfo)
		{

			listView1.Items.Clear();
			ListViewItem.ListViewSubItem[] subItems;
			ListViewItem item = null;

			foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
			{
				item = new ListViewItem(dir.Name, 0);
				subItems = new ListViewItem.ListViewSubItem[]
							{
								new ListViewItem.ListViewSubItem(item, "Directory"),
								new ListViewItem.ListViewSubItem(item, dir.LastAccessTime.ToShortDateString())
							};

				item.SubItems.AddRange(subItems);
				listView1.Items.Add(item);
			}

			foreach (FileInfo file in nodeDirInfo.GetFiles())
			{
				item = new ListViewItem(file.Name, 1);
				subItems = new ListViewItem.ListViewSubItem[]
						  {
							new ListViewItem.ListViewSubItem(item, "File"),
							new ListViewItem.ListViewSubItem(item, file.LastAccessTime.ToShortDateString()),
							new ListViewItem.ListViewSubItem(item, file.Length.ToString())
						  };

				item.SubItems.AddRange(subItems);
				listView1.Items.Add(item);
			}

			listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

		}

	   
	}
}
