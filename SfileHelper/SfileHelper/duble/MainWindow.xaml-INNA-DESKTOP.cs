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
using System.IO;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using System.Collections;

namespace SfileHelper
{

    public partial class MainWindow : Window
    {

        string[] allLines;

        public MainWindow()
        {
            InitializeComponent();

        }


        // this function add zeros to quata code if needed. 

        public void ChackingListProblems(List<string> list)
        {

            List<int> CodeToInt = new List<int>();


            CodeToInt = list.Select(int.Parse).ToList();

            var max = CodeToInt.Max();

            foreach (var item in CodeToInt)
            {

                if (item.ToString().Length < max.ToString().Length)
                {

                    list[item - 1] = '0' + list[item - 1];

                    MessageBox.Show(list[item - 1]);
                }
            }

            CodeToInt = list.Select(int.Parse).ToList();

            foreach (var item in CodeToInt)
            {

                if (item.ToString().Length < max.ToString().Length)
                {

                    ChackingListProblems(list);
                }
            }
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {

            var location = B_location.Text;

            //using the csv path from user
            using (TextFieldParser parser = new TextFieldParser(@location))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                var i = 0;
                var StringTotal = "TTStatusCode:\"18\"(" + Total.Text + ") TOTAL";
                var StringMiddle = "TTExtraData+284:\"1\"(9999) _באמצע סקר_";

                List<string> name_list = new List<string>();
                List<string> number_list = new List<string>();
                List<string> position_list = new List<string>();
                List<string> code_list = new List<string>();
                List<string> Final_list = new List<string>();

                code_list.Select(int.Parse).ToList();

                Final_list.Add(StringTotal);
                while (!parser.EndOfData)
                {

                    string[] fields = parser.ReadFields();

                    i++;

                    //step over headers
                    if (i > 1)
                    {
                        name_list.Add(fields[0]);
                        number_list.Add(fields[1]);
                        position_list.Add(fields[2]);
                        code_list.Add(fields[3]);


                        //todo 
                       

                        var pose = Int32.Parse(fields[2]);
                        int position = pose - 286;
                        pose = 0;

                        // "TTExtraData+284:"1"(9999) _באמצע סקר_";
                        string final = "TTExtraData+" + position + ":" + "\"" + fields[3] + "\"" + "(" + fields[1] + ")" + "*" + fields[0] + "*";

                        Final_list.Add(final);

                    }



                }

                ChackingListProblems(code_list);


                Final_list.Add(StringMiddle);
                string directoryName = System.IO.Path.GetDirectoryName(@location) + "\\";
                System.IO.File.WriteAllLines(@directoryName + SurveyName.Text + "S", Final_list);

                MyData.ItemsSource = Final_list;

            }

            
           MessageBox.Show("S file has been successfully created to the survey folder");
        }


        // browse button to get the csv from user


        private void Browse_click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

            Nullable<bool> result = openFileDlg.ShowDialog();

            if (result == true)
            {
                B_location.Text = openFileDlg.FileName;

            }
        }



        // letting the user open exist S file and showing it on data grid


        private void Browse_Data_Grid(object sender, RoutedEventArgs e)
        {
        
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = openFileDlg.ShowDialog();
      
            if (result == true)
            {
                L_Databrows.Text = openFileDlg.FileName;
              
                allLines = System.IO.File.ReadAllLines(L_Databrows.Text);
                MyData.ItemsSource = allLines;

            }
        }


        private void Delete_Record(object sender, RoutedEventArgs e)
        {
            var Edit = MyData.ItemsSource;
            MyData.ItemsSource = null;

            if (MyData.SelectedIndex != -1)
            {
                for (int i = MyData.SelectedItems.Count - 1; i >= 0; i--)
                    MyData.Items.Remove(MyData.SelectedItems[i]);
            }
        }
    }
}
