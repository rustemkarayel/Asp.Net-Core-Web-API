using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Models;

namespace WebApi.Repositories.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        //CONFIG = tip konfigürasyonu = bazı alanlara default değerler vermek(çekirdek(seed) datalar girmek için) ve bazı alanları kısıtlamak için.
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                 new Book { Id = 1, Title = "Karagöz ve Hacivat", Price = 75 },
                 new Book { Id = 2, Title = "Mesnevi", Price = 175 },
                 new Book { Id = 3, Title = "Devlet", Price = 375 }
                );

        }
    }
}
