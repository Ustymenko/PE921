using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _26052020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonADD_Click(object sender, EventArgs e)
        {
            TreeNode root = new TreeNode();
            root.Text = "D123";
            root.Nodes.Add(new TreeNode("Тимощук", 1, 3));
            root.Nodes.Add(new TreeNode("Петрук", 1, 4));

            treeView1.Nodes.Add(root);
            //treeView1.Nodes.Add(root); //error

            TreeNode rootcopy = (TreeNode)root.Clone();
            treeView1.Nodes.Add(rootcopy);
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            TreeNode node = new TreeNode("Іщук");
            TreeNode selectNode = treeView1.SelectedNode;
            selectNode?.Nodes.Insert(-10, node);
            //treeView1.Nodes[0].Nodes.Insert(11,node);
            // treeView1.Nodes[1].Nodes.Add(node);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //treeView1.Nodes.Remove(treeView1.SelectedNode);

            treeView1.Nodes.RemoveAt(1);
            treeView1.Focus();
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            if (buttonMove.Text == "Selected for Move")
            {
                treeView1.Tag = treeView1.SelectedNode;
                treeView1.Nodes.Remove(treeView1.SelectedNode);
                buttonMove.Text = "Selected for Insert";
            }
            else
            {
                treeView1.SelectedNode.Nodes.Add((TreeNode)treeView1.Tag);
                buttonMove.Text = "Selected for Move";
                treeView1.Tag = null;
                treeView1.SelectedNode.Expand();
                //  treeView1.SelectedNode.Collapse();
                treeView1.Focus();

            }

            // treeView1.Nodes[1].Nodes.Add(temp);
        }
        private void Recursive(TreeNodeCollection nodes, string text = "")
        {
            foreach (TreeNode item in nodes)
            {
                listBox1.Items.Add(text + item.Text);
                if (item.Nodes.Count > 0)
                    Recursive(item.Nodes, text + "\t");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Recursive(treeView1.Nodes);
        }
        private void RecursiveDel(TreeNodeCollection nodes)
        {
            var elemdel = nodes.OfType<TreeNode>().Where(x => x.Checked);
            foreach (var item in elemdel)
                treeView1.Nodes.Remove(item);
            foreach (TreeNode item in nodes)
                RecursiveDel(item.Nodes);
        }
      


        private void button1_Click(object sender, EventArgs e)
        {
            RecursiveDel(treeView1.Nodes);
        }

        private void FtoOne(int n)//5
        {
            if (n < 1) return;
            listBox2.Items.Add(n);
            FtoOne(n - 1);
        }
        private void OnetoN(int n)//5
        {
            //if (n > 0)
            //{
            //    OnetoN(n - 1);
            //    listBox2.Items.Add(n);
            //}
            if (n < 1) return;
            OnetoN(n - 1);
            listBox2.Items.Add(n);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            FtoOne(5);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            OnetoN(5);
        }
        private void RecursiveFind(TreeNodeCollection nodes, string text)
        {
            foreach (TreeNode item in nodes)
            {
                if (item.Text == text)
                    listBox1.Items.Add(item);
                if (item.Nodes.Count > 0)
                    RecursiveFind(item.Nodes, text);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string textfind = "Петренко";//"BE911";
            //var arr = treeView1.Nodes.Find(textfind, true);
            //foreach (var item in arr)
            //    listBox1.Items.Add(item);

            RecursiveFind(treeView1.Nodes, textfind);
        }
    }
}
