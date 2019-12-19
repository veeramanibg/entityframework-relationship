using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnetoManyDemo.Model
{
    [Table("CustomerDetails")]
    public partial class CustomerDetails
    {
        [Key]
        [Column(Order =1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactID { get; set; }

        [Key,ForeignKey("Customer")]
        [Column(Order = 2)]
        public int CustomerID { get; set; }

        [StringLength(255)]
        [Required]
        public string Email { get; set; }

        [StringLength(255)]
        [Required]
        public string Address { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
