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
        private string Title { get; set; }

        [Column("description")]
        [Required]      
        public string Description { get; set; }

        [Column("visible")]
        public bool Visible { get; set; }=false;

        [NotMapped] public IFormFile? ImgFormFile { get; set; }

        //relations
        [Column("image_id")]
        public int? ImgeId { get; set; }
        public Image? Image { get; set; }
        [NotMapped] public string ImageBase64 => Image == null ? "" : "data:image/jpg;base64," + Convert.ToBase64String(Image.Data);
        public List<Category> Categories { get; set; }

        //[Column("user_id")]
        //public int UserId{get;set;}
        //public AspNetUsers User{get;set;}

        public Photo() { }
        public Photo( string title, string description, bool visible, int? imgeId)
        {
            Title = title;
            Description = description;
            Visible = visible;
            ImgeId = imgeId;
        }
    }
}
