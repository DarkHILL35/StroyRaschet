using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows.Forms;
using System.Data;
using System.Runtime.CompilerServices;

namespace StroyRaschet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double price = 0;
            if (comboBox1.SelectedItem != null)
            { 
                if (comboBox1.SelectedIndex == 0)
                { price = 10; }
                if (comboBox1.SelectedIndex == 1)
                { price = 15; }
                if (comboBox1.SelectedIndex == 2)
                { price = 25; }
            }

            double query = Convert.ToDouble(textBox1.Text);

            double totalprice = price * query;

            BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

            iTextSharp.text.Document doc = new iTextSharp.text.Document();

            //Создаем объект записи пдф-документа в файл
            PdfWriter.GetInstance(doc, new FileStream("Смета_стройматериалов.pdf", FileMode.Create));
            doc.Open();

                        PdfPTable table = new PdfPTable(2);

                        PdfPCell cell = new PdfPCell(new Phrase("Здесь будет текст договора и реквизиты"));

                        cell.Colspan = 2;
                        cell.HorizontalAlignment = 1;

                        cell.Border = 0;
                        table.AddCell(cell);

                        cell = new PdfPCell(new Phrase(new Phrase("Название столбцов", font)));
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table.AddCell(cell);
                        cell = new PdfPCell(new Phrase(new Phrase("Название столбцов", font)));
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table.AddCell(cell);
                        table.AddCell(new Phrase(comboBox1.Text, font));
                        table.AddCell(new Phrase(totalprice.ToString(), font));
                        doc.Add(table);
            doc.Close();

            MessageBox.Show("Pdf-документ сохранен");
        }
            
        }
    }