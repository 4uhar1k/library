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
            db = new ApplicationContext();
        }

        public void addInfo(object sender, EventArgs e)
        {
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

        public void mainMenu(object sender, EventArgs e)
        {
            this.Hide();
            MainWindow ma = new MainWindow();
            ma.Show();
        }
    }
}
