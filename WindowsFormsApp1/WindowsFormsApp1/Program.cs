using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void testOCR()
        {
            Console.WriteLine("TESTING OCR");
            Console.WriteLine("CURRENT DIRECTORY: " + Directory.GetCurrentDirectory());
            String tessdataDirectory = Directory.GetCurrentDirectory() + @"\tessdata";
            var engine = new TesseractEngine(tessdataDirectory, "eng", EngineMode.Default);

            String testImagePath = @"C:\Users\joeya\Desktop\Programming Files\C#\OCR\TESTIMAGES\iWrote.png";
            var img = Pix.LoadFromFile(testImagePath);
            var page = engine.Process(img);

            var text = page.GetText();
            Console.WriteLine("Mean confidence: {0}", page.GetMeanConfidence());

            Console.WriteLine("Text (GetText): \r\n{0}", text);
            Console.Read();
        }

        public static void printToConsole(string filePath)
        {
            Console.WriteLine("CURRENT DIRECTORY: " + Directory.GetCurrentDirectory());
            String tessdataDirectory = Directory.GetCurrentDirectory() + @"\tessdata";
            var engine = new TesseractEngine(tessdataDirectory, "eng", EngineMode.Default);

                        var img = Pix.LoadFromFile(filePath);
            var page = engine.Process(img);

            var text = page.GetText();
            Console.WriteLine("Mean confidence: {0}", page.GetMeanConfidence());

            Console.WriteLine("Text (GetText): \r\n{0}", text);
            Console.Read();
        }

    }
}
