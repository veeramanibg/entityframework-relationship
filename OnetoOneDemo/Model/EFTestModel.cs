using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnetoOneDemo.Model
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

        }
    }
}
