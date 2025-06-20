namespace FYP_Tool
{
    partial class ImageSteganographyForm
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
            openFileDialog_coverImg = new OpenFileDialog();
            openFileDialog_stegoImg = new OpenFileDialog();
            tabControl_imgStego = new TabControl();
            embedData_tab = new TabPage();
            classify_button = new Button();
            calcImageCap_button = new Button();
            embedData_rtb = new RichTextBox();
            showEmbedData_button = new Button();
            calculateMetrics_button = new Button();
            saveStegoImg_button = new Button();
            resultStegoImg_picBox = new PictureBox();
            resultImg_label = new Label();
            embedData_button = new Button();
            embedData_label = new Label();
            coverImg_picBox = new PictureBox();
            chooseCoverImg_button = new Button();
            extractData_tab = new TabPage();
            originalData_rtb = new RichTextBox();
            decompressedData_rtb = new RichTextBox();
            extractedData_rtb = new RichTextBox();
            showFullOriginalData_button = new Button();
            showFullDecompressedData_button = new Button();
            showFullExtractedData_button = new Button();
            originalData_label = new Label();
            decompressData_button = new Button();
            decompressedData_label = new Label();
            decryptData_button = new Button();
            extractedData_label = new Label();
            extractData_button = new Button();
            stegoImg_picBox = new PictureBox();
            chooseStegoImg_button = new Button();
            saveFileDialog_resultStegoImg = new SaveFileDialog();
            tabControl_imgStego.SuspendLayout();
            embedData_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)resultStegoImg_picBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)coverImg_picBox).BeginInit();
            extractData_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)stegoImg_picBox).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog_coverImg
            // 
            openFileDialog_coverImg.FileName = "openFileDialog_coverImg";
            // 
            // openFileDialog_stegoImg
            // 
            openFileDialog_stegoImg.FileName = "openFileDialog_stegoImg";
            // 
            // tabControl_imgStego
            // 
            tabControl_imgStego.Controls.Add(embedData_tab);
            tabControl_imgStego.Controls.Add(extractData_tab);
            tabControl_imgStego.Location = new Point(-3, -1);
            tabControl_imgStego.Name = "tabControl_imgStego";
            tabControl_imgStego.SelectedIndex = 0;
            tabControl_imgStego.Size = new Size(860, 455);
            tabControl_imgStego.TabIndex = 0;
            // 
            // embedData_tab
            // 
            embedData_tab.Controls.Add(classify_button);
            embedData_tab.Controls.Add(calcImageCap_button);
            embedData_tab.Controls.Add(embedData_rtb);
            embedData_tab.Controls.Add(showEmbedData_button);
            embedData_tab.Controls.Add(calculateMetrics_button);
            embedData_tab.Controls.Add(saveStegoImg_button);
            embedData_tab.Controls.Add(resultStegoImg_picBox);
            embedData_tab.Controls.Add(resultImg_label);
            embedData_tab.Controls.Add(embedData_button);
            embedData_tab.Controls.Add(embedData_label);
            embedData_tab.Controls.Add(coverImg_picBox);
            embedData_tab.Controls.Add(chooseCoverImg_button);
            embedData_tab.Location = new Point(4, 29);
            embedData_tab.Name = "embedData_tab";
            embedData_tab.Padding = new Padding(3);
            embedData_tab.Size = new Size(852, 422);
            embedData_tab.TabIndex = 0;
            embedData_tab.Text = "Embed data";
            embedData_tab.UseVisualStyleBackColor = true;
            // 
            // classify_button
            // 
            classify_button.Location = new Point(640, 381);
            classify_button.Name = "classify_button";
            classify_button.RightToLeft = RightToLeft.No;
            classify_button.Size = new Size(190, 29);
            classify_button.TabIndex = 17;
            classify_button.Text = "Classify image quality";
            classify_button.UseVisualStyleBackColor = true;
            classify_button.Click += classify_button_Click;
            // 
            // calcImageCap_button
            // 
            calcImageCap_button.Location = new Point(196, 28);
            calcImageCap_button.Name = "calcImageCap_button";
            calcImageCap_button.Size = new Size(165, 29);
            calcImageCap_button.TabIndex = 16;
            calcImageCap_button.Text = "Image capacity";
            calcImageCap_button.UseVisualStyleBackColor = true;
            calcImageCap_button.Click += calcImageCap_button_Click;
            // 
            // embedData_rtb
            // 
            embedData_rtb.Location = new Point(125, 336);
            embedData_rtb.Name = "embedData_rtb";
            embedData_rtb.Size = new Size(257, 35);
            embedData_rtb.TabIndex = 15;
            embedData_rtb.Text = "";
            // 
            // showEmbedData_button
            // 
            showEmbedData_button.Location = new Point(388, 338);
            showEmbedData_button.Name = "showEmbedData_button";
            showEmbedData_button.Size = new Size(38, 29);
            showEmbedData_button.TabIndex = 9;
            showEmbedData_button.Text = "▼\r\n";
            showEmbedData_button.UseVisualStyleBackColor = true;
            showEmbedData_button.Click += showEmbedData_button_Click;
            // 
            // calculateMetrics_button
            // 
            calculateMetrics_button.Location = new Point(698, 342);
            calculateMetrics_button.Name = "calculateMetrics_button";
            calculateMetrics_button.RightToLeft = RightToLeft.No;
            calculateMetrics_button.Size = new Size(132, 29);
            calculateMetrics_button.TabIndex = 8;
            calculateMetrics_button.Text = "Calculate metrics";
            calculateMetrics_button.UseVisualStyleBackColor = true;
            calculateMetrics_button.Click += calculateMetrics_button_Click;
            // 
            // saveStegoImg_button
            // 
            saveStegoImg_button.Location = new Point(157, 387);
            saveStegoImg_button.Name = "saveStegoImg_button";
            saveStegoImg_button.RightToLeft = RightToLeft.No;
            saveStegoImg_button.Size = new Size(132, 29);
            saveStegoImg_button.TabIndex = 7;
            saveStegoImg_button.Text = "Save stego img";
            saveStegoImg_button.UseVisualStyleBackColor = true;
            saveStegoImg_button.Click += saveStegoImg_button_Click;
            // 
            // resultStegoImg_picBox
            // 
            resultStegoImg_picBox.BorderStyle = BorderStyle.FixedSingle;
            resultStegoImg_picBox.Location = new Point(463, 71);
            resultStegoImg_picBox.Name = "resultStegoImg_picBox";
            resultStegoImg_picBox.Size = new Size(350, 250);
            resultStegoImg_picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            resultStegoImg_picBox.TabIndex = 6;
            resultStegoImg_picBox.TabStop = false;
            // 
            // resultImg_label
            // 
            resultImg_label.AutoSize = true;
            resultImg_label.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            resultImg_label.Location = new Point(457, 28);
            resultImg_label.Name = "resultImg_label";
            resultImg_label.Size = new Size(383, 28);
            resultImg_label.TabIndex = 5;
            resultImg_label.Text = "Resulting  image after embedding data";
            // 
            // embedData_button
            // 
            embedData_button.Location = new Point(11, 387);
            embedData_button.Name = "embedData_button";
            embedData_button.RightToLeft = RightToLeft.No;
            embedData_button.Size = new Size(120, 29);
            embedData_button.TabIndex = 4;
            embedData_button.Text = "Embed data";
            embedData_button.UseVisualStyleBackColor = true;
            embedData_button.Click += embedData_button_Click;
            // 
            // embedData_label
            // 
            embedData_label.AutoSize = true;
            embedData_label.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            embedData_label.Location = new Point(2, 342);
            embedData_label.Name = "embedData_label";
            embedData_label.Size = new Size(117, 20);
            embedData_label.TabIndex = 2;
            embedData_label.Text = "Data to embed: ";
            // 
            // coverImg_picBox
            // 
            coverImg_picBox.BorderStyle = BorderStyle.FixedSingle;
            coverImg_picBox.Location = new Point(11, 71);
            coverImg_picBox.Name = "coverImg_picBox";
            coverImg_picBox.Size = new Size(350, 250);
            coverImg_picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            coverImg_picBox.TabIndex = 1;
            coverImg_picBox.TabStop = false;
            // 
            // chooseCoverImg_button
            // 
            chooseCoverImg_button.Location = new Point(11, 27);
            chooseCoverImg_button.Name = "chooseCoverImg_button";
            chooseCoverImg_button.Size = new Size(165, 29);
            chooseCoverImg_button.TabIndex = 0;
            chooseCoverImg_button.Text = "Choose a cover image";
            chooseCoverImg_button.UseVisualStyleBackColor = true;
            chooseCoverImg_button.Click += chooseCoverImg_button_Click;
            // 
            // extractData_tab
            // 
            extractData_tab.Controls.Add(originalData_rtb);
            extractData_tab.Controls.Add(decompressedData_rtb);
            extractData_tab.Controls.Add(extractedData_rtb);
            extractData_tab.Controls.Add(showFullOriginalData_button);
            extractData_tab.Controls.Add(showFullDecompressedData_button);
            extractData_tab.Controls.Add(showFullExtractedData_button);
            extractData_tab.Controls.Add(originalData_label);
            extractData_tab.Controls.Add(decompressData_button);
            extractData_tab.Controls.Add(decompressedData_label);
            extractData_tab.Controls.Add(decryptData_button);
            extractData_tab.Controls.Add(extractedData_label);
            extractData_tab.Controls.Add(extractData_button);
            extractData_tab.Controls.Add(stegoImg_picBox);
            extractData_tab.Controls.Add(chooseStegoImg_button);
            extractData_tab.Location = new Point(4, 29);
            extractData_tab.Name = "extractData_tab";
            extractData_tab.Padding = new Padding(3);
            extractData_tab.Size = new Size(852, 422);
            extractData_tab.TabIndex = 1;
            extractData_tab.Text = "Extract data";
            extractData_tab.UseVisualStyleBackColor = true;
            // 
            // originalData_rtb
            // 
            originalData_rtb.Location = new Point(465, 279);
            originalData_rtb.Name = "originalData_rtb";
            originalData_rtb.Size = new Size(340, 35);
            originalData_rtb.TabIndex = 18;
            originalData_rtb.Text = "";
            // 
            // decompressedData_rtb
            // 
            decompressedData_rtb.Location = new Point(465, 167);
            decompressedData_rtb.Name = "decompressedData_rtb";
            decompressedData_rtb.Size = new Size(340, 35);
            decompressedData_rtb.TabIndex = 17;
            decompressedData_rtb.Text = "";
            // 
            // extractedData_rtb
            // 
            extractedData_rtb.Location = new Point(465, 72);
            extractedData_rtb.Name = "extractedData_rtb";
            extractedData_rtb.Size = new Size(340, 35);
            extractedData_rtb.TabIndex = 16;
            extractedData_rtb.Text = "";
            // 
            // showFullOriginalData_button
            // 
            showFullOriginalData_button.Location = new Point(811, 285);
            showFullOriginalData_button.Name = "showFullOriginalData_button";
            showFullOriginalData_button.Size = new Size(38, 29);
            showFullOriginalData_button.TabIndex = 14;
            showFullOriginalData_button.Text = "▼\r\n";
            showFullOriginalData_button.UseVisualStyleBackColor = true;
            showFullOriginalData_button.Click += showFullOriginalData_button_Click;
            // 
            // showFullDecompressedData_button
            // 
            showFullDecompressedData_button.Location = new Point(811, 173);
            showFullDecompressedData_button.Name = "showFullDecompressedData_button";
            showFullDecompressedData_button.Size = new Size(38, 29);
            showFullDecompressedData_button.TabIndex = 13;
            showFullDecompressedData_button.Text = "▼\r\n";
            showFullDecompressedData_button.UseVisualStyleBackColor = true;
            showFullDecompressedData_button.Click += showFullDecompressedData_button_Click;
            // 
            // showFullExtractedData_button
            // 
            showFullExtractedData_button.Location = new Point(811, 78);
            showFullExtractedData_button.Name = "showFullExtractedData_button";
            showFullExtractedData_button.Size = new Size(38, 29);
            showFullExtractedData_button.TabIndex = 12;
            showFullExtractedData_button.Text = "▼\r\n";
            showFullExtractedData_button.UseVisualStyleBackColor = true;
            showFullExtractedData_button.Click += showFullExtractedData_button_Click;
            // 
            // originalData_label
            // 
            originalData_label.AutoSize = true;
            originalData_label.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            originalData_label.Location = new Point(465, 253);
            originalData_label.Name = "originalData_label";
            originalData_label.Size = new Size(88, 23);
            originalData_label.TabIndex = 10;
            originalData_label.Text = "Decrypted";
            // 
            // decompressData_button
            // 
            decompressData_button.Location = new Point(708, 113);
            decompressData_button.Name = "decompressData_button";
            decompressData_button.Size = new Size(138, 29);
            decompressData_button.TabIndex = 9;
            decompressData_button.Text = "Decompress data";
            decompressData_button.UseVisualStyleBackColor = true;
            decompressData_button.Click += decompressData_button_Click;
            // 
            // decompressedData_label
            // 
            decompressedData_label.AutoSize = true;
            decompressedData_label.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            decompressedData_label.Location = new Point(465, 141);
            decompressedData_label.Name = "decompressedData_label";
            decompressedData_label.Size = new Size(122, 23);
            decompressedData_label.TabIndex = 7;
            decompressedData_label.Text = "Decompressed";
            // 
            // decryptData_button
            // 
            decryptData_button.Location = new Point(708, 208);
            decryptData_button.Name = "decryptData_button";
            decryptData_button.Size = new Size(138, 29);
            decryptData_button.TabIndex = 6;
            decryptData_button.Text = "Decrypt data";
            decryptData_button.UseVisualStyleBackColor = true;
            decryptData_button.Click += decryptData_button_Click;
            // 
            // extractedData_label
            // 
            extractedData_label.AutoSize = true;
            extractedData_label.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            extractedData_label.Location = new Point(465, 46);
            extractedData_label.Name = "extractedData_label";
            extractedData_label.Size = new Size(81, 23);
            extractedData_label.TabIndex = 4;
            extractedData_label.Text = "Extracted";
            // 
            // extractData_button
            // 
            extractData_button.Location = new Point(11, 346);
            extractData_button.Name = "extractData_button";
            extractData_button.Size = new Size(122, 29);
            extractData_button.TabIndex = 3;
            extractData_button.Text = "Extract data";
            extractData_button.UseVisualStyleBackColor = true;
            extractData_button.Click += extractData_button_Click;
            // 
            // stegoImg_picBox
            // 
            stegoImg_picBox.BorderStyle = BorderStyle.FixedSingle;
            stegoImg_picBox.Location = new Point(11, 79);
            stegoImg_picBox.Name = "stegoImg_picBox";
            stegoImg_picBox.Size = new Size(317, 243);
            stegoImg_picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            stegoImg_picBox.TabIndex = 2;
            stegoImg_picBox.TabStop = false;
            // 
            // chooseStegoImg_button
            // 
            chooseStegoImg_button.Location = new Point(11, 29);
            chooseStegoImg_button.Name = "chooseStegoImg_button";
            chooseStegoImg_button.Size = new Size(160, 29);
            chooseStegoImg_button.TabIndex = 0;
            chooseStegoImg_button.Text = "Choose stego image";
            chooseStegoImg_button.UseVisualStyleBackColor = true;
            chooseStegoImg_button.Click += chooseStegoImg_button_Click;
            // 
            // ImageSteganographyForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 450);
            Controls.Add(tabControl_imgStego);
            Name = "ImageSteganographyForm";
            Text = "ImageSteganographyForm";
            tabControl_imgStego.ResumeLayout(false);
            embedData_tab.ResumeLayout(false);
            embedData_tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)resultStegoImg_picBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)coverImg_picBox).EndInit();
            extractData_tab.ResumeLayout(false);
            extractData_tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)stegoImg_picBox).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private OpenFileDialog openFileDialog_coverImg;
        private OpenFileDialog openFileDialog_stegoImg;
        private TabControl tabControl_imgStego;
        private TabPage embedData_tab;
        private TabPage extractData_tab;
        private PictureBox coverImg_picBox;
        private Button chooseCoverImg_button;
        private Button embedData_button;
        private Label embedData_label;
        private Button chooseStegoImg_button;
        private PictureBox stegoImg_picBox;
        private Button extractData_button;
        private Button saveStegoImg_button;
        private PictureBox resultStegoImg_picBox;
        private Label resultImg_label;
        private SaveFileDialog saveFileDialog_resultStegoImg;
        private Label extractedData_label;
        private Label decompressedData_label;
        private Button decryptData_button;
        private Button decompressData_button;
        private Label originalData_label;
        private Button calculateMetrics_button;
        private Button showEmbedData_button;
        private Button showFullOriginalData_button;
        private Button showFullDecompressedData_button;
        private Button showFullExtractedData_button;
        private RichTextBox embedData_rtb;
        private RichTextBox extractedData_rtb;
        private RichTextBox decompressedData_rtb;
        private RichTextBox originalData_rtb;
        private Button calcImageCap_button;
        private Button classify_button;
    }
}