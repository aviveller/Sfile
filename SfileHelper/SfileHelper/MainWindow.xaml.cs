using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.VisualBasic.FileIO;
using System.ComponentModel;
using System.Diagnostics;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Text.RegularExpressions;
using System.Windows.Data;
using System.Globalization;
namespace SfileHelper
{
    public partial class MainWindow : MetroWindow, INotifyPropertyChanged
    {
        public MainWindow()
        {
            RecordNum = 0;
            InitializeComponent();
            DataContext = this;
            var Fly = new DataOnFly();
            SurveyNameOk = false;
            RedBorder1 = Visibility.Hidden;
            RedBorder2 = Visibility.Hidden;
            RedBorder3 = Visibility.Hidden;
            //  CreateDataOnfly.ItemsSource = Fly.LoadExmple();
        }
        string location;
        //deafult is true, if false, the programm will not create s file.
        bool CreateOrNot = true;
        List<string> Final_list = new List<string>();
        // this function checking problems in list
        // first check: add zeros to quata code if needed. (support up to 4 digits diffrence)
        public void ChackingListProblems(List<string> code_list, List<string> quantity_list, List<string> position_list)
        {
            //first test
            List<string> codelist = new List<string>();
            List<int> CodeToInt = new List<int>();
            List<int> positionlist = new List<int>();
            codelist = code_list;
            CodeToInt = codelist.Select(int.Parse).ToList();
            positionlist = position_list.Select(int.Parse).ToList();
            var max = CodeToInt.Max();
            int A = max.ToString().Length;
            string M = "";
            foreach (var item in CodeToInt)
            {
                int B = item.ToString().Length;
                if (A - B == 1)
                {
                    codelist[CodeToInt.IndexOf(item)] = "0" + item;
                }
                else if (A - B == 2)
                {
                    codelist[CodeToInt.IndexOf(item)] = "00" + item;
                }
                else if (A - B == 3)
                {
                    codelist[CodeToInt.IndexOf(item)] = "000" + item;
                }
                else if (A - B == 4)
                {
                    codelist[CodeToInt.IndexOf(item)] = "0000" + item;
                }
                else if (A - B != 0)
                {
                    M = "problem";
                }
            }
            if (M == "problem")
            {
                async void ToMenyZeros()
                {
                    await this.ShowMessageAsync("Error", "we found to meny difrencess in quata code, please make shure you add zeros where needed ", MessageDialogStyle.Affirmative);
                };
                ToMenyZeros();
                CreateOrNot = false;
            }
            // second check: test comatbilty between total quata to all quatas.
                if (QuantitySum / int.Parse(numOfquatas.Text)  != int.Parse(Total.Text))
                {
                    async void TotalDifrentFromQuatas()
                    {
                        await this.ShowMessageAsync("Error", "The Total number dosent fit to the quatas number, plesea check agein", MessageDialogStyle.Affirmative);
                    };
                    TotalDifrentFromQuatas();
                    CreateOrNot = false;
                } 
            //try
            //{
            //    List<int> FullQuantity = new List<int>();
            //    FullQuantity = quantity_list.Select(int.Parse).ToList();
            //    List<int> quantityGroupOne = new List<int>();
            //    List<int> quantityGroupTwo = new List<int>();
            //    List<int> quantityGroupThree = new List<int>();
            //    List<int> quantityGroupFour = new List<int>();
            //    List<int> quantityGroupFive = new List<int>();
            //    quantityGroupOne.Add(FullQuantity[0]);
            //    int counter = 0;
            //    for (int i = 1; i < FullQuantity.Count; i++)
            //    {
            //        if (positionlist[i] == positionlist[i - 1])
            //        {
            //            quantityGroupOne.Add(FullQuantity[i]);
            //        }
            //        else { quantityGroupTwo.Add(FullQuantity[i]); counter += i + 1; break; }
            //    }
            //    for (int i = counter; i < FullQuantity.Count; i++)
            //    {
            //        if (positionlist[i] == positionlist[i - 1])
            //        {
            //            quantityGroupTwo.Add(FullQuantity[i]);
            //        }
            //        else { quantityGroupThree.Add(FullQuantity[i]); counter = i + 1; break; }
            //    }
            //    for (int i = counter; i < FullQuantity.Count; i++)
            //    {
            //        if (positionlist[i] == positionlist[i - 1])
            //        {
            //            quantityGroupThree.Add(FullQuantity[i]);
            //        }
            //        else { quantityGroupFour.Add(FullQuantity[i]); counter = i + 1; break; }
            //    }
            //    for (int i = counter; i < FullQuantity.Count; i++)
            //    {
            //        if (positionlist[i] == positionlist[i - 1])
            //        {
            //            quantityGroupFour.Add(FullQuantity[i]);
            //        }
            //        else { quantityGroupFive.Add(FullQuantity[i]); counter = i + 1; break; }
            //    }
            //    if (quantityGroupOne.Count > 0 && quantityGroupOne.Sum() != Int32.Parse(Total.Text) || quantityGroupTwo.Count > 0 && quantityGroupTwo.Sum() != Int32.Parse(Total.Text) || quantityGroupThree.Count > 0 && quantityGroupThree.Sum() != Int32.Parse(Total.Text) || quantityGroupFour.Count > 0 && quantityGroupFour.Sum() != Int32.Parse(Total.Text))
            //    {
            //        async void NotEqual()
            //        {
            //            await this.ShowMessageAsync("Error", "quata groups are not equal to  total quata number", MessageDialogStyle.Affirmative);
            //        };
            //        NotEqual();
            //        CreateOrNot = false;
            //    }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("error");
            //    CreateOrNot = false;
            //}
        }
        // first we are reading the csv to get only list of quata code, this list will be checked by " ChackingListProblems " function.
        private void button_Click(object sender, RoutedEventArgs e)
        {
            CreateOrNot = true;
            Final_list.Clear();
            location = B_location.Text;
            List<string> code_list = new List<string>();
            List<string> quantity_list = new List<string>();
            List<string> position_list = new List<string>();
            try
            {
                using (TextFieldParser ReadCodeFromCsv = new TextFieldParser(@location))
                {
                    ReadCodeFromCsv.TextFieldType = FieldType.Delimited;
                    ReadCodeFromCsv.SetDelimiters(",");
                    code_list.Select(int.Parse).ToList();
                    ReadCodeFromCsv.ReadLine();
                    while (!ReadCodeFromCsv.EndOfData)
                    {
                        string[] code = ReadCodeFromCsv.ReadFields();
                        code_list.Add(code[3]);
                        quantity_list.Add(code[1]);
                        position_list.Add((code[2]));
                    }
                    if (runchecks.IsChecked == true)
                    {
                        ChackingListProblems(code_list, quantity_list, position_list);
                    }
                    else { CreateOrNot = true; }
                }
                //reading the csv after we alredy checked the quata code.
                //using the csv path from user to create new s file
                using (TextFieldParser parser = new TextFieldParser(@location))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.ReadLine();
                    var StringTotal = "TTStatusCode:\"18\"(" + Total.Text + ") TOTAL";
                    var StringMiddle = "TTExtraData+284:\"1\"(9999) _באמצע סקר_";
                    //  List<string> name_list = new List<string>();
                    //  List<string> number_list = new List<string>();
                    // List<string> position_list = new List<string>();
                    Final_list.Add(StringTotal);
                    int A = 0;
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        //  name_list.Add(fields[0]);
                        //  number_list.Add(fields[1]);
                        //  position_list.Add(fields[2]);
                        var pose = Int32.Parse(fields[2]);
                        int position = pose - 286;
                        pose = 0;
                        // "TTExtraData+284:"1"(9999) _באמצע סקר_";
                        string final = "TTExtraData+" + position + ":" + "\"" + code_list[A] + "\"" + "(" + fields[1] + ")" + "_" + fields[0] + "_";
                        A++;
                        Final_list.Add(final);
                    }
                    Final_list.Add(StringMiddle);
                    string directoryName = System.IO.Path.GetDirectoryName(@location) + "\\";
                    MyData.ItemsSource = null;
                    if (CreateOrNot == true)
                    {
                        MyData.ItemsSource = Final_list;
                        System.IO.File.WriteAllLines(@directoryName + SurveyName.Text + "S", Final_list, Encoding.GetEncoding("windows-1255"));
                        async void SfileWasSecssesfulyCreatedMessage()
                        {
                            MessageDialogResult CheckIfOk1;
                            CheckIfOk1 = await this.ShowMessageAsync("Success", "S file has been successfully created to the survey folder, press ok to navigate to file location", MessageDialogStyle.AffirmativeAndNegative);
                            if (CheckIfOk1 == MessageDialogResult.Affirmative)
                            {
                                Process.Start(System.IO.Path.GetDirectoryName(@location));
                            }
                        };
                        SfileWasSecssesfulyCreatedMessage();
                    }
                }
                // var CheckIfOk1 = MessageBox.Show("S file has been successfully created to the survey folder, press yes to navigate to file location", "Success", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
            }
            catch (Exception)
            {
                async void CantLoadCsvMessage()
                {
                    await this.ShowMessageAsync("Error", "there was a problem to load the file", MessageDialogStyle.Affirmative);
                };
                CantLoadCsvMessage();
                //MessageBox.Show("there was a problem loading the csv file","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
        private void Browse_click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = openFileDlg.ShowDialog();
            if (result == true)
            {
                B_location.Text = openFileDlg.FileName;
            }
            try
            {
                using (TextFieldParser ReadCodeFromCsv = new TextFieldParser(@B_location.Text))
                {
                    List<DataOnFly> A = new List<DataOnFly>();
                    ReadCodeFromCsv.TextFieldType = FieldType.Delimited;
                    ReadCodeFromCsv.SetDelimiters(",");
                    ReadCodeFromCsv.ReadLine();
                    QuantitySum = 0;
                    while (!ReadCodeFromCsv.EndOfData)
                    {
                        string[] reader = ReadCodeFromCsv.ReadFields();
                        var a = new DataOnFly()
                        {
                            Name = reader[0],
                            quantity = reader[1],
                            position = reader[2],
                            code = reader[3],
                        };
                        A.Add(a);
                        QuantitySum += Int32.Parse(reader[1]);
                    }
                    ShowBrowseCsv.ItemsSource = A;
                }
            }
            catch (Exception)
            {
                async void WrongFile()
                {
                    await this.ShowMessageAsync("Error", "there was a problem to load the file", MessageDialogStyle.Affirmative);
                };
                WrongFile();
            }
            var Counter = 0;
            foreach (var item in ShowBrowseCsv.Items)
            {
                Counter++;
            }
            RecordNum = Counter;
        }
        private void Delete_Record(object sender, RoutedEventArgs e)
        {
            IEditableCollectionView items = MyData.Items; //Cast to interface
            if (items.CanRemove)
            {
                while (MyData.SelectedValue != null)
                {
                    items.Remove(MyData.SelectedItem);
                }
            }
        }
        // mail sender in about page
        private void OnNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(e.Uri.AbsoluteUri);
            e.Handled = true;
        }
        private void Add_Record(object sender, RoutedEventArgs e)
        {
            var dialog = new dialog();
            if (dialog.ShowDialog() == true)
            {
                MessageBox.Show("You said: " + dialog.ResponseText);
                var pose = Int32.Parse(dialog.L_quata_position.Text);
                int position = pose - 286;
                string final = "TTExtraData+" + position + ":" + "\"" + dialog.L_quata_code.Text + "\"" + "(" + dialog.L_quta_quantity.Text + ")" + "*" + dialog.L_quata_name.Text + "*";
                var editableCollectionView = MyData.Items as IEditableCollectionView;
                if (!editableCollectionView.CanAddNew)
                {
                    MessageBox.Show("You cannot add items to the list.");
                    return;
                }
                editableCollectionView.CommitNew();
            }
        }
        private void CreateTemp(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Windows.Forms.DialogResult result;
                System.Windows.Forms.FolderBrowserDialog newdialog;
                using (newdialog = new System.Windows.Forms.FolderBrowserDialog())
                {
                    result = newdialog.ShowDialog();
                }
                string directoryName = newdialog.SelectedPath + "\\";
                MyData.ItemsSource = null;
                MyData.ItemsSource = Final_list;
                List<string> TempList = new List<string>();
                var StringTotal = "TTStatusCode:\"18\"(999) TOTAL";
                var StringMiddle = "TTExtraData+284:\"1\"(9999) _באמצע סקר_";
                TempList.Add(StringTotal);
                TempList.Add(StringMiddle);
                System.IO.File.WriteAllLines(@directoryName + SurveyName.Text + "S", TempList, Encoding.GetEncoding("windows-1255"));
                async void CreateBasic()
                {
                    MessageDialogResult CheckIfOk2;
                    CheckIfOk2 = await this.ShowMessageAsync("Success", "basic S file has been successfully created to the survey folder, press ok to navigate to file location", MessageDialogStyle.AffirmativeAndNegative);
                    if (CheckIfOk2 == MessageDialogResult.Affirmative)
                    {
                        Process.Start(newdialog.SelectedPath);
                    }
                }
                CreateBasic();
                MyData.ItemsSource = TempList;
            }
            catch (System.Exception)
            {
            }
        }
        private Visibility _RedBorder3;
        public Visibility RedBorder3
        {
            get
            {
                return _RedBorder3;
            }
            set
            {
                _RedBorder3 = value;
                OnPropertyChanged("RedBorder3");
            }
        }
        private Visibility _RedBorder2;
        public Visibility RedBorder2
        {
            get
            {
                return _RedBorder2;
            }
            set
            {
                _RedBorder2 = value;
                OnPropertyChanged("RedBorder2");
            }
        }
        private Visibility _RedBorder1;
        public Visibility RedBorder1
        {
            get
            {
                return _RedBorder1;
            }
            set
            {
                _RedBorder1 = value;
                OnPropertyChanged("RedBorder1");
            }
        }
        private bool _SurveyNameOk;
        public bool SurveyNameOk
        {
            get
            {
                return _SurveyNameOk;
            }
            set
            {
                _SurveyNameOk = value;
                OnPropertyChanged("SurveyNameOk");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RB1(object sender, RoutedEventArgs e)
        {
            //string reg = @"^[1 - 9]\d{3}[a-zA-Z].{2}$|^[1-9]\d{4}[a-zA-Z].{2}$";
            //if (Regex.IsMatch(SurveyName.Text, reg))
            if (String.IsNullOrEmpty(SurveyName.Text))
            {
                RedBorder1 = Visibility.Visible;
            }
            else
            {
                RedBorder1 = Visibility.Hidden;
            }
            if (String.IsNullOrEmpty(Total.Text) == false && (String.IsNullOrEmpty(SurveyName.Text) == false) && (String.IsNullOrEmpty(numOfquatas.Text) == false)) { SurveyNameOk = true; } else { SurveyNameOk = false; }
        }
        private void RB2(object sender, RoutedEventArgs e)
        {
            Total.Text = Regex.Replace(Total.Text, "[^0-9]+", "");
            if (String.IsNullOrEmpty(Total.Text))
            {
                RedBorder2 = Visibility.Visible;
            }
            else
            {
                RedBorder2 = Visibility.Hidden;
            }
            if (String.IsNullOrEmpty(Total.Text) == false && (String.IsNullOrEmpty(SurveyName.Text) == false) && (String.IsNullOrEmpty(numOfquatas.Text) == false)) { SurveyNameOk = true; } else { SurveyNameOk = false; }
        }
        private void RB3(object sender, RoutedEventArgs e)
        {
            numOfquatas.Text = Regex.Replace(numOfquatas.Text, "[^0-9]+", "");
            if (String.IsNullOrEmpty(numOfquatas.Text))
            {
                RedBorder3 = Visibility.Visible;
            }
            else
            {
                RedBorder3 = Visibility.Hidden;
            }
            if (String.IsNullOrEmpty(Total.Text) == false && (String.IsNullOrEmpty(SurveyName.Text) == false) && (String.IsNullOrEmpty(numOfquatas.Text) == false)) { SurveyNameOk = true; } else { SurveyNameOk = false; }
        }
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        private void NoRed1(object sender, RoutedEventArgs e)
        {
            RedBorder1 = Visibility.Hidden;
        }
        private void NoRed2(object sender, RoutedEventArgs e)
        {
            RedBorder2 = Visibility.Hidden;
        }
        private void NoRed3(object sender, RoutedEventArgs e)
        {
            RedBorder3 = Visibility.Hidden;
        }
        private int _RecordNum;
        public int RecordNum
        {
            get
            {
                return _RecordNum;
            }
            set
            {
                _RecordNum = value;
                OnPropertyChanged("RecordNum");
            }
        }
        private int _QuantitySum;
        public int QuantitySum
        {
            get
            {
                return _QuantitySum;
            }
            set
            {
                _QuantitySum = value;
                OnPropertyChanged("QuantitySum");
            }
        }
    }
}