using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_il_mio_fotoalbum.Models
{
    public class Message
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("text")]
        private string Text { get; set; }

        /* [Column("email")]
         [Required]
         private string Email { get; set; }*/

        //[Column("receiver_id")]
        //public int ReceiverId { get; set; }
        //public AspNetUsers Receiver { get; set; }

        //[Column("sender_id")]
        //public int SenderId { get; set; }
        //public AspNetUsers Sender { get; set; }

        public Message() { }
        public Message(string text) {  Text = text; }
        //public Message(int id, string text, int receiverId, int senderId)
        //{
        //    Id = id;
        //    Text = text;
        //    ReceiverId = receiverId;
        //    SenderId = senderId;  
        //}
    }
}
