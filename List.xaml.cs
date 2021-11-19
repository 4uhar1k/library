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
        //StackPanel[] stacks = new StackPanel[20] { panel1, panel2, panel3, panel4, panel5, panel6, panel7, panel8, panel9, panel10, panel11, panel12, panel13, panel14, panel15, panel16, panel17, panel18, panel19, panel20 };
        
        public List()
        {
            InitializeComponent();
            Label[] nameArray = new Label[4] { Name1, Name2, Name3, Name4 };
            db = new ApplicationContext();
            int i = 0;
            foreach (Debt debt in db.debts)
            {

                nameArray[i].Content = $"{debt.name}";//{debt.surname} {debt.grade} {debt.book} {debt.take_date} {debt.return_date}";
                i++;//infolabel.Content += "\n";
            }
        }


    }
}
