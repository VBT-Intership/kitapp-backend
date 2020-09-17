using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{

    [Table("Categories")]
    public  class Categories
    {
        public Categories()
        {
            Books = new HashSet<Books>();
            UserFavorites = new HashSet<UserFavorites>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDetail { get; set; }
        public string photoUrl { get; set; }
        public int TotalItem { get; set; }

        public virtual ICollection<Books> Books { get; set; }
        public virtual ICollection<UserFavorites> UserFavorites { get; set; }

    }
}
