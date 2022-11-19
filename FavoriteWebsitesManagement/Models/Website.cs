using System.ComponentModel.DataAnnotations;

namespace FavoriteWebsitesManagement.Models
{
    public class Website
    {
        [Key]
        public Guid Id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public Guid categoryId {get; set; }

        public Website(string name, string link, Guid categoryId)
        {
            this.name = name;
            this.link = link;
            this.categoryId = categoryId;
        }

        public Website()
        {
        }
    }
}
