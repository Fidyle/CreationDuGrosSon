using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml.Linq;
using NReco.VideoConverter;
using System.Xml;

namespace CreationDuGrosSon
{
    public partial class MainForm : Form
    {
        /***
         * Source bind to the datagridview (dgvFiles)
         * makes it easier to manage data in the datagridview
         * ***/
        private BindingSource bs = new BindingSource();
        public MainForm()
        {
            InitializeComponent();

            ToolTip toolTipDirectory = new ToolTip();
            toolTipDirectory.ShowAlways = true;
            toolTipDirectory.SetToolTip(btnChooseDirectory, "A directory named SoundsForSoundBlock will be created in the specified directory");
        }

        /***
         * 
         * ***/
        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileChooser = new OpenFileDialog();
            fileChooser.InitialDirectory = "c:\\";
            /* A set of different audio and video files
             * Obviously only the audio part will be used
            */
            fileChooser.Filter = "Audio/Video files (*.mp3;*.mp4;*.avi;*.wav;*.wma;*.m4a;*.ogg;*.flac)|*.mp3;*.mp4;*.avi;*.wav;*.wma*.m4a;*.ogg;*.flac|" +
                "All files (*.*)|*.*";
            fileChooser.RestoreDirectory = true;
            fileChooser.Multiselect = true;
            
