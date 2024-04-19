using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication1.Models;

public partial class DatabaseFirstProjectContext : DbContext
{
    public DatabaseFirstProjectContext()
    {
    }

    public DatabaseFirstProjectContext(DbContextOptions<DatabaseFirstProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<BlogPost> BlogPosts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DatabaseFirstProject;trusted_connection=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity
                .ToTable("author").HasKey(e=>e.Id);
                

            entity.Property(e => e.AuthorEmail)
                .HasMaxLength(20)
                .HasColumnName("authorEmail");
            entity.Property(e => e.AuthorName)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("authorName");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
        });

        modelBuilder.Entity<BlogPost>(entity =>
        {
            entity
                
                .ToTable("blog_post").HasKey(e=>e.Id);

            entity.Property(e => e.Author)
                .HasMaxLength(20)
                .HasColumnName("author");
            entity.Property(e => e.AuthorId).HasColumnName("authorId");
            entity.Property(e => e.Content)
                .HasMaxLength(500)
                .HasColumnName("content");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.PublicationDate).HasColumnName("publicationDate");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
