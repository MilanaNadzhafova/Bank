using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank
{
    public partial class Calculator : Form
    {
        string FirstIncomeStr, SecondIncomeStr, ThirdIncomeStr, StartSum,Period;
        string TextFirst, TextSecond, TextThird;
        public Calculator()
        {
            InitializeComponent();
            TextFirst = "600000";
            TextSecond = "365";
            TextThird = "0";
            CountTime.Start();

        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
            GC.Collect();
            Rates rate = new Rates();
            rate.Visible = true;
            rate.ShowInTaskbar = true;
        }

        private void TrackBarSum_ValueChanged(object sender, EventArgs e)
        {
            TxtForSum.Text = TrackBarSum.Value.ToString();
        }

        private void TxtForSum_TextChanged(object sender, EventArgs e)
        {
            int check =0;
            try
            {
                check = Convert.ToInt32(TxtForSum.Text);
                TrackBarSum.Value = check;
            }
            catch
            {
               if(check > 10000000) TxtForSum.Text = "10000000";
            }
            TextFirst = TxtForSum.Text;
            

        }

        private void TxtForSum_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number!= 8) e.Handled = true;
        }

        private void TxtForSum_Validated(object sender, EventArgs e)
        {
            if (TxtForSum.Text == "") TxtForSum.Text = "0";
        }

        private void TrackBarForDays_ValueChanged(object sender, EventArgs e)
        {
            TxtForDays.Text = TrackBarForDays.Value.ToString();
        }

        private void TxtForDays_TextChanged(object sender, EventArgs e)
        {
            int check = 0;
            try
            {
                check = Convert.ToInt32(TxtForDays.Text);
                TrackBarForDays.Value = check;
            }
            catch
            {
                if(check> 1825) TxtForDays.Text = "1825";
            }
            TextSecond = TxtForDays.Text;
        }

        private void TxtForDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) e.Handled = true;
        }

        private void TxtForRep_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) e.Handled = true;
        }

        private void TrackBarForRep_ValueChanged(object sender, EventArgs e)
        {
            TxtForRep.Text = TrackBarForRep.Value.ToString();
        }

        private void TxtForRep_TextChanged(object sender, EventArgs e)
        {
            int check =0;
            try
            {
                check = Convert.ToInt32(TxtForRep.Text);
                TrackBarForRep.Value = check;
            }
            catch
            {
                if (check > 5000000) TxtForRep.Text = "5000000";
            }
            if (TxtForDays.Text == "30") TxtForRep.Text = "0";
            TextThird = TxtForRep.Text;
            
        }

        private void TxtForDays_Validated(object sender, EventArgs e)
        {
            if (TxtForDays.Text == "") TxtForDays.Text = "0";
        }

        private void TxtForRep_Validated(object sender, EventArgs e)
        {
            if (TxtForRep.Text == "") TxtForRep.Text = "0";
        }

        private void CountTime_Tick(object sender, EventArgs e)
        {
            TextUpdate();
            FirstIncomeStr = FirstIncome.Text;
            SecondIncomeStr = SecondIncome.Text;
            ThirdIncomeStr = ThirdIncome.Text;
            StartSum = TxtForSum.Text;
            Period = TxtForDays.Text;
        }

        private void CompareParametersBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            GC.Collect();
            CompareDeposits comp = new CompareDeposits();
            comp.Write(FirstIncomeStr, SecondIncomeStr, ThirdIncomeStr, StartSum,Period);
            comp.Show();
        }
          public void TextUpdate()
        {
            try
            {
                if (TextFirst == "") TextFirst = "1000";
                if (TextSecond == "") TextSecond = "30";
                if (TextThird == "") TextThird = "0";
                if (Convert.ToInt32(TextFirst) < 1000) TextFirst = "1000";
                if (Convert.ToInt32(TextSecond) < 30) TextFirst = "30";
                int InitialSum =0, Time =0 , Replenishment =0;
                try { InitialSum = Convert.ToInt32(TextFirst);} catch { InitialSum = 1000; }
                try { Time = Convert.ToInt32(TextSecond); } catch { Time = 30; }
                try { Replenishment = Convert.ToInt32(TextThird); } catch { Replenishment = 0; }
                double Result =0;
                double Result_Second = 0;
                double Result_Third = 0;

                if (Replenishment != 0)
                {
                    int Count = (int)(Time / 30);
                    Result = InitialSum * 0.08 / 366 * 30;
                    Result_Second = InitialSum * 0.05 / 366 * 30;
                    Result_Third = InitialSum * 0.06 / 366 * 30;
                    for (int i = 1; i < Count; i++)
                    {
                        Result += (InitialSum + Replenishment) * 0.08 / 366 * 30;
                        Result_Second += (InitialSum + Replenishment) * 0.05 / 366 * 30;
                        Result_Third += (InitialSum + Replenishment) * 0.06 / 366 * 30;
                    }

                    int day = Time - Count * 30;
                    Result += (InitialSum + Replenishment) * 0.08 / 366 * day;
                    Result_Second += (InitialSum + Replenishment) * 0.05 / 366 * day;
                    Result_Third += (InitialSum + Replenishment) * 0.06 / 366 * day;
                }
                else
                {
                    Result = InitialSum * 0.08 / 366 * Time;
                    Result_Second = InitialSum * 0.05 / 366 * Time;
                    Result_Third = InitialSum * 0.06 / 366 * Time;
                }
                
                FirstIncome.Text = Math.Round(Result,0).ToString();
                SecondIncome.Text = Math.Round(Result_Second, 0).ToString();
                ThirdIncome.Text = Math.Round(Result_Third, 0).ToString();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


    }
}
