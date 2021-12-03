using System;
using System.Windows;
using System.Windows.Media;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Win32;

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
            AddDebt adi = new AddDebt(0, "", "", "", 0);
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
            BookList adi = new BookList("mainwindow", "", "", "", 0);
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

        public void colorChangeWhenEntered(object sender, RoutedEventArgs e)
        {
            closeButton.Background = Brushes.Black;
        }

        public void history(object sender, EventArgs e)
        {
            this.Hide();
            nonActives no = new nonActives();
            no.Show();

            
        }

        public void report(object sender, EventArgs e)
        {
            Excel.Application ex = new Microsoft.Office.Interop.Excel.Application();

            ex.Visible = false;

            ex.SheetsInNewWorkbook = 1;

            Excel.Workbook workbook = ex.Workbooks.Add(Type.Missing);

            ex.DisplayAlerts = false;

            Excel.Worksheet worksheet = ex.Worksheets.get_Item(1);

            worksheet.Cells.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Excel.Range c1 = worksheet.Cells[1, 1];
            Excel.Range c2 = worksheet.Cells[1, 2];
            Excel.Range c3 = worksheet.Cells[1, 3];
            Excel.Range c4 = worksheet.Cells[1, 4];
            Excel.Range c5 = worksheet.Cells[1, 5];
            c1.EntireColumn.ColumnWidth = 20;
            c2.EntireColumn.ColumnWidth = 20;
            c3.EntireColumn.ColumnWidth = 20;
            c4.EntireColumn.ColumnWidth = 20;
            c5.EntireColumn.ColumnWidth = 20;
            c1.Value = "Всего выдано";
            c2.Value = "Всего возвращено";
            c3.Value = "На казахском";
            c4.Value = "На русском";
            c5.Value = "Другой";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\";      
            saveFileDialog1.Title = "Сохранение отчета";
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "xlsx";
            saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == true)
            {
                workbook.SaveAs(saveFileDialog1.FileName);
                MessageBox.Show("bebra");
            }

        }
    }
}
