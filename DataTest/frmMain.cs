using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataTest
{
    public partial class frmMain : Form
    {

        clsT24Driver loadCell;

        private delegate void Set_TextBox_TextValue(ref TextBox your_textBox, string value);

        public void set_textbox_text_value(ref TextBox your_TextBox, string value)
        {
            if (your_TextBox != null)
            {
                if (your_TextBox.InvokeRequired)
                {
                    Set_TextBox_TextValue obj = new Set_TextBox_TextValue(set_textbox_text_value);
                    this.Invoke(obj, new object[] { your_TextBox, value });
                }
                else
                {
                    your_TextBox.Text = value + Environment.NewLine;
                    Application.DoEvents();
                }
            }
        }

        private delegate void Set_PictureBox_BackColor(ref PictureBox your_Picbox, Color backColor);

        public void set_picturebox_backcolor(ref PictureBox your_Picbox, Color backColor)
        {
            if (your_Picbox != null)
            {
                if (your_Picbox.InvokeRequired)
                {
                    Set_PictureBox_BackColor obj = new Set_PictureBox_BackColor(set_picturebox_backcolor);
                    this.Invoke(obj, new object[] { your_Picbox, backColor });
                }
                else
                {
                    your_Picbox.BackColor = backColor;
                    Application.DoEvents();
                }
            }
        }

        private delegate void Set_PictureBox_Image(ref PictureBox your_Picbox, Image indicator);

        public void set_picturebox_image(ref PictureBox your_Picbox, Image indicator)
        {
            if (your_Picbox != null)
            {
                if (your_Picbox.InvokeRequired)
                {
                    Set_PictureBox_Image obj = new Set_PictureBox_Image(set_picturebox_image);
                    this.Invoke(obj, new object[] { your_Picbox, indicator });
                }
                else
                {
                    your_Picbox.Image = indicator;
                    Application.DoEvents();
                }
            }
        }

        private delegate void Set_ProgressBar_Value(ref ProgressBar your_ProgressBar, int value);

        public void set_progressbar_value(ref ProgressBar your_ProgressBar, int value)
        {
            if (your_ProgressBar != null)
            {
                if (your_ProgressBar.InvokeRequired)
                {
                    Set_ProgressBar_Value obj = new Set_ProgressBar_Value(set_progressbar_value);
                    this.Invoke(obj, new object[] { your_ProgressBar, value });
                }
                else
                {
                    your_ProgressBar.Value = value;
                    Application.DoEvents();
                }
            }
        }

    

        private delegate void Set_Label_Text(ref Label your_Label, String text);
        public void set_label_text(ref Label your_Label, String text)
        {
            if (your_Label != null)
            {
                if (your_Label.InvokeRequired)
                {
                    Set_Label_Text obj = new Set_Label_Text(set_label_text);
                    this.Invoke(obj, new object[] { your_Label, text });
                }
                else
                {
                    your_Label.Text = text;
                    Application.DoEvents();
                }
            }
        }

        private delegate void Set_Toolstrip_Label_Text(ref ToolStripStatusLabel your_Label, String text);
        public void set_toolstrip_label_text(ref ToolStripStatusLabel your_Label, String text)
        {
            /*if (your_Label != null)
            {
                if (your_Label.InvokeRequired)
                {
                    Set_Toolstrip_Label_Text obj = new Set_Toolstrip_Label_Text(set_label_text);
                    this.Invoke(obj, new object[] { your_Label, text });
                 }
                 else
                 {*/
            your_Label.Text = text;
            //}
            //}
        }



        public frmMain()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            MessageBox.Show(loadCell.getVersion().ToString());
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            loadCell = new clsT24Driver();

            loadCell.initializeDriver();
        }

        private void btnOpenUSB_Click(object sender, EventArgs e)
        {
            Console.WriteLine("USB Status: " + loadCell.openUSB());
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
