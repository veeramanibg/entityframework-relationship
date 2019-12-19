using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnetoManyFluentDemo.Model
{
    [Table("Customer")]
    public partial class Customer
    {
        public Customer()
        {
            this.CustomerDetails = new HashSet<CustomerDetails>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public virtual ICollection<CustomerDetails> CustomerDetails { get; set; }
    }
}
