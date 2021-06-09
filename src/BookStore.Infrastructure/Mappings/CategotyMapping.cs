using BookStare.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Infrastructure.Mappings
{
    public class CategotyMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.ID);

            builder.Property(c => c.Name).IsRequired().HasColumnType("Varchar(150)");

            // 1 : N -> Category : Books
            builder.HasMany(c => c.Books).WithOne(b => b.Categoty).HasForeignKey(k => k.CategoryID);

            builder.ToTable("Categories");
        }
    }
}
