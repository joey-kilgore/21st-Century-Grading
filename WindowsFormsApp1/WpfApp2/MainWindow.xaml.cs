using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Xaml;
using Tesseract;
using WinForms = System.Windows.Forms;


namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
<<<<<<< HEAD
        
        public MainWindow()
        {

            Variables.numberOfInputTests = 0;
=======
        public List<string> keyAnswers = new List<string>();
        public List<string> studentNames = new List<string>();
        public List<List<string>> studentAnswers = new List<List<string>>();
        public List<List<int>> grades = new List<List<int>>();

        public TesseractEngine engine;

        public MainWindow()
        {
            String tessdataDirectory = System.IO.Directory.GetCurrentDirectory() + @"\tessdata";
            engine = new TesseractEngine(tessdataDirectory, "eng", EngineMode.Default);
>>>>>>> refs/remotes/origin/master
            InitializeComponent();
            
        }
        private void resultFileLocationSearchButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            finalFileDestinationTextBox.Text = dialog.SelectedPath;
        }
        private void resultFileLocationSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string finalFileDestinationFolder = finalFileDestinationTextBox.Text;
            finalDestinationSubmitted.IsChecked = true;
            
            
        }
        private void KeySearchButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog searchKey = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = searchKey.ShowDialog();
            if (result == true)
            {
                string filename = searchKey.FileName;
                KeyTextBox.Text = filename;
            }
        }

        private void KeySubmitButton_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            printToConsole(KeyTextBox.Text);
            KeySubmitted.IsChecked = true;
            
            
        }

        private void StudentSearchButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog searchStudentTests = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = searchStudentTests.ShowDialog();
            if (result == true)
            {
                string filename = searchStudentTests.FileName;
                StudentsTextBox.Text = filename;
            }
        }
        
        public void StudentSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            printToConsole(StudentsTextBox.Text);
            Variables.numberOfInputTests++;
            studentTestsSubmittedCounter.Content = Variables.numberOfInputTests + " tests have been submitted";
=======
            //printToConsole(KeyTextBox.Text);
            Grading.sendKey(KeyTextBox.Text);
>>>>>>> refs/remotes/origin/master
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
<<<<<<< HEAD

        private void beginGradingButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ProblemGrading ProblemGrading = new ProblemGrading();
            ProblemGrading.Show();
        }
        
=======
>>>>>>> refs/remotes/origin/master
        
    }
}
