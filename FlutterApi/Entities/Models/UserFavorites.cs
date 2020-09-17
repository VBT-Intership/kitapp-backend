﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("UserFavorites")]
    public class UserFavorites
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int BooksId { get; set; }
        [ForeignKey("BookId")]
        public virtual BookTag BookTag { get; set; }

        public int userId { get; set; }
        [ForeignKey("userId")]
        public virtual Users Users { get; set; }
    }
}
