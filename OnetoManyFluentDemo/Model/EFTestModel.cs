using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnetoManyFluentDemo.Model
{
    public partial class EFTestModel : DbContext
    {
        public EFTestModel() : base("name=DefaultConnection")
        {

        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerDetails> CustomerDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CustomerDetails>().HasKey(cd=>cd.ContactID).HasRequired<Customer>(s => s.Customer).WithMany(s => s.CustomerDetails).HasForeignKey(s => s.CustomerID);
        }
    }
}
