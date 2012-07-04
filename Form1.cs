using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GetFNTV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int interest = Convert.ToInt32(textBox1.Text);
                double sum = 0.0f;
                String[] strs = textBox2.Text.Split(',');
                for (int i = 0; i < strs.Length; i++)
                {
                    sum += int.Parse(strs[i]) * Math.Round(1 / getValue((double)interest, i + 1), 4);
                    //Console.WriteLine(strs[i] + "X" + (Math.Round(1 / getValue(interest, i + 1), 4)).ToString());
                }
                textBox3.Text = sum.ToString();
            }
            catch
            {
                MessageBox.Show("请检查输入的数据是否正确!");
                textBox1.Focus();
            }
        }
        private double getValue(double val, int number)
        {
            double result = 1;

            double tempValue = 1 + val / 100;
            for (int i = 1; i <= number; i++)
            {
                result *= tempValue;
            }
            return Math.Round(result, 4);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            double sum = 0.0f;
            String[] strs = textBox2.Text.Split(',');
            List<Model> list = new List<Model>();
            for (double j = 1.0; j <= 20; j+=0.01)
            {
                sum = 0;
                for (int i = 0; i < strs.Length; i++)
                {
                    sum += int.Parse(strs[i]) * Math.Round(1 / getValue(j, i + 1), 4);
                    //Console.WriteLine(strs[i] + "X" + (Math.Round(1 / getValue(interest, i + 1), 4)).ToString());
                }
                if (sum > 0)
                {
                    textBox4.Text =Math.Round(j,2).ToString();
                }
                else
                {
                    break;
                }
            }
            //textBox3.Text = sum.ToString();
        }


    }
    public class Model
    {
        public int id { get; set; }
        public double value { get; set; }
    }
}
