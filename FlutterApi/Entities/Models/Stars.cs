using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("Stars")]
    public class Stars
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int StarCount { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsActive { get; set; }

        public int bookId { get; set; }
        [ForeignKey("bookId")]
        public virtual Books Books { get; set; }


        public int userId { get; set; }
        [ForeignKey("userId")]
        public virtual Users Users { get; set; }
    }
}
