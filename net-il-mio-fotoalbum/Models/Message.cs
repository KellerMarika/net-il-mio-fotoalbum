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

        [Column("created_at")]
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        [Column("text")]
        private string Text { get; set; }

      //  private string email;

        //[Column("email")]
        //private string Email
        //{
        //    get => email;

        //    set => email = Sender.Email;
        //}


        //[Column("Receiver_Id")]
        //[ForeignKey("Receiver")]
        //public string ReceiverId { get; set; }
        //public User Receiver { get; set; }

        //[Column("Sender_Id")]
        //[ForeignKey("Sender")]
        //public string SenderId { get; set; }
        //public User Sender { get; set; }

        public Message() { }
        public Message(string text) {  Text = text; }
        //public Message(string text, string receiverId, string senderId)
        //{
        //    Text = text;
        //    ReceiverId = receiverId;
        //    SenderId = senderId;
        //}
    }
}
