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
        //attributes for choice of file and folder path
        public string file;
        public string folderPath;

        //default initialization
        public LevelEditor()
        {
            InitializeComponent();
        }

        //clicking the first button opens a seach for a file
        private void button1_Click(object sender, EventArgs e)
        {
            
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                file = openFileDialog1.FileName;
                try
                {
                    //places the file path in the text box correllating to the button pressed.
                    textBox1.Text = file;
                    
                }
                catch(IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //nothing here
        }

        //pressing button2 allows the user to select a folder path
        //removed from final product becasue of lack of functionality
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                folderPath = folderBrowserDialog1.SelectedPath;
                try
                {
                    //places the folder path in the text box correllating to the button
                    //textBox2.Text = folderPath;
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
            //nothing here
        }

        //set the values of the text boxes to the values of the strings containing information
        //output the data to a binary file that will later be read in by the game
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //set filename
                string filename = textBox3.Text + ".dat";


                //index the Content folder inside of the filepath
                int index = file.IndexOf("Content");

                //make a substring of the file path
                string Finalfilepath = file.Substring(index);

                //open a stream
                Stream str = new FileStream(filename, FileMode.Append, FileAccess.Write);
                //write to the stream
                BinaryWriter output = new BinaryWriter(str);

                output.Write(Finalfilepath);
                //CLOSE STREAM
                output.Close();
                //read out a done message to the user to make it obvious that the button works.
                label1.Text = "Done!";


                
            }
            catch(IOException ex)
            {
                Console.WriteLine(ex.Message);         
            }
        }
    }
}
