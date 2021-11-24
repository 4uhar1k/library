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
    /// Логика взаимодействия для List.xaml
    /// </summary>
    public partial class List : Window
    {
        ApplicationContext db;
        StackPanel[] stacks;
        Label[] nameArray;
        Label[] surnameArray;
        Label[] gradeArray;
        Label[] bookArray;
        Label[] takeArray;
        Label[] returnArray;
        Button[] limitArray;
        Button[] deleteArray;
        Label[] limitcheckArray;
        Label[] numArray;
        int n = 0;
        public List()
        {
            InitializeComponent();
            stacks = new StackPanel[10] { panel1, panel2, panel3, panel4, panel5, panel6, panel7, panel8, panel9, panel10};
            for (int j = 0;j<10;j++)
            {
                stacks[j].Visibility = Visibility.Hidden;
            }
            next.Visibility = Visibility.Hidden;
            prev.Visibility = Visibility.Hidden;
            numArray = new Label[10] { Num1, Num2, Num3, Num4, Num5, Num6, Num7, Num8, Num9, Num10 };
            nameArray = new Label[10] { Name1, Name2, Name3, Name4, Name5, Name6, Name7, Name8, Name9, Name10 };
            surnameArray = new Label[10] { Surname1, Surname2, Surname3, Surname4, Surname5, Surname6, Surname7, Surname8, Surname9, Surname10 };
            gradeArray = new Label[10] {Grade1, Grade2, Grade3, Grade4, Grade5, Grade6, Grade7, Grade8, Grade9, Grade10 };
            bookArray = new Label[10] { Book1, Book2, Book3, Book4, Book5, Book6, Book7, Book8, Book9, Book10 };
            takeArray = new Label[10] { TakeDate1, TakeDate2, TakeDate3, TakeDate4, TakeDate5, TakeDate6, TakeDate7, TakeDate8, TakeDate9, TakeDate10 };
            returnArray = new Label[10] { RetutrnDate1, RetutrnDate2, RetutrnDate3, RetutrnDate4, RetutrnDate5, RetutrnDate6, RetutrnDate7, RetutrnDate8, RetutrnDate9, RetutrnDate10 };
            limitArray = new Button[10] { limit1, limit2, limit3, limit4, limit5, limit6, limit7, limit8, limit9, limit10 };
            deleteArray = new Button[10] { delete1, delete2, delete3, delete4, delete5, delete6, delete7, delete8, delete9, delete10};
            limitcheckArray = new Label[10] { limitcheck1, limitcheck2, limitcheck3, limitcheck4, limitcheck5, limitcheck6, limitcheck7, limitcheck8, limitcheck9, limitcheck10};
            db = new ApplicationContext();
            int i = 0, maxId = 0;

            foreach (Debt debt in db.debts)
            {
                if (debt!=null && i<=9)
                {
                    stacks[i].Visibility = Visibility.Visible;
                    limitcheckArray[i].Visibility = Visibility.Hidden;
                    nameArray[i].Content = debt.name;
                    surnameArray[i].Content= debt.surname;
                    gradeArray[i].Content = debt.grade;
                    bookArray[i].Content = debt.book;
                    takeArray[i].Content = debt.take_date;
                    returnArray[i].Content = debt.return_date;
                    numArray[i].Content = debt.currentid;           
                    DateTime t1 = Convert.ToDateTime(debt.return_date);
                    DateTime t2 = DateTime.Now.Date.Add(new TimeSpan(0, 0, 0));
                    if (t1==t2)
                    {
                        limitcheckArray[i].Visibility = Visibility.Visible;
                        limitcheckArray[i].Foreground = Brushes.DarkOrange;
                    }
                    else if (t1<t2)
                    {
                        limitcheckArray[i].Visibility = Visibility.Visible;
                        limitcheckArray[i].Foreground = Brushes.Red;
                    }
                    i++;
                    
                }
                maxId++;
            }
            if (maxId>n+10)
            {
                next.Visibility = Visibility.Visible;
            }
        }

       
        
        public void updLimitOfBook(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            //MessageBox.Show(testarr[0].ToString());
            Label name = nameArray[Array.IndexOf(limitArray, btn)];
            Label surname = surnameArray[Array.IndexOf(limitArray, btn)];
            Label grade = gradeArray[Array.IndexOf(limitArray, btn)];
            Label book = bookArray[Array.IndexOf(limitArray, btn)];
            Label take = takeArray[Array.IndexOf(limitArray, btn)];
            Label ret = returnArray[Array.IndexOf(limitArray, btn)];
            this.Hide();
            updLimit up = new updLimit(name.Content.ToString(), surname.Content.ToString(), grade.Content.ToString(), book.Content.ToString(), take.Content.ToString(), ret.Content.ToString());
            up.Show();
        }

        public void deleteDebt(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            //MessageBox.Show(testarr[0].ToString());
            Label name = nameArray[Array.IndexOf(deleteArray, btn)];
            Label surname = surnameArray[Array.IndexOf(deleteArray, btn)];
            Label grade = gradeArray[Array.IndexOf(deleteArray, btn)];
            Label book = bookArray[Array.IndexOf(deleteArray, btn)];
            Label take = takeArray[Array.IndexOf(deleteArray, btn)];
            Label ret = returnArray[Array.IndexOf(deleteArray, btn)];
            //MessageBox
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить ученика из списка?", "", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.No:
                    return;
                case MessageBoxResult.Yes:
                    Debt user;

                    using (ApplicationContext db = new ApplicationContext())
                    {
                        user = db.debts.Where(b => b.name == name.Content.ToString() && b.surname == surname.Content.ToString() && b.grade == grade.Content.ToString() && b.book == book.Content.ToString() && b.take_date == take.Content.ToString() && b.return_date == ret.Content.ToString()).FirstOrDefault();
                        db.debts.Remove(user);
                        db.SaveChanges(); 
                    }
                    int curid = 1;
                    foreach (Debt debt in db.debts)
                    {
                        
                            
                            debt.currentid = curid;
                            db.SaveChanges();

                        
                        curid++;
                    }
                    this.Hide();
                    MessageBox.Show("Пользователь был успешно удален.");
                    List li = new List();
                    li.Show();
                    break;
            }

            
            
        }
        public void mainMenu(object sender, EventArgs e)
        {
            this.Hide();
            MainWindow ma = new MainWindow();
            ma.Show();
        }

        public void search(object sender, EventArgs e)
        {
            //Debt user;
            string s = searchBar.Text.ToUpper();
            
            //s = s.ToUpper();
            int i = 0;
            //MessageBox.Show("ШИПАЧЕВ".Contains("ЕГОР").ToString());
            
                //MessageBox.Show($"{user.surname.Contains(searchBar.Text.ToLower())}");
                for (int j = 0; j < 10; j++)
                {
                    stacks[j].Visibility = Visibility.Hidden;
                }

                foreach (Debt debt in db.debts)
                {
                    //MessageBox.Show(searchBar.Text);

                    //MessageBox.Show($"{debt.name} , {debt.surname}, {debt.grade}, {debt.book}");

                    //this.Hide();
                    //List li = new List();
                    // li.Show();
                    //MessageBox.Show($"{debt.surname} , {searchBar.Text.ToLower()} : {debt.surname.Contains(searchBar.Text.ToLower())}");
                    if (debt.surname.StartsWith(searchBar.Text.ToUpper()))//if (debt.surname.Contains(searchBar.Text.ToUpper()))
                    {
                        stacks[i].Visibility = Visibility.Visible;
                        limitcheckArray[i].Visibility = Visibility.Hidden;
                        nameArray[i].Content = debt.name;
                        surnameArray[i].Content = debt.surname;
                        gradeArray[i].Content = debt.grade;
                        bookArray[i].Content = debt.book;
                        takeArray[i].Content = debt.take_date;
                        returnArray[i].Content = debt.return_date;
                    Debt userTest = null;
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        userTest = db.debts.Where(b => b.name == debt.name && b.surname == debt.surname && b.grade == debt.grade && b.book == debt.book && b.take_date == debt.take_date && b.return_date == debt.return_date).FirstOrDefault();
                    }
                    //MessageBox.Show(userTest.name);
                    DateTime t1 = Convert.ToDateTime(userTest.return_date);
                    DateTime t2 = DateTime.Now.Date.Add(new TimeSpan(0, 0, 0));
                    if (t1 == t2)
                    {
                        limitcheckArray[i].Visibility = Visibility.Visible;
                        limitcheckArray[i].Foreground = Brushes.DarkOrange;
                    }
                    else if (t1 < t2)
                    {
                        limitcheckArray[i].Visibility = Visibility.Visible;
                        limitcheckArray[i].Foreground = Brushes.Red;
                    }
                    i++;
                    }
                    
                    
                }



            

        }

        public void onlyDebt(object sender, EventArgs e)
        {
            int i = 0, maxId = 0;
            next.Visibility = Visibility.Hidden;
            prev.Visibility = Visibility.Hidden;
            if (debters.IsChecked == true)
            {
                for (int j = 0; j < 10; j++)
                {
                    stacks[j].Visibility = Visibility.Hidden;
                }
                foreach (Debt debt in db.debts)
                {
                    DateTime t1 = Convert.ToDateTime(debt.return_date);
                    DateTime t2 = DateTime.Now.Date.Add(new TimeSpan(0, 0, 0));
                    if (debt != null)
                    {

                        
                        if (t1 == t2 || t1 < t2)
                        {
                            maxId++;
                            if (i<=9)
                            {
                                stacks[i].Visibility = Visibility.Visible;
                                limitcheckArray[i].Visibility = Visibility.Hidden;
                                nameArray[i].Content = debt.name;
                                surnameArray[i].Content = debt.surname;
                                gradeArray[i].Content = debt.grade;
                                bookArray[i].Content = debt.book;
                                takeArray[i].Content = debt.take_date;
                                returnArray[i].Content = debt.return_date;
                                limitcheckArray[i].Visibility = Visibility.Visible;
                                if (t1 == t2)
                                    limitcheckArray[i].Foreground = Brushes.DarkOrange;
                                if (t1 < t2)
                                    limitcheckArray[i].Foreground = Brushes.Red;
                                i++;
                            }
                            
                            
                            
                        }



                        //infolabel.Content += "\n";
                    }
                    

                }

                if (maxId > n + 10)
                {
                    next.Visibility = Visibility.Visible;
                }
                if (maxId - 10 < n && maxId-10>0)
                {
                    prev.Visibility = Visibility.Visible;
                }

            }
            else
            {
                maxId = 0;
                foreach (Debt debt in db.debts)
                {
                    maxId++;
                    if (debt != null && i <= 9)
                    {
                        
                        stacks[i].Visibility = Visibility.Visible;
                        limitcheckArray[i].Visibility = Visibility.Hidden;
                        nameArray[i].Content = debt.name;
                        surnameArray[i].Content = debt.surname;
                        gradeArray[i].Content = debt.grade;
                        bookArray[i].Content = debt.book;
                        takeArray[i].Content = debt.take_date;
                        returnArray[i].Content = debt.return_date;
                        DateTime t1 = Convert.ToDateTime(debt.return_date);
                        DateTime t2 = DateTime.Now.Date.Add(new TimeSpan(0, 0, 0));
                        if (t1 == t2)
                        {
                            limitcheckArray[i].Visibility = Visibility.Visible;
                            limitcheckArray[i].Foreground = Brushes.DarkOrange;
                        }
                        else if (t1 < t2)
                        {
                            limitcheckArray[i].Visibility = Visibility.Visible;
                            limitcheckArray[i].Foreground = Brushes.Red;
                        }
                        i++;//infolabel.Content += "\n";
                    }

                }
                if (maxId > n + 10)
                {
                    next.Visibility = Visibility.Visible;
                }
                if (maxId - 10 < n && maxId - 10 > 0)
                {
                    prev.Visibility = Visibility.Visible;
                }
            }

        }

        public void nextpage(object sender, EventArgs e)
        {
            for (int j = 0; j < 10; j++)
            {
                stacks[j].Visibility = Visibility.Hidden;
            }
            next.Visibility = Visibility.Hidden;
            prev.Visibility = Visibility.Hidden;
            db = new ApplicationContext();
            int i = 0;
            n += 10;
            int maxId = 0;
            foreach (Debt debt in db.debts)
            {
                if (debt != null && debt.currentid>n && debt.currentid<=n+10)
                {
                    stacks[i].Visibility = Visibility.Visible;
                    limitcheckArray[i].Visibility = Visibility.Hidden;
                    nameArray[i].Content = debt.name;
                    surnameArray[i].Content = debt.surname;
                    gradeArray[i].Content = debt.grade;
                    bookArray[i].Content = debt.book;
                    takeArray[i].Content = debt.take_date;
                    returnArray[i].Content = debt.return_date;
                    DateTime t1 = Convert.ToDateTime(debt.return_date);
                    DateTime t2 = DateTime.Now.Date.Add(new TimeSpan(0, 0, 0));
                    if (t1 == t2)
                    {
                        limitcheckArray[i].Visibility = Visibility.Visible;
                        limitcheckArray[i].Foreground = Brushes.DarkOrange;
                    }
                    else if (t1 < t2)
                    {
                        limitcheckArray[i].Visibility = Visibility.Visible;
                        limitcheckArray[i].Foreground = Brushes.Red;
                    }
                    i++;
                    
                }
                maxId++;

            }
            if (maxId > n + 10)
            {
                next.Visibility = Visibility.Visible;
            }
            if (maxId - 10 < n && maxId - 10 > 0)
            {
                prev.Visibility = Visibility.Visible;
            }
        }

        public void previouspage(object sender, EventArgs e)
        {
            for (int j = 0; j < 10; j++)
            {
                stacks[j].Visibility = Visibility.Hidden;
            }
            next.Visibility = Visibility.Hidden;
            prev.Visibility = Visibility.Hidden;
            db = new ApplicationContext();
            int i = 0;
            n -= 10;
            int maxId = 0;
            foreach (Debt debt in db.debts)
            {
                if (debt != null && debt.currentid > n && debt.currentid <= n + 10)
                {
                    stacks[i].Visibility = Visibility.Visible;
                    limitcheckArray[i].Visibility = Visibility.Hidden;
                    nameArray[i].Content = debt.name;
                    surnameArray[i].Content = debt.surname;
                    gradeArray[i].Content = debt.grade;
                    bookArray[i].Content = debt.book;
                    takeArray[i].Content = debt.take_date;
                    returnArray[i].Content = debt.return_date;
                    DateTime t1 = Convert.ToDateTime(debt.return_date);
                    DateTime t2 = DateTime.Now.Date.Add(new TimeSpan(0, 0, 0));
                    if (t1 == t2)
                    {
                        limitcheckArray[i].Visibility = Visibility.Visible;
                        limitcheckArray[i].Foreground = Brushes.DarkOrange;
                    }
                    else if (t1 < t2)
                    {
                        limitcheckArray[i].Visibility = Visibility.Visible;
                        limitcheckArray[i].Foreground = Brushes.Red;
                    }
                    i++;//infolabel.Content += "\n";
                    
                }
                maxId++;

            }
            if (maxId > n + 10)
            {
                next.Visibility = Visibility.Visible;
            }
            if (maxId - 10 < n && maxId - 10 > 0)
            {
                prev.Visibility = Visibility.Visible;
            }
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
