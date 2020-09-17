﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{

    [Table("Books")]
    public  class Books
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int bookId { get; set; }
        public string BookName { get; set; }
        public string Isbn { get; set; }
        public bool IsFavorite { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryOfBook { get; set; }
        public DateTime PublishedTime{ get; set; }
        public int EditionNumber { get; set; }
        public int PrintNumber { get; set; }
        public string Language { get; set; }
        public string CoverType { get; set; }
        public string TypeofPaper { get; set; }
        public string WriterName { get; set; }
        public double BookStarCount { get; set; }


        [NotMapped]
        public bool IsUserFavorite { get; set; }
        [NotMapped]
        public int UserStarCount { get; set; }


        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Stars> UserStars { get; set; }


        public int categoryId { get; set; }
        [ForeignKey("categoryId")]
        public virtual  Categories Categories { get; set; }
    }
}