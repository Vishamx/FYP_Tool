namespace FYP_Tool
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            msg_label = new Label();
            compressionForm_load = new Button();
            encryptionForm_load = new Button();
            imageStegoForm_load = new Button();
            showFullText_button = new Button();
            audioStegoForm_load = new Button();
            msg_rtb = new RichTextBox();
            SuspendLayout();
            // 
            // msg_label
            // 
            msg_label.AutoSize = true;
            msg_label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            msg_label.Location = new Point(7, 41);
            msg_label.Name = "msg_label";
            msg_label.Size = new Size(197, 28);
            msg_label.TabIndex = 0;
            msg_label.Text = "Enter secret message:";
            // 
            // compressionForm_load
            // 
            compressionForm_load.Location = new Point(240, 131);
            compressionForm_load.Name = "compressionForm_load";
            compressionForm_load.Size = new Size(184, 41);
            compressionForm_load.TabIndex = 2;
            compressionForm_load.Text = "Load compression form";
            compressionForm_load.UseVisualStyleBackColor = true;
            compressionForm_load.Click += compressionForm_load_Click;
            // 
            // encryptionForm_load
            // 
            encryptionForm_load.Location = new Point(12, 131);
            encryptionForm_load.Name = "encryptionForm_load";
            encryptionForm_load.Size = new Size(184, 41);
            encryptionForm_load.TabIndex = 3;
            encryptionForm_load.Text = "Load encryption form";
            encryptionForm_load.UseVisualStyleBackColor = true;
            encryptionForm_load.Click += encryptionForm_load_Click;
            // 
            // imageStegoForm_load
            // 
            imageStegoForm_load.BackColor = SystemColors.ButtonHighlight;
            imageStegoForm_load.ForeColor = SystemColors.ActiveCaptionText;
            imageStegoForm_load.Location = new Point(7, 237);
            imageStegoForm_load.Name = "imageStegoForm_load";
            imageStegoForm_load.Size = new Size(184, 41);
            imageStegoForm_load.TabIndex = 4;
            imageStegoForm_load.Text = "Image stego";
            imageStegoForm_load.UseVisualStyleBackColor = false;
            imageStegoForm_load.Click += imageStegoForm_load_Click;
            // 
            // showFullText_button
            // 
            showFullText_button.Location = new Point(639, 44);
            showFullText_button.Name = "showFullText_button";
            showFullText_button.Size = new Size(38, 29);
            showFullText_button.TabIndex = 14;
            showFullText_button.Text = "▼\r\n";
            showFullText_button.UseVisualStyleBackColor = true;
            showFullText_button.Click += showFullText_button_Click;
            // 
            // audioStegoForm_load
            // 
            audioStegoForm_load.BackColor = SystemColors.ButtonHighlight;
            audioStegoForm_load.ForeColor = SystemColors.ActiveCaptionText;
            audioStegoForm_load.Location = new Point(240, 237);
            audioStegoForm_load.Name = "audioStegoForm_load";
            audioStegoForm_load.Size = new Size(184, 41);
            audioStegoForm_load.TabIndex = 15;
            audioStegoForm_load.Text = "Audio stego";
            audioStegoForm_load.UseVisualStyleBackColor = false;
            audioStegoForm_load.Click += audioStegoForm_load_Click;
            // 
            // msg_rtb
            // 
            msg_rtb.Location = new Point(210, 38);
            msg_rtb.Name = "msg_rtb";
            msg_rtb.Size = new Size(423, 44);
            msg_rtb.TabIndex = 16;
            msg_rtb.Text = "";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(msg_rtb);
            Controls.Add(audioStegoForm_load);
            Controls.Add(showFullText_button);
            Controls.Add(imageStegoForm_load);
            Controls.Add(encryptionForm_load);
            Controls.Add(compressionForm_load);
            Controls.Add(msg_label);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label msg_label;
        private Button compressionForm_load;
        private Button encryptionForm_load;
        private Button imageStegoForm_load;
        private Button showFullText_button;
        private Button audioStegoForm_load;
        private RichTextBox msg_rtb;
    }
}
