using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{

    [Table("Users")]
    public partial class Users
    {
        public Users()
        {
            UserFavorites = new HashSet<UserFavorites>();
            UserStars = new HashSet<UserStars>();
            PurchaseHistory = new HashSet<PurchaseHistory>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public bool IsActive { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }


        public virtual ICollection<UserFavorites> UserFavorites { get; set; }
        public virtual ICollection<UserStars> UserStars { get; set; }
        public virtual ICollection<PurchaseHistory> PurchaseHistory { get; set; }

    }
}
