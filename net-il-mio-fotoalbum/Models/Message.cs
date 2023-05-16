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


        private string email;

        [Column("email")]
        private string Email
        {
            get => email;

            set => email = Sender.Email;
        }   

        [Column("receiver_id")]
        public string ReceiverId { get; set; }
        public User Receiver { get; set; }

        [Column("sender_id")]
        public string SenderId { get; set; }
        public User Sender { get; set; }

        public Message() { }
        public Message(string text) {  Text = text; }
        public Message(int id, string text, string receiverId, string senderId)
        {
            Id = id;
            Text = text;
            ReceiverId = receiverId;
            SenderId = senderId;
        }
    }
}
