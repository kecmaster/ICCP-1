﻿using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICCPReclamos
{
    public class ITextEvents : PdfPageEventHelper
    {
        // This is the contentbyte object of the writer
        PdfContentByte cb;

        // we will put the final number of pages in a template
        PdfTemplate headerTemplate, footerTemplate;

        // this is the BaseFont we are going to use for the header / footer
        BaseFont bf = null;

        // This keeps track of the creation time
        DateTime PrintTime = DateTime.Now;


        #region Fields
        private string _header;
        #endregion

        #region Properties
        public string Header
        {
            get { return _header; }
            set { _header = value; }
        }
        #endregion


        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                PrintTime = DateTime.Now;
                bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb = writer.DirectContent;
                headerTemplate = cb.CreateTemplate(400, 150);
                footerTemplate = cb.CreateTemplate(50, 50);
            }
            catch (DocumentException de)
            {

            }
            catch (System.IO.IOException ioe)
            {

            }
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);

            Font baseFontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 12f, Font.NORMAL, BaseColor.BLACK);

            Font baseFontBig = FontFactory.GetFont(FontFactory.TIMES, 12f, Font.NORMAL, BaseColor.BLACK);
            Font time = FontFactory.GetFont(FontFactory.HELVETICA, 11f, Font.NORMAL);

            var logo = Image.GetInstance(HttpContext.Current.Server.MapPath("~/Images/LSC.png"));
            logo.ScaleToFit(150f, 62f);
            //document.Add(new Phrase(Environment.NewLine));
            var p1Header = new Phrase("ICCP.NET | REPORTE RECLAMO", baseFontNormal);

            //Create PdfTable object
            var pdfTab = new PdfPTable(3);
            float[] width = { 100f, 320f, 100f };
            pdfTab.SetWidths(width);
            pdfTab.TotalWidth = 520f;
            pdfTab.LockedWidth = true;
            //We will have to create separate cells to include image logo and 2 separate strings
            //Row 1
            var pdfCell1 = new PdfPCell(logo);
            var pdfCell2 = new PdfPCell(p1Header);
            var text = "Página ";
            //string

            //Add paging to header
            {
                cb.BeginText();
                cb.SetFontAndSize(bf, 12);
                cb.SetTextMatrix(document.PageSize.GetRight(100), document.PageSize.GetTop(45));
                cb.ShowText(text);
                cb.EndText();
                float len = bf.GetWidthPoint(text, 12);
                cb.AddTemplate(headerTemplate, document.PageSize.GetRight(100) + len, document.PageSize.GetTop(45));
            }
            // FOOTER 
            {
                var leftCol = new Paragraph("ICCP.Net", time);
                var rightCol = new Paragraph("reclamosiccp.tk", time);
                var empresa = new Paragraph("Accenture Chile", time);
                var direccion = new Paragraph("                 ROBOTECH INC\n" + "                  Santiago, Chile", time);
                var email = new Paragraph("admin@reclamosiccp.tk", time);

                leftCol.Alignment = Element.ALIGN_LEFT;
                rightCol.Alignment = Element.ALIGN_RIGHT;
                email.Alignment = Element.ALIGN_RIGHT;
                empresa.Alignment = Element.ALIGN_LEFT;
                direccion.Alignment = Element.ALIGN_CENTER;

                var footerTbl = new PdfPTable(3) { TotalWidth = 520f, HorizontalAlignment = Element.ALIGN_CENTER, LockedWidth = true };
                float[] widths = { 150f, 220f, 150f };
                footerTbl.SetWidths(widths);
                var footerCell1 = new PdfPCell(leftCol);
                var footerCell2 = new PdfPCell();
                var footerCell3 = new PdfPCell(rightCol);
                var sep = new PdfPCell();
                var footerCell4 = new PdfPCell(empresa);
                var footerCell5 = new PdfPCell(direccion);
                var footerCell6 = new PdfPCell(email);


                footerCell1.Border = 0;
                footerCell2.Border = 0;
                footerCell3.Border = 0;
                footerCell4.Border = 0;
                footerCell5.Border = 0;
                footerCell6.Border = 0;
                footerCell6.HorizontalAlignment = Element.ALIGN_RIGHT;
                sep.Border = 0;
                sep.FixedHeight = 10f;
                footerCell3.HorizontalAlignment = Element.ALIGN_RIGHT;
                footerCell6.PaddingLeft = 0;
                sep.Colspan = 3;

                footerTbl.AddCell(footerCell1);
                footerTbl.AddCell(footerCell2);
                footerTbl.AddCell(footerCell3);
                footerTbl.AddCell(sep);
                footerTbl.AddCell(footerCell4);
                footerTbl.AddCell(footerCell5);
                footerTbl.AddCell(footerCell6);
                footerTbl.WriteSelectedRows(0, -1, 40, 80, writer.DirectContent);
            }

            var pdfCell3 = new PdfPCell(new Phrase("Fecha:" + PrintTime.ToShortDateString(), baseFontBig));
            var pdfCell4 = new PdfPCell();
            //var pdfCell5 = new PdfPCell(new Phrase("TIME:" + string.Format("{0:t}", DateTime.Now), baseFontBig));

            // todo a 0
            pdfCell1.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell2.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell3.HorizontalAlignment = Element.ALIGN_RIGHT;
            //pdfCell5.HorizontalAlignment = Element.ALIGN_RIGHT;


            pdfCell2.PaddingTop = 9f;
            pdfCell3.PaddingTop = 20f;
            //pdfCell5.PaddingTop = 9f;

            pdfCell1.Border = 0;
            pdfCell2.Border = 0;
            pdfCell3.Border = 0;
            pdfCell4.Border = 0;
            //pdfCell5.Border = 0;

            //agregar celdas
            pdfTab.AddCell(pdfCell1);
            pdfTab.AddCell(pdfCell2);
            pdfTab.AddCell(pdfCell3);
            pdfTab.AddCell(pdfCell4);
            //pdfTab.AddCell(pdfCell5);

            pdfTab.TotalWidth = 520f;
            pdfTab.LockedWidth = true;

            //call WriteSelectedRows of PdfTable. This writes rows from PdfWriter in PdfTable
            //first param is start row. -1 indicates there is no end row and all the rows to be included to write
            //Third and fourth param is x and y position to start writing
            pdfTab.WriteSelectedRows(0, -1, 40, document.PageSize.Height - 30, writer.DirectContent);
            //set pdfContent value

            //Move the pointer and draw line to separate header section from rest of page
            cb.MoveTo(40, document.PageSize.Height - 100);
            cb.LineTo(document.PageSize.Width - 40, document.PageSize.Height - 100);
            cb.Stroke();

            //Move the pointer and draw line to separate footer section from rest of page
            cb.MoveTo(40, document.PageSize.GetBottom(57));
            cb.LineTo(document.PageSize.Width - 40, document.PageSize.GetBottom(57));
            cb.Stroke();
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);

            headerTemplate.BeginText();
            headerTemplate.SetFontAndSize(bf, 12);
            headerTemplate.SetTextMatrix(0, 0);
            headerTemplate.ShowText((writer.PageNumber).ToString());
            headerTemplate.EndText();

            footerTemplate.BeginText();
            footerTemplate.SetFontAndSize(bf, 12);
            footerTemplate.SetTextMatrix(0, 0);
            footerTemplate.ShowText((writer.PageNumber).ToString());
            footerTemplate.EndText();
        }
    }
}