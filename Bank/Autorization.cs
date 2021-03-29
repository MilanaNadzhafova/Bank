using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank
{
    public partial class Autorization : Form
    {
        int SumEnd, Period,Percent,StartSum;
        public Autorization()
        {
            InitializeComponent();
            TxtForPass.UseSystemPasswordChar = false;
            
        }
        

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
            GC.Collect();
            CompareDeposits compare = new CompareDeposits();
            compare.Show();
        }
        public void GetParameters( string GetSumEnd, string GetPeriod,string GetPercent,string GetStartSum)
        {
            StartSum = Convert.ToInt32(GetStartSum);
            SumEnd = Convert.ToInt32(GetSumEnd);
            Period = Convert.ToInt32(GetPeriod);
            Percent = Convert.ToInt32(GetPercent);
        }

        private void TxtForLogin_Click(object sender, EventArgs e)
        {
            if (TxtForLogin.Text == "Введите логин")
            {
                TxtForLogin.Text = "";
            }
            TxtForLogin.ForeColor = Color.Black;
        }

        private void TxtForPass_Click(object sender, EventArgs e)
        {
            if (TxtForPass.Text == "Введите пароль")
            {
                TxtForPass.Text = "";
                TxtForPass.UseSystemPasswordChar = true;
            }
            TxtForPass.ForeColor = Color.Black;
        }

        private void CompareParametersBtn_Click(object sender, EventArgs e)
        {
            if (TxtForPass.Text != "" && TxtForLogin.Text != "" && TxtForPass.Text != "Введите пароль" && TxtForLogin.Text != "Введите логин")
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=AYE\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True"))
                {
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = conn.CreateCommand();
                        cmd.CommandText = "SELECT [Password] FROM [User] WHERE [Login] = @Login ";
                        cmd.Parameters.AddWithValue(@"Login", TxtForLogin.Text);

                        if (cmd.ExecuteScalar() != null)
                        {
                            if (cmd.ExecuteScalar().ToString() == TxtForPass.Text)
                            {
                                SqlCommand cmd_2 = conn.CreateCommand();
                                cmd_2.CommandText = "SELECT [IDUser] FROM [User] WHERE [Login] = @login";
                                cmd_2.Parameters.AddWithValue(@"login", TxtForLogin.Text);
                                int IdUser = Convert.ToInt32(cmd_2.ExecuteScalar());
                                this.Close();
                                GC.Collect();
                                PersonalAccount personalAccount = new PersonalAccount(IdUser,SumEnd,Period,Percent,StartSum);
                                personalAccount.Show();

                            }
                            else MessageBox.Show("Неверный Пароль !!!");
                        }
                        else MessageBox.Show("Неверный Логин !!!");



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            } else MessageBox.Show("Вы не ввели данные!");

        }

        private void TxtForLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) e.Handled = true;
        }
    }
}
