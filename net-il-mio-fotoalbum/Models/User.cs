using Microsoft.AspNetCore.Identity;

namespace net_il_mio_fotoalbum.Models
{
    public class User : IdentityUser
    {
      public List<Photo>? Photos { get; set; }
      public List <Message>? Messages { get; set; }
    }
}
