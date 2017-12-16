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
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for ProblemGrading.xaml
    /// </summary>
    public partial class ProblemGrading : Window
    {
        
        int problemCounter;
        public ProblemGrading()
        {
            
            problemCounter = 1;
            InitializeComponent();
            string[] problemTypes = new string[] { "Multiple Choice", "Short Answer" };
            chooseProblemType.ItemsSource = problemTypes;
            chooseProblemType.Text = "--Choose the problem type--";
            

        }

        private void problemTypeSubmitButton_Click(object sender, RoutedEventArgs e)
        {

            
            int pointsPossible = Convert.ToInt32(enterPointsTextBox.Text);
            string problemType = chooseProblemType.Text;
         

            List<string> pointPossibilities = new List<string>();
            for (int i = 0; i <= pointsPossible; i++)
            {
                pointPossibilities.Add(Convert.ToString(i));
                
            }
            



            if (problemType == "Multiple Choice")
            {
                //autoGradeMultipleChoice(1,enterPointsTextBox.Text);
                MessageBox.Show("Problem " + problemCounter + " successfully graded");
                pointSelection.ItemsSource = null;
                enterPointsTextBox.Text = null;
                problemCounter++;
                problemCounterLabel.Content = "Problem " + problemCounter;
            }
            else if (problemType == "Short Answer")
            {
                typeAndPointsSubmittedCheckbox.IsChecked = true;
                pointSelection.ItemsSource = pointPossibilities;

                //string keyAnswer = getKeyAnsQNum(problemCounter);
                //List<string> studentAnswers = getAnsForQNum(problemCounter);
                //keyAnswerLabel.Content = keyAnswer;
                //studentAnswerLabel.Content = studentAnswers.ElementAt(0);

            }
            

        }


        int k = 0;
        List<int> listOfGrades = new List<int>();
        private void problemSubmissionButton_click(object sender, RoutedEventArgs e)
        {
            int pointsAwarded = Convert.ToInt32(pointSelection.Text);
            listOfGrades.Add(pointsAwarded);
            //change to second student answer
            //studentAnswerLabel.Content = studentAnswers.ElementAt(problemCounter-1);

            pointSelection.Text = null;

            k++;
            if (k == Variables.numberOfInputTests)
            {
                //send listOfGrades to joey here
                listOfGrades.Clear();
                typeAndPointsSubmittedCheckbox.IsChecked = false;
                pointSelection.Text = null;
                studentAnswerLabel.Content = null;
                keyAnswerLabel.Content = null;
                enterPointsTextBox.Text = null;
                problemCounter++;
                problemCounterLabel.Content = "Problem " + problemCounter;
            }
            

        }
    }
}
