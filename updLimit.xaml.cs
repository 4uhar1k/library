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

namespace library
{
    /// <summary>
    /// Логика взаимодействия для updLimit.xaml
    /// </summary>
    public partial class updLimit : Window
    {
        ApplicationContext db;
        public updLimit()
        {
            InitializeComponent();
        }
        int currentid;
        
        public updLimit(int currentid): this()
        {
            this.currentid = currentid;
        }

        public void close(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        public void min(object sender, EventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        public void readyButton(object sender, EventArgs e)
        {
            db = new ApplicationContext();
            string s = datePicker.Text;
            if (s == "")
            {
                MessageBox.Show("Выберите дату");
                return;
            }
            DateTime t1 = DateTime.Now.Date.Add(new TimeSpan(0, 0, 0));
            DateTime t2 = Convert.ToDateTime(s);
            if (t2<t1)
            {
                MessageBox.Show("Введена прошедшая дата");
                return;
            }
            Debt user;
            using (ApplicationContext db = new ApplicationContext())
            {
                user = db.debts.Where(b => b.currentid == currentid).FirstOrDefault();
                user.return_date = s;
                db.SaveChanges();
                MessageBox.Show("Книга была успешно продлена.");
            }
            this.Hide();
            List li1 = new List();
            li1.Show();
        }
        
    }
}
