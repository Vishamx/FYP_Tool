namespace FYP_Tool
{
    partial class DataCompressionForm
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
            compression_header = new Label();
            NormalText_label = new Label();
            CompressedText_label = new Label();
            applyCompression_button = new Button();
            calcSizeOgText_button = new Button();
            calcSizeCompText_button = new Button();
            applyDecompression_button = new Button();
            showFullCompressedText_button = new Button();
            compressed_rtb = new RichTextBox();
            normalText_rtb = new RichTextBox();
            showFullNormalText_button = new Button();
            SuspendLayout();
            // 
            // compression_header
            // 
            compression_header.AutoSize = true;
            compression_header.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            compression_header.Location = new Point(212, 24);
            compression_header.Name = "compression_header";
            compression_header.Size = new Size(364, 38);
            compression_header.TabIndex = 0;
            compression_header.Text = "Perform data compression";
            // 
            // NormalText_label
            // 
            NormalText_label.AutoSize = true;
            NormalText_label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NormalText_label.Location = new Point(12, 91);
            NormalText_label.Name = "NormalText_label";
            NormalText_label.Size = new Size(167, 28);
            NormalText_label.TabIndex = 1;
            NormalText_label.Text = "Text to compress: ";
            // 
            // CompressedText_label
            // 
            CompressedText_label.AutoSize = true;
            CompressedText_label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CompressedText_label.Location = new Point(12, 168);
            CompressedText_label.Name = "CompressedText_label";
            CompressedText_label.Size = new Size(162, 28);
            CompressedText_label.TabIndex = 4;
            CompressedText_label.Text = "Compressed text:";
            // 
            // applyCompression_button
            // 
            applyCompression_button.Location = new Point(12, 245);
            applyCompression_button.Name = "applyCompression_button";
            applyCompression_button.Size = new Size(174, 41);
            applyCompression_button.TabIndex = 6;
            applyCompression_button.Text = "Apply compression";
            applyCompression_button.UseVisualStyleBackColor = true;
            applyCompression_button.Click += applyCompression_button_Click;
            // 
            // calcSizeOgText_button
            // 
            calcSizeOgText_button.Location = new Point(12, 366);
            calcSizeOgText_button.Name = "calcSizeOgText_button";
            calcSizeOgText_button.Size = new Size(126, 53);
            calcSizeOgText_button.TabIndex = 7;
            calcSizeOgText_button.Text = "Calculate size of original text";
            calcSizeOgText_button.UseVisualStyleBackColor = true;
            calcSizeOgText_button.Click += calcSizeOgText_button_Click;
            // 
            // calcSizeCompText_button
            // 
            calcSizeCompText_button.Location = new Point(160, 366);
            calcSizeCompText_button.Name = "calcSizeCompText_button";
            calcSizeCompText_button.Size = new Size(126, 53);
            calcSizeCompText_button.TabIndex = 8;
            calcSizeCompText_button.Text = "Calculate size of compressed text";
            calcSizeCompText_button.UseVisualStyleBackColor = true;
            calcSizeCompText_button.Click += calcSizeCompText_button_Click;
            // 
            // applyDecompression_button
            // 
            applyDecompression_button.Location = new Point(221, 245);
            applyDecompression_button.Name = "applyDecompression_button";
            applyDecompression_button.Size = new Size(174, 41);
            applyDecompression_button.TabIndex = 9;
            applyDecompression_button.Text = "Apply decompression";
            applyDecompression_button.UseVisualStyleBackColor = true;
            applyDecompression_button.Click += applyDecompression_button_Click;
            // 
            // showFullCompressedText_button
            // 
            showFullCompressedText_button.Location = new Point(612, 171);
            showFullCompressedText_button.Name = "showFullCompressedText_button";
            showFullCompressedText_button.Size = new Size(38, 29);
            showFullCompressedText_button.TabIndex = 13;
            showFullCompressedText_button.Text = "▼\r\n";
            showFullCompressedText_button.UseVisualStyleBackColor = true;
            showFullCompressedText_button.Click += showFullCompressedText_button_Click;
            // 
            // compressed_rtb
            // 
            compressed_rtb.Location = new Point(183, 167);
            compressed_rtb.Name = "compressed_rtb";
            compressed_rtb.Size = new Size(423, 44);
            compressed_rtb.TabIndex = 14;
            compressed_rtb.Text = "";
            // 
            // normalText_rtb
            // 
            normalText_rtb.Location = new Point(183, 91);
            normalText_rtb.Name = "normalText_rtb";
            normalText_rtb.Size = new Size(423, 45);
            normalText_rtb.TabIndex = 16;
            normalText_rtb.Text = "";
            // 
            // showFullNormalText_button
            // 
            showFullNormalText_button.Location = new Point(612, 94);
            showFullNormalText_button.Name = "showFullNormalText_button";
            showFullNormalText_button.Size = new Size(38, 29);
            showFullNormalText_button.TabIndex = 17;
            showFullNormalText_button.Text = "▼\r\n";
            showFullNormalText_button.UseVisualStyleBackColor = true;
            showFullNormalText_button.Click += showFullNormalText_button_Click;
            // 
            // DataCompressionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(showFullNormalText_button);
            Controls.Add(normalText_rtb);
            Controls.Add(compressed_rtb);
            Controls.Add(showFullCompressedText_button);
            Controls.Add(applyDecompression_button);
            Controls.Add(calcSizeCompText_button);
            Controls.Add(calcSizeOgText_button);
            Controls.Add(applyCompression_button);
            Controls.Add(CompressedText_label);
            Controls.Add(NormalText_label);
            Controls.Add(compression_header);
            Name = "DataCompressionForm";
            Text = "DataCompressionForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label compression_header;
        private Label NormalText_label;
        private Label CompressedText_label;
        private Button applyCompression_button;
        private Button calcSizeOgText_button;
        private Button calcSizeCompText_button;
        private Button applyDecompression_button;
        private Button showFullCompressedText_button;
        private RichTextBox compressed_rtb;
        private RichTextBox normalText_rtb;
        private Button showFullNormalText_button;
    }
}