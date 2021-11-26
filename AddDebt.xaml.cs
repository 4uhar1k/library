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
using Z.EntityFramework.Extensions;

namespace library
{
    /// <summary>
    /// Логика взаимодействия для AddDebt.xaml
    /// </summary>
    public partial class AddDebt : Window
    {
        ApplicationContext db;
        public AddDebt()
        {
            InitializeComponent();
        }

        long bookcode;
        string namet, surnamet, gradet;
        int dayst;
        public AddDebt(long bookcode, string name, string surname, string grade, int days): this()
        {
            this.bookcode = bookcode;
            namet = name;
            surnamet = surname;
            gradet = grade;
            dayst = days;
            nameText.Text = namet;
            surnameText.Text = surnamet;
            gradeText.Text = gradet;
            
            if (bookcode == 0)
            {
                bookText.Text = "Нажмите на кнопку выбора";
            }
            else
            {
                Book book = null;
                using (ApplicationContext db = new ApplicationContext())
                {
                    book = db.books.Where(b => b.code == bookcode).FirstOrDefault();
                    bookText.Text = book.name;
                }
            }
        }

        public void addInfo(object sender, EventArgs e)
        {
            db = new ApplicationContext();
            string name = nameText.Text.ToUpper();
            string surname = surnameText.Text.ToUpper();
            string books = bookText.Text.ToUpper();
            string grade = gradeText.Text.ToUpper();
            string date1 = DateTime.Now.ToString("dd.MM.yyyy");
            string date2 = DateTime.Now.AddDays(Convert.ToDouble(limitText.Text)).ToString("dd.MM.yyyy");
            int currentid = 1;
            foreach (Debt debt1 in db.debts)
            {
                currentid++;
            }



            // if (auslander == null)
            //{
            //MessageBox.Show(currentid.ToString());
                Debt debt = new Debt(currentid, name, surname, books, grade, date1, date2, 0);
                db.debts.Add(debt);
                db.SaveChanges();
            Book book = null;
                using (ApplicationContext db = new ApplicationContext())
                {
                    book = db.books.Where(b=> b.code== bookcode).FirstOrDefault();
                book.amount--;
                book.namount++;
                db.SaveChanges();
            }
            
                MessageBox.Show("Запись успешно сохранена.");
                this.Hide();
                MainWindow maw = new MainWindow();
                maw.Show();
            //}
        }

        public void close(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        public void min(object sender, EventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        public void chooseBookClick (object sender, EventArgs e)
        {
            this.Hide();
            BookList bookList = new BookList("adddebt", namet, surnamet, gradet, dayst);
            bookList.Show();
        }

        public void mainMenu(object sender, EventArgs e)
        {
            this.Hide();
            MainWindow ma = new MainWindow();
            ma.Show();
        }
    }
}
