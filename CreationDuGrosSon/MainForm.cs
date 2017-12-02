using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using NReco.VideoConverter;
using System.Xml;
using System.Reflection;
using System.Media;
using System.Linq;

namespace CreationDuGrosSon
{
    public partial class MainForm : Form
    {
        /***
         * Source bind to the datagridview (dgvFiles)
         * makes it easier to manage data in the datagridview
         * ***/
        private BindingSource bs;
        private SoundPlayer soundPlayer;
        private bool playState;
        
        public MainForm()
        {
            InitializeComponent();

            //bs will 'contain' the data of the datagridview
            bs = (BindingSource)dgvFiles.DataSource;
            bs = soundBindingSource;
            
            //just a tooltip
            ToolTip toolTipDirectory = new ToolTip
            {
                ShowAlways = true
            };
            toolTipDirectory.SetToolTip(btnChooseDirectory, "A directory named SoundsForSoundBlock will be created in the specified directory");

            //background music
            Assembly assembly = Assembly.GetCallingAssembly();
            Stream stream = assembly.GetManifestResourceStream("CreationDuGrosSon.elevatorWav.wav");
            soundPlayer = new SoundPlayer(stream);
            soundPlayer.PlayLooping();
            playState = true;
        }

        /***
         * 
         * ***/
        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileChooser = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                /* set of supported audio and video files
                 * Obviously only the audio part will be used
                */
                Filter = "Audio/Video files (*.mp3;*.mp4;*.avi;*.wav;*.wma;*.m4a;*.ogg;*.flac)|*.mp3;*.mp4;*.avi;*.wav;*.wma*.m4a;*.ogg;*.flac|" +
                "All files (*.*)|*.*",
                RestoreDirectory = true,
                Multiselect = true
            };

            if (fileChooser.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //Check if file already in the table (same file path) before adding
                    bool check;
                    foreach (String path in fileChooser.FileNames)
                    {
                        check = false;
                        foreach(Sound s in bs)
                        {
                            if(s.FilePath == path)
                            {
                                check = true;
                            }
                        }

                        if (!check)
                        {
                            bs.Add(new Sound(path));
                        }
                    }
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
            if(folderBrowser.ShowDialog() == DialogResult.OK )
            {
                if (Directory.Exists(folderBrowser.SelectedPath + @"\SoundsForSoundBlock"))
                {
                   if(MessageBox.Show("The selected directory "+folderBrowser.SelectedPath+ @"\SoundsForSoundBlock already exists. It needs to be deleted do you want to delete it now?"
                            , "Directory already exists"
                            , MessageBoxButtons.YesNoCancel
                            , MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            Directory.Delete(folderBrowser.SelectedPath + @"\SoundsForSoundBlock", true);
                            tbOutputDirectory.Text = folderBrowser.SelectedPath + @"\SoundsForSoundBlock";
                        } catch(Exception ex)
                        {
                            MessageBox.Show(@"The app couldn't remove the directory """ + folderBrowser.SelectedPath + @"\SoundsForSoundBlock\"" Make sure the app has the right to do so (antivirus for example can block such actions) or delete it manually. Error message: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    tbOutputDirectory.Text = folderBrowser.SelectedPath + @"\SoundsForSoundBlock";
                }
                
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
            //check if output direcotry is chosen and if there's files in teh table
            if (dgvFiles.Rows.Count == 0 || tbOutputDirectory.Text == "")
            {
                MessageBox.Show("You need to choose at least one file and an output directory for the created mod", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String message = "Are you sure you want to create the mod?\nThe following songs will converted for the creation of the mod (the original files won't move): \n\n";
                foreach (var a in bs)
                {
                    message += "- " + ((Sound)a).NameToShow + "\n";
                }

                var confirmResult = MessageBox.Show(message,
                                         "Confirm creation",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (confirmResult == DialogResult.Yes)
                {
                    Directory.CreateDirectory(tbOutputDirectory.Text);
                    Directory.CreateDirectory(tbOutputDirectory.Text + @"\Audio");
                    Directory.CreateDirectory(tbOutputDirectory.Text + @"\Data");

                    String outputPath;
                    String soundDescXml = "";
                    String sounds  = "";
                    foreach(Sound aSound in bs)
                    {
                        //Handle file convertion here
                        outputPath = tbOutputDirectory.Text + @"\Audio\" + aSound.NameToShow + ".wmv";
                        if (await convertFile(aSound.FilePath, outputPath, Format.wmv) == 1)
                        {
                            pbTotal.Value = (bs.IndexOf(aSound)+1)*100 / bs.Count;
                        }

                        //Handle creation of xml part needing the loop here
                        soundDescXml += "<SoundDesc Id=\"SBMOD"+bs.IndexOf(aSound)+"\" SoundName=\"Mod sounds: "+aSound.NameToShow+"\"/>";
                        sounds+= 
                                "<Sound>" +
                                    "<Id>" +
                                        "<TypeId>AudioDefinition</TypeId >" +
                                        "<SubtypeId>SBMOD" + bs.IndexOf(aSound) + "</SubtypeId>" +
                                    "</Id>" +
                                    "<Category>Sb</Category>" +
                                    "<MaxDistance>"+aSound.MaxDistance+"</MaxDistance>" +
                                    "<Volume>"+aSound.Volume+"</Volume>" +
                                    "<Loopable>"+aSound.Loopable.ToString()+"</Loopable>" +
                                    "<Waves>" +
                                        "<Wave Type = \"D3\">" +
                                            "<Start>Audio\\"+aSound.NameToShow+".xwm</Start>" +
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
                        writer.WriteStartElement("SoundCategories");
                            writer.WriteStartElement("SoundCategory");
                                writer.WriteStartElement("id");
                                    writer.WriteElementString("TypeId", "SoundCategoryDefinition");
                                    writer.WriteElementString("SubtypeId", "SoundsForSoundBlock");
                                writer.WriteEndElement();
                                writer.WriteStartElement("Sounds");
                                    writer.WriteRaw(soundDescXml);
                                writer.WriteEndElement();
                            writer.WriteEndElement();
                        writer.WriteEndElement();
                    writer.WriteStartElement("Sounds");
                        writer.WriteRaw(sounds);
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                    doc.WriteTo(writer);
                    doc.Save(writer);
                    writer.Close();

                    if(MessageBox.Show("The mod has been created! Do you want to open the directory ?", "Mod created", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        Process.Start("explorer.exe", tbOutputDirectory.Text);
                    }
                    pbConvert.Value = 0;
                    pbTotal.Value = 0;

                    //Deletes temporary file created by NReco to convert audio
                    File.Delete(Application.StartupPath + @"\ffmpeg.exe");
                }
            }
        }

        
        /***
         * Conversion of all the files to wmv audio files
         * parameters:
         * 
         * ***/
        private async Task<int> convertFile(String pathOfFile, String pathOutput, String format)
        {
            try
            {
                FFMpegConverter ffmpeg = new FFMpegConverter();
                ffmpeg.ConvertProgress += updateProgress;
                //Creates a task for void func
                await Task.Factory.StartNew(() => ffmpeg.ConvertMedia(pathOfFile, null, pathOutput, format, new ConvertSettings() { CustomOutputArgs = "-vn"}));
                return 1;
            } catch (Exception ex)
            {
                MessageBox.Show("There was an error during the convertion of the files. Make sure that the app has the right to modify files.\n\n Error message: " +ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return 0;
            }
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

        private void btnMusic_Click(object sender, EventArgs e)
        {
            if (playState)
            {
                soundPlayer.Stop();
            }
            else
            {
                soundPlayer.PlayLooping();
            }
            playState = !playState;
        }
    }
}
