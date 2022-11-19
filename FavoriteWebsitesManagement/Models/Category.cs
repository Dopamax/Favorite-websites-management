using System.ComponentModel.DataAnnotations;

namespace FavoriteWebsitesManagement.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public string name {get;set; }
        public DateTime created_at { get; set; }

        public Category(string name, DateTime created_at)
        {
            this.name = name;
            this.created_at = created_at;
        }

        public Category()
        {
        }
    }
}
