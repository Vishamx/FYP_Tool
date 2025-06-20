using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FYP_Tool
{
    public partial class RichTextBoxViewForm : Form
    {
        public RichTextBoxViewForm(string Data)
        {
            InitializeComponent();
            richTextBoxView.Text = Data;
        }
    }
}
