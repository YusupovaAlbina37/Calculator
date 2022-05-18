using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7_я_лаба_ТРПО
{
    public partial class Form1 : Form
    {
        public string oper; //операция  
        public string Num1; 
        public bool Num2_flag; // если принимает значение true, значит первое число введено и сейчас будет вводиться второе число
        public bool minus = false; 
        public Form1()
        {
            Num2_flag = false;
            InitializeComponent();
        }

        private void btn_num0_Click(object sender, EventArgs e) //обработчик события "нажатие на цифру"
        {
            if(Num2_flag)
            {
                Num2_flag = false;
                tb_out.Text = "0";
            }
            Button B = (Button)sender;
            if (tb_out.Text == "0")
                tb_out.Text = B.Text;
            else
                tb_out.Text = tb_out.Text + B.Text;

        }

        private void btn_clean_Click(object sender, EventArgs e) //полностью очистить 
        {
            tb_out.Text = "0";
        }

        private void btn_plus_Click(object sender, EventArgs e) // обработчик событий: нажать на кнопку "+", нажать на кнопку "-", нажать на кнопку "х", нажать на кнопку "÷", нажать кнопку "x^y", нажать на кнопку "%"
        {
            Button B = (Button)sender;
            oper = B.Text;
            Num1 = tb_out.Text;
            Num2_flag = true;
        }

        private void btn_equa_Click(object sender, EventArgs e) // равно
        {
            double dnum1, dnum2, res;
            res = 0;
            dnum1 = Convert.ToDouble(Num1);
            dnum2 = Convert.ToDouble(tb_out.Text);
            if (oper == "+")
                res = dnum1 + dnum2;
            if (oper == "-")
                res = dnum1 - dnum2;
            if (oper == "x")
                res = dnum1 * dnum2;
            if (oper == "÷")
                res = dnum1 / dnum2;
            if (oper=="x^y")
                res = Math.Pow(dnum1, dnum2);
            if (oper == "%")
            {
                res = Math.Abs(dnum1) % Math.Abs(dnum2);
                if (((dnum1<0)&&(dnum2>0)&&(-dnum1!=dnum2))||((dnum1 > 0) && (dnum2 < 0)&&(dnum1!=-dnum2))) minus = true;
            }
             oper = "num";
            Num2_flag = true;
            if (minus)
                tb_out.Text = "-" + res.ToString();
            else tb_out.Text = res.ToString();
        }

        private void btn_sqrt_Click(object sender, EventArgs e) //квадратный корень числа
        {
            double d_cur_num, res;
            d_cur_num = Convert.ToDouble(tb_out.Text);
            if (tb_out.Text.Contains("-"))
            {
                tb_out.Text = "Ошибка";
                Num2_flag = true;
            }
            else
            {
                res = Math.Sqrt(d_cur_num);
                tb_out.Text = res.ToString();
            }
        }

        private void btn_1div_Click(object sender, EventArgs e) // 1 разделить на число
        {
            double d_cur_num, res;
            d_cur_num = Convert.ToDouble(tb_out.Text);
            res = 1/d_cur_num;
            tb_out.Text = res.ToString();
        }

        private void btn_sign_Click(object sender, EventArgs e) //знак
        {
            double d_cur_num, res;
            d_cur_num = Convert.ToDouble(tb_out.Text);
            res = - d_cur_num;
            tb_out.Text = res.ToString();
        }

        private void btn_comma_Click(object sender, EventArgs e) //запятая
        {
            if (!tb_out.Text.Contains(","))
                tb_out.Text = tb_out.Text + ",";
        }

        private void btn_del_Click(object sender, EventArgs e) //удаление последнего символа
        {
            tb_out.Text = tb_out.Text.Substring(0, tb_out.TextLength - 1);
            if (tb_out.Text == "")
                tb_out.Text = "0";
        }

        private void btn_fact_Click(object sender, EventArgs e) //факториал
        {
            double d_cur_num, res;
            res = 1;
            d_cur_num = Convert.ToDouble(tb_out.Text);
            if (tb_out.Text.Contains("-"))
            {
                tb_out.Text = "Ошибка";
                Num2_flag = true;
            }
            else
            {
                for (int i = 1; i <= d_cur_num; i++)
                {
                    res = res * i;
                }
                tb_out.Text = res.ToString();
            }
        }

        //логарифмические функции
        private void btn_log_Click(object sender, EventArgs e) //десятичный логарифм
        {
            double d_cur_num, res;
            d_cur_num = Convert.ToDouble(tb_out.Text);
            if (tb_out.Text.Contains("-") || tb_out.Text == "0")
            {
                tb_out.Text = "Ошибка";
                Num2_flag = true;
            }
            else
            {
                res = Math.Log10(d_cur_num);
                tb_out.Text = res.ToString();
            }
        }

        private void btn_ln_Click(object sender, EventArgs e) //натуральный логарифм
        {
            double d_cur_num, res;
            d_cur_num = Convert.ToDouble(tb_out.Text);
            if (tb_out.Text.Contains("-") || tb_out.Text == "0")
            {
                tb_out.Text = "Ошибка";
                Num2_flag = true;
            }
            else
            {
                res = Math.Log(d_cur_num);
                tb_out.Text = res.ToString();
            }
        }

        //тригонометрические функции
        private void btn_sin_Click(object sender, EventArgs e)
        {
            double d_cur_num, res;
            d_cur_num = Convert.ToDouble(tb_out.Text) * (Math.PI) / 180;
            res = Math.Sin(d_cur_num);
            tb_out.Text = res.ToString();
            
        }

        private void btn_cos_Click(object sender, EventArgs e)
        {
            double d_cur_num, res;
            d_cur_num = Convert.ToDouble(tb_out.Text) * (Math.PI) / 180;
            res = Math.Cos(d_cur_num);
            tb_out.Text = res.ToString();
        }

        private void btn_tg_Click(object sender, EventArgs e)
        {
            double d_cur_num, res;
            d_cur_num = Convert.ToDouble(tb_out.Text) * (Math.PI) / 180;
            res = Math.Tan(d_cur_num);
            tb_out.Text = res.ToString();
        }

        private void btn_ctg_Click(object sender, EventArgs e)
        {
            double d_cur_num, res;
            d_cur_num = Convert.ToDouble(tb_out.Text) * (Math.PI) / 180;
            res = Math.Pow(Math.Tan(d_cur_num), -1);
            tb_out.Text = res.ToString();
        }
    }
 }