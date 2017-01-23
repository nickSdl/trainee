using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinArc
{
   public static class ViewMethods
    {
        public static void  GetDrives(TreeView treeView)
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

                    treeView.Nodes.Add(node);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void GetDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
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

        public static void DisplayFolderContent(DirectoryInfo nodeDirInfo, ListView listView)
        {

            listView.Items.Clear();
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;
            try
            {
                foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
                {
                    item = new ListViewItem(dir.Name, 0);
                    subItems = new ListViewItem.ListViewSubItem[]
                                {
                                new ListViewItem.ListViewSubItem(item, "Directory"),
                                new ListViewItem.ListViewSubItem(item, dir.LastAccessTime.ToShortDateString())
                                };

                    item.SubItems.AddRange(subItems);
                    listView.Items.Add(item);
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
                    listView.Items.Add(item);
                }

                listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
