using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    internal class Book
    {
        [Key]
        public int id { get; set; }


        public string name { get; set; }
        public string publisher { get; set; }
        public long code { get; set; }
        public string author { get; set; }
        public int amount { get; set; }

        public int namount { get; set; }
        public int currentid { get; set; }
        

        public Book()
        {

        }

        public Book(string name, string publisher, long code, string author, int amount, int namount, int currentid)
        {
            this.name = name;
            this.publisher = publisher;
            this.code = code;
            this.author = author;
            this.amount = amount;
            this.namount = namount;
            this.currentid = currentid;
        }
    }
}
