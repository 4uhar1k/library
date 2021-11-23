using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    class Debt
    {
        [Key]
        public int id { get; set; }


        public int currentid { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string grade { get; set; }
        public string book { get; set; }
        public string take_date { get; set; }
        public string return_date { get; set; }


        public Debt() { }

        public Debt(int currentid, string name, string surname, string book, string grade, string take_date, string return_date)
        {
            this.currentid = currentid;
            this.name = name;
            this.surname = surname;
            this.grade = grade;
            this.book = book;
            this.take_date = take_date;
            this.return_date = return_date;
        }

    }
}
