﻿namespace CreationDuGrosSon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.soundBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAddFiles = new System.Windows.Forms.Button();
            this.tbxInfo = new System.Windows.Forms.TextBox();
            this.btnCreateMod = new System.Windows.Forms.Button();
            this.btnChooseDirectory = new System.Windows.Forms.Button();
            this.gbButtons = new System.Windows.Forms.GroupBox();
            this.lblAntislash = new System.Windows.Forms.Label();
            this.tbDirectory = new System.Windows.Forms.TextBox();
            this.btnMusic = new System.Windows.Forms.Button();
            this.pbTotal = new System.Windows.Forms.ProgressBar();
            this.pbConvert = new System.Windows.Forms.ProgressBar();
            this.btnRemoveFIles = new System.Windows.Forms.Button();
            this.tbOutputDirectory = new System.Windows.Forms.TextBox();
            this.lblTable = new System.Windows.Forms.Label();
            this.filePathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameToShowDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxDistanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loopableDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bitRateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.waveTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundBindingSource)).BeginInit();
            this.gbButtons.SuspendLayout();
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
            this.typeDataGridViewTextBoxColumn,
            this.nameToShowDataGridViewTextBoxColumn,
            this.maxDistanceDataGridViewTextBoxColumn,
            this.volumeDataGridViewTextBoxColumn,
            this.loopableDataGridViewCheckBoxColumn,
            this.bitRateDataGridViewTextBoxColumn,
            this.waveTypeDataGridViewTextBoxColumn});
            this.dgvFiles.DataSource = this.soundBindingSource;
            this.dgvFiles.Location = new System.Drawing.Point(12, 12);
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.RowHeadersVisible = false;
            this.dgvFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFiles.Size = new System.Drawing.Size(660, 218);
            this.dgvFiles.TabIndex = 1;
            this.dgvFiles.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFiles_CellEndEdit);
            this.dgvFiles.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvFiles_DataError);
            // 
            // soundBindingSource
            // 
            this.soundBindingSource.DataSource = typeof(CreationDuGrosSon.Sound);
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddFiles.Location = new System.Drawing.Point(6, 18);
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
            this.tbxInfo.ReadOnly = true;
            this.tbxInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxInfo.Size = new System.Drawing.Size(660, 87);
            this.tbxInfo.TabIndex = 3;
            this.tbxInfo.Text = resources.GetString("tbxInfo.Text");
            // 
            // btnCreateMod
            // 
            this.btnCreateMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateMod.Location = new System.Drawing.Point(6, 76);
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
            this.btnChooseDirectory.Location = new System.Drawing.Point(6, 47);
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
            this.gbButtons.Controls.Add(this.lblAntislash);
            this.gbButtons.Controls.Add(this.tbDirectory);
            this.gbButtons.Controls.Add(this.btnMusic);
            this.gbButtons.Controls.Add(this.pbTotal);
            this.gbButtons.Controls.Add(this.pbConvert);
            this.gbButtons.Controls.Add(this.btnRemoveFIles);
            this.gbButtons.Controls.Add(this.tbOutputDirectory);
            this.gbButtons.Controls.Add(this.btnAddFiles);
            this.gbButtons.Controls.Add(this.btnCreateMod);
            this.gbButtons.Controls.Add(this.btnChooseDirectory);
            this.gbButtons.Location = new System.Drawing.Point(12, 249);
            this.gbButtons.Name = "gbButtons";
            this.gbButtons.Size = new System.Drawing.Size(660, 107);
            this.gbButtons.TabIndex = 6;
            this.gbButtons.TabStop = false;
            // 
            // lblAntislash
            // 
            this.lblAntislash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAntislash.AutoSize = true;
            this.lblAntislash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAntislash.Location = new System.Drawing.Point(505, 49);
            this.lblAntislash.Margin = new System.Windows.Forms.Padding(0);
            this.lblAntislash.Name = "lblAntislash";
            this.lblAntislash.Size = new System.Drawing.Size(12, 16);
            this.lblAntislash.TabIndex = 13;
            this.lblAntislash.Text = "\\";
            // 
            // tbDirectory
            // 
            this.tbDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDirectory.Location = new System.Drawing.Point(520, 48);
            this.tbDirectory.Name = "tbDirectory";
            this.tbDirectory.Size = new System.Drawing.Size(134, 20);
            this.tbDirectory.TabIndex = 12;
            this.tbDirectory.Text = "SoundsForSoundBlock";
            // 
            // btnMusic
            // 
            this.btnMusic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMusic.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnMusic.Location = new System.Drawing.Point(504, 18);
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
            this.pbTotal.Maximum = 1000000;
            this.pbTotal.Name = "pbTotal";
            this.pbTotal.Size = new System.Drawing.Size(492, 10);
            this.pbTotal.TabIndex = 10;
            // 
            // pbConvert
            // 
            this.pbConvert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbConvert.Location = new System.Drawing.Point(162, 92);
            this.pbConvert.Name = "pbConvert";
            this.pbConvert.Size = new System.Drawing.Size(492, 10);
            this.pbConvert.TabIndex = 9;
            // 
            // btnRemoveFIles
            // 
            this.btnRemoveFIles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveFIles.Location = new System.Drawing.Point(162, 18);
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
            this.tbOutputDirectory.Size = new System.Drawing.Size(340, 20);
            this.tbOutputDirectory.TabIndex = 6;
            // 
            // lblTable
            // 
            this.lblTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTable.AutoSize = true;
            this.lblTable.Location = new System.Drawing.Point(12, 233);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(182, 13);
            this.lblTable.TabIndex = 7;
            this.lblTable.Text = "Click on gray areas to modify element";
            // 
            // filePathDataGridViewTextBoxColumn
            // 
            this.filePathDataGridViewTextBoxColumn.DataPropertyName = "FilePath";
            this.filePathDataGridViewTextBoxColumn.FillWeight = 1F;
            this.filePathDataGridViewTextBoxColumn.HeaderText = "File path";
            this.filePathDataGridViewTextBoxColumn.Name = "filePathDataGridViewTextBoxColumn";
            this.filePathDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.FillWeight = 1F;
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameToShowDataGridViewTextBoxColumn
            // 
            this.nameToShowDataGridViewTextBoxColumn.DataPropertyName = "NameToShow";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.nameToShowDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.nameToShowDataGridViewTextBoxColumn.FillWeight = 1F;
            this.nameToShowDataGridViewTextBoxColumn.HeaderText = "Name to show";
            this.nameToShowDataGridViewTextBoxColumn.Name = "nameToShowDataGridViewTextBoxColumn";
            // 
            // maxDistanceDataGridViewTextBoxColumn
            // 
            this.maxDistanceDataGridViewTextBoxColumn.DataPropertyName = "MaxDistance";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.maxDistanceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.maxDistanceDataGridViewTextBoxColumn.FillWeight = 1F;
            this.maxDistanceDataGridViewTextBoxColumn.HeaderText = "Max distance";
            this.maxDistanceDataGridViewTextBoxColumn.Name = "maxDistanceDataGridViewTextBoxColumn";
            // 
            // volumeDataGridViewTextBoxColumn
            // 
            this.volumeDataGridViewTextBoxColumn.DataPropertyName = "Volume";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.volumeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.volumeDataGridViewTextBoxColumn.FillWeight = 1F;
            this.volumeDataGridViewTextBoxColumn.HeaderText = "Volume";
            this.volumeDataGridViewTextBoxColumn.Name = "volumeDataGridViewTextBoxColumn";
            this.volumeDataGridViewTextBoxColumn.ToolTipText = "Between 0 and 1";
            // 
            // loopableDataGridViewCheckBoxColumn
            // 
            this.loopableDataGridViewCheckBoxColumn.DataPropertyName = "Loopable";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.NullValue = false;
            this.loopableDataGridViewCheckBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.loopableDataGridViewCheckBoxColumn.FillWeight = 1F;
            this.loopableDataGridViewCheckBoxColumn.HeaderText = "Loopable";
            this.loopableDataGridViewCheckBoxColumn.Name = "loopableDataGridViewCheckBoxColumn";
            // 
            // bitRateDataGridViewTextBoxColumn
            // 
            this.bitRateDataGridViewTextBoxColumn.DataPropertyName = "BitRate";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bitRateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.bitRateDataGridViewTextBoxColumn.FillWeight = 1F;
            this.bitRateDataGridViewTextBoxColumn.HeaderText = "Bit rate";
            this.bitRateDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "20000",
            "32000",
            "44100",
            "64000",
            "96000",
            "160000",
            "192000"});
            this.bitRateDataGridViewTextBoxColumn.Name = "bitRateDataGridViewTextBoxColumn";
            this.bitRateDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.bitRateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // waveTypeDataGridViewTextBoxColumn
            // 
            this.waveTypeDataGridViewTextBoxColumn.DataPropertyName = "WaveType";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.waveTypeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.waveTypeDataGridViewTextBoxColumn.FillWeight = 1F;
            this.waveTypeDataGridViewTextBoxColumn.HeaderText = "Wave type";
            this.waveTypeDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "D2",
            "D3"});
            this.waveTypeDataGridViewTextBoxColumn.Name = "waveTypeDataGridViewTextBoxColumn";
            this.waveTypeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.waveTypeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.waveTypeDataGridViewTextBoxColumn.ToolTipText = "D2 for stereo and D3 for mono";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.dgvFiles);
            this.Controls.Add(this.lblTable);
            this.Controls.Add(this.gbButtons);
            this.Controls.Add(this.tbxInfo);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "MainForm";
            this.Text = "Sound Block Creator";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundBindingSource)).EndInit();
            this.gbButtons.ResumeLayout(false);
            this.gbButtons.PerformLayout();
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
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.Button btnRemoveFIles;
        private System.Windows.Forms.ProgressBar pbConvert;
        private System.Windows.Forms.ProgressBar pbTotal;
        private System.Windows.Forms.Button btnMusic;
        private System.Windows.Forms.TextBox tbDirectory;
        private System.Windows.Forms.Label lblAntislash;
        private System.Windows.Forms.BindingSource soundBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn filePathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameToShowDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxDistanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn loopableDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn bitRateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn waveTypeDataGridViewTextBoxColumn;
    }
}

