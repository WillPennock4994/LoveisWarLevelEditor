using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LevelEditor
{
    

    public partial class LevelEditor : Form
    {
        public string file;
        public string folderPath;

        public LevelEditor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                file = openFileDialog1.FileName;
                try
                {
                    
                    textBox1.Text = file;
                    
                }
                catch(IOException)
                {

                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                folderPath = folderBrowserDialog1.SelectedPath;
                try
                {
                    textBox2.Text = folderPath;
                }
                catch (IOException)
                {

                }
            }

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = textBox3.Text;

                Stream str = File.OpenWrite(filename);
                BinaryWriter output = new BinaryWriter(str);

                output.Write(file);

                output.Close();

                label1.Text = "Done!";
            }
            catch(IOException)
            {

            }
        }
    }
}
