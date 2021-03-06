﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Pdf.IO;
using System.IO;

namespace CPSC5210TestProject
{
    [TestClass]
    public class TejasUnitTest
    {
        private object document;

        public TejasUnitTest()
        {

        }
        [TestMethod]
        public void TestCreateDocument()
        {
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Created with PDFsharp";
        }

        [TestMethod]
        public void TestAddPageToDocument()
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
        }

        [TestMethod]
        public void TestCreatePDFDocumentWithName()
        {
            PdfDocument testDocument = new PdfDocument("..\\..\\..\\newDoc.pdf");
            PdfPage page = testDocument.AddPage();
            testDocument.Close();
            Assert.IsNotNull(testDocument);
        }

        [TestMethod]
        public void TestCreatePDFDocumentWithNewName()
        {
            PdfDocument testDocument = new PdfDocument();
            Assert.IsNotNull(testDocument);
        }

        [TestMethod]
        public void TestClosePDFDocument()
        {
            PdfDocument testDocument = new PdfDocument();
            //PdfReader.Open("testfile");
            testDocument.Close();
            //Assert.IsNotNull(testDocument);
        }

        [TestMethod]
        public void TestCreatePDFDocumentWithStream()
        {
            Stream outputStream = null;
            PdfDocument testDocument = new PdfDocument(outputStream);
            Assert.IsNotNull(testDocument);
        }

        [TestMethod]
        public void TestDisposePDFDocument()
        {
            PdfDocument testDocument = new PdfDocument();
            testDocument.Dispose();
        }

        [TestMethod]
        public void TestDisposeCheckPDFDocument()
        {
            PdfDocument testDocument = new PdfDocument();
            //testDocument.Open();
            testDocument.Dispose();
        }

        [TestMethod]
        public void TestAddPageToDocument1()
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
        }

        [TestMethod]
        public void TestInsertPageToDocument()
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.InsertPage(0);
        }

        [TestMethod]
        public void TestFlattenDocument()
        {
            PdfDocument document = new PdfDocument();
            var doc = PdfReader.Open("..\\..\\..\\blank.pdf", PdfDocumentOpenMode.Modify);
            //if (doc.AcroForm != null)
             doc.Flatten();

            //var document = PdfReader.Open("Hello world.pdf");
            // Flatten the form
            //document.Flatten();

            //PdfDocument document = new PdfDocument("sample.pdf");
           // PdfDocument document = PdfReader.Open("Hello world.pdf", PdfDocumentOpenMode.Modify);
            //document.Flatten();
        }
        [TestMethod]
        public void TestInsertPageFromDocToDocument()
        {
            //PdfDocument document = new PdfDocument();
            //PdfPage page = document.InsertPage(0);
           // document._openMode = PdfDocumentOpenMode.Import;
            PdfDocument newDocument = new PdfDocument();
            newDocument.InsertPage(0,new PdfPage());
            Assert.IsTrue(1 == newDocument.PageCount);
        }

        [TestMethod]
        public void TestAddPageFromDocToDocument()
        {
            PdfDocument inputDocument = PdfReader.Open("..\\..\\..\\blank.pdf", PdfDocumentOpenMode.Import);
            
           PdfDocument newDocument = new PdfDocument();
           newDocument.AddPage(inputDocument.Pages[0]);
           newDocument.Save("blank2.pdf");
           Assert.IsTrue(1 == newDocument.PageCount);

            /*PdfDocument inputDocument = PdfReader.Open("Hello world.pdf", PdfDocumentOpenMode.ReadOnly);

            string name = Path.GetFileNameWithoutExtension("Hello world");
            for (int idx = 0; idx < inputDocument.PageCount; idx++)
            {
                // Create new document
                PdfDocument outputDocument = new PdfDocument();
                outputDocument.Version = inputDocument.Version;
                outputDocument.Info.Title =
                  String.Format("Page {0} of {1}", idx + 1, inputDocument.Info.Title);
                outputDocument.Info.Creator = inputDocument.Info.Creator;

                // Add the page and save it
                outputDocument.AddPage(inputDocument.Pages[idx]);
                outputDocument.Save(String.Format("{0} - Page {1}.pdf", name, idx + 1));
            }

    */
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAddPageFromDocToDocumentThrowsEx()
        {
            PdfDocument inputDocument = PdfReader.Open("..\\..\\..\\blank.pdf");

            PdfDocument newDocument = new PdfDocument();
            newDocument.AddPage(inputDocument.Pages[0]);
            newDocument.Save("blank2.pdf");
            Assert.IsTrue(1 == newDocument.PageCount);
        }

        [TestMethod]
        public void TestGetXgraphicsPage()
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
        }

        [TestMethod]
        public void TestCreateFontStyle()
        {
            XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);
        }

        [TestMethod]
        public void TestDrawTextWithFont()
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 30, XFontStyle.Italic);
            gfx.DrawString("Hello, World!", font, XBrushes.Black,
                new XRect(0, 0, page.Width, page.Height),
                XStringFormats.Center);
        }

        [TestMethod]
        public void TestSaveDocument()
        {
            
            //Assert.Equals("PracticeDocument.pdf","Practicedocument.pdf");
            PdfDocument document = new PdfDocument();
            string filename = "HelloWorld.pdf";
            try
            {
                document.Save(filename);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Cannot save a PDF document with no pages.", e.Message);
            }
            //Assert.Equals(filename, "HelloWorld.pdf")           
        }

        /*[TestMethod]
        public void TestPrepareForSaveDocument()
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = new PdfPage();
            PdfObject object = new PdfObject();
          
        }*/


    }
}
