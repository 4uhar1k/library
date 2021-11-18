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
    /// Логика взаимодействия для AddDebt.xaml
    /// </summary>
    public partial class AddDebt : Window
    {
        ApplicationContext db;
        public AddDebt()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }

        public void addInfo(object sender, EventArgs e)
        {
            string name = nameText.Text;
            string surname = surnameText.Text;
            string books = bookText.Text;
            string grade = gradeText.Text;
            string date1 = DateTime.Now.ToString("dd/MM/yyyy");
            string date2 = DateTime.Now.AddDays(10).ToString("dd/MM/yyyy");

            Debt auslander = null;
            using (ApplicationContext db = new ApplicationContext())
            {
                auslander = db.debts.Where(b => b.name == name).FirstOrDefault();
            }


            if (auslander == null)
            {
                Debt debt = new Debt(name, surname, books, grade, date1, date2);
                db.debts.Add(debt);
                db.SaveChanges();
                MessageBox.Show(date1 + " " + date2);
                this.Hide();
                MainWindow maw = new MainWindow();
                maw.Show();
            }
        }
    }
}