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
            worksheet.Cells.Style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


            Excel.Range c1 = worksheet.Cells[1, 1];
            Excel.Range c2 = worksheet.Cells[1, 2];
            Excel.Range c3 = worksheet.Cells[1, 3];
            Excel.Range c4 = worksheet.Cells[1, 14];
            Excel.Range c33 = worksheet.Cells[3, 1];
            worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[2, 1]].Merge();
            worksheet.Range[worksheet.Cells[1, 2], worksheet.Cells[2, 2]].Merge();
            worksheet.Range[worksheet.Cells[1, 3], worksheet.Cells[1, 13]].Merge();
            worksheet.Range[worksheet.Cells[1, 14], worksheet.Cells[1, 16]].Merge();
            c1.EntireColumn.ColumnWidth = 26;
            c2.EntireColumn.ColumnWidth = 26;
            c33.RowHeight = 36;
            
            c1.Value = "Всего выдано";
            c2.Value = "Всего возвращено";
            c3.Value = "В том числе по категориям";
            c4.Value = "В том числе по языкам";
            

            Excel.Range c5 = worksheet.Cells[2, 3];
            Excel.Range c6 = worksheet.Cells[2, 4];
            Excel.Range c7 = worksheet.Cells[2, 5];
            Excel.Range c8 = worksheet.Cells[2, 6];
            Excel.Range c9 = worksheet.Cells[2, 7];
            Excel.Range c10 = worksheet.Cells[2, 8];
            Excel.Range c11 = worksheet.Cells[2, 9];
            Excel.Range c12 = worksheet.Cells[2, 10];
            Excel.Range c13 = worksheet.Cells[2, 11];
            Excel.Range c14 = worksheet.Cells[2, 12];
            Excel.Range c15 = worksheet.Cells[2, 13];
            c5.Value = "Естественные науки";
            c6.Value = "Технические науки";
            c7.Value = "Медицинские науки";
            c8.Value = "Общественно-политические науки";
            c9.Value = "Наука, культура";
            c10.Value = "Просвещение";
            c11.Value = "Спорт";
            c12.Value = "Филологические науки";
            c13.Value = "Художественная литература";
            c14.Value = "Искусство";
            c15.Value = "Литература универсального содержания";

            Excel.Range c16 = worksheet.Cells[2, 14];
            Excel.Range c17 = worksheet.Cells[2, 15];
            Excel.Range c18 = worksheet.Cells[2, 16];
            c16.Value = "Казахский";
            c17.Value = "Русский";
            c18.Value = "Другой";
            Excel.Range secondrow = worksheet.Range[c5, c18];
            worksheet.Rows["2"].Cells.Orientation = Excel.XlOrientation.xlUpward;

            c1.Style.Orientation = Excel.XlOrientation.xlHorizontal;
            c2.Style.Orientation = Excel.XlOrientation.xlHorizontal;
            c3.Style.Orientation = Excel.XlOrientation.xlHorizontal;
            c4.Style.Orientation = Excel.XlOrientation.xlHorizontal;

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
