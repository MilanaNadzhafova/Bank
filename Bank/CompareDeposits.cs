using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Bank.Properties;

namespace Bank
{
    public partial class CompareDeposits : Form
    {
        string PeriodDays,SumStart;
        public CompareDeposits()
        {
            InitializeComponent();
        }
        public void Write(string FirstIncome, string SecondIncome, string ThirdIncome, string StartSum, string Period)
        {
            LabFirstIncome.Text = FirstIncome;
            LabSecondIncome.Text = SecondIncome;
            LabThirdIncome.Text = ThirdIncome;
            LabFirstSumEnd.Text = (Convert.ToInt32(FirstIncome) + Convert.ToInt32(StartSum)).ToString();
            LabSecondSumEnd.Text = (Convert.ToInt32(SecondIncome) + Convert.ToInt32(StartSum)).ToString();
            LabThirdSumEnd.Text = (Convert.ToInt32(ThirdIncome) + Convert.ToInt32(StartSum)).ToString();
            PeriodDays = Period;
            SumStart = StartSum; ;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
            GC.Collect();
            Calculator calc = new Calculator();
            calc.Show();
        }

        private void OpenFirstDepositBtn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.ShowInTaskbar = false;
            Autorization autorization = new Autorization();
            string SumEnd = LabFirstSumEnd.Text;
            autorization.GetParameters(SumEnd, PeriodDays, "8",SumStart);
            autorization.Show();
        }

        private void OpenSecondDepositBtn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.ShowInTaskbar = false;
            Autorization autorization = new Autorization();
            string SumEnd = LabSecondSumEnd.Text;
            autorization.GetParameters(SumEnd, PeriodDays, "5", SumStart);
            autorization.Show();
        }

        private void OpenThirdDepositBtn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.ShowInTaskbar = false;
            Autorization autorization = new Autorization();
            string SumEnd = LabThirdSumEnd.Text;
            autorization.GetParameters(SumEnd, PeriodDays, "6", SumStart);
            autorization.Show();
        }

        private void CreateExtractBtn_Click(object sender, EventArgs e)
        {
            CreatePdfDoc();
        }
        private void CreatePdfDoc()
        {
            string FirstCell, SecondCell, ThirdCell, FourthCell;
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            PdfWriter.GetInstance(doc, new FileStream(@"C:\Users\temch\Desktop\Выписка.pdf", FileMode.Create));
            doc.Open();
            BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\Calibri.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL,BaseColor.GRAY);
            PdfPTable table = new PdfPTable(4);
            PdfPCell[] cells = new PdfPCell[4];
            cells[0] = new PdfPCell(new Phrase($"Название", font));
            cells[1] = new PdfPCell(new Phrase($"Доход", font));
            cells[2] = new PdfPCell(new Phrase($"Сумма к концу срока", font));
            cells[3] = new PdfPCell(new Phrase($"Ставка", font));
            foreach (var el in cells)
            {
                el.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                el.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                el.Border = 0;
            }
            var row = new PdfPRow(cells);
            table.Rows.Add(row);
            AddPicture(table);
            font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            FirstCell = "Стабильный";
            SecondCell = LabFirstIncome.Text;
            ThirdCell = LabFirstSumEnd.Text;
            FourthCell = "8% ";
            AddRow(table,FirstCell,SecondCell,ThirdCell,FourthCell,font);
            AddPicture(table);
            FirstCell = "Оптимальный";
            SecondCell = LabSecondIncome.Text;
            ThirdCell = LabSecondSumEnd.Text;
            FourthCell = "5% ";
            AddRow(table,FirstCell,SecondCell,ThirdCell,FourthCell,font);
            AddPicture(table);
            FirstCell = "Стандарт";
            SecondCell = LabThirdIncome.Text;
            ThirdCell = LabThirdSumEnd.Text;
            FourthCell = "6% ";
            AddRow(table, FirstCell, SecondCell, ThirdCell, FourthCell,font);
            AddPicture(table);
            doc.Add(table);
            doc.Close();
            MessageBox.Show("Pdf-документ сохранен");
        }
        public void AddPicture(PdfPTable table)
        {
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(@"..\\..\\Resources\Полосочка.jpg");
            var cells = new PdfPCell[4];
            cells[0] = new PdfPCell(image);
            image.ScalePercent(45);
            cells[0].PaddingLeft = -60;
            cells[0].PaddingTop = 10;
            cells[0].Border = 0;
            cells[0].Colspan = 4;
            var row = new PdfPRow(cells);
            table.Rows.Add(row);
        }
        public void AddRow(PdfPTable table, string CellName1, string CellName2, string CellName3, string CellName4, iTextSharp.text.Font font)
        {
            
            var cells = new PdfPCell[4];
            cells[0] = new PdfPCell(new Phrase(CellName1, font));
            cells[1] = new PdfPCell(new Phrase(CellName2+" Руб.", font));
            cells[2] = new PdfPCell(new Phrase(CellName3+" Руб.", font));
            cells[3] = new PdfPCell(new Phrase(CellName4 + "Руб.", font));
            foreach (var el in cells)
            {
                el.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                el.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                el.Border = 0;
                el.PaddingTop = 20;
                el.PaddingBottom = 20;
            }
             var row = new PdfPRow(cells);
             table.Rows.Add(row);
        }
    }
}
