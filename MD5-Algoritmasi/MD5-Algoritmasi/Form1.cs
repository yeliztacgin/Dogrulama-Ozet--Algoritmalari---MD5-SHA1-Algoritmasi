using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace MD5_Algoritmasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text) 
            {
                case "Ceaser":
                   
                 label1.Text = Ceaser(textBox1.Text, int.Parse(textBox2.Text));
                break;

                case "MD5":

                    label1.Text = md5(textBox1.Text);
                     break;

                case "SHA1":

                    label1.Text = sha1(textBox1.Text);
                    break;

                default:
                    MessageBox.Show("Select any options in the combobox","Program",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;

            }
        }
        private static string Ceaser(string text, int key)
        {
            ///key=3 A=65+3=68=D   B=66+3=69=E C=67+3=70=F
            StringBuilder builder = new StringBuilder();
            foreach (char item in text)
            {
                builder.Append(Convert.ToChar(Convert.ToInt32(item) + key));
            }



            return builder.ToString();
        }
        private string md5(string text)
        {

            MD5 md5Encrypting = new MD5CryptoServiceProvider();
            byte[] bytes = md5Encrypting.ComputeHash(Encoding.UTF8.GetBytes(text.ToCharArray()));
            StringBuilder builder = new StringBuilder();
            foreach (var item in bytes)
            {
                builder.Append(item.ToString("x2"));
            }
            
            return builder.ToString();
        }
        private string sha1(string text)
        {
            SHA1 sha1Encrypting = new SHA1CryptoServiceProvider();
            byte[] bytes=sha1Encrypting.ComputeHash(Encoding.UTF8.GetBytes(text.ToCharArray()));
            StringBuilder builder = new StringBuilder();
            foreach (var item in bytes)
            {
                builder.Append(item.ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
