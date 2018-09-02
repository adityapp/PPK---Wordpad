using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tugas1___Wordpad
{
    public partial class Form1 : Form
    {
        private Boolean italic = false;
        private Boolean bold = false;
        private Boolean underline = false;
        private float[] fontSize = {8,9,10,11,12,14,16,18,20,22,24,26,28,36,48,72};

        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_1054_1_Click(object sender, EventArgs e)
        {
            richTextBox_1054_main.Clear();
        }

        private void saveAsToolStripMenuItem_1054_1_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text Files|*.txt";
            save.Title = "Save As a File";
            if (save.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(save.FileName);
                sw.Write(richTextBox_1054_main.Text);
                sw.Close();
            }
        }

        private void exitToolStripMenuItem_1054_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_1054_1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Text Files|*.txt";
            open.Title = "Open a File";
            if (open.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(open.FileName);
                richTextBox_1054_main.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void comboBox_1054_fontStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                richTextBox_1054_main.SelectionFont = new Font(comboBox_1054_fontStyle.Text, float.Parse(comboBox_1054_fontSize.Text));
            }
            catch
            {
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(var item in fontSize)
            {
                comboBox_1054_fontSize.Items.Add(item);
            }
            foreach (var item in FontFamily.Families)
            {
                comboBox_1054_fontStyle.Items.Add(item.Name);
            }
            comboBox_1054_fontStyle.Text = this.richTextBox_1054_main.Font.Name.ToString();
            comboBox_1054_fontSize.Text = this.richTextBox_1054_main.Font.Size.ToString();
        }

        private void button_1054_bold_Click(object sender, EventArgs e)
        {
            bold = styling(bold, FontStyle.Bold);
        }

        private void button_1054_italic_Click(object sender, EventArgs e)
        {
            italic = styling(italic, FontStyle.Italic);
        }

        private void button_1054_underline_Click(object sender, EventArgs e)
        {
            underline = styling(underline, FontStyle.Underline);
        }

        private void button_1054_left_Click(object sender, EventArgs e)
        {
            richTextBox_1054_main.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void button_1054_center_Click(object sender, EventArgs e)
        {
            richTextBox_1054_main.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void button_1054_right_Click(object sender, EventArgs e)
        {
            richTextBox_1054_main.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void button_1054_justify_Click(object sender, EventArgs e)
        {
            richTextBox_1054_main.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void button_1054_insertImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image File |*.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                using (var img = Image.FromFile(open.FileName))
                {
                    Clipboard.SetImage(img);
                    richTextBox_1054_main.Paste();
                }
            }
        }

        private Boolean styling(Boolean value, FontStyle fontStyle)
        {
            try
            {
                if (value)
                {
                    richTextBox_1054_main.SelectionFont = new Font(richTextBox_1054_main.SelectionFont, richTextBox_1054_main.SelectionFont.Style & ~fontStyle);
                    value = false;
                }
                else
                {
                    richTextBox_1054_main.SelectionFont = new Font(richTextBox_1054_main.SelectionFont, richTextBox_1054_main.SelectionFont.Style | fontStyle);
                    value = true;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return value;
        }

        private void comboBox_1054_fontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                richTextBox_1054_main.SelectionFont = new Font(comboBox_1054_fontStyle.Text, float.Parse(comboBox_1054_fontSize.Text));
            }
            catch
            {
            }
        }

        private void button_1054_paste_Click(object sender, EventArgs e)
        {
            richTextBox_1054_main.Paste();
        }

        private void button_1054_cut_Click(object sender, EventArgs e)
        {
            richTextBox_1054_main.Cut();
        }

        private void button_1054_copy_Click(object sender, EventArgs e)
        {
            richTextBox_1054_main.Copy();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox_1054_main.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox_1054_main.Redo();
        }

        private void panel_1054_panel_Click(object sender, EventArgs e)
        {
            
        }

        private void button_1054_color_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            DialogResult colors = colorDialog.ShowDialog();
            if (colors == DialogResult.OK)
            {
                panel_1054_color.BackColor = colorDialog.Color;
                richTextBox_1054_main.SelectionColor = colorDialog.Color;
            }
        }
    }
}
