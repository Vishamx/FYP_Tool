namespace FYP_Tool
{
    partial class RichTextBoxViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RichTextBox richTextBoxView;

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
            richTextBoxView = new RichTextBox();
            SuspendLayout();
            // 
            // richTextBoxView
            // 
            richTextBoxView.Dock = DockStyle.Fill;
            richTextBoxView.Location = new Point(0, 0);
            richTextBoxView.Margin = new Padding(4, 5, 4, 5);
            richTextBoxView.Name = "richTextBoxView";
            richTextBoxView.Size = new Size(1067, 692);
            richTextBoxView.TabIndex = 0;
            richTextBoxView.Text = "";
            // 
            // RichTextBoxViewForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 692);
            Controls.Add(richTextBoxView);
            Margin = new Padding(4, 5, 4, 5);
            Name = "RichTextBoxViewForm";
            Text = "RichTextBox Viewer";
            ResumeLayout(false);
        }

        #endregion
    }
}