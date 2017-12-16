using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace WpfApp2
{
    public static class Grading
    {
        public static List<string> keyAnswers = new List<string>();
        public static List<string> studentNames = new List<string>();
        public static List<List<string>> studentAnswers = new List<List<string>>();
        public static List<List<int>> grades = new List<List<int>>();
        public static TesseractEngine engine;

        /// <summary>
        /// Reads the key and takes apart the test into multiple images then proceeds
        /// to read each question, and save the answers
        /// </summary>
        /// <param name="filePath"></param>
        public static void sendKey(string filePath)
        {
            engine.DefaultPageSegMode = PageSegMode.SingleLine;
            var img = new Bitmap(filePath);

            bool textHasBegun;
            int blankRowBeforeText = 0;
            int blankRowAfterText = 0;
            int initialRow = 0;
            do
            {
                textHasBegun = false;

                for (int row = initialRow; row < img.Height; row++)  //loops through image scanning for blank lines
                {
                    bool isBlankRow = true;
                    for (int col = 0; col < img.Width; col++)
                    {
                        if (img.GetPixel(col, row).ToArgb() != -1) //the pixel color is not white
                        {
                            isBlankRow = false;
                            break;
                        }
                    }

                    if (textHasBegun)
                    {
                        if (isBlankRow) //already looped through the rows of text and now is done
                        {
                            blankRowAfterText = row;
                            break;
                        }
                    }
                    else
                    {
                        if (isBlankRow) //found a blank row before text
                        {
                            blankRowBeforeText = row;
                        }
                        else //found the first row of text
                        {
                            textHasBegun = true;
                        }
                    }
                }

                System.Drawing.Rectangle crop = new System.Drawing.Rectangle(0, blankRowBeforeText, 120, blankRowAfterText - blankRowBeforeText);

                var cropImg = cropImage(img, crop); //lots of conversions to get to the text
                var bitMap = new Bitmap(cropImg);
                var pix = PixConverter.ToPix(bitMap);
                var page = engine.Process(pix);
                var text = page.GetText();

                page.Dispose(); //needs to be disposed or the creates an error with the engine

                saveKeyText(text);  //saves the key data

                initialRow = blankRowAfterText; //sets new starting row for search
            } while (checkIfMoreText(img, blankRowAfterText));


        }

        /// <summary>
        /// Reads the student test and takes apart the test into multiple images then proceeds
        /// to read each question, and save the answers
        /// </summary>
        /// <param name="filePath"></param>
        public static void sendTest(string filePath)
        {
            List<string> ans = new List<string>();

            engine.DefaultPageSegMode = PageSegMode.SingleLine;
            var img = new Bitmap(filePath);

            bool textHasBegun;
            int blankRowBeforeText = 0;
            int blankRowAfterText = 0;
            int initialRow = 0;
            do
            {
                textHasBegun = false;

                for (int row = initialRow; row < img.Height; row++)  //loops through image scanning for blank lines
                {
                    bool isBlankRow = true;
                    for (int col = 0; col < img.Width; col++)
                    {
                        if (img.GetPixel(col, row).ToArgb() != -1) //the pixel color is not white
                        {
                            isBlankRow = false;
                            break;
                        }
                    }

                    if (textHasBegun)
                    {
                        if (isBlankRow) //already looped through the rows of text and now is done
                        {
                            blankRowAfterText = row;
                            break;
                        }
                    }
                    else
                    {
                        if (isBlankRow) //found a blank row before text
                        {
                            blankRowBeforeText = row;
                        }
                        else //found the first row of text
                        {
                            textHasBegun = true;
                        }
                    }
                }

                System.Drawing.Rectangle crop = new System.Drawing.Rectangle(0, blankRowBeforeText, 120, blankRowAfterText - blankRowBeforeText);

                var cropImg = cropImage(img, crop); //lots of conversions to get to the text
                var bitMap = new Bitmap(cropImg);
                var pix = PixConverter.ToPix(bitMap);
                var page = engine.Process(pix);
                var text = page.GetText();

                page.Dispose(); //needs to be disposed or the creates an error with the engine

                ans = saveStudentText(text, ans);  //saves the data to the ans list

                initialRow = blankRowAfterText; //sets new starting row for search
            } while (checkIfMoreText(img, blankRowAfterText));

            studentNames.Add(ans.ElementAt(0)); // the first element is the name
            ans.RemoveAt(0);
            studentAnswers.Add(ans);    //add the actual answers to the list of all student answers
        }

        /// <summary>
        /// parses the text and then saves the relevent information
        /// into corresponding lists
        /// </summary>
        /// <param name="text"></param>
        public static void saveKeyText(string text)
        {
            if (!text.Contains("Name:"))
            {
                var textArr = text.Split(":".ToCharArray());
                string answer = parseAnswer(textArr[textArr.Length - 1]);
                keyAnswers.Add(answer);
            }
        }

        /// <summary>
        /// save student text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="ans"></param>
        public static List<string> saveStudentText(string text, List<string> ans)
        {
            if (text.Contains("Name:"))
            {
                var textArr = text.Split(":".ToCharArray());
                string name = parseAnswer(textArr[textArr.Length - 1]);
                ans.Add(name);
            }
            else
            {
                var textArr = text.Split(":".ToCharArray());
                string answer = parseAnswer(textArr[textArr.Length - 1]);
                ans.Add(answer);
            }

            return ans;
        }

        /// <summary>
        /// returns the string with no leading or trailing spaces
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string parseAnswer(string str)
        {
            str.TrimStart(" ".ToCharArray());
            str.TrimEnd(" ".ToCharArray());
            List<char> lstChar = str.ToList();
            bool isDone = true;
            do
            {
                if (lstChar.Contains('\n'))
                {
                    int index = lstChar.IndexOf('\n');
                    lstChar.RemoveAt(index);    //done twice to remove letter after
                    lstChar.RemoveAt(index);    // '/' in escape sequence

                    isDone = false;
                }
                else
                {
                    isDone = true;
                }
            } while (!isDone);
            str = "";
            foreach (char chr in lstChar)
            {
                str += chr;
            }
            return str;
        }

        /// <summary>
        /// Checks if there is any more text left starting a certain row
        /// </summary>
        /// <param name="img"></param>
        /// <param name="startingRow"></param>
        /// <returns></returns>
        private static bool checkIfMoreText(Bitmap img, int startingRow)
        {
            bool isMoreText = false;
            for (int row = startingRow; row < img.Height; row++)  //loops through image scanning for blank lines
            {
                for (int col = 0; col < img.Width; col++)
                {
                    if (img.GetPixel(col, row).ToArgb() != -1) //the pixel color is not white
                    {
                        isMoreText = true;
                        break;
                    }
                }
                if (isMoreText)
                {
                    break;
                }
            }
            return isMoreText;
        }

        /// <summary>
        /// Crops given image and returns it
        /// </summary>
        /// <param name="img"></param>
        /// <param name="cropArea"></param>
        /// <returns></returns>
        private static System.Drawing.Image cropImage(System.Drawing.Image img, System.Drawing.Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }

        /// <summary>
        /// auto grades multiple choice questions
        /// </summary>
        /// <param name="qnum"></param>
        /// <param name="points"></param>
        public static void autoGrader(int qnum, int points)
        {
            string correctAns = keyAnswers.ElementAt(qnum - 1); //gets correct answer from key
            List<string> ansForQNum = getAnsForQNum(qnum); //gets all answers from students on specific question

            List<int> gradeForQNum = new List<int>();

            foreach (string ans in ansForQNum) //loops through all students answers
            {
                int earnedPoints = 0;
                if (String.Compare(ans, correctAns, true) == 0)
                {
                    earnedPoints = points;  //sets points earned to number of possible points
                }                           //when student gets question correct
                else
                {
                    earnedPoints = 0;   //sets points earned to zero on a wrong answer
                }
                gradeForQNum.Add(earnedPoints); //adds the earned points to the grade list
            }
        }


        public static List<string> getAnsForQNum(int qnum)
        {
            List<string> qNumAns = new List<string>();
            foreach (List<string> lst in studentAnswers)
            {
                qNumAns.Add(lst.ElementAt(qnum - 1));
            }
            return qNumAns; 
        }

        public static string getKeyAnsForQNum(int qnum)
        {
            return keyAnswers.ElementAt(qnum - 1);
        }

        public static void addGrades(List<int> grade, int qnum)
        {
            grades.Insert(qnum - 1, grade);
        }
    }
}
