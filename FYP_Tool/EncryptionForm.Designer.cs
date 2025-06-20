namespace FYP_Tool
{
    partial class EncryptionForm
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
            encryption_header = new Label();
            dataToEncrypt_label = new Label();
            applyEncryption_button = new Button();
            encryptedData_label = new Label();
            applyDecryption_button = new Button();
            showFullEncryptedData_button = new Button();
            dataToEncrypt_rtb = new RichTextBox();
            encryptedData_rtb = new RichTextBox();
            showFullMsg_button = new Button();
            SuspendLayout();
            // 
            // encryption_header
            // 
            encryption_header.AutoSize = true;
            encryption_header.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            encryption_header.Location = new Point(260, 24);
            encryption_header.Name = "encryption_header";
            encryption_header.Size = new Size(275, 38);
            encryption_header.TabIndex = 1;
            encryption_header.Text = "Perform encryption";
            // 
            // dataToEncrypt_label
            // 
            dataToEncrypt_label.AutoSize = true;
            dataToEncrypt_label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataToEncrypt_label.Location = new Point(12, 87);
            dataToEncrypt_label.Name = "dataToEncrypt_label";
            dataToEncrypt_label.Size = new Size(157, 28);
            dataToEncrypt_label.TabIndex = 2;
            dataToEncrypt_label.Text = "Data to encrypt: ";
            // 
            // applyEncryption_button
            // 
            applyEncryption_button.Location = new Point(12, 279);
            applyEncryption_button.Name = "applyEncryption_button";
            applyEncryption_button.Size = new Size(174, 41);
            applyEncryption_button.TabIndex = 7;
            applyEncryption_button.Text = "Apply encryption";
            applyEncryption_button.UseVisualStyleBackColor = true;
            applyEncryption_button.Click += applyEncryption_button_Click;
            // 
            // encryptedData_label
            // 
            encryptedData_label.AutoSize = true;
            encryptedData_label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            encryptedData_label.Location = new Point(12, 165);
            encryptedData_label.Name = "encryptedData_label";
            encryptedData_label.Size = new Size(153, 28);
            encryptedData_label.TabIndex = 8;
            encryptedData_label.Text = "Encrypted data: ";
            // 
            // applyDecryption_button
            // 
            applyDecryption_button.Location = new Point(227, 279);
            applyDecryption_button.Name = "applyDecryption_button";
            applyDecryption_button.Size = new Size(174, 41);
            applyDecryption_button.TabIndex = 10;
            applyDecryption_button.Text = "Apply decryption";
            applyDecryption_button.UseVisualStyleBackColor = true;
            applyDecryption_button.Click += applyDecryption_button_Click;
            // 
            // showFullEncryptedData_button
            // 
            showFullEncryptedData_button.Location = new Point(600, 168);
            showFullEncryptedData_button.Name = "showFullEncryptedData_button";
            showFullEncryptedData_button.Size = new Size(38, 29);
            showFullEncryptedData_button.TabIndex = 14;
            showFullEncryptedData_button.Text = "▼\r\n";
            showFullEncryptedData_button.UseVisualStyleBackColor = true;
            showFullEncryptedData_button.Click += showFullEncryptedData_button_Click;
            // 
            // dataToEncrypt_rtb
            // 
            dataToEncrypt_rtb.Location = new Point(175, 86);
            dataToEncrypt_rtb.Name = "dataToEncrypt_rtb";
            dataToEncrypt_rtb.Size = new Size(423, 45);
            dataToEncrypt_rtb.TabIndex = 17;
            dataToEncrypt_rtb.Text = "";
            // 
            // encryptedData_rtb
            // 
            encryptedData_rtb.Location = new Point(171, 165);
            encryptedData_rtb.Name = "encryptedData_rtb";
            encryptedData_rtb.Size = new Size(423, 45);
            encryptedData_rtb.TabIndex = 18;
            encryptedData_rtb.Text = "";
            // 
            // showFullMsg_button
            // 
            showFullMsg_button.Location = new Point(604, 86);
            showFullMsg_button.Name = "showFullMsg_button";
            showFullMsg_button.Size = new Size(38, 29);
            showFullMsg_button.TabIndex = 19;
            showFullMsg_button.Text = "▼\r\n";
            showFullMsg_button.UseVisualStyleBackColor = true;
            showFullMsg_button.Click += showFullMsg_button_Click;
            // 
            // EncryptionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(showFullMsg_button);
            Controls.Add(encryptedData_rtb);
            Controls.Add(dataToEncrypt_rtb);
            Controls.Add(showFullEncryptedData_button);
            Controls.Add(applyDecryption_button);
            Controls.Add(encryptedData_label);
            Controls.Add(applyEncryption_button);
            Controls.Add(dataToEncrypt_label);
            Controls.Add(encryption_header);
            Name = "EncryptionForm";
            Text = "EncryptionForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label encryption_header;
        private Label dataToEncrypt_label;
        private Button applyEncryption_button;
        private Label encryptedData_label;
        private Button applyDecryption_button;
        private Button showFullEncryptedData_button;
        private RichTextBox dataToEncrypt_rtb;
        private RichTextBox encryptedData_rtb;
        private Button showFullMsg_button;
    }
}