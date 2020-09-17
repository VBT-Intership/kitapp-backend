using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("SellDetail")]
    public class SellDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int sellId {get;set;}
        public double ProductPrice {get;set;}
        public DateTime PublishDate { get; set; }
        public bool IsActive { get; set; }
        public int Status { get; set; }
        public double OfferPrice { get; set; }


        public int bookId { get; set; }
        [ForeignKey("bookId")]
        public virtual Books Books { get; set; }

        public int userId { get; set; }
        [ForeignKey("userId")]
        public virtual Users Users { get; set; }

        public virtual ICollection<OfferDetail> OfferDetail { get; set; }

    }
}
