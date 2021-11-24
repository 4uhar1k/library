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
        public int code { get; set; }
        public string author { get; set; }
        public int amount { get; set; }
        

        public Book()
        {

        }

        public Book(string name, string publisher, int code, string author, int amount)
        {
            this.name = name;
            this.publisher = publisher;
            this.code = code;
            this.author = author;
            this.amount = amount;
        }
    }
}
