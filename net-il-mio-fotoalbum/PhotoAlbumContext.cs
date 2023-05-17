using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Composition;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum
{
    public class PhotoAlbumContext : IdentityDbContext<User>
    {
        
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Data Source = localhost; Initial Catalog = db_FotoAlbum; Integrated Security = True;TrustServerCertificate=True");
            }
           // public DbSet<User>? Users{get;set;}
            public DbSet<Category>? Categories { get; set; }
            public DbSet<Photo>? Photos { get; set; }
            public DbSet<Message>? Messages { get; set; }
    }
}
