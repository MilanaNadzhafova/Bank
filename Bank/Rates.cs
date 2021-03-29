using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace Bank
{
    public partial class Rates : Form
    {
        public Rates()
        {
            InitializeComponent();
           
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void CalculateBtn_Click(object sender, EventArgs e)
        {
           // CreateWordDocument();
            Calculator calculator = new Calculator();
            calculator.Show();
            this.Visible = false;
            this.ShowInTaskbar = false;
            


        }
        private void CreateWordDocument()
        {
            _Document oDoc =null;
            try
            {
                Word._Application oWord = new Word.Application();
                string source = @"C:\Users\temch\Desktop\Шаблон.dotx";
                 oDoc = oWord.Documents.Add(source);
                Word.Bookmarks wBookmarks = oDoc.Bookmarks;
                Word.Range wRange;
                string[] arr = { "27", "Tema", "Shevchenko" };
                int i = 0;
                foreach (Word.Bookmark mark in wBookmarks)
                {
                    wRange = mark.Range;
                    wRange.Text = arr[i];
                    i++;
                }
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
            }

        }
        private void LabDescriptionrateFirst_Click(object sender, EventArgs e)
        {

        }

        private void LabRateNameFirst_Click(object sender, EventArgs e)
        {

        }
    }
}
