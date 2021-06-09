using BookStare.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Infrastructure.Mappings
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.Name).IsRequired().HasColumnType("Varchar(150)");

            builder.Property(x => x.Authot).IsRequired().HasColumnType("Varchar(150)");
            
            builder.Property(x => x.Description).IsRequired(false).HasColumnType("Varchar(Max)");

            builder.Property(x => x.Vakue).IsRequired();

            builder.Property(x => x.PublishDate).IsRequired();

            builder.Property(x => x.CategoryID).IsRequired();

            builder.ToTable("Books");
        }
    }
}
