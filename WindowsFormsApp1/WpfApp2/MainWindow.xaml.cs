using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tesseract;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void KeySearchButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                KeyTextBox.Text = filename;
            }
        }

        private void KeySubmitButton_Click(object sender, RoutedEventArgs e)
        {
            printToConsole(KeyTextBox.Text);
        }

        public static void printToConsole(string filePath)
        {
           
                Console.WriteLine("CURRENT DIRECTORY: " + System.IO.Directory.GetCurrentDirectory());
                
                String tessdataDirectory = System.IO.Directory.GetCurrentDirectory() + @"\tessdata";
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