            if(fileChooser.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    foreach (String path in fileChooser.FileNames)
                    {
                        bs.Add(new Sound(path));
                    }
                    
                    dgvFiles.DataSource = bs;
                } catch (Exception ex)
                {
                    MessageBox.Show("Error: Couldn't read the file(s). Error message: " + ex.Message);
                }
            }
        }

        
        
        /***
         * Let the user choose the place where the mod will be created 
         * 
         * ***/
        private void btnChooseDirectory_Click(object sender, EventArgs e)
        {
            
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if(folderBrowser.ShowDialog() == DialogResult.OK)
            {
                if (tbOutputDirectory.Text != "")
                {
                    if (!Directory.EnumerateFiles(tbOutputDirectory.Text).Any() && Directory.GetDirectories(tbOutputDirectory.Text).Equals(new String[] {"Audio","Data" }))
                    {
                        Directory.Delete(tbOutputDirectory.Text, true);
                    }
                    else
                    {
                        MessageBox.Show("Some subfolders were present in the folder \"" + tbOutputDirectory.Text + "\"\n" +
                            "They were not deleted, though only the folders \"Audio\" and \"Data\" should be present for the mod to work"
                            , "Information"
                            , MessageBoxButtons.OK
                            , MessageBoxIcon.Information);
                    }
                }
                tbOutputDirectory.Text = folderBrowser.SelectedPath + "\\SoundsForSoundBlock\\";
                Directory.CreateDirectory(tbOutputDirectory.Text);
                Directory.CreateDirectory(tbOutputDirectory.Text + "\\Audio");
                Directory.CreateDirectory(tbOutputDirectory.Text + "\\Data");
            }
        }

        /*** 
         * Remove selected rows in dgvFiles
         * 
         * ***/
        private void btnRemoveFIles_Click(object sender, EventArgs e)
        {
            var confirmRemove = MessageBox.Show("Remove selected sounds from the table ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(confirmRemove == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvFiles.SelectedRows)
                {
                    bs.RemoveAt(row.Index); 
                }
            }
        }

        private async void btnCreateMod_Click(object sender, EventArgs e)
        {
            pbConvert.Value = 0;
            pbTotal.Value = 0;
            if (dgvFiles.Rows.Count == 0 || tbOutputDirectory.Text == "")
            {
                MessageBox.Show("You need to choose at least one file and an output directory for the created mod", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String message = "Are you sure you want to create the mod?\nThe following songs will converted for the creation of the mod (the original files won't move): \n\n";
                //foreach (DataGridViewRow dgvRow in dgvFiles.Rows)
                foreach (var a in bs)
                {
                    //message += "- " + ((Sound)dgvRow.DataBoundItem).NameToShow + "\n";
                    message += "- " + ((Sound)a).NameToShow + "\n";
                }

                var confirmResult = MessageBox.Show(message,
                                         "Confirm creation",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (confirmResult == DialogResult.Yes)
                {
                    String outputPath;
                    String soundDescXml = "";
                    String sounds  = "";
                    foreach(Sound aSound in bs)
                    {
                        //Handle file convertion here
                        outputPath = tbOutputDirectory.Text+@"\Audio\" + aSound.NameToShow + ".wmv";
                        
                        if (await convertFile(aSound.FilePath, outputPath, Format.wmv) == 1)
                        {
                            pbTotal.Value += Convert.ToInt32(pbConvert.Value / bs.Count);
                        }

                        //Handle creation of xml part needing the loop here
                        soundDescXml += "<SoundDesc Id=\"SBMOD"+bs.IndexOf(aSound)+"\" SoundName=\"Mod sounds: "+aSound.NameToShow+"\"/>";
                        sounds+= 
                                "<Sound>" +
                                    "<Id>" +
                                        "<TypeId>AudioDefinition</TypeId >" +
                                        "<SubtypeId>SBMOD" + bs.IndexOf(aSound) + "</SubtypeId>" +
                                    "</Id>" +
                                    "<Category > Sb </Category>" +
                                    "<MaxDistance> 100 </MaxDistance>" +
                                    "<Volume> 1.00 </Volume>" +
                                    "<Loopable> true </Loopable>" +
                                    "<Waves>" +
                                        "<Wave Type = \"D3\">" +
                                            "<Start> Audio\\"+aSound.NameToShow+".xwm </Start>" +
                                        "</Wave>" +
                                    "</Waves>" +
                                "</Sound>";
                    }
                    //Encoding in utf8 

                    XmlDocument doc = new XmlDocument();

                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.CheckCharacters = true;
                    settings.Encoding = Encoding.UTF8;
                    settings.Indent = true;
                    XmlWriter writer = XmlWriter.Create(tbOutputDirectory.Text + @"\Data\Sounds.sbc", settings);

                    writer.WriteStartDocument();
                    writer.WriteStartElement("Definitions");
                    /*writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                    writer.WriteAttributeString("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");*/
                        writer.WriteStartElement("SoundCategories");
                            writer.WriteStartElement("SoundCategory");
                                writer.WriteStartElement("id");
                                    writer.WriteElementString("TypeId", "SoundCategoryDefinition");
                                    writer.WriteElementString("SubtypeId", "SoundsForSoundBlock");
                                writer.WriteEndElement();
                                writer.WriteStartElement("Sounds");
                    //write elements here
                                    writer.WriteRaw(soundDescXml);
                                writer.WriteEndElement();
                            writer.WriteEndElement();
                        writer.WriteEndElement();
                    writer.WriteStartElement("Sounds");
                    //write element here
                        writer.WriteRaw(sounds);
                    writer.WriteEndElement();

                    /*writer.WriteStartElement("Foo");
                    writer.WriteAttributeString("Bar", "Some & value");
                    writer.WriteElementString("Nested", "data");*/

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                    doc.WriteTo(writer);
                    doc.Save(writer);
                    writer.Close();

                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await convertFile(@"F:\Musique\Deja Vu.mp3", @"F:\Musique\Deja Vu.wmv", Format.wmv);
        }
        
        /***
         * Conversion of all the files to wmv audio files
         * parameters:
         * 
         * ***/
        private async Task<int> convertFile(String pathOfFile, String pathOutput, String format)
        {
            FFMpegConverter ffmpeg = new FFMpegConverter();
            ffmpeg.ConvertProgress += updateProgress;
            //Creates a task for void func
            await Task.Factory.StartNew(() => ffmpeg.ConvertMedia(pathOfFile, pathOutput, format));
            return 1;
        }

        /***
         * Updates progress bar of file convertion
         * ***/
        private void updateProgress(object sender, ConvertProgressEventArgs e)
        {
            pbConvert.Invoke(new Action(() =>
            {
                pbConvert.Value = Convert.ToInt32(((double)e.Processed.Ticks / (double)e.TotalDuration.Ticks) * 100);
            }));
        }
    }
}
