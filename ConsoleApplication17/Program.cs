using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication17
{
    class Program
    {    
        static void Main(string[] args)
        {
            string nameString = "Aaron Ben Carmelina Dorethy Erinn Karin " +
                               "Lester Mitsue Nichol Ria Sherie Zachary";
            string assignmentsString = "44 92 100 100 100 97 100 95 100 0 100 100 " +
                                       "95 95 97 90 100 95 100 100 100 100 100 75 " +
                                        "98 100 65 0 100 100 100 100 100 100 95 75 " +
                                       "85 100 0 50 100 95 90 0 80 100 100 100";

            string[] arrayNames = new string[12];
            string[] str;
            double[][] arrayGrades = new double[4][];
            double[] arrayAverage = new double[12];

            arrayNames = FillArray(nameString);            
            str = FillArray(assignmentsString);
            arrayGrades = FillArray(str, arrayGrades, 4, 12);
            arrayAverage = GetAverage(4, 12, arrayGrades);


            DisplayArray(arrayNames);
            DisplayArray(arrayGrades, 4, 12);

        }
        static  char[] GetChar()
        {
            char[] separator = new char[] { ' ' };
            return separator;
        }

        //Method to Fill Array
          static string[] FillArray(string str)
        {
            return str.Split(GetChar());          
        }
        static double[][] FillArray(string[] str,double[][] arrayGrades, int row,int clum)
        {
           
            int c = 0;
            for (int i = 0; i < row; i++)
            {
                arrayGrades[i] = new double[clum];
                for (int j = 0; j < clum; j++)
                {
                    if (!double.TryParse(str[c++], out arrayGrades[i][j]))
                    {
                        //the number is error 
                    }
                }
            }
            return arrayGrades;
           
        }
        static double[] GetAverage(int row,int clum, double[][] arrayGrades)
        {
            double[] arrayAverage = new double[clum];
            for (int i = 0; i< clum; i++)
            {
                double s = 0;
                for (int j = 0; j< row; j++)
                {
                    s += Convert.ToInt32(arrayGrades[j][i]);

                }
                arrayAverage[i] = s / 4;
            }
            return arrayAverage;
       }

        //Method to Display Array of names and assignment grades

        private static void DisplayArray(string[] nameString)
        {
            for (int i = 0; i < nameString.Length; i++)
            {
                // lbxDisplay.Items.Add(nameString[i] + " ");
            }
        }
        private static void DisplayArray( double[][] assignmentsString,int row,int clum)
        {
            for (int i = 0; i < row; i++)
            {                
                for (int j = 0; j < clum; j++)
                {
                 //  arrayGrades[i][j]
                }               
            }       
        }
    }     
}
