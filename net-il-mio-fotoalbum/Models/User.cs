using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_il_mio_fotoalbum.Models
{
    public class User : IdentityUser
    {
      public List<Photo>? Photos { get; set; }

        //[InverseProperty("Sender")]
        //public List<Message>? SentMessages { get; set; }

        //[InverseProperty("Receiver")]
        //public List<Message>? ReceivedMessages { get; set; }

      //  public List<Message>? Messages()=> SentMessages?.Concat(ReceivedMessages).OrderBy(m => m.CreationDate).ToList();
    }
}
