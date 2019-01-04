﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VideoWay
{
    public partial class UploadVideoForm : Form
    {
        public UploadVideoForm()
        {
            InitializeComponent();
        }

        private void previewVideoPlayButton_Click(object sender, EventArgs e)
        {
            //when pressed it will start the webbrowser if the item is sellected from the item box
            //if not then add a message box
            webBrowser1.Navigate(listBox1.SelectedItem.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // first here has to be some conditions before uploading and after
            // 1- there cannot be any any list whit the same name, so theres a need to search to see if hereres name tittles
            // and the textbox tittle cannot be emphty.
            // 2- , there has to be something on the list of videos, even if its just one, 
            // 3- before uploading it will show a confirmation message box
            // 4-after the video is uploaded, text box will be cleared along whit the video list, and i will show on the status bar the success

            //first making sure the list isnt emphty, that theres a tittle sellected and that thres a category added
            //secod check if an existing tittle exist

            //checking if the if all text boxes whit the data we want are filled,
            
            if(textBox2.Text != "" && comboBox1.Text != "")
            {
                //after, we check if theres a textfile whit the same tittle, ergo, if a list whit the name tittle exists

                if(File.Exists(@"text_folder/" + textBox2.Text + "-list.txt"))
                {
                    toolStripStatusLabel1.Text = "Este titulo existe, tente novamente.";
                    
                }


                
                else
                {
                    //summon constructor base
                    VideoList list = new VideoList();

                    //adding data do the bases
                    list.listname = textBox2.Text;
                    list.category = comboBox1.Text;
                    list.listveiws = 0;
                    list.videopath = @"text_folder/" + list.listname + "-list.txt";
                    list.commentpath = @"text_folder/" + list.listname + "-comments.text";

                    // after all those are done, we will open the SW and save our files
                    StreamWriter sw;
                    sw = File.CreateText(list.commentpath);
                    sw = File.CreateText(list.videopath);
                    
                    //after the files are created we need to add the listbox1 links and tittle to the of the videos
                    
                    //get the number of items for the for cycle
                    string numb = listBox1.Items.Count.ToString();
                    int counter = Convert.ToInt16(numb);

                    for (int i = 0; i < counter; i++)
                    {
                        string line = listBox1.Items[i].ToString();
                        sw.WriteLine(line);//this will be in seperate lines has in ENTER kind
                    }
                    sw.Close();


                }
                

            }

            else
            {
                toolStripStatusLabel1.Text = " Selecione a categoria e insira o titulo.";
            }
            
        }

        private void adicionarVideoButton_Click(object sender, EventArgs e)
        {
            //upgrade to do: there can not be any duplicate links
            if(textBox1.Text != "" && textBox3.Text != "")
            {
                string link = textBox1.Text;
                string title = textBox3.Text;
                listBox1.Items.Add(title + ";" + link);
                textBox1.Text = "";

            }

            else
            {
                toolStripStatusLabel1.Text = "Insira o link of video e titulo";
            }
            
        }

        private void removerVideoButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            removerVideoButton.Enabled = true;
            previewVideoPlayButton.Enabled = true;
        }

        private void UploadVideoForm_Load(object sender, EventArgs e)
        {
            // status will show time and status of the stuff
            //if pre defined categories we will load the category text file
            
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}