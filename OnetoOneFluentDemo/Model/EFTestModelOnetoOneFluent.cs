using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace OnetoOneFluentDemo.Model
{
    class EFTestModelOnetoOneFluent:DbContext
    {
        public EFTestModelOnetoOneFluent():base("name=DefaultConnection")
        {

        }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<CustomerDetails> CustomerDetails { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(c => c.CustomerID).HasOptional(e => e.CustomerDetails).WithRequired(e => e.Customer);
        }
    }
}
