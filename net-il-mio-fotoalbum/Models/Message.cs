using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_il_mio_fotoalbum.Models
{
    [Table("messages")]
    public class Message
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

      /*  [Column("created_at")]
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;*/

        [Column("text")]
        public string Text { get; set; }

        [Column("email")]
        public string Email { get; set; }


        public Message() { }
        public Message(string text, string email) {  Text = text; Email = email; }
    }
}
