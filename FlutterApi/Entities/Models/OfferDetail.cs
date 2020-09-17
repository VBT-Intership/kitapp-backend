using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("OfferDetail")]
    public class OfferDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SellDetalId {get;set;}
        public DateTime OfferDate {get;set;}
        public int OfferStatus { get; set; }
        public int colorType { get; set; }
        public int OfferUserId { get; set; }
        public double OfferPrice { get; set; }


        public int BooksId { get; set; }
        [ForeignKey("BookId")]
        public virtual BookTag BookTag { get; set; }
    }
}
