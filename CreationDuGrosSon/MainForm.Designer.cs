namespace CreationDuGrosSon
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.btnAddFiles = new System.Windows.Forms.Button();
            this.tbxInfo = new System.Windows.Forms.TextBox();
            this.btnCreateMod = new System.Windows.Forms.Button();
            this.btnChooseDirectory = new System.Windows.Forms.Button();
            this.gbButtons = new System.Windows.Forms.GroupBox();
            this.btnMusic = new System.Windows.Forms.Button();
            this.pbTotal = new System.Windows.Forms.ProgressBar();
            this.pbConvert = new System.Windows.Forms.ProgressBar();
            this.btnRemoveFIles = new System.Windows.Forms.Button();
            this.tbOutputDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.filePathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameToShowDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxDistanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loopableDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.soundBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            this.gbButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soundBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFiles
            // 
            this.dgvFiles.AllowUserToAddRows = false;
            this.dgvFiles.AllowUserToResizeRows = false;
            this.dgvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFiles.AutoGenerateColumns = false;
            this.dgvFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFiles.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.filePathDataGridViewTextBoxColumn,
            this.nameToShowDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.maxDistanceDataGridViewTextBoxColumn,
            this.volumeDataGridViewTextBoxColumn,
            this.loopableDataGridViewCheckBoxColumn});
            this.dgvFiles.DataSource = this.soundBindingSource;
            this.dgvFiles.Location = new System.Drawing.Point(12, 12);
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.RowHeadersVisible = false;
            this.dgvFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFiles.Size = new System.Drawing.Size(560, 218);
            this.dgvFiles.TabIndex = 1;
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddFiles.Location = new System.Drawing.Point(6, 19);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(150, 23);
            this.btnAddFiles.TabIndex = 2;
            this.btnAddFiles.Text = "Add File(s)";
            this.btnAddFiles.UseVisualStyleBackColor = true;
            this.btnAddFiles.Click += new System.EventHandler(this.btnAddFiles_Click);
            // 
            // tbxInfo
            // 
            this.tbxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxInfo.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxInfo.Location = new System.Drawing.Point(12, 362);
            this.tbxInfo.Multiline = true;
            this.tbxInfo.Name = "tbxInfo";
            this.tbxInfo.Size = new System.Drawing.Size(560, 87);
            this.tbxInfo.TabIndex = 3;
            this.tbxInfo.Text = "Supported formats:\r\n- Audio: WAV | MP3 | FLAC | WMA | M4A | OGG\r\n- Video: MP4 | A" +
    "VI (Only the audio part will be converted)\r\n\r\nCredits:\r\n- FFmpeg (https://ffmpeg" +
    ".org/)";
            // 
            // btnCreateMod
            // 
            this.btnCreateMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateMod.Location = new System.Drawing.Point(6, 77);
            this.btnCreateMod.Name = "btnCreateMod";
            this.btnCreateMod.Size = new System.Drawing.Size(150, 23);
            this.btnCreateMod.TabIndex = 4;
            this.btnCreateMod.Text = "Create mod";
            this.btnCreateMod.UseVisualStyleBackColor = true;
            this.btnCreateMod.Click += new System.EventHandler(this.btnCreateMod_Click);
            // 
            // btnChooseDirectory
            // 
            this.btnChooseDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChooseDirectory.Location = new System.Drawing.Point(6, 48);
            this.btnChooseDirectory.Name = "btnChooseDirectory";
            this.btnChooseDirectory.Size = new System.Drawing.Size(150, 23);
            this.btnChooseDirectory.TabIndex = 5;
            this.btnChooseDirectory.Text = "Output directory";
            this.btnChooseDirectory.UseVisualStyleBackColor = true;
            this.btnChooseDirectory.Click += new System.EventHandler(this.btnChooseDirectory_Click);
            // 
            // gbButtons
            // 
            this.gbButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbButtons.Controls.Add(this.btnMusic);
            this.gbButtons.Controls.Add(this.pbTotal);
            this.gbButtons.Controls.Add(this.pbConvert);
            this.gbButtons.Controls.Add(this.btnRemoveFIles);
            this.gbButtons.Controls.Add(this.tbOutputDirectory);
            this.gbButtons.Controls.Add(this.btnAddFiles);
            this.gbButtons.Controls.Add(this.btnCreateMod);
            this.gbButtons.Controls.Add(this.btnChooseDirectory);
            this.gbButtons.Location = new System.Drawing.Point(12, 248);
            this.gbButtons.Name = "gbButtons";
            this.gbButtons.Size = new System.Drawing.Size(560, 108);
            this.gbButtons.TabIndex = 6;
            this.gbButtons.TabStop = false;
            // 
            // btnMusic
            // 
            this.btnMusic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMusic.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnMusic.Location = new System.Drawing.Point(404, 19);
            this.btnMusic.Name = "btnMusic";
            this.btnMusic.Size = new System.Drawing.Size(150, 23);
            this.btnMusic.TabIndex = 11;
            this.btnMusic.Text = "Stop/Restart music";
            this.btnMusic.UseVisualStyleBackColor = false;
            this.btnMusic.Click += new System.EventHandler(this.btnMusic_Click);
            // 
            // pbTotal
            // 
            this.pbTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbTotal.Location = new System.Drawing.Point(162, 77);
            this.pbTotal.Name = "pbTotal";
            this.pbTotal.Size = new System.Drawing.Size(392, 10);
            this.pbTotal.TabIndex = 10;
            // 
            // pbConvert
            // 
            this.pbConvert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbConvert.Location = new System.Drawing.Point(162, 92);
            this.pbConvert.Name = "pbConvert";
            this.pbConvert.Size = new System.Drawing.Size(392, 10);
            this.pbConvert.TabIndex = 9;
            // 
            // btnRemoveFIles
            // 
            this.btnRemoveFIles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveFIles.Location = new System.Drawing.Point(162, 19);
            this.btnRemoveFIles.Name = "btnRemoveFIles";
            this.btnRemoveFIles.Size = new System.Drawing.Size(150, 23);
            this.btnRemoveFIles.TabIndex = 7;
            this.btnRemoveFIles.Text = "Remove File(s)";
            this.btnRemoveFIles.UseVisualStyleBackColor = true;
            this.btnRemoveFIles.Click += new System.EventHandler(this.btnRemoveFIles_Click);
            // 
            // tbOutputDirectory
            // 
            this.tbOutputDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOutputDirectory.Enabled = false;
            this.tbOutputDirectory.Location = new System.Drawing.Point(162, 48);
            this.tbOutputDirectory.Name = "tbOutputDirectory";
            this.tbOutputDirectory.Size = new System.Drawing.Size(392, 20);
            this.tbOutputDirectory.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Click on gray areas to modify element";
            // 
            // filePathDataGridViewTextBoxColumn
            // 
            this.filePathDataGridViewTextBoxColumn.DataPropertyName = "FilePath";
            this.filePathDataGridViewTextBoxColumn.FillWeight = 20F;
            this.filePathDataGridViewTextBoxColumn.HeaderText = "File Path";
            this.filePathDataGridViewTextBoxColumn.Name = "filePathDataGridViewTextBoxColumn";
            this.filePathDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameToShowDataGridViewTextBoxColumn
            // 
            this.nameToShowDataGridViewTextBoxColumn.DataPropertyName = "NameToShow";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.nameToShowDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.nameToShowDataGridViewTextBoxColumn.FillWeight = 20F;
            this.nameToShowDataGridViewTextBoxColumn.HeaderText = "Name to show";
            this.nameToShowDataGridViewTextBoxColumn.Name = "nameToShowDataGridViewTextBoxColumn";
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.FillWeight = 10F;
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // maxDistanceDataGridViewTextBoxColumn
            // 
            this.maxDistanceDataGridViewTextBoxColumn.DataPropertyName = "MaxDistance";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.maxDistanceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.maxDistanceDataGridViewTextBoxColumn.FillWeight = 15F;
            this.maxDistanceDataGridViewTextBoxColumn.HeaderText = "Max distance";
            this.maxDistanceDataGridViewTextBoxColumn.Name = "maxDistanceDataGridViewTextBoxColumn";
            // 
            // volumeDataGridViewTextBoxColumn
            // 
            this.volumeDataGridViewTextBoxColumn.DataPropertyName = "Volume";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.volumeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.volumeDataGridViewTextBoxColumn.FillWeight = 10F;
            this.volumeDataGridViewTextBoxColumn.HeaderText = "Volume";
            this.volumeDataGridViewTextBoxColumn.Name = "volumeDataGridViewTextBoxColumn";
            // 
            // loopableDataGridViewCheckBoxColumn
            // 
            this.loopableDataGridViewCheckBoxColumn.DataPropertyName = "Loopable";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.NullValue = false;
            this.loopableDataGridViewCheckBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.loopableDataGridViewCheckBoxColumn.FillWeight = 10F;
            this.loopableDataGridViewCheckBoxColumn.HeaderText = "Loopable";
            this.loopableDataGridViewCheckBoxColumn.Name = "loopableDataGridViewCheckBoxColumn";
            // 
            // soundBindingSource
            // 
            this.soundBindingSource.DataSource = typeof(CreationDuGrosSon.Sound);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbButtons);
            this.Controls.Add(this.tbxInfo);
            this.Controls.Add(this.dgvFiles);
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "MainForm";
            this.Text = "Sound Block Creator";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            this.gbButtons.ResumeLayout(false);
            this.gbButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soundBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvFiles;
        private System.Windows.Forms.Button btnAddFiles;
        private System.Windows.Forms.TextBox tbxInfo;
        private System.Windows.Forms.Button btnCreateMod;
        private System.Windows.Forms.Button btnChooseDirectory;
        private System.Windows.Forms.GroupBox gbButtons;
        private System.Windows.Forms.TextBox tbOutputDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRemoveFIles;
        private System.Windows.Forms.ProgressBar pbConvert;
        private System.Windows.Forms.ProgressBar pbTotal;
        private System.Windows.Forms.BindingSource soundBindingSource;
        private System.Windows.Forms.Button btnMusic;
        private System.Windows.Forms.DataGridViewTextBoxColumn filePathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameToShowDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxDistanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn loopableDataGridViewCheckBoxColumn;
    }
}

