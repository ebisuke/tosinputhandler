using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tosinputhandler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveInputText();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void SaveInputText()
        {
            using (StreamWriter tx = new StreamWriter(Path.Combine(  Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName),"tx.txt") ))
            {
                tx.Write(textBox1.Text);
            }
            this.Close();
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var args=Environment.GetCommandLineArgs();
            if (args.Length >= 5)
            {
                Rectangle rect = new Rectangle(int.Parse(args[1]), int.Parse(args[2]), int.Parse(args[3]),
                    int.Parse(args[4]));
                Bounds = rect;
            }   
            using (StreamReader rx = new StreamReader(Path.Combine(  Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName),"rx.txt") ))
            {
                textBox1.Text= rx.ReadToEnd();
            }
        }
    }
}