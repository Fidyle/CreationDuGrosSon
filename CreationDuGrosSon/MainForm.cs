using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using NReco.VideoConverter;
using System.Xml;
using System.Reflection;
using System.Media;
using System.Linq;
using System.Collections.Generic;
using System.Data;

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
        private String lastSelectedFolder = "";
        public MainForm()
        {
            InitializeComponent();


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
            if (dgvFiles.CanSelect)
            {
                OpenFileDialog fileChooser = new OpenFileDialog
                {
                    //InitialDirectory = "c:\\",
                    /* set of supported audio and video files
                        * Obviously only the audio part will be used
                    */
                    Filter = "Audio/Video files (*.mp3;*.mp4;*.avi;*.wav;*.wma;*.m4a;*.ogg;*.flac)|*.mp3;*.mp4;*.avi;*.wav;*.wma*.m4a;*.ogg;*.flac",
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
                                var query = from Sound s in bs.List
                                            where s.NameToShow.ToLower() == new Sound(path).NameToShow.ToLower()
                                            select s.NameToShow;
                            
                                if(query.ToList().Count > 1)
                                {
                                    ((Sound)bs[bs.Count - 1]).NameToShow += " - copy";
                                }
                            }
                        }
                        dgvFiles.ClearSelection();
                    } catch (Exception ex)
                    {
                        MessageBox.Show("Error: Couldn't read the file(s). Error message: " + ex.Message);
                    }
                }
            }
        }
        
        
        /***
         * Let the user choose the place where the mod will be created 
         * 
         * ***/
        private void btnChooseDirectory_Click(object sender, EventArgs e)
        {
            if (dgvFiles.CanSelect)
            {
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                if(lastSelectedFolder != "")
                {
                    folderBrowser.SelectedPath = lastSelectedFolder;
                }
                
                
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    /*if (Directory.Exists(folderBrowser.SelectedPath + @"\SoundsForSoundBlock"))
                    {
                        if (MessageBox.Show("The selected directory " + folderBrowser.SelectedPath + @"\SoundsForSoundBlock already exists. It needs to be deleted do you want to delete it now? It will be deleted during the creation"
                                 , "Directory already exists"
                                 , MessageBoxButtons.YesNo
                                 , MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                if (Directory.Exists(folderBrowser.SelectedPath + @"\SoundsForSoundBlock"))
                                {
                                    Directory.Delete(folderBrowser.SelectedPath + @"\SoundsForSoundBlock", true);
                                }
                                tbOutputDirectory.Text = folderBrowser.SelectedPath + @"\SoundsForSoundBlock";
                                lastSelectedFolder = folderBrowser.SelectedPath;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(@"The app couldn't remove the directory """ + folderBrowser.SelectedPath + @"\SoundsForSoundBlock\"" Make sure the app has the right to do so (antivirus for example can block such actions) or delete it manually. Error message: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            lastSelectedFolder = folderBrowser.SelectedPath;
                            tbOutputDirectory.Text = folderBrowser.SelectedPath + @"\SoundsForSoundBlock";
                            return;
                        }
                    }
                    else
                    {
                        tbOutputDirectory.Text = folderBrowser.SelectedPath + @"\SoundsForSoundBlock";
                    }*/
                    tbOutputDirectory.Text = folderBrowser.SelectedPath;

                }
            }
        }

        /*** 
         * Remove selected rows in dgvFiles
         * 
         * ***/
        private void btnRemoveFIles_Click(object sender, EventArgs e)
        {
            if (dgvFiles.SelectedRows.Count > 0)
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
            
        }

        private async void btnCreateMod_Click(object sender, EventArgs e)
        {
            if (dgvFiles.CanSelect)
            {
                pbConvert.Value = 0;
                pbTotal.Value = 0;
                //check if output direcotry is chosen and if there's files in teh table
                if (dgvFiles.Rows.Count == 0 || tbOutputDirectory.Text == "" || tbDirectory.Text == "")
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
                        dgvFiles.Enabled = false;
                        dgvFiles.ClearSelection();
                        String outputDirecory = tbOutputDirectory.Text + @"\" + tbDirectory.Text;

                        try
                        {
                            if (Directory.Exists(outputDirecory))
                            {
                                if( MessageBox.Show(@"The directory """  +outputDirecory + @""" already exists, it needs to be deleted to avoid errors do yo uwant to do it now ?",
                                    "Warning",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning) == DialogResult.Yes)
                                {
                                    Directory.Delete(outputDirecory, true);
                                }
                                else
                                {
                                    dgvFiles.Enabled = true;
                                    return;
                                }
                            }
                            Directory.CreateDirectory(outputDirecory);
                            Directory.CreateDirectory(outputDirecory + @"\Audio");
                            Directory.CreateDirectory(outputDirecory + @"\Data");

                            String outputPath;
                            foreach (Sound aSound in bs)
                            {
                                //Handle file convertion here
                                outputPath = outputDirecory + @"\Audio\" + aSound.NameToShow;
                                await convertFile(aSound.FilePath, outputPath, "wav", bs.IndexOf(aSound));
                            }

                            /***
                             * Start of the creation of the XML (.sbc file)
                             * Loops can be optimised using writer.writeRaw method in the loop right above this comment
                             * 
                             * */

                            XmlDocument doc = new XmlDocument();

                            XmlWriterSettings settings = new XmlWriterSettings();
                            settings.CheckCharacters = true;
                            settings.Indent = true;
                            settings.Encoding = Encoding.ASCII;
                            XmlWriter writer = XmlWriter.Create(outputDirecory + @"\Data\Sounds.sbc", settings);

                            writer.WriteStartDocument();

                            writer.WriteStartElement("Definitions");
                            writer.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
                            writer.WriteAttributeString("xmlns", "xsd", null, "http://www.w3.org/2001/XMLSchema-instance");
                            writer.WriteStartElement("SoundCategories");
                            writer.WriteStartElement("SoundCategory");
                            writer.WriteStartElement("Id");
                            writer.WriteStartElement("TypeId");
                            writer.WriteString("SoundCategoryDefinition");
                            writer.WriteEndElement();
                            writer.WriteStartElement("SubtypeId");
                            writer.WriteString("SoundsForSoundBlock");
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                            writer.WriteStartElement("Sounds");

                            foreach (Sound aSound in bs)
                            {
                                writer.WriteStartElement("SoundDesc");
                                writer.WriteAttributeString("Id", "SBMod" + (bs.IndexOf(aSound) + 1).ToString());
                                writer.WriteAttributeString("SoundName", "Mod sounds: " + aSound.NameToShow);
                                writer.WriteEndElement();
                            }

                            writer.WriteEndElement();
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                            writer.WriteStartElement("Sounds");

                            foreach (Sound aSound in bs)
                            {
                                writer.WriteStartElement("Sound");

                                writer.WriteStartElement("Id");
                                writer.WriteStartElement("TypeId");
                                writer.WriteString("AudioDefinition");
                                writer.WriteEndElement();
                                writer.WriteStartElement("SubtypeId");
                                writer.WriteString("SBMod" + (bs.IndexOf(aSound) + 1).ToString());
                                writer.WriteEndElement();
                                writer.WriteEndElement();
                                writer.WriteStartElement("Category");
                                writer.WriteString("Sb");
                                writer.WriteEndElement();
                                writer.WriteStartElement("MaxDistance");
                                writer.WriteString(aSound.MaxDistance.ToString());
                                writer.WriteEndElement();
                                writer.WriteStartElement("Volume");
                                writer.WriteString(aSound.Volume.ToString());
                                writer.WriteEndElement();
                                writer.WriteStartElement("Loopable");
                                writer.WriteString(aSound.Loopable.ToString().ToLower());
                                writer.WriteEndElement();
                                writer.WriteStartElement("Waves");
                                writer.WriteStartElement("Wave");
                                writer.WriteAttributeString("Type", "D3");
                                writer.WriteStartElement("Start");
                                writer.WriteString(@"Audio\" + aSound.NameToShow + ".xwm");
                                writer.WriteEndElement();
                                writer.WriteEndElement();
                                writer.WriteEndElement();

                                writer.WriteEndElement();
                            }

                            writer.WriteEndElement();
                            writer.WriteEndElement();
                            writer.WriteEndDocument();

                            writer.Flush();
                            doc.WriteTo(writer);
                            doc.Save(writer);
                            writer.Close();
                            /***
                             * End of XML
                             * 
                             * 
                             * */
                            

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occured, it shouldn't happen. Send this to the dev he'll look into it! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvFiles.Enabled = true;
                        }
                    }
                }
            }
        }

        
        /***
         * Conversion of all the files to xwm audio files
         * 
         * ***/
        private async Task<bool> convertFile(String pathOfFile, String pathOutput, String format, int indexInBs)
        {
            try
            {
                FFMpegConverter ffmpeg = new FFMpegConverter();
                ffmpeg.ConvertProgress += updateProgress;
                Task<bool> task = Task.Run(
                    () => {
                        ffmpeg.ConvertMedia(pathOfFile, null, pathOutput + "." + format, format, new ConvertSettings() { CustomOutputArgs = "-vn" });
                        return true;
                    }
                );
                Process process = new Process();
                process.StartInfo.FileName = "xWMAEncode.exe";
                process.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                string bitRate = ((Sound)bs[indexInBs]).BitRate;
                process.StartInfo.Arguments = @"-b " + bitRate + @" """ + pathOutput + "." + format + @""" """ + pathOutput + @".xwm""";

                Task continuation = task.ContinueWith(
                    async antecedant => {
                        await Task.Run(() => process.Start());
                        process.WaitForExit();

                        Console.WriteLine(pathOutput + "." + format);
                        pbTotal.Invoke(new Action(() => { pbTotal.Value += Convert.ToInt32(pbTotal.Maximum / bs.Count); }));
                        pbConvert.Invoke(new Action(() => { pbConvert.Value = pbConvert.Maximum; }));
                        Console.WriteLine(pbTotal.Value);
                        if (File.Exists(pathOutput + "." + format))
                        {
                            await Task.Run(() => File.Delete(pathOutput + "." + format));
                        }
                        
                        //Since it's the last item we don't nedd ffmpeg anymore so we can delete it 
                        if (indexInBs == bs.IndexOf(bs[bs.Count - 1]))
                        {
                            if (File.Exists(Application.StartupPath + @"\ffmpeg.exe"))
                            {
                                File.Delete(Application.StartupPath + @"\ffmpeg.exe");
                            }
                            dgvFiles.Invoke(new Action(() => { dgvFiles.Enabled = true; }));
                        }
                        /***
                         * Since the convertion is threaded we check at the end of a convertion if the maximum is reached.
                         * if it's not the thread ends, if it is we ask if the user want to open the output directory
                         * 
                         * */
                        if(pbTotal.Value == Convert.ToInt32(pbTotal.Maximum/bs.Count)*bs.Count)
                        {
                            if (MessageBox.Show("The mod has been created! Do you want to open the directory ?", "Mod created", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                                Process.Start("explorer.exe", tbOutputDirectory.Text + @"\" + tbDirectory.Text);
                            }
                            
                            pbConvert.Invoke(new Action(() => { pbConvert.Value = pbConvert.Minimum; }));
                            pbTotal.Invoke(new Action(() => { pbTotal.Value = pbTotal.Minimum; }));
                        }
                    }
                    );

                    await task;

                    return true;
                } catch (Exception ex)
                {
                    MessageBox.Show("There was an error during the convertion of the files. Make sure that the app has the right to modify files.\n\n Error message: " +ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return false;
                }
            }
            /***
             * Updates progress bar of file convertion (bottom one)
             * ***/
        private void updateProgress(object sender, ConvertProgressEventArgs e)
        {
            pbConvert.Invoke(new Action(() =>
            {
                pbConvert.Value = Convert.ToInt32(((double)e.Processed.Ticks / (double)e.TotalDuration.Ticks) * pbConvert.Maximum*0.9);
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
            foreach(Sound s in bs)
            {
                Console.WriteLine(s.BitRate);
            }
        }

        private void dgvFiles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvFiles.Columns[e.ColumnIndex].Name.Equals("NameToShow"))
                {
                    var query = from Sound s in bs.List
                                where s.NameToShow.ToLower() == ((Sound)bs[e.RowIndex]).NameToShow.ToLower()
                                select s.NameToShow;

                    if (query.ToList().Count > 1)
                    {
                        ((Sound)bs[e.RowIndex]).NameToShow += " - copy";
                    }
                }
            } catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void dgvFiles_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Error. The information you entered and the property don't have the same type " +
                "\nColumn : [" + dgvFiles.Columns[e.ColumnIndex].HeaderText + "] -- Value : [" + e.Context.ToString() + "].  " +
                "\nDon't write characters in number property for example", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            bs.CancelEdit();
        }
    }
}
