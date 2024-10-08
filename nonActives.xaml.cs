﻿using System;
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

namespace library
{
    /// <summary>
    /// Логика взаимодействия для List.xaml
    /// </summary>
    public partial class nonActives : Window
    {
        ApplicationContext db;
        StackPanel[] stacks;
        Label[] nameArray;
        Label[] surnameArray;
        Label[] gradeArray;
        Label[] bookArray;
        Label[] takeArray;
        Label[] returnArray;
        Label[] numArray;
        int n = 0;
        string bookname;

        public void mainLogic(int n)
        {
            int i = 0, maxId = 0;
            next.Visibility = Visibility.Hidden;
            prev.Visibility = Visibility.Hidden;
            for (int j = 0; j < 10; j++)
            {
                stacks[j].Visibility = Visibility.Hidden;
            }

            foreach (Debt debt in db.debts)
            {
                if (((searchType.SelectionBoxItem.ToString() == "По фамилиям") ? (debt.surname.StartsWith(searchBar.Text.ToUpper())) : (debt.book.StartsWith(searchBar.Text.ToUpper()))) && debt.debtstate >= 3)//if (debt.surname.Contains(searchBar.Text.ToUpper()))
                {
                    maxId++;
                    if (i <= 9 && (searchBar.Text == "") ? (debt.currentid>n && debt.currentid <=n+10) : (true))
                    {
                        stacks[i].Visibility = Visibility.Visible;
                        nameArray[i].Content = debt.name;
                        surnameArray[i].Content = debt.surname;
                        gradeArray[i].Content = debt.grade;
                        bookArray[i].Content = debt.book;
                        takeArray[i].Content = debt.take_date;
                        returnArray[i].Content = debt.return_date;
                        numArray[i].Content = "Неактивен";
                        numArray[i].FontSize = 15;
                        if (debt.debtstate == 3)
                        {

                            numArray[i].Foreground = Brushes.DarkGreen;
                        }
                        else if (debt.debtstate == 4)
                        {

                            numArray[i].Foreground = Brushes.DarkOrange;
                        }
                        else if (debt.debtstate == 5)
                        {

                            numArray[i].Foreground = Brushes.Red;
                        }
                        i++;
                    }

                }


            }

            if (maxId > n + 10)
            {
                next.Visibility = Visibility.Visible;
            }
            if (n - 10 >= 0)
            {
                prev.Visibility = Visibility.Visible;
            }
        }
        public nonActives()
        {
            InitializeComponent();
            stacks = new StackPanel[10] { panel1, panel2, panel3, panel4, panel5, panel6, panel7, panel8, panel9, panel10 };


            next.Visibility = Visibility.Hidden;
            prev.Visibility = Visibility.Hidden;
            nameArray = new Label[10] { Name1, Name2, Name3, Name4, Name5, Name6, Name7, Name8, Name9, Name10 };
            surnameArray = new Label[10] { Surname1, Surname2, Surname3, Surname4, Surname5, Surname6, Surname7, Surname8, Surname9, Surname10 };
            gradeArray = new Label[10] { Grade1, Grade2, Grade3, Grade4, Grade5, Grade6, Grade7, Grade8, Grade9, Grade10 };
            bookArray = new Label[10] { Book1, Book2, Book3, Book4, Book5, Book6, Book7, Book8, Book9, Book10 };
            takeArray = new Label[10] { TakeDate1, TakeDate2, TakeDate3, TakeDate4, TakeDate5, TakeDate6, TakeDate7, TakeDate8, TakeDate9, TakeDate10 };
            returnArray = new Label[10] { RetutrnDate1, RetutrnDate2, RetutrnDate3, RetutrnDate4, RetutrnDate5, RetutrnDate6, RetutrnDate7, RetutrnDate8, RetutrnDate9, RetutrnDate10 };
            
            numArray = new Label[10] { Num1, Num2, Num3, Num4, Num5, Num6, Num7, Num8, Num9, Num10 };

            db = new ApplicationContext();
            mainLogic(n);
        }

        public void firstopen(object sender, EventArgs e)
        {
            searchType.SelectionChanged += search;
            //searchType.SelectionChanged -= firstopen;

        }



       
        public void mainMenu(object sender, EventArgs e)
        {
            this.Hide();
            MainWindow ma = new MainWindow();
            ma.Show();
        }

        public void search(object sender, EventArgs e)
        {
            n = 0;
            mainLogic(n);
        }

        

        public void nextpage(object sender, EventArgs e)
        {
            
            db = new ApplicationContext();
            n += 10;
            mainLogic(n);
        }

        public void previouspage(object sender, EventArgs e)
        {
            db = new ApplicationContext();
            n -= 10;
            mainLogic(n);
        }
        public void close(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        public void min(object sender, EventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

    }
}