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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }
        public string comment { get; set; }
        public DateTime PublisDate { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsActive { get; set; }
        [NotMapped]
        public string userName { get; set; }
        public double UserStarCount { get; set; }


        public int booksId { get; set; }
        [ForeignKey("booksId")]
        public virtual Books Books { get; set; }

        public int usersId { get; set; }
        [ForeignKey("usersId")]
        public virtual Users Users { get; set; }


    }
}
