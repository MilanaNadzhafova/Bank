using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task = System.Threading.Tasks.Task;
using Word = Microsoft.Office.Interop.Word;

namespace Bank
{
    public partial class PersonalAccount : Form
    {
        
        int UserId;
        int SumEnd,SumStart, Period, Percent;
        System.Data.DataTable table;
        List<string> DocParameters;

        public PersonalAccount(int Id,int GetSumEnd,int GetPeriod,int GetPercent,int GetSumStart)
        {
            InitializeComponent();
            UserId = Id;
            SumStart = GetSumStart;
            SumEnd = GetSumEnd;
            Period = GetPeriod;
            Percent = GetPercent;
            InfoUser();
            InfoDocument();
            AddContractSql();
            InformationForWord();
            CreateWordDocument();
        }
        private void PersonalAccount_Load(object sender, EventArgs e)
        {

        }
        private void InfoUser()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=AYE\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True"))
            {

                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT [Name], [Surname],[Patronymic],[Phone],[Adress],[E-Mail],[DateOfBirth],[PlaceOfBirth] FROM [User] WHERE [IDUser] = @IdUser ";
                    cmd.Parameters.AddWithValue(@"IdUser", UserId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    table = new System.Data.DataTable();
                    table.Load(reader);
                    reader.Close();
                    Head.Text = table.Rows[0][1].ToString()+" "+ table.Rows[0][0].ToString()+" "+ table.Rows[0][2].ToString();
                    LabAdress.Text = table.Rows[0][4].ToString();
                    LabPhone.Text = table.Rows[0][3].ToString();
                    LabEmail.Text = table.Rows[0][5].ToString();
                    LabDataOfBirth.Text = (table.Rows[0][6].ToString());
                    LabDataOfBirth.Text = LabDataOfBirth.Text.Remove(10); 
                    LabPlaceOfBirth.Text = table.Rows[0][7].ToString();
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
        }
        private void InfoDocument()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=AYE\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True"))
            {

                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    SqlCommand cmd_1 = conn.CreateCommand();
                    cmd.CommandText = "SELECT [NumberAccount] FROM [BankAccount] WHERE [UserID] =@UserId ";
                    cmd.Parameters.AddWithValue(@"UserId", UserId);
                    string Doc = cmd.ExecuteScalar().ToString();
                    RichMyCount.Text = "\n\n      " + Doc;
                    cmd_1.CommandText = "SELECT h.[NameOperation],h.[DateTime],h.[Amount], b.[Balance] FROM [History] AS h " +
                       "" +
                       "INNER JOIN [BankAccount] AS b ON h.[NumberAccount] = b.[NumberAccount] WHERE h.[NumberAccount] =  @NumAcc";
                    cmd_1.Parameters.AddWithValue(@"NumAcc", Doc);
                    SqlDataReader reader = cmd_1.ExecuteReader();
                    table = new System.Data.DataTable();
                    table.Load(reader);
                    reader.Close();
                    if (table.Rows.Count != 0)
                    {
                        int CountRows = table.Rows.Count;
                        CountRows -= 1;
                        RichMyHistory.Text = "\n Операция           Дата          Сумма       Остаток \n";
                        RichMyHistory.Text += $"\n {table.Rows[CountRows][0]}  {table.Rows[CountRows][1].ToString().Remove(10)}    {table.Rows[CountRows][2]}     {table.Rows[CountRows][3]} \n";
                    } else RichMyHistory.Text = "\n     У вас еще нет ни одной операции";
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
        }
        private void AddContractSql()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=AYE\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True"))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    SqlCommand cmd_1 = conn.CreateCommand();
                    cmd_1.CommandText = "SELECT [NumberAccount] FROM [BankAccount] WHERE [UserID] =@UserId ";
                    cmd_1.Parameters.AddWithValue(@"UserId", UserId);
                    string Doc = cmd_1.ExecuteScalar().ToString();
                    DateTime date = DateTime.Now;
                    date = date.AddDays(Period); 
                    cmd.CommandText = "INSERT INTO [Contract] VALUES (@Account,@UserId,@SumEnd,@Period,@Date,@Percent)";
                    cmd.Parameters.AddWithValue(@"Account",Doc);
                    cmd.Parameters.AddWithValue(@"UserId", UserId);
                    cmd.Parameters.AddWithValue(@"SumEnd", SumEnd);
                    cmd.Parameters.AddWithValue(@"Period", Period);
                    cmd.Parameters.AddWithValue(@"Date", date);
                    cmd.Parameters.AddWithValue(@"Percent", Percent);
                    cmd.ExecuteNonQuery();
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
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            if (table.Rows.Count != 0)
            {
                if (table.Rows.Count != 1)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        if (table.Rows[i][1].ToString().Remove(10) == TxtForFind.Text)
                        {
                            RichMyHistory.Text = "\n Операция           Дата          Сумма       Остаток \n";
                            RichMyHistory.Text += $"\n {table.Rows[i][0]}  {table.Rows[i][1].ToString().Remove(10)}    {table.Rows[i][2]}     {table.Rows[i][3]} \n";
                        }
                    }
                }
            }
            else MessageBox.Show("У вас нет еще ни одной операции");
        }
        async private void CreateWordDocument()
        {
            await Task.Run(() =>
                {
                    _Document oDoc = null;
                    Word._Application oWord = new Word.Application();
                    try
                    {

                        string source = @"C:\Users\temch\Desktop\Договор.dotx";
                        oDoc = oWord.Documents.Add(source);
                        Word.Range markRange;
                        oDoc.Bookmarks["NumberDocument"].Range.Text = DocParameters[0];
                        markRange = oDoc.Bookmarks["Day"].Range;
                        markRange.Text = DocParameters[1];
                        markRange = oDoc.Bookmarks["Month"].Range;
                        markRange.Text = DocParameters[2];
                        markRange = oDoc.Bookmarks["Year"].Range;
                        markRange.Text = DocParameters[3];
                        markRange = oDoc.Bookmarks["Fio"].Range;
                        markRange.Text = DocParameters[4];
                        markRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        markRange.Underline = WdUnderline.wdUnderlineSingle;
                        markRange = oDoc.Bookmarks["SumIncome"].Range;
                        markRange.Text =  DocParameters[5];
                        markRange.Underline = WdUnderline.wdUnderlineSingle;
                        markRange = oDoc.Bookmarks["PeriodIncome"].Range;
                        markRange.Text =  DocParameters[6] ;
                        markRange.Underline = WdUnderline.wdUnderlineSingle;
                        markRange = oDoc.Bookmarks["DateEndIncome"].Range;
                        markRange.Text =DocParameters[7];
                        markRange.Underline = WdUnderline.wdUnderlineSingle;
                        markRange = oDoc.Bookmarks["Percent"].Range;
                        markRange.Text =  DocParameters[8] ;
                        markRange.Underline = WdUnderline.wdUnderlineSingle;
                        markRange = oDoc.Bookmarks["NumberAccount"].Range;
                        markRange.Text =  DocParameters[9] ;
                        markRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        markRange.Underline = WdUnderline.wdUnderlineSingle;
                        markRange = oDoc.Bookmarks["FioUser"].Range;
                        markRange.Text =  DocParameters[10] ;
                        markRange.Underline = WdUnderline.wdUnderlineSingle;
                        markRange = oDoc.Bookmarks["Address"].Range;
                        markRange.Text =  DocParameters[11] ;
                        markRange.Underline = WdUnderline.wdUnderlineSingle;
                        markRange = oDoc.Bookmarks["Email"].Range;
                        markRange.Text =  DocParameters[12];
                        markRange.Underline = WdUnderline.wdUnderlineSingle;
                        markRange = oDoc.Bookmarks["Series"].Range;
                        markRange.Text = DocParameters[13];
                        markRange.Underline = WdUnderline.wdUnderlineSingle;
                        markRange = oDoc.Bookmarks["NumberPassport"].Range;
                        markRange.Text = DocParameters[14];
                        markRange.Underline = WdUnderline.wdUnderlineSingle;
                        markRange = oDoc.Bookmarks["Issued"].Range;
                        markRange.Text = DocParameters[15];
                        markRange.Underline = WdUnderline.wdUnderlineSingle;
                        markRange = oDoc.Bookmarks["DateIssued"].Range; 
                        markRange.Text = DocParameters[16];
                        markRange.Underline = WdUnderline.wdUnderlineSingle;
                        markRange = oDoc.Bookmarks["DateOfBirth"].Range;
                        markRange.Text =  DocParameters[17] ;
                        markRange.Underline = WdUnderline.wdUnderlineSingle;
                        markRange = oDoc.Bookmarks["PlaceOfBirth"].Range;
                        markRange.Text = DocParameters[18];
                        markRange.Underline = WdUnderline.wdUnderlineSingle;
                        string pathToSaveObj = @"C:\Users\temch\Desktop\Контракт.docx";
                        oDoc.SaveAs2(pathToSaveObj);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        oDoc.Close();
                        oDoc = null;
                        oWord.Quit();
                    }
                });

        }

        private void InformationForWord()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=AYE\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True"))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    SqlCommand cmd_1 = conn.CreateCommand();
                    DocParameters = new List<string>();
                    cmd.CommandText = "SELECT MAX(IDContract) FROM [Contract]";
                    DocParameters.Add(cmd.ExecuteScalar().ToString());
                    DateTime DateToday = DateTime.Today;
                    DocParameters.Add(DateTime.Today.Day.ToString());
                    DocParameters.Add(DateTime.Today.Month.ToString());
                    DocParameters.Add(DateTime.Today.Year.ToString());
                    DocParameters.Add(Head.Text);
                    DocParameters.Add(SumStart.ToString());
                    DocParameters.Add(Period.ToString());
                    DocParameters.Add(DateToday.AddDays(Period).ToString().Remove(10));
                    DocParameters.Add(Percent.ToString()+"%");
                    DocParameters.Add(RichMyCount.Text.Trim());
                    DocParameters.Add(Head.Text);
                    DocParameters.Add(LabAdress.Text);
                    DocParameters.Add(LabEmail.Text);
                    cmd.CommandText = "SELECT [Series],[Number],[Issued],[DateOfIssue] FROM  [User] WHERE [IDUser] =@IdUser";
                    cmd.Parameters.AddWithValue(@"IdUser", UserId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if(reader.Read())
                    {
                        DocParameters.Add(reader.GetValue(0).ToString());
                        DocParameters.Add(reader.GetValue(1).ToString());
                        DocParameters.Add(reader.GetValue(2).ToString());
                        DocParameters.Add(reader.GetValue(3).ToString().Remove(10));
                    }
                    reader.Close();
                    DocParameters.Add(LabDataOfBirth.Text);
                    DocParameters.Add(LabPlaceOfBirth.Text);
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
        }
    }
}
