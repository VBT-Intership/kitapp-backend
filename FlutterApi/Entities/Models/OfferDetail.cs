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
        public int OfferDetalId {get;set;}
        public DateTime OfferDate {get;set;}
        public int OfferStatus { get; set; }
        public int OfferUserId { get; set; }
        public double OfferPrice { get; set; }


        public int userId { get; set; }
        [ForeignKey("userId")]
        public virtual Users Users { get; set; }

        public int SellDetalId { get; set; }
        [ForeignKey("SellDetalId")]
        public virtual SellDetail SellDetail { get; set; }
    }
}
