using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private string str;
        public Form1()
        {
            InitializeComponent();
            str = "";
        }

        private void Cac_Click(object sender, EventArgs e)
        {
            this.output.Text = Algorithm.GetValueByBack(Algorithm.MidToBack(Algorithm.DealInput(this.str))).ToString();
            this.str = this.output.Text;
        }


        private void Solts(string str)
        {
            this.str = this.str + str;
            this.input.Text = this.str;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Solts("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Solts("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Solts("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Solts("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Solts("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Solts("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Solts("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Solts("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Solts("9");
        }

        private void button0_Click(object sender, EventArgs e)
        {
            this.Solts("0");
        }

        private void button00_Click(object sender, EventArgs e)
        {
            this.Solts("00");
        }

        private void buttonPoint_Click(object sender, EventArgs e)
        {
            this.Solts(".");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.Solts("+");
        }

        private void buttonSub_Click(object sender, EventArgs e)
        {
            this.Solts("-");
        }

        private void buttonMulit_Click(object sender, EventArgs e)
        {
            this.Solts("*");
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            this.Solts("/");
        }

        private void buttonMod_Click(object sender, EventArgs e)
        {
            this.Solts("%");
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            this.Solts("(");
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            this.Solts(")");
        }

        private void zero_Click(object sender, EventArgs e)
        {
            this.str = "";
            this.output.Text = "";
            this.input.Text = "";
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (this.str.Length > 0)
            {
                this.str = this.str.Remove(this.str.Length - 1);
                this.input.Text = this.str;
            }
        }
    }
}
