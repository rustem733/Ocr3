using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ocr3
{
    public partial class Form1 : Form
    {
        Bitmap img;
        private string path = AppDomain.CurrentDomain.BaseDirectory.ToString();
        FormText Form2;


        public Form1()
        {
            InitializeComponent();
        }
        private Bitmap captureArea(Control control)
        {
            Size size = control.ClientSize;
            Bitmap tmpBmp = new Bitmap(size.Width, size.Height);
            Graphics g;
            g = Graphics.FromImage(tmpBmp);
            g.CopyFromScreen(control.PointToScreen(new Point(0, 0)), new Point(0, 0), new Size(size.Width, size.Height));
            return tmpBmp;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form2 = new FormText();

            img = captureArea(pictureBox1);
            string pathImage = path+"\\image.png";
            img.Save(pathImage, System.Drawing.Imaging.ImageFormat.Png);
            Tesseract tesseract = new Tesseract(path, "eng", OcrEngineMode.TesseractLstmCombined);
            tesseract.SetImage(new Image<Bgr, byte>(pathImage));
            tesseract.Recognize();
            Form2.richTextBox1.Text = tesseract.GetUTF8Text();
            Form2.Show();
            img.Dispose();


        }
    }
}
