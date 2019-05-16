﻿namespace Sample
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbScale = new System.Windows.Forms.ComboBox();
            this.cbExactCopy = new System.Windows.Forms.CheckBox();
            this.cbPixLines = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bkSelectLanguages = new System.Windows.Forms.Button();
            this.cbBin = new System.Windows.Forms.CheckBox();
            this.bkLoadBlocks = new System.Windows.Forms.Button();
            this.bkSaveBlocks = new System.Windows.Forms.Button();
            this.bkClearBlocks = new System.Windows.Forms.Button();
            this.bkDetectBlocks = new System.Windows.Forms.Button();
            this.bkOptions = new System.Windows.Forms.Button();
            this.bkHelp = new System.Windows.Forms.Button();
            this.bkSave = new System.Windows.Forms.Button();
            this.bkFile = new System.Windows.Forms.Button();
            this.bkRecognize = new System.Windows.Forms.Button();
            this.PicBox = new System.Windows.Forms.PictureBox();
            this.tbText = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbSkew = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbLines = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbInverted = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLogin = new System.Windows.Forms.ToolStripStatusLabel();
            this.opImg = new System.Windows.Forms.OpenFileDialog();
            this.edPage = new System.Windows.Forms.TextBox();
            this.lbPages = new System.Windows.Forms.Label();
            this.pmBlock = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nnTypeOCRText = new System.Windows.Forms.ToolStripMenuItem();
            this.nnTypeOCRDigit = new System.Windows.Forms.ToolStripMenuItem();
            this.nnTypeICRDigit = new System.Windows.Forms.ToolStripMenuItem();
            this.nnTypeBarCode = new System.Windows.Forms.ToolStripMenuItem();
            this.nnTypeTable = new System.Windows.Forms.ToolStripMenuItem();
            this.nnTypePicture = new System.Windows.Forms.ToolStripMenuItem();
            this.nnTypeClear = new System.Windows.Forms.ToolStripMenuItem();
            this.nnTypeZoning = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.nnInvert = new System.Windows.Forms.ToolStripMenuItem();
            this.nnRotate90 = new System.Windows.Forms.ToolStripMenuItem();
            this.nnRotate270 = new System.Windows.Forms.ToolStripMenuItem();
            this.nnRotate180 = new System.Windows.Forms.ToolStripMenuItem();
            this.nnMirrorH = new System.Windows.Forms.ToolStripMenuItem();
            this.nnMirrorV = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.nnSetRegExp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.nnDeleteBlock = new System.Windows.Forms.ToolStripMenuItem();
            this.opBlocks = new System.Windows.Forms.OpenFileDialog();
            this.svBlocks = new System.Windows.Forms.SaveFileDialog();
            this.svFile = new System.Windows.Forms.SaveFileDialog();
            this.bkScan = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbScanners = new System.Windows.Forms.ComboBox();
            this.lbWait = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btEnviarGedoc = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bkSetPage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.pmBlock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 68);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.PicBox);
            this.splitContainer1.Panel1.Resize += new System.EventHandler(this.OnPanelResize);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbText);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(697, 640);
            this.splitContainer1.SplitterDistance = 505;
            this.splitContainer1.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbScale);
            this.panel1.Controls.Add(this.cbExactCopy);
            this.panel1.Controls.Add(this.cbPixLines);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.cbBin);
            this.panel1.Controls.Add(this.bkLoadBlocks);
            this.panel1.Controls.Add(this.bkSaveBlocks);
            this.panel1.Controls.Add(this.bkClearBlocks);
            this.panel1.Controls.Add(this.bkDetectBlocks);
            this.panel1.Controls.Add(this.bkOptions);
            this.panel1.Controls.Add(this.bkHelp);
            this.panel1.Controls.Add(this.bkSave);
            this.panel1.Controls.Add(this.bkFile);
            this.panel1.Controls.Add(this.bkRecognize);
            this.panel1.Location = new System.Drawing.Point(29, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(462, 211);
            this.panel1.TabIndex = 15;
            this.panel1.Visible = false;
            // 
            // cbScale
            // 
            this.cbScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbScale.FormattingEnabled = true;
            this.cbScale.Items.AddRange(new object[] {
            "Auto",
            "0.25",
            "0.5",
            "1.0",
            "1.5",
            "2.0",
            "2.5",
            "4.0"});
            this.cbScale.Location = new System.Drawing.Point(57, 3);
            this.cbScale.Name = "cbScale";
            this.cbScale.Size = new System.Drawing.Size(117, 21);
            this.cbScale.TabIndex = 32;
            this.cbScale.Visible = false;
            // 
            // cbExactCopy
            // 
            this.cbExactCopy.AutoSize = true;
            this.cbExactCopy.Location = new System.Drawing.Point(18, 37);
            this.cbExactCopy.Name = "cbExactCopy";
            this.cbExactCopy.Size = new System.Drawing.Size(170, 17);
            this.cbExactCopy.TabIndex = 23;
            this.cbExactCopy.Text = "Exact copy (do not format text)";
            this.cbExactCopy.UseVisualStyleBackColor = true;
            this.cbExactCopy.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cbPixLines
            // 
            this.cbPixLines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbPixLines.AutoSize = true;
            this.cbPixLines.Location = new System.Drawing.Point(200, 138);
            this.cbPixLines.Name = "cbPixLines";
            this.cbPixLines.Size = new System.Drawing.Size(108, 17);
            this.cbPixLines.TabIndex = 14;
            this.cbPixLines.Text = "Show image lines";
            this.cbPixLines.UseVisualStyleBackColor = true;
            this.cbPixLines.CheckedChanged += new System.EventHandler(this.cbPixLines_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bkSelectLanguages);
            this.groupBox1.Location = new System.Drawing.Point(246, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 53);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Languages";
            // 
            // bkSelectLanguages
            // 
            this.bkSelectLanguages.Location = new System.Drawing.Point(41, 20);
            this.bkSelectLanguages.Name = "bkSelectLanguages";
            this.bkSelectLanguages.Size = new System.Drawing.Size(113, 23);
            this.bkSelectLanguages.TabIndex = 0;
            this.bkSelectLanguages.Text = "Select Languages";
            this.bkSelectLanguages.UseVisualStyleBackColor = true;
            this.bkSelectLanguages.Click += new System.EventHandler(this.bkSelectLanguages_Click);
            // 
            // cbBin
            // 
            this.cbBin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbBin.AutoSize = true;
            this.cbBin.Location = new System.Drawing.Point(200, 99);
            this.cbBin.Name = "cbBin";
            this.cbBin.Size = new System.Drawing.Size(136, 17);
            this.cbBin.TabIndex = 9;
            this.cbBin.Text = "Display binarized image";
            this.cbBin.UseVisualStyleBackColor = true;
            this.cbBin.CheckedChanged += new System.EventHandler(this.cbBin_CheckedChanged);
            // 
            // bkLoadBlocks
            // 
            this.bkLoadBlocks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bkLoadBlocks.Enabled = false;
            this.bkLoadBlocks.Location = new System.Drawing.Point(359, 167);
            this.bkLoadBlocks.Name = "bkLoadBlocks";
            this.bkLoadBlocks.Size = new System.Drawing.Size(75, 23);
            this.bkLoadBlocks.TabIndex = 10;
            this.bkLoadBlocks.Text = "Load Zones";
            this.bkLoadBlocks.UseVisualStyleBackColor = true;
            this.bkLoadBlocks.Click += new System.EventHandler(this.bkLoadBlocks_Click);
            // 
            // bkSaveBlocks
            // 
            this.bkSaveBlocks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bkSaveBlocks.Enabled = false;
            this.bkSaveBlocks.Location = new System.Drawing.Point(375, 138);
            this.bkSaveBlocks.Name = "bkSaveBlocks";
            this.bkSaveBlocks.Size = new System.Drawing.Size(75, 23);
            this.bkSaveBlocks.TabIndex = 11;
            this.bkSaveBlocks.Text = "Save Zones";
            this.bkSaveBlocks.UseVisualStyleBackColor = true;
            this.bkSaveBlocks.Click += new System.EventHandler(this.bkSaveBlocks_Click);
            // 
            // bkClearBlocks
            // 
            this.bkClearBlocks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bkClearBlocks.Enabled = false;
            this.bkClearBlocks.Location = new System.Drawing.Point(375, 109);
            this.bkClearBlocks.Name = "bkClearBlocks";
            this.bkClearBlocks.Size = new System.Drawing.Size(75, 23);
            this.bkClearBlocks.TabIndex = 12;
            this.bkClearBlocks.Text = "Clear Zones";
            this.bkClearBlocks.UseVisualStyleBackColor = true;
            this.bkClearBlocks.Click += new System.EventHandler(this.bkClearBlocks_Click);
            // 
            // bkDetectBlocks
            // 
            this.bkDetectBlocks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bkDetectBlocks.Enabled = false;
            this.bkDetectBlocks.Location = new System.Drawing.Point(366, 80);
            this.bkDetectBlocks.Name = "bkDetectBlocks";
            this.bkDetectBlocks.Size = new System.Drawing.Size(84, 23);
            this.bkDetectBlocks.TabIndex = 13;
            this.bkDetectBlocks.Text = "Detect Zones";
            this.bkDetectBlocks.UseVisualStyleBackColor = true;
            this.bkDetectBlocks.Click += new System.EventHandler(this.bkDetectBlocks_Click);
            // 
            // bkOptions
            // 
            this.bkOptions.Location = new System.Drawing.Point(110, 119);
            this.bkOptions.Name = "bkOptions";
            this.bkOptions.Size = new System.Drawing.Size(75, 23);
            this.bkOptions.TabIndex = 30;
            this.bkOptions.Text = "Options";
            this.bkOptions.UseVisualStyleBackColor = true;
            this.bkOptions.Click += new System.EventHandler(this.bkOptions_Click);
            // 
            // bkHelp
            // 
            this.bkHelp.Location = new System.Drawing.Point(110, 80);
            this.bkHelp.Name = "bkHelp";
            this.bkHelp.Size = new System.Drawing.Size(75, 23);
            this.bkHelp.TabIndex = 31;
            this.bkHelp.Text = "Help";
            this.bkHelp.UseVisualStyleBackColor = true;
            this.bkHelp.Click += new System.EventHandler(this.bkHelp_Click);
            // 
            // bkSave
            // 
            this.bkSave.Location = new System.Drawing.Point(29, 156);
            this.bkSave.Name = "bkSave";
            this.bkSave.Size = new System.Drawing.Size(75, 23);
            this.bkSave.TabIndex = 26;
            this.bkSave.Text = "Save";
            this.bkSave.UseVisualStyleBackColor = true;
            this.bkSave.Click += new System.EventHandler(this.bkSave_Click);
            // 
            // bkFile
            // 
            this.bkFile.Location = new System.Drawing.Point(113, 156);
            this.bkFile.Name = "bkFile";
            this.bkFile.Size = new System.Drawing.Size(75, 23);
            this.bkFile.TabIndex = 9;
            this.bkFile.Text = "Open File";
            this.bkFile.UseVisualStyleBackColor = true;
            this.bkFile.Click += new System.EventHandler(this.bkFile_Click);
            // 
            // bkRecognize
            // 
            this.bkRecognize.Location = new System.Drawing.Point(29, 109);
            this.bkRecognize.Name = "bkRecognize";
            this.bkRecognize.Size = new System.Drawing.Size(75, 23);
            this.bkRecognize.TabIndex = 10;
            this.bkRecognize.Text = "Recognize";
            this.bkRecognize.UseVisualStyleBackColor = true;
            this.bkRecognize.Click += new System.EventHandler(this.bkRecognize_Click);
            // 
            // PicBox
            // 
            this.PicBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PicBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PicBox.Location = new System.Drawing.Point(4, 3);
            this.PicBox.Name = "PicBox";
            this.PicBox.Size = new System.Drawing.Size(688, 634);
            this.PicBox.TabIndex = 8;
            this.PicBox.TabStop = false;
            this.PicBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicBoxOnMouseDown);
            this.PicBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicBoxMouseMove);
            this.PicBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicBoxOnMouseUp);
            // 
            // tbText
            // 
            this.tbText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbText.Location = new System.Drawing.Point(3, 3);
            this.tbText.Multiline = true;
            this.tbText.Name = "tbText";
            this.tbText.ReadOnly = true;
            this.tbText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbText.Size = new System.Drawing.Size(539, 418);
            this.tbText.TabIndex = 1;
            this.tbText.WordWrap = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbSize,
            this.lbSkew,
            this.lbLines,
            this.lbInverted,
            this.toolStripStatusLabel1,
            this.statusLogin});
            this.statusStrip1.Location = new System.Drawing.Point(0, 711);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(697, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbSize
            // 
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(0, 17);
            // 
            // lbSkew
            // 
            this.lbSkew.Name = "lbSkew";
            this.lbSkew.Size = new System.Drawing.Size(0, 17);
            // 
            // lbLines
            // 
            this.lbLines.Name = "lbLines";
            this.lbLines.Size = new System.Drawing.Size(0, 17);
            // 
            // lbInverted
            // 
            this.lbInverted.Name = "lbInverted";
            this.lbInverted.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel1.Text = "Versão 3.0";
            // 
            // statusLogin
            // 
            this.statusLogin.Name = "statusLogin";
            this.statusLogin.Size = new System.Drawing.Size(0, 17);
            // 
            // opImg
            // 
            this.opImg.Filter = "Image Files (bmp, jpg, tif, png, gif, pdf)|*.bmp;*.jpg;*.tif;*.png;*.gif;*.pdf|Al" +
    "l Files|*";
            this.opImg.Title = "Open Image File";
            // 
            // edPage
            // 
            this.edPage.Enabled = false;
            this.edPage.Location = new System.Drawing.Point(349, 13);
            this.edPage.Name = "edPage";
            this.edPage.Size = new System.Drawing.Size(27, 20);
            this.edPage.TabIndex = 13;
            this.edPage.Text = "1";
            // 
            // lbPages
            // 
            this.lbPages.AutoSize = true;
            this.lbPages.Location = new System.Drawing.Point(383, 16);
            this.lbPages.Name = "lbPages";
            this.lbPages.Size = new System.Drawing.Size(25, 13);
            this.lbPages.TabIndex = 14;
            this.lbPages.Text = "of 1";
            // 
            // pmBlock
            // 
            this.pmBlock.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nnTypeOCRText,
            this.nnTypeOCRDigit,
            this.nnTypeICRDigit,
            this.nnTypeBarCode,
            this.nnTypeTable,
            this.nnTypePicture,
            this.nnTypeClear,
            this.nnTypeZoning,
            this.toolStripMenuItem1,
            this.nnInvert,
            this.nnRotate90,
            this.nnRotate270,
            this.nnRotate180,
            this.nnMirrorH,
            this.nnMirrorV,
            this.toolStripMenuItem2,
            this.nnSetRegExp,
            this.toolStripMenuItem3,
            this.nnDeleteBlock});
            this.pmBlock.Name = "pmBlock";
            this.pmBlock.Size = new System.Drawing.Size(267, 374);
            this.pmBlock.Opening += new System.ComponentModel.CancelEventHandler(this.pmBlock_Opening);
            // 
            // nnTypeOCRText
            // 
            this.nnTypeOCRText.Name = "nnTypeOCRText";
            this.nnTypeOCRText.Size = new System.Drawing.Size(266, 22);
            this.nnTypeOCRText.Text = "Type: Machine-printed Text";
            this.nnTypeOCRText.Click += new System.EventHandler(this.nnTypeOCRText_Click);
            // 
            // nnTypeOCRDigit
            // 
            this.nnTypeOCRDigit.Name = "nnTypeOCRDigit";
            this.nnTypeOCRDigit.Size = new System.Drawing.Size(266, 22);
            this.nnTypeOCRDigit.Text = "Type: Machine-printed Digits";
            this.nnTypeOCRDigit.Click += new System.EventHandler(this.nnTypeOCRDigit_Click);
            // 
            // nnTypeICRDigit
            // 
            this.nnTypeICRDigit.Name = "nnTypeICRDigit";
            this.nnTypeICRDigit.Size = new System.Drawing.Size(266, 22);
            this.nnTypeICRDigit.Text = "Type: Handwritten Digits";
            this.nnTypeICRDigit.Click += new System.EventHandler(this.nnTypeICRDigit_Click);
            // 
            // nnTypeBarCode
            // 
            this.nnTypeBarCode.Name = "nnTypeBarCode";
            this.nnTypeBarCode.Size = new System.Drawing.Size(266, 22);
            this.nnTypeBarCode.Text = "Type: Bar Code";
            this.nnTypeBarCode.Click += new System.EventHandler(this.nnTypeBarCode_Click);
            // 
            // nnTypeTable
            // 
            this.nnTypeTable.Name = "nnTypeTable";
            this.nnTypeTable.Size = new System.Drawing.Size(266, 22);
            this.nnTypeTable.Text = "Type: Table";
            this.nnTypeTable.Click += new System.EventHandler(this.nnTypeTable_Click);
            // 
            // nnTypePicture
            // 
            this.nnTypePicture.Name = "nnTypePicture";
            this.nnTypePicture.Size = new System.Drawing.Size(266, 22);
            this.nnTypePicture.Text = "Type: Picture";
            this.nnTypePicture.Click += new System.EventHandler(this.nnTypePicture_Click);
            // 
            // nnTypeClear
            // 
            this.nnTypeClear.Name = "nnTypeClear";
            this.nnTypeClear.Size = new System.Drawing.Size(266, 22);
            this.nnTypeClear.Text = "Type: Clear Area";
            this.nnTypeClear.Click += new System.EventHandler(this.nnTypeClear_Click);
            // 
            // nnTypeZoning
            // 
            this.nnTypeZoning.Name = "nnTypeZoning";
            this.nnTypeZoning.Size = new System.Drawing.Size(266, 22);
            this.nnTypeZoning.Text = "Type: Zoning area";
            this.nnTypeZoning.Click += new System.EventHandler(this.nnTypeZoning_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(263, 6);
            // 
            // nnInvert
            // 
            this.nnInvert.Name = "nnInvert";
            this.nnInvert.Size = new System.Drawing.Size(266, 22);
            this.nnInvert.Text = "Image Inverted";
            this.nnInvert.Click += new System.EventHandler(this.nnInvert_Click);
            // 
            // nnRotate90
            // 
            this.nnRotate90.Name = "nnRotate90";
            this.nnRotate90.Size = new System.Drawing.Size(266, 22);
            this.nnRotate90.Text = "Image Rotateed 90° clockwise";
            this.nnRotate90.Click += new System.EventHandler(this.nnRotate90_Click);
            // 
            // nnRotate270
            // 
            this.nnRotate270.Name = "nnRotate270";
            this.nnRotate270.Size = new System.Drawing.Size(266, 22);
            this.nnRotate270.Text = "Image Rotated 90° counterclockwise";
            this.nnRotate270.Click += new System.EventHandler(this.nnRotate270_Click);
            // 
            // nnRotate180
            // 
            this.nnRotate180.Name = "nnRotate180";
            this.nnRotate180.Size = new System.Drawing.Size(266, 22);
            this.nnRotate180.Text = "Image Rotated 180°";
            this.nnRotate180.Click += new System.EventHandler(this.nnRotate180_Click);
            // 
            // nnMirrorH
            // 
            this.nnMirrorH.Name = "nnMirrorH";
            this.nnMirrorH.Size = new System.Drawing.Size(266, 22);
            this.nnMirrorH.Text = "Image Mirrored Horizontally";
            this.nnMirrorH.Click += new System.EventHandler(this.nnMirrorH_Click);
            // 
            // nnMirrorV
            // 
            this.nnMirrorV.Name = "nnMirrorV";
            this.nnMirrorV.Size = new System.Drawing.Size(266, 22);
            this.nnMirrorV.Text = "Image Mirrored Vertically";
            this.nnMirrorV.Click += new System.EventHandler(this.nnMirrorV_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(263, 6);
            // 
            // nnSetRegExp
            // 
            this.nnSetRegExp.Name = "nnSetRegExp";
            this.nnSetRegExp.Size = new System.Drawing.Size(266, 22);
            this.nnSetRegExp.Text = "Set Regular Expression";
            this.nnSetRegExp.Click += new System.EventHandler(this.nnSetRegExp_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(263, 6);
            // 
            // nnDeleteBlock
            // 
            this.nnDeleteBlock.Name = "nnDeleteBlock";
            this.nnDeleteBlock.Size = new System.Drawing.Size(266, 22);
            this.nnDeleteBlock.Text = "Delete Block(Zone)";
            this.nnDeleteBlock.Click += new System.EventHandler(this.nnDeleteBlock_Click);
            // 
            // opBlocks
            // 
            this.opBlocks.DefaultExt = "blk";
            this.opBlocks.Filter = "blk files|*.blk";
            // 
            // svBlocks
            // 
            this.svBlocks.DefaultExt = "blk";
            this.svBlocks.Filter = "blk files|*.blk";
            // 
            // svFile
            // 
            this.svFile.DefaultExt = "pdf";
            this.svFile.Filter = "PDF document(*.pdf)|*.pdf|RTF document (*.rtf)|*.rtf|ASCII Text document (*.txt)|" +
    "*.txt|Unicode Text document (*.txt)|*.txt";
            // 
            // bkScan
            // 
            this.bkScan.Location = new System.Drawing.Point(10, 9);
            this.bkScan.Name = "bkScan";
            this.bkScan.Size = new System.Drawing.Size(75, 23);
            this.bkScan.TabIndex = 27;
            this.bkScan.Text = "Scan";
            this.bkScan.UseVisualStyleBackColor = true;
            this.bkScan.Click += new System.EventHandler(this.bkScan_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Sample.Properties.Resources.login_logo;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(507, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(121, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Scaner";
            // 
            // cbScanners
            // 
            this.cbScanners.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbScanners.FormattingEnabled = true;
            this.cbScanners.Location = new System.Drawing.Point(164, 41);
            this.cbScanners.Name = "cbScanners";
            this.cbScanners.Size = new System.Drawing.Size(273, 21);
            this.cbScanners.TabIndex = 39;
            // 
            // lbWait
            // 
            this.lbWait.AutoSize = true;
            this.lbWait.Location = new System.Drawing.Point(7, 33);
            this.lbWait.Name = "lbWait";
            this.lbWait.Size = new System.Drawing.Size(219, 13);
            this.lbWait.TabIndex = 41;
            this.lbWait.Text = "Enviando para o GEDOC - Favor aguardar....";
            this.lbWait.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 49);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(95, 17);
            this.checkBox1.TabIndex = 42;
            this.checkBox1.Text = "Frente e Verso";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // btEnviarGedoc
            // 
            this.btEnviarGedoc.Location = new System.Drawing.Point(129, 9);
            this.btEnviarGedoc.Name = "btEnviarGedoc";
            this.btEnviarGedoc.Size = new System.Drawing.Size(144, 23);
            this.btEnviarGedoc.TabIndex = 43;
            this.btEnviarGedoc.Text = "Enviar para GEDOC";
            this.btEnviarGedoc.UseVisualStyleBackColor = true;
            this.btEnviarGedoc.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(305, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 20);
            this.button2.TabIndex = 45;
            this.button2.Text = "<";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // bkSetPage
            // 
            this.bkSetPage.Location = new System.Drawing.Point(411, 12);
            this.bkSetPage.Name = "bkSetPage";
            this.bkSetPage.Size = new System.Drawing.Size(40, 20);
            this.bkSetPage.TabIndex = 44;
            this.bkSetPage.Text = ">";
            this.bkSetPage.UseVisualStyleBackColor = true;
            this.bkSetPage.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(473, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "V.2.0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 733);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bkSetPage);
            this.Controls.Add(this.btEnviarGedoc);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.lbWait);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbScanners);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bkScan);
            this.Controls.Add(this.lbPages);
            this.Controls.Add(this.edPage);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GEDOC - SCAN";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.Resize += new System.EventHandler(this.OnPanelResize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pmBlock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox PicBox;
        private System.Windows.Forms.TextBox tbText;
        private System.Windows.Forms.Button bkFile;
        private System.Windows.Forms.Button bkRecognize;
        private System.Windows.Forms.OpenFileDialog opImg;
        private System.Windows.Forms.TextBox edPage;
        private System.Windows.Forms.Label lbPages;
        private System.Windows.Forms.CheckBox cbExactCopy;
        private System.Windows.Forms.ContextMenuStrip pmBlock;
        private System.Windows.Forms.ToolStripMenuItem nnTypeOCRText;
        private System.Windows.Forms.ToolStripMenuItem nnTypeICRDigit;
        private System.Windows.Forms.ToolStripMenuItem nnTypePicture;
        private System.Windows.Forms.ToolStripMenuItem nnTypeClear;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nnInvert;
        private System.Windows.Forms.ToolStripMenuItem nnRotate90;
        private System.Windows.Forms.ToolStripMenuItem nnRotate180;
        private System.Windows.Forms.ToolStripMenuItem nnRotate270;
        private System.Windows.Forms.ToolStripMenuItem nnMirrorH;
        private System.Windows.Forms.ToolStripMenuItem nnMirrorV;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem nnDeleteBlock;
        private System.Windows.Forms.CheckBox cbBin;
        private System.Windows.Forms.Button bkClearBlocks;
        private System.Windows.Forms.Button bkSaveBlocks;
        private System.Windows.Forms.Button bkLoadBlocks;
        private System.Windows.Forms.OpenFileDialog opBlocks;
        private System.Windows.Forms.SaveFileDialog svBlocks;
        private System.Windows.Forms.Button bkDetectBlocks;
        private System.Windows.Forms.ToolStripStatusLabel lbSkew;
        private System.Windows.Forms.ToolStripStatusLabel lbSize;
        private System.Windows.Forms.ToolStripStatusLabel lbLines;
        private System.Windows.Forms.Button bkSave;
        private System.Windows.Forms.SaveFileDialog svFile;
        private System.Windows.Forms.Button bkScan;
        private System.Windows.Forms.ToolStripMenuItem nnTypeOCRDigit;
        private System.Windows.Forms.ToolStripMenuItem nnTypeZoning;
        private System.Windows.Forms.ToolStripMenuItem nnTypeBarCode;
        private System.Windows.Forms.ToolStripMenuItem nnTypeTable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bkSelectLanguages;
        private System.Windows.Forms.CheckBox cbPixLines;
        private System.Windows.Forms.ToolStripStatusLabel lbInverted;
        private System.Windows.Forms.Button bkOptions;
        private System.Windows.Forms.Button bkHelp;
        private System.Windows.Forms.ToolStripMenuItem nnSetRegExp;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbScanners;
        private System.Windows.Forms.Label lbWait;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btEnviarGedoc;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button bkSetPage;
        private System.Windows.Forms.ComboBox cbScale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusLogin;
    }
}

