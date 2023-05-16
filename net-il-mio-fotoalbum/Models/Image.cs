using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_il_mio_fotoalbum.Models
{
    public class Image
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("data")]
        public byte[] Data { get; set; }

        //rel 1-1
        public Photo Photo { get; set; }
        [Column("photo_id")]
        public int PhotoId { get; set; }

        //costruttori
        public Image() { }  
        public Image(byte[] data, int photoId) { Data = data; PhotoId = photoId;}
    }
}
