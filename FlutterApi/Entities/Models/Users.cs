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
            UserStars = new HashSet<Stars>();
            SellDetail = new HashSet<SellDetail>();
            OfferDetail = new HashSet<OfferDetail>();
            UserFavoritesCategories = new HashSet<UserFavoritesCategories>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime IDate { get; set; }
        public string RefreshToken { get; set; }
        public bool IsActive { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }


        public virtual ICollection<UserFavorites> UserFavorites { get; set; }
        public virtual ICollection<UserFavoritesCategories> UserFavoritesCategories { get; set; }
        public virtual ICollection<Stars> UserStars { get; set; }
        public virtual ICollection<SellDetail> SellDetail { get; set; }
        public virtual ICollection<OfferDetail> OfferDetail { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }

    }
}
