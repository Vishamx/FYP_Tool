namespace FYP_Tool
{
    public partial class MainForm : Form
    {
        private string compressedText;
        private string encryptedText;

        public MainForm()
        {
            InitializeComponent();
        }


        private void encryptionForm_load_Click(object sender, EventArgs e)
        {
            EncryptionForm ef = new EncryptionForm();

            string msg = msg_rtb.Text;
            ef.SetOriginalText(msg);
            ef.Show();
        }

        private void compressionForm_load_Click(object sender, EventArgs e)
        {
            encryptedText = EncryptionForm.encryptedText;
            DataCompressionForm dcf = new DataCompressionForm();
            dcf.SetEncryptedMessage(encryptedText);
            dcf.Show();

        }

        private void imageStegoForm_load_Click(object sender, EventArgs e)
        {
            ImageSteganographyForm imageSteganography = new ImageSteganographyForm();

            compressedText = DataCompressionForm.compressedText;
            imageSteganography.SetCompressedData(compressedText);
            imageSteganography.Show();
        }

        private void audioStegoForm_load_Click(object sender, EventArgs e)
        {

            AudioSteganographyForm audioSteganography = new AudioSteganographyForm();
            compressedText = DataCompressionForm.compressedText;
            audioSteganography.SetCompressedData(compressedText);
            audioSteganography.Show();
        }

        private void showFullText_button_Click(object sender, EventArgs e)
        {
            using (RichTextBoxViewForm viewer = new RichTextBoxViewForm(msg_rtb.Text))
            {
                viewer.ShowDialog();
            }
        }
    }
}
