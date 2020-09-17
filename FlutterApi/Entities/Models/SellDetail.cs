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
        public int ShopId {get;set;}
        public double ProductPrice {get;set;}
        public DateTime PublishDate { get; set; }
        public bool IsActive { get; set; }
        public int Status { get; set; }
        public double OfferPrice { get; set; }


        public int BooksId { get; set; }
        [ForeignKey("BookId")]
        public virtual BookTag BookTag { get; set; }

        public int userId { get; set; }
        [ForeignKey("userId")]
        public virtual Users Users { get; set; }
    }
}
