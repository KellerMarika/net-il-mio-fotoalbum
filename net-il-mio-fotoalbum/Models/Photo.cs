using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_il_mio_fotoalbum.Models
{
    [Table("photos")]
    public class Photo
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        [Required]
        public string Title { get; set; }

        [Column("description")]
        [Required]      
        public string Description { get; set; }

        [Column("is_visible")]
        public bool Visible { get; set; }=false;

        [Column("img")]
        public string Image { get; set; }

        public List<Category>? Categories { get; set; } = new List<Category>();

        public Photo() { }
        public Photo( string title, string description, bool visible, string? image)
        {
            Title = title;
            Description = description;
            Visible = visible;
            Image = image;
            Categories = new List<Category>();

        }
    }
}
