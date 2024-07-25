using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [DisplayName("Display order")]
        [Range(1,100,ErrorMessage ="Display order between 1 to 100!!")]
        public int DetailsOrder { get; set; }
        public DateTime CreatedDateTime  { get; set; } = DateTime.Now; //to create default value of date
    }
}
