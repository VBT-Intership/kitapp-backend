using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{

    [Table("Comments")]
    public class Comments
    {

        public int CommentId { get; set; }
        public string Comment { get; set; }
        public DateTime PublisDate { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsActive { get; set; }


        




        [NotMapped]
        public bool IsUserFavorite { get; set; }
        [NotMapped]
        public int UserStarCount { get; set; }

        public virtual ICollection<ProductPhotos> ProductPhotos { get; set; }
        public virtual ICollection<SubCategories> SubCategories { get; set; }

        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Products Products { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual Products BookTag { get; set; }


    }
}
