using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordApp{
    public partial class Form1 : Form {
        private string generatedPassword;
        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {

        }
        private void label1_Click(object sender, EventArgs e) {
        }

        private void label2_Click(object sender, EventArgs e) {
        }
        private void label3_Click(object sender, EventArgs e) {
        }
        private void label4_Click(object sender, EventArgs e) {

        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e) {

        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e) {

        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e) {

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e) {

        }
        private void button1_Click_1(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(generatedPassword))
                Clipboard.SetText(generatedPassword);
        }
        private void button1_Click(object sender, EventArgs e) {
            int length = (int)numericUpDown1.Value;
            char[] character_list;
            if (radioButton1.Checked)
                character_list = PasswordGenerate.character_list1;
            else if (radioButton2.Checked)
                character_list = PasswordGenerate.character_list2;
            else
                character_list = PasswordGenerate.character_list3;
            generatedPassword = PasswordGenerate.PasswordGenerator1(length, character_list);
            textBox3.Text = generatedPassword;
            if (checkBox1.Checked)
                Clipboard.SetText(generatedPassword);
        }
    }
}
