using GeneratePDFWithiTextSharp.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace GeneratePDFWithiTextSharp.Report
{
    public class UniversityReport
    {
        #region Declaration
        int _totalColumn = 3;
        Document _document;
        Font _fontStyle;
        PdfPTable _pdfTable = new PdfPTable(3);
        PdfPCell _pdfPCell;
        MemoryStream _memoryStream = new MemoryStream();
        University _university = new University();
        #endregion

        public byte[] PrepareReport(University university)
        {
            _university = university;

            _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();
            _pdfTable.SetWidths(new float[] { 20f, 150f, 100f });

            this.ReportHeader();
            this.ReportBody();

            _pdfTable.HeaderRows = 2;
            _document.Add(_pdfTable);
            _document.Close();
            return _memoryStream.ToArray();
        }

        private void ReportBody()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _pdfPCell = new PdfPCell(UniversityInfo());
            _pdfPCell.Colspan = 2;
            _pdfPCell.Border = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _pdfPCell = new PdfPCell(UniversityAddress());
            _pdfPCell.Colspan = 2;
            _pdfPCell.Border = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Seri Numarası", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("İsim", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Sıra", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 0);
            int serialNumber = 1;
            foreach (Student student in _university.Students)
            {
                _pdfPCell = new PdfPCell(new Phrase(serialNumber++.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(student.Name, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(student.Roll, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);
                _pdfTable.CompleteRow();
            }

        }

        private PdfPTable UniversityAddress()
        {
            PdfPTable oPdfPTable = new PdfPTable(2);
            oPdfPTable.SetWidths(new float[] { 100f, 100f });


            _pdfPCell = new PdfPCell(new Phrase("Adres :", _fontStyle));
            _pdfPCell.Border = 0;
            oPdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_university.Address, _fontStyle));
            _pdfPCell.Border = 0;
            oPdfPTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Sehir :", _fontStyle));
            _pdfPCell.Border = 0;
            oPdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_university.City, _fontStyle));
            _pdfPCell.Border = 0;
            oPdfPTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Ulke : ", _fontStyle));
            _pdfPCell.Border = 0;
            oPdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_university.Country, _fontStyle));
            _pdfPCell.Border = 0;
            oPdfPTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            return oPdfPTable;
        }

        private PdfPTable UniversityInfo()
        {
            PdfPTable oPdfPTable = new PdfPTable(2);
            oPdfPTable.SetWidths(new float[] { 100f, 100f });


            _pdfPCell = new PdfPCell(new Phrase("Ad :", _fontStyle));
            _pdfPCell.Border = 0;
            oPdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_university.Name, _fontStyle));
            _pdfPCell.Border = 0;
            oPdfPTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Yayım Tarihi :", _fontStyle));
            _pdfPCell.Border = 0;
            oPdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_university.PublishedDate.ToString("dd-MMM-yyyy"), _fontStyle));
            _pdfPCell.Border = 0;
            oPdfPTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Rektör : ", _fontStyle));
            _pdfPCell.Border = 0;
            oPdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_university.PrincipalName, _fontStyle));
            _pdfPCell.Border = 0;
            oPdfPTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            return oPdfPTable;
        }

        private void ReportHeader()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Sakarya Üniversitesi", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase(_university.Address +", " + _university.City +", "+ _university.Country  , _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();
        }
    }
}