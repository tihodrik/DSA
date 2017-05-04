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
using System.Numerics;

namespace DSA
{
    public partial class Form1 : Form
    {
        BigInteger paramQ { get; set; }
        BigInteger paramP { get; set; }
        BigInteger paramT { get; set; }

        BigInteger tmpQ;
        BigInteger tmpP;

        Sign s;

        public Form1()
        {
            InitializeComponent();
            tmpP = BigInteger.Zero;
            tmpQ = BigInteger.Zero;
            //paramQ = new BigInteger(int.MaxValue);
            //paramT = new BigInteger(524287);
            //paramP = paramQ * paramT + BigInteger.One;
            paramQ = new BigInteger(142433);
            paramT = new BigInteger(6);
            paramP = paramQ * paramT + BigInteger.One;
            
        }

        private void userInput_CheckedChanged(object sender, EventArgs e)
        {
            if (userInput.Checked)
            {
                userParams.Enabled = true;
            }
            else
            {
                userParams.Enabled = false;
            }
        }

        private void text_TextChanged(object sender, EventArgs e)
        {
            if (text.Text.Length != 0)
            {
                Generate.Enabled = true;
                if (gen.Text.Length != 0)
                {
                    Check.Enabled = true;
                }
            }
            else
            {
                Generate.Enabled = false;
                Check.Enabled = false;
            }
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            if (paramP <= paramQ)
            {
                message.Text = "Неверно заданы параметры";
                message.ForeColor = System.Drawing.Color.DeepPink;
                message.Visible = true;
            }
            else
            {
                P.Text = paramP.ToString();
                Q.Text = paramQ.ToString();
                s = new Sign(paramQ, paramP);
                StringBuilder SB = s.GenerateSign(text.Text);
                gen.Clear();
                gen.AppendText(SB.ToString());
                Check.Enabled = true;
            }
        }

        private void Q_TextChanged(object sender, EventArgs e)
        {
            message.Visible = false;
            if (Q.Text.Length != 0)
            {
                if (!BigInteger.TryParse(Q.Text, out tmpQ))
                {
                    wrongQ.Visible = true;
                }
                else
                {
                    paramQ = tmpQ;
                    wrongQ.Visible = false;
                }

            }
            else
            {
                paramQ = int.MaxValue;
                wrongQ.Visible = false;
            }
        }

        private void P_TextChanged(object sender, EventArgs e)
        {
            message.Visible = false;
            if (P.Text.Length != 0)
            {
                if (!BigInteger.TryParse(P.Text, out tmpP))
                {
                    wrongP.Visible = true;
                }
                else
                {
                    paramP = tmpP;
                    wrongP.Visible = false;
                }

            }
            else
            {
                paramP = paramQ * paramT + BigInteger.One;
                wrongP.Visible = false;
            }
        }

        private void Check_Click(object sender, EventArgs e)
        {
            StringBuilder SB = s.CheckSign(text.Text, gen.Lines, ref message);
            ch.Clear();
            ch.AppendText(SB.ToString());
        }
    }
}
