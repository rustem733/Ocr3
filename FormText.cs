using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Ocr3
{

    public partial class FormText : Form
    {

        string outputfile = "output.txt";
        public FormText()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text != String.Empty
                || toolStripTextBox2.Text != String.Empty
                || toolStripTextBox3.Text != String.Empty)
            {

                var sw = new StreamWriter(outputfile, true);
                string[] outTofile = richTextBox1.Lines;
                var result = outTofile.Where(x => !string.IsNullOrWhiteSpace(x));

                foreach (string s in result)
                {

                    sw.WriteLine($"{toolStripTextBox1};{toolStripTextBox2};{toolStripTextBox3};{s}");
                    sw.Flush();

                }
                MessageBox.Show("Записи добавлены");

            }
            else
            {
                MessageBox.Show("Не все поля заполнены");

            }

        }


    }
}
