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
    /// Логика взаимодействия для addBook.xaml
    /// </summary>
    public partial class addBook : Window
    {
        ApplicationContext db;
        public addBook()
        {
            InitializeComponent();
        }

        public void addBookClick(object sender, EventArgs e)
        {
            db = new ApplicationContext();
            string name = bookNameTextBox.Text;
            string publisher = isdatelBookTextBox.Text;
            int code = Convert.ToInt32(bookCodeTextBox.Text);
            string author = bookAuthorTextBox.Text;
            int amount = Convert.ToInt32(amountText.Text);
            
            Book book = null;
            using (ApplicationContext db = new ApplicationContext())
            {
                book = db.books.Where(b=>b.code == code).FirstOrDefault();
                if (book == null)
                {
                    Book book1 = new Book(name, publisher, code, author, amount);
                    db.books.Add(book1);
                    db.SaveChanges();
                    MessageBox.Show("Книга успешно добавлена в базу");
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Книга с таким кодом уже существует. Вы уверены, что хотите добавить экземпляры?" , "", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.No:
                            return;
                        case MessageBoxResult.Yes:
                            int n = book.amount;
                            book.amount = n + amount;
                            db.SaveChanges();
                            MessageBox.Show("suka");
                            break;
                    }


                    

                }
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

        public void mainMenu(object sender, EventArgs e)
        {
            this.Hide();
            MainWindow ma = new MainWindow();
            ma.Show();
        }
    }
}
