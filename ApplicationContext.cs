using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    class ApplicationContext : DbContext
    {
        public DbSet<Debt> debts { get; set; }

        public DbSet<Book> books { get; set; }

        public ApplicationContext() : base("DefaultConnection") { }


    }
}
