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

namespace WinArc
{
	public partial class Form1 : Form
	{
		private string path;
		public Form1()
		{
			InitializeComponent();
		}        

		private void Form1_Load(object sender, EventArgs e)
		{
			DisplayTreeView();
		}

		private void DisplayTreeView()
		{
			try
			{
				string path = "";// I NEEEEED THE PAAAAAAATH !!!!!!!!!!!1111!!!!1
				TreeNode rootNode;
				string myComputerPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
				DirectoryInfo mainFolder = new DirectoryInfo(@"D:\Downloads");//System.IO.DriveInfo.GetDrives()[0].RootDirectory();
				if (mainFolder.Exists)
				{
					rootNode = new TreeNode(mainFolder.Name);
					rootNode.Tag = mainFolder;
					GetDirectories(mainFolder.GetDirectories(), rootNode);
					treeView1.Nodes.Add(rootNode);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void GetDirectories(DirectoryInfo[] subDirs,TreeNode nodeToAddTo)
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

		private void button4_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			TreeNode newSelected = e.Node;
			path = newSelected.FullPath;
			textBox1.Text = path;
			DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
			DisplayFolderContent(nodeDirInfo);            
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				//open entered directory on listView1                
				DirectoryInfo nodeDirInfo = new DirectoryInfo(textBox1.Text);
				DisplayFolderContent(nodeDirInfo);
			}            
		}

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

		private void listView1_DoubleClick(object sender, EventArgs e)
		{
			//double click on item
			//- directory : open this directory on listView1
			//- file : open file

			//listView1.SelectedItems;


			listView1.SelectedItems[0].BackColor = Color.Aquamarine;

			//System.Diagnostics.Process.Start(Path.Combine(path,))
		}

		private void buttonCreate_Click(object sender, EventArgs e)
		{
			Archivator arc = new Archivator();

		}

		private void buttonExtract_Click(object sender, EventArgs e)
		{
			Archivator arc = new Archivator();
		}

		private void listView1_Click(object sender, EventArgs e)
		{
			string itemName = listView1.SelectedItems[0].ToString().Replace("ListViewItem: {", "");
			itemName = itemName.Replace("}", "");
			textBox1.Text = path + "\\" + itemName;
		}
	}
}
