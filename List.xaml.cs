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
        Label[] nameArray;
        Label[] surnameArray;
        Label[] gradeArray;
        Label[] bookArray;
        Label[] takeArray;
        Label[] returnArray;
        Button[] limitArray;
        Button[] deleteArray;
        public List()
        {
            InitializeComponent();
            StackPanel[] stacks = new StackPanel[10] { panel1, panel2, panel3, panel4, panel5, panel6, panel7, panel8, panel9, panel10};
            for (int j = 0;j<10;j++)
            {
                stacks[j].Visibility = Visibility.Hidden;
            }
            nameArray = new Label[10] { Name1, Name2, Name3, Name4, Name5, Name6, Name7, Name8, Name9, Name10 };
            surnameArray = new Label[10] { Surname1, Surname2, Surname3, Surname4, Surname5, Surname6, Surname7, Surname8, Surname9, Surname10 };
            gradeArray = new Label[10] {Grade1, Grade2, Grade3, Grade4, Grade5, Grade6, Grade7, Grade8, Grade9, Grade10 };
            bookArray = new Label[10] { Book1, Book2, Book3, Book4, Book5, Book6, Book7, Book8, Book9, Book10 };
            takeArray = new Label[10] { TakeDate1, TakeDate2, TakeDate3, TakeDate4, TakeDate5, TakeDate6, TakeDate7, TakeDate8, TakeDate9, TakeDate10 };
            returnArray = new Label[10] { RetutrnDate1, RetutrnDate2, RetutrnDate3, RetutrnDate4, RetutrnDate5, RetutrnDate6, RetutrnDate7, RetutrnDate8, RetutrnDate9, RetutrnDate10 };
            limitArray = new Button[10] { limit1, limit2, limit3, limit4, limit5, limit6, limit7, limit8, limit9, limit10 };
            deleteArray = new Button[10] { delete1, delete2, delete3, delete4, delete5, delete6, delete7, delete8, delete9, delete10};
            db = new ApplicationContext();
            int i = 0;
            foreach (Debt debt in db.debts)
            {
                if (debt!=null)
                {
                    stacks[i].Visibility = Visibility.Visible;
                    nameArray[i].Content = debt.name;
                    surnameArray[i].Content= debt.surname;
                    gradeArray[i].Content = debt.grade;
                    bookArray[i].Content = debt.book;
                    takeArray[i].Content = debt.take_date;
                    returnArray[i].Content = debt.return_date;
                    i++;//infolabel.Content += "\n";
                }
                
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
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите вычеркнуть ученика из списка?", "", MessageBoxButton.YesNo);
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
                        this.Hide();
                        MessageBox.Show("Пользователь был успешно удален.");
                        List li = new List();
                        li.Show();
                    }
                    break;
            }
            
        }

    }
}
