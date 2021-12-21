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
    /// Логика взаимодействия для BookList.xaml
    /// </summary>
    public partial class BookList : Window
    {
        ApplicationContext db;
        StackPanel[] stacks;
        Label[] nameArray;
        Label[] authorArray;
        Label[] codeArray;
        Label[] pubArray;
        Label[] avArray;
        Label[] navArray;
        Button[] chooseArray;
        Label[] langArray;
        int n = 0;

        public void mainLogic(int n)
        {
            int i = 0, maxId = 0;
            next.Visibility = Visibility.Hidden;
            prev.Visibility = Visibility.Hidden;
            for (int j = 0; j < 10; j++)
            {
                stacks[j].Visibility = Visibility.Hidden;
            }

            foreach (Book book in db.books)
            {

                if (book.name.StartsWith(searchBar.Text.ToUpper()))
                {
                    maxId++;
                    if (i <= 9 && (searchBar.Text == "") ? (book.currentid > n && book.currentid <= n + 10) : (true))
                    {
                        stacks[i].Visibility = Visibility.Visible;

                        nameArray[i].Content = book.name;
                        authorArray[i].Content = book.author;
                        codeArray[i].Content = book.code;
                        long curr = Convert.ToInt64(codeArray[i].Content);
                        if (window == "adddebt")
                        {
                            Book book1;
                            using (ApplicationContext db = new ApplicationContext())
                            {
                                book1 = db.books.Where(b => b.code == curr).FirstOrDefault();
                            }
                            if (book1.amount > 0)
                                chooseArray[i].Visibility = Visibility.Visible;
                            else
                                chooseArray[i].Visibility = Visibility.Hidden;
                        }

                        else
                            chooseArray[i].Visibility = Visibility.Hidden;
                        pubArray[i].Content = book.publisher;
                        avArray[i].Content = book.amount;
                        navArray[i].Content = book.namount;
                        langArray[i].Content = book.language;
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

        public BookList()
        {
            InitializeComponent();

        }
        string window, username, usersur, usergrade;
        int userdays;

        public BookList(string window, string username, string usersur, string usergrade, int userdays): this()
        {
            
            this.window = window;
            this.username = username;
            this.usersur = usersur;
            this.usergrade = usergrade;
            this.userdays = userdays;

            if (window == "adddebt")
            {
                backButton.Content = "Назад";
                backButton.Click -= mainMenu;
                backButton.Click += addMenu;
            }

            stacks = new StackPanel[10] { panel1, panel2, panel3, panel4, panel5, panel6, panel7, panel8, panel9, panel10 };
            
            next.Visibility = Visibility.Hidden;
            prev.Visibility = Visibility.Hidden;
            nameArray = new Label[10] { Name1, Name2, Name3, Name4, Name5, Name6, Name7, Name8, Name9, Name10 };
            authorArray = new Label[10] { Author1, Author2, Author3, Author4, Author5, Author6, Author7, Author8, Author9, Author10 };
            codeArray = new Label[10] { Code1, Code2, Code3, Code4, Code5, Code6, Code7, Code8, Code9, Code10 };
            pubArray = new Label[10] { Pub1, Pub2, Pub3, Pub4, Pub5, Pub6, Pub7, Pub8, Pub9, Pub10 };
            avArray = new Label[10] { Avail1, Avail2, Avail3, Avail4, Avail5, Avail6, Avail7, Avail8, Avail9, Avail10 };
            navArray = new Label[10] { NAvail1, NAvail2, NAvail3, NAvail4, NAvail5, NAvail6, NAvail7, NAvail8, NAvail9, NAvail10 };
            chooseArray = new Button[10] { choose1, choose2, choose3, choose4, choose5, choose6, choose7, choose8, choose9, choose10 };
            langArray = new Label[10] {Lang1, Lang2, Lang3, Lang4, Lang5, Lang6, Lang7, Lang8, Lang9, Lang10 };
            db = new ApplicationContext();


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
        public void mainMenu(object sender, EventArgs e)
        {
            this.Hide();
            MainWindow ma = new MainWindow();
            ma.Show();
        }

        public void addMenu(object sender, EventArgs e)
        {
            this.Hide();
            AddDebt ad = new AddDebt(0, username, usersur, usergrade, userdays);
            ad.Show();
        }

        public void updLimitOfBook(object sender, EventArgs e)
        {

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

        public void chooseBook(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            long code = Convert.ToInt64(codeArray[Array.IndexOf(chooseArray, btn)].Content);
            this.Hide();
            AddDebt ad = new AddDebt(code, username, usersur, usergrade, userdays);
            ad.Show();
        }
    }
}


