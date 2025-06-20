namespace FYP_Tool
{
    partial class AudioSteganographyForm
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
            tabControl1 = new TabControl();
            audioEmbedData_tab = new TabPage();
            audioClassify_button = new Button();
            calcAudQualityMetrics_button = new Button();
            embedData_rtb = new RichTextBox();
            calcAvailableBits_button = new Button();
            stopStegoAud_button = new Button();
            playStegoAud_button = new Button();
            saveStegoAud_button = new Button();
            showEmbedData_button = new Button();
            embedData_label = new Label();
            displayStegoAud_tb = new TextBox();
            stegoAud_label = new Label();
            coverAud_label = new Label();
            embedData_button = new Button();
            stopCoverAud_button = new Button();
            playCoverAud_button = new Button();
            displayCoverAud_tb = new TextBox();
            chooseCoverAud_button = new Button();
            audioExtractData_tab = new TabPage();
            showFulldecryptedData_rtb_extrctTab_button = new Button();
            showFulldecompressedData_rtb_extrctTab_button = new Button();
            showFullextractedData_rtb_extrctTab_button = new Button();
            showFulldisplayStegoAud_tb_extrctTab_button = new Button();
            decryptedData_rtb_extrctTab = new RichTextBox();
            decompressedData_rtb_extrctTab = new RichTextBox();
            extractedData_rtb_extrctTab = new RichTextBox();
            decryptedData_label_extrctTab = new Label();
            decryptData_button_extrctTab = new Button();
            decompressedData_label_extrctTab = new Label();
            extractedData_label_extrctTab = new Label();
            decompressData_button_extrctTab = new Button();
            extractEmbeddedData_btn = new Button();
            stopStegoAud_button_extractTab = new Button();
            playStegoAud_button_extrctTab = new Button();
            chooseStegoAud_button = new Button();
            stegoAud_label_extrctTab = new Label();
            displayStegoAud_tb_extrctTab = new TextBox();
            openFileDialog_coverAud = new OpenFileDialog();
            saveFileDialog_resultStegoAud = new SaveFileDialog();
            openFileDialog_stegoAud = new OpenFileDialog();
            tabControl1.SuspendLayout();
            audioEmbedData_tab.SuspendLayout();
            audioExtractData_tab.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(audioEmbedData_tab);
            tabControl1.Controls.Add(audioExtractData_tab);
            tabControl1.Location = new Point(-4, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(808, 454);
            tabControl1.TabIndex = 0;
            // 
            // audioEmbedData_tab
            // 
            audioEmbedData_tab.Controls.Add(audioClassify_button);
            audioEmbedData_tab.Controls.Add(calcAudQualityMetrics_button);
            audioEmbedData_tab.Controls.Add(embedData_rtb);
            audioEmbedData_tab.Controls.Add(calcAvailableBits_button);
            audioEmbedData_tab.Controls.Add(stopStegoAud_button);
            audioEmbedData_tab.Controls.Add(playStegoAud_button);
            audioEmbedData_tab.Controls.Add(saveStegoAud_button);
            audioEmbedData_tab.Controls.Add(showEmbedData_button);
            audioEmbedData_tab.Controls.Add(embedData_label);
            audioEmbedData_tab.Controls.Add(displayStegoAud_tb);
            audioEmbedData_tab.Controls.Add(stegoAud_label);
            audioEmbedData_tab.Controls.Add(coverAud_label);
            audioEmbedData_tab.Controls.Add(embedData_button);
            audioEmbedData_tab.Controls.Add(stopCoverAud_button);
            audioEmbedData_tab.Controls.Add(playCoverAud_button);
            audioEmbedData_tab.Controls.Add(displayCoverAud_tb);
            audioEmbedData_tab.Controls.Add(chooseCoverAud_button);
            audioEmbedData_tab.Location = new Point(4, 29);
            audioEmbedData_tab.Name = "audioEmbedData_tab";
            audioEmbedData_tab.Padding = new Padding(3);
            audioEmbedData_tab.Size = new Size(800, 421);
            audioEmbedData_tab.TabIndex = 0;
            audioEmbedData_tab.Text = "Embed data";
            audioEmbedData_tab.UseVisualStyleBackColor = true;
            // 
            // audioClassify_button
            // 
            audioClassify_button.Location = new Point(600, 375);
            audioClassify_button.Name = "audioClassify_button";
            audioClassify_button.Size = new Size(188, 29);
            audioClassify_button.TabIndex = 20;
            audioClassify_button.Text = "classify ";
            audioClassify_button.UseVisualStyleBackColor = true;
            audioClassify_button.Click += audioClassify_button_Click;
            // 
            // calcAudQualityMetrics_button
            // 
            calcAudQualityMetrics_button.Location = new Point(600, 330);
            calcAudQualityMetrics_button.Name = "calcAudQualityMetrics_button";
            calcAudQualityMetrics_button.Size = new Size(188, 29);
            calcAudQualityMetrics_button.TabIndex = 19;
            calcAudQualityMetrics_button.Text = "Calculate quality metrics";
            calcAudQualityMetrics_button.UseVisualStyleBackColor = true;
            calcAudQualityMetrics_button.Click += calcAudQualityMetrics_button_Click;
            // 
            // embedData_rtb
            // 
            embedData_rtb.Location = new Point(143, 181);
            embedData_rtb.Name = "embedData_rtb";
            embedData_rtb.Size = new Size(374, 44);
            embedData_rtb.TabIndex = 18;
            embedData_rtb.Text = "";
            // 
            // calcAvailableBits_button
            // 
            calcAvailableBits_button.Location = new Point(523, 78);
            calcAvailableBits_button.Name = "calcAvailableBits_button";
            calcAvailableBits_button.Size = new Size(165, 29);
            calcAvailableBits_button.TabIndex = 17;
            calcAvailableBits_button.Text = "Embedding capacity";
            calcAvailableBits_button.UseVisualStyleBackColor = true;
            calcAvailableBits_button.Click += calcAvailableBits_button_Click;
            // 
            // stopStegoAud_button
            // 
            stopStegoAud_button.Location = new Point(113, 330);
            stopStegoAud_button.Name = "stopStegoAud_button";
            stopStegoAud_button.Size = new Size(71, 29);
            stopStegoAud_button.TabIndex = 16;
            stopStegoAud_button.Text = "stop";
            stopStegoAud_button.UseVisualStyleBackColor = true;
            stopStegoAud_button.Click += stopStegoAud_button_Click;
            // 
            // playStegoAud_button
            // 
            playStegoAud_button.Location = new Point(12, 330);
            playStegoAud_button.Name = "playStegoAud_button";
            playStegoAud_button.Size = new Size(71, 29);
            playStegoAud_button.TabIndex = 15;
            playStegoAud_button.Text = "play";
            playStegoAud_button.UseVisualStyleBackColor = true;
            playStegoAud_button.Click += playStegoAud_button_Click;
            // 
            // saveStegoAud_button
            // 
            saveStegoAud_button.Location = new Point(215, 330);
            saveStegoAud_button.Name = "saveStegoAud_button";
            saveStegoAud_button.RightToLeft = RightToLeft.No;
            saveStegoAud_button.Size = new Size(120, 29);
            saveStegoAud_button.TabIndex = 12;
            saveStegoAud_button.Text = "Save stego aud";
            saveStegoAud_button.UseVisualStyleBackColor = true;
            saveStegoAud_button.Click += saveStegoAud_button_Click;
            // 
            // showEmbedData_button
            // 
            showEmbedData_button.Location = new Point(523, 188);
            showEmbedData_button.Name = "showEmbedData_button";
            showEmbedData_button.Size = new Size(38, 29);
            showEmbedData_button.TabIndex = 11;
            showEmbedData_button.Text = "▼\r\n";
            showEmbedData_button.UseVisualStyleBackColor = true;
            showEmbedData_button.Click += showEmbedData_button_Click;
            // 
            // embedData_label
            // 
            embedData_label.AutoSize = true;
            embedData_label.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            embedData_label.Location = new Point(12, 190);
            embedData_label.Name = "embedData_label";
            embedData_label.Size = new Size(134, 23);
            embedData_label.TabIndex = 9;
            embedData_label.Text = "Data to embed: ";
            // 
            // displayStegoAud_tb
            // 
            displayStegoAud_tb.BackColor = SystemColors.Info;
            displayStegoAud_tb.ForeColor = SystemColors.WindowText;
            displayStegoAud_tb.Location = new Point(143, 285);
            displayStegoAud_tb.Name = "displayStegoAud_tb";
            displayStegoAud_tb.Size = new Size(374, 27);
            displayStegoAud_tb.TabIndex = 8;
            // 
            // stegoAud_label
            // 
            stegoAud_label.AutoSize = true;
            stegoAud_label.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            stegoAud_label.Location = new Point(12, 285);
            stegoAud_label.Name = "stegoAud_label";
            stegoAud_label.Size = new Size(125, 28);
            stegoAud_label.TabIndex = 7;
            stegoAud_label.Text = "Stego audio";
            // 
            // coverAud_label
            // 
            coverAud_label.AutoSize = true;
            coverAud_label.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            coverAud_label.Location = new Point(12, 75);
            coverAud_label.Name = "coverAud_label";
            coverAud_label.Size = new Size(125, 28);
            coverAud_label.TabIndex = 6;
            coverAud_label.Text = "Cover audio";
            // 
            // embedData_button
            // 
            embedData_button.Location = new Point(12, 233);
            embedData_button.Name = "embedData_button";
            embedData_button.RightToLeft = RightToLeft.No;
            embedData_button.Size = new Size(120, 29);
            embedData_button.TabIndex = 5;
            embedData_button.Text = "Embed data";
            embedData_button.UseVisualStyleBackColor = true;
            embedData_button.Click += embedData_button_Click;
            // 
            // stopCoverAud_button
            // 
            stopCoverAud_button.Location = new Point(113, 128);
            stopCoverAud_button.Name = "stopCoverAud_button";
            stopCoverAud_button.Size = new Size(71, 29);
            stopCoverAud_button.TabIndex = 3;
            stopCoverAud_button.Text = "stop";
            stopCoverAud_button.UseVisualStyleBackColor = true;
            stopCoverAud_button.Click += stopCoverAud_button_Click;
            // 
            // playCoverAud_button
            // 
            playCoverAud_button.Location = new Point(12, 128);
            playCoverAud_button.Name = "playCoverAud_button";
            playCoverAud_button.Size = new Size(71, 29);
            playCoverAud_button.TabIndex = 2;
            playCoverAud_button.Text = "play";
            playCoverAud_button.UseVisualStyleBackColor = true;
            playCoverAud_button.Click += playCoverAud_button_Click;
            // 
            // displayCoverAud_tb
            // 
            displayCoverAud_tb.BackColor = SystemColors.Info;
            displayCoverAud_tb.ForeColor = SystemColors.WindowText;
            displayCoverAud_tb.Location = new Point(143, 79);
            displayCoverAud_tb.Name = "displayCoverAud_tb";
            displayCoverAud_tb.Size = new Size(374, 27);
            displayCoverAud_tb.TabIndex = 1;
            // 
            // chooseCoverAud_button
            // 
            chooseCoverAud_button.Location = new Point(12, 28);
            chooseCoverAud_button.Name = "chooseCoverAud_button";
            chooseCoverAud_button.Size = new Size(172, 29);
            chooseCoverAud_button.TabIndex = 0;
            chooseCoverAud_button.Text = "Choose a cover audio";
            chooseCoverAud_button.UseVisualStyleBackColor = true;
            chooseCoverAud_button.Click += chooseCoverAud_button_Click;
            // 
            // audioExtractData_tab
            // 
            audioExtractData_tab.Controls.Add(showFulldecryptedData_rtb_extrctTab_button);
            audioExtractData_tab.Controls.Add(showFulldecompressedData_rtb_extrctTab_button);
            audioExtractData_tab.Controls.Add(showFullextractedData_rtb_extrctTab_button);
            audioExtractData_tab.Controls.Add(showFulldisplayStegoAud_tb_extrctTab_button);
            audioExtractData_tab.Controls.Add(decryptedData_rtb_extrctTab);
            audioExtractData_tab.Controls.Add(decompressedData_rtb_extrctTab);
            audioExtractData_tab.Controls.Add(extractedData_rtb_extrctTab);
            audioExtractData_tab.Controls.Add(decryptedData_label_extrctTab);
            audioExtractData_tab.Controls.Add(decryptData_button_extrctTab);
            audioExtractData_tab.Controls.Add(decompressedData_label_extrctTab);
            audioExtractData_tab.Controls.Add(extractedData_label_extrctTab);
            audioExtractData_tab.Controls.Add(decompressData_button_extrctTab);
            audioExtractData_tab.Controls.Add(extractEmbeddedData_btn);
            audioExtractData_tab.Controls.Add(stopStegoAud_button_extractTab);
            audioExtractData_tab.Controls.Add(playStegoAud_button_extrctTab);
            audioExtractData_tab.Controls.Add(chooseStegoAud_button);
            audioExtractData_tab.Controls.Add(stegoAud_label_extrctTab);
            audioExtractData_tab.Controls.Add(displayStegoAud_tb_extrctTab);
            audioExtractData_tab.Location = new Point(4, 29);
            audioExtractData_tab.Name = "audioExtractData_tab";
            audioExtractData_tab.Padding = new Padding(3);
            audioExtractData_tab.Size = new Size(800, 421);
            audioExtractData_tab.TabIndex = 1;
            audioExtractData_tab.Text = "Extract data";
            audioExtractData_tab.UseVisualStyleBackColor = true;
            // 
            // showFulldecryptedData_rtb_extrctTab_button
            // 
            showFulldecryptedData_rtb_extrctTab_button.Location = new Point(404, 380);
            showFulldecryptedData_rtb_extrctTab_button.Name = "showFulldecryptedData_rtb_extrctTab_button";
            showFulldecryptedData_rtb_extrctTab_button.Size = new Size(38, 29);
            showFulldecryptedData_rtb_extrctTab_button.TabIndex = 35;
            showFulldecryptedData_rtb_extrctTab_button.Text = "▼\r\n";
            showFulldecryptedData_rtb_extrctTab_button.UseVisualStyleBackColor = true;
            showFulldecryptedData_rtb_extrctTab_button.Click += showFulldecryptedData_rtb_extrctTab_button_Click;
            // 
            // showFulldecompressedData_rtb_extrctTab_button
            // 
            showFulldecompressedData_rtb_extrctTab_button.Location = new Point(404, 291);
            showFulldecompressedData_rtb_extrctTab_button.Name = "showFulldecompressedData_rtb_extrctTab_button";
            showFulldecompressedData_rtb_extrctTab_button.Size = new Size(38, 29);
            showFulldecompressedData_rtb_extrctTab_button.TabIndex = 34;
            showFulldecompressedData_rtb_extrctTab_button.Text = "▼\r\n";
            showFulldecompressedData_rtb_extrctTab_button.UseVisualStyleBackColor = true;
            showFulldecompressedData_rtb_extrctTab_button.Click += showFulldecompressedData_rtb_extrctTab_button_Click;
            // 
            // showFullextractedData_rtb_extrctTab_button
            // 
            showFullextractedData_rtb_extrctTab_button.Location = new Point(404, 212);
            showFullextractedData_rtb_extrctTab_button.Name = "showFullextractedData_rtb_extrctTab_button";
            showFullextractedData_rtb_extrctTab_button.Size = new Size(38, 29);
            showFullextractedData_rtb_extrctTab_button.TabIndex = 33;
            showFullextractedData_rtb_extrctTab_button.Text = "▼\r\n";
            showFullextractedData_rtb_extrctTab_button.UseVisualStyleBackColor = true;
            showFullextractedData_rtb_extrctTab_button.Click += showFullextractedData_rtb_extrctTab_button_Click;
            // 
            // showFulldisplayStegoAud_tb_extrctTab_button
            // 
            showFulldisplayStegoAud_tb_extrctTab_button.Location = new Point(404, 85);
            showFulldisplayStegoAud_tb_extrctTab_button.Name = "showFulldisplayStegoAud_tb_extrctTab_button";
            showFulldisplayStegoAud_tb_extrctTab_button.Size = new Size(38, 29);
            showFulldisplayStegoAud_tb_extrctTab_button.TabIndex = 32;
            showFulldisplayStegoAud_tb_extrctTab_button.Text = "▼\r\n";
            showFulldisplayStegoAud_tb_extrctTab_button.UseVisualStyleBackColor = true;
            showFulldisplayStegoAud_tb_extrctTab_button.Click += showFulldisplayStegoAud_tb_extrctTab_button_Click;
            // 
            // decryptedData_rtb_extrctTab
            // 
            decryptedData_rtb_extrctTab.Location = new Point(24, 365);
            decryptedData_rtb_extrctTab.Name = "decryptedData_rtb_extrctTab";
            decryptedData_rtb_extrctTab.Size = new Size(374, 44);
            decryptedData_rtb_extrctTab.TabIndex = 31;
            decryptedData_rtb_extrctTab.Text = "";
            // 
            // decompressedData_rtb_extrctTab
            // 
            decompressedData_rtb_extrctTab.Location = new Point(24, 276);
            decompressedData_rtb_extrctTab.Name = "decompressedData_rtb_extrctTab";
            decompressedData_rtb_extrctTab.Size = new Size(374, 44);
            decompressedData_rtb_extrctTab.TabIndex = 30;
            decompressedData_rtb_extrctTab.Text = "";
            // 
            // extractedData_rtb_extrctTab
            // 
            extractedData_rtb_extrctTab.Location = new Point(24, 197);
            extractedData_rtb_extrctTab.Name = "extractedData_rtb_extrctTab";
            extractedData_rtb_extrctTab.Size = new Size(374, 44);
            extractedData_rtb_extrctTab.TabIndex = 29;
            extractedData_rtb_extrctTab.Text = "";
            // 
            // decryptedData_label_extrctTab
            // 
            decryptedData_label_extrctTab.AutoSize = true;
            decryptedData_label_extrctTab.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            decryptedData_label_extrctTab.Location = new Point(24, 339);
            decryptedData_label_extrctTab.Name = "decryptedData_label_extrctTab";
            decryptedData_label_extrctTab.Size = new Size(88, 23);
            decryptedData_label_extrctTab.TabIndex = 28;
            decryptedData_label_extrctTab.Text = "Decrypted";
            // 
            // decryptData_button_extrctTab
            // 
            decryptData_button_extrctTab.Location = new Point(260, 337);
            decryptData_button_extrctTab.Name = "decryptData_button_extrctTab";
            decryptData_button_extrctTab.Size = new Size(138, 29);
            decryptData_button_extrctTab.TabIndex = 26;
            decryptData_button_extrctTab.Text = "Decrypt data";
            decryptData_button_extrctTab.UseVisualStyleBackColor = true;
            decryptData_button_extrctTab.Click += decryptData_button_extrctTab_Click;
            // 
            // decompressedData_label_extrctTab
            // 
            decompressedData_label_extrctTab.AutoSize = true;
            decompressedData_label_extrctTab.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            decompressedData_label_extrctTab.Location = new Point(24, 250);
            decompressedData_label_extrctTab.Name = "decompressedData_label_extrctTab";
            decompressedData_label_extrctTab.Size = new Size(122, 23);
            decompressedData_label_extrctTab.TabIndex = 25;
            decompressedData_label_extrctTab.Text = "Decompressed";
            // 
            // extractedData_label_extrctTab
            // 
            extractedData_label_extrctTab.AutoSize = true;
            extractedData_label_extrctTab.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            extractedData_label_extrctTab.Location = new Point(24, 171);
            extractedData_label_extrctTab.Name = "extractedData_label_extrctTab";
            extractedData_label_extrctTab.Size = new Size(81, 23);
            extractedData_label_extrctTab.TabIndex = 23;
            extractedData_label_extrctTab.Text = "Extracted";
            // 
            // decompressData_button_extrctTab
            // 
            decompressData_button_extrctTab.Location = new Point(260, 250);
            decompressData_button_extrctTab.Name = "decompressData_button_extrctTab";
            decompressData_button_extrctTab.Size = new Size(138, 29);
            decompressData_button_extrctTab.TabIndex = 22;
            decompressData_button_extrctTab.Text = "Decompress data";
            decompressData_button_extrctTab.UseVisualStyleBackColor = true;
            decompressData_button_extrctTab.Click += decompressData_button_extrctTab_Click;
            // 
            // extractEmbeddedData_btn
            // 
            extractEmbeddedData_btn.Location = new Point(304, 116);
            extractEmbeddedData_btn.Name = "extractEmbeddedData_btn";
            extractEmbeddedData_btn.Size = new Size(94, 29);
            extractEmbeddedData_btn.TabIndex = 21;
            extractEmbeddedData_btn.Text = "Extract data";
            extractEmbeddedData_btn.UseVisualStyleBackColor = true;
            extractEmbeddedData_btn.Click += extractEmbeddedData_btn_Click;
            // 
            // stopStegoAud_button_extractTab
            // 
            stopStegoAud_button_extractTab.Location = new Point(111, 116);
            stopStegoAud_button_extractTab.Name = "stopStegoAud_button_extractTab";
            stopStegoAud_button_extractTab.Size = new Size(71, 29);
            stopStegoAud_button_extractTab.TabIndex = 18;
            stopStegoAud_button_extractTab.Text = "stop";
            stopStegoAud_button_extractTab.UseVisualStyleBackColor = true;
            stopStegoAud_button_extractTab.Click += stopStegoAud_button_extractTab_Click;
            // 
            // playStegoAud_button_extrctTab
            // 
            playStegoAud_button_extrctTab.Location = new Point(12, 116);
            playStegoAud_button_extrctTab.Name = "playStegoAud_button_extrctTab";
            playStegoAud_button_extrctTab.Size = new Size(71, 29);
            playStegoAud_button_extrctTab.TabIndex = 17;
            playStegoAud_button_extrctTab.Text = "play";
            playStegoAud_button_extrctTab.UseVisualStyleBackColor = true;
            playStegoAud_button_extrctTab.Click += playStegoAud_button_extrctTab_Click;
            // 
            // chooseStegoAud_button
            // 
            chooseStegoAud_button.Location = new Point(12, 26);
            chooseStegoAud_button.Name = "chooseStegoAud_button";
            chooseStegoAud_button.Size = new Size(152, 29);
            chooseStegoAud_button.TabIndex = 9;
            chooseStegoAud_button.Text = "Load stego audio";
            chooseStegoAud_button.UseVisualStyleBackColor = true;
            chooseStegoAud_button.Click += chooseStegoAud_button_Click;
            // 
            // stegoAud_label_extrctTab
            // 
            stegoAud_label_extrctTab.AutoSize = true;
            stegoAud_label_extrctTab.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            stegoAud_label_extrctTab.Location = new Point(24, 85);
            stegoAud_label_extrctTab.Name = "stegoAud_label_extrctTab";
            stegoAud_label_extrctTab.Size = new Size(107, 23);
            stegoAud_label_extrctTab.TabIndex = 8;
            stegoAud_label_extrctTab.Text = "Stego audio";
            // 
            // displayStegoAud_tb_extrctTab
            // 
            displayStegoAud_tb_extrctTab.BackColor = SystemColors.Info;
            displayStegoAud_tb_extrctTab.ForeColor = SystemColors.WindowText;
            displayStegoAud_tb_extrctTab.Location = new Point(146, 83);
            displayStegoAud_tb_extrctTab.Name = "displayStegoAud_tb_extrctTab";
            displayStegoAud_tb_extrctTab.Size = new Size(252, 27);
            displayStegoAud_tb_extrctTab.TabIndex = 7;
            // 
            // openFileDialog_coverAud
            // 
            openFileDialog_coverAud.FileName = "openFileDialog_coverAud";
            // 
            // openFileDialog_stegoAud
            // 
            openFileDialog_stegoAud.FileName = "openFileDialog_stegoAud";
            // 
            // AudioSteganographyForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "AudioSteganographyForm";
            Text = "AudioSteganographyForm";
            tabControl1.ResumeLayout(false);
            audioEmbedData_tab.ResumeLayout(false);
            audioEmbedData_tab.PerformLayout();
            audioExtractData_tab.ResumeLayout(false);
            audioExtractData_tab.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage audioEmbedData_tab;
        private TabPage audioExtractData_tab;
        private Button chooseCoverAud_button;
        private TextBox displayCoverAud_tb;
        private OpenFileDialog openFileDialog_coverAud;
        private Button stopCoverAud_button;
        private Button playCoverAud_button;
        private Label coverAud_label;
        private Button embedData_button;
        private Label stegoAud_label;
        private TextBox displayStegoAud_tb;
        private Label embedData_label;
        private Button showEmbedData_button;
        private Button saveStegoAud_button;
        private SaveFileDialog saveFileDialog_resultStegoAud;
        private Button stopStegoAud_button;
        private Button playStegoAud_button;
        private Button calcAvailableBits_button;
        private Button chooseStegoAud_button;
        private Label stegoAud_label_extrctTab;
        private TextBox displayStegoAud_tb_extrctTab;
        private OpenFileDialog openFileDialog_stegoAud;
        private Button stopStegoAud_button_extractTab;
        private Button playStegoAud_button_extrctTab;
        private Button extractEmbeddedData_btn;
        private Button decompressData_button_extrctTab;
        private Label extractedData_label_extrctTab;
        private Label decompressedData_label_extrctTab;
        private Button decryptData_button_extrctTab;
        private Label decryptedData_label_extrctTab;
        private RichTextBox embedData_rtb;
        private RichTextBox extractedData_rtb_extrctTab;
        private RichTextBox decompressedData_rtb_extrctTab;
        private RichTextBox decryptedData_rtb_extrctTab;
        private Button showFulldisplayStegoAud_tb_extrctTab_button;
        private Button showFullextractedData_rtb_extrctTab_button;
        private Button showFulldecompressedData_rtb_extrctTab_button;
        private Button showFulldecryptedData_rtb_extrctTab_button;
        private Button calcAudQualityMetrics_button;
        private Button audioClassify_button;
    }
}