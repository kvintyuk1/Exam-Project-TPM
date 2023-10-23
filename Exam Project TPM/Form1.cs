﻿using CalcClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam_Project_TPM
{
    public partial class Form1 : Form
    {
        private string _expr = "";
        private int _memory = 0;
        private int _result = 0;
        private bool _error = false;

        public Form1()
        {
            InitializeComponent();
        }
        private void expressionBox_TextChanged(object sender, EventArgs e)
        {
            _expr = expressionBox.Text;
        }

        private void leftBraceButton_Click(object sender, EventArgs e)
        {
            _expr += "(";
            expressionBox.Text = _expr;
        }
        private void rightBraceButton_Click(object sender, EventArgs e)
        {
            _expr += ")";
            expressionBox.Text = _expr;
        }
        private void backspaceButton_Click(object sender, EventArgs e)
        {
            if (_expr.Length > 0)
            {
                _expr = _expr.Remove(_expr.Length - 1);
                expressionBox.Text = _expr;
            }
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            _expr = "";
            expressionBox.Text = "";
            resultBox.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _expr += "1";
            expressionBox.Text = _expr;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            _expr += "2";
            expressionBox.Text = _expr;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            _expr += "3";
            expressionBox.Text = _expr;
        }
        private void buttonDiv_Click(object sender, EventArgs e)
        {
            _expr += "/";
            expressionBox.Text = _expr;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            _expr += "4";
            expressionBox.Text = _expr;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            _expr += "5";
            expressionBox.Text = _expr;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            _expr += "6";
            expressionBox.Text = _expr;
        }
        private void buttonMul_Click(object sender, EventArgs e)
        {
            _expr += "*";
            expressionBox.Text = _expr;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            _expr += "7";
            expressionBox.Text = _expr;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            _expr += "8";
            expressionBox.Text = _expr;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            _expr += "9";
            expressionBox.Text = _expr;
        }
        private void buttonSub_Click(object sender, EventArgs e)
        {
            _expr += "-";
            expressionBox.Text = _expr;
        }
        private void buttonDot_Click(object sender, EventArgs e)
        {
            _expr += ",";
            expressionBox.Text = _expr;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            _expr += "0";
            expressionBox.Text = _expr;
        }
        private void buttonMod_Click(object sender, EventArgs e)
        {
            _expr += "%";
            expressionBox.Text = _expr;
        }
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            _expr += "+";
            expressionBox.Text = _expr;
        }
        private void buttonMR_Click(object sender, EventArgs e)
        {
            _result = _memory;
        }

        private void buttonMPlus_Click(object sender, EventArgs e)
        {
            _memory += _result;
        }

        private void buttonMC_Click(object sender, EventArgs e)
        {
            _memory = 0;
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            resultBox.Text = Equals();
        }

        private string Equals()
        {
            _expr = expressionBox.Text;
            if (!string.IsNullOrEmpty(_expr))
            {
                string res = ExpressionEvaluator.Estimate(_expr);
                char[] tmpChr = res.ToCharArray();
                foreach (var item in tmpChr)
                    if (char.IsLetter(item))
                    {
                        _error = true;
                        break;
                    }
                return res;
            }
            else
                return expressionBox.Text;
        }

        private void buttonABSOrIABS_Click(object sender, EventArgs e)
        {
            string res = Equals();
            if (!string.IsNullOrEmpty(res) && !_error)
            {
                int tmpInt = Convert.ToInt32(res);
                if (tmpInt > 0)
                    resultBox.Text = "-" + res;
                else
                    resultBox.Text = res.Remove(0, 1);
            }
            else
                resultBox.Text = res;
        }
    }
}