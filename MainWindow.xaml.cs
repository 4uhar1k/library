
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

namespace library
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        public void addUser(object sender, EventArgs e)
        {
            this.Hide();
            AddDebt adi = new AddDebt();
            adi.Show();
        }

        public void showList(object sender, EventArgs e)
        {
            this.Hide();
            List adi = new List();
            adi.Show();
        }

        public void showBookList(object sender, EventArgs e)
        {
            this.Hide();
            BookList adi = new BookList();
            adi.Show();
        }

        public void close(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        public void min(object sender, EventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

       public void addBook(object sender, EventArgs e)
        {
            this.Hide();
            addBook ad = new addBook();
            ad.Show();
        }
    }
}
