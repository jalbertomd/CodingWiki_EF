﻿using CodingWiki_DataAccess.FluentConfig;
using CodingWiki_Model.Models;
using CodingWiki_Model.Models.FluentModels;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki_DataAccess.Data;

public class ApplicationDbContext : DbContext
{    
    public DbSet<Book> Books { get; set; }
    public DbSet<MainBookDetails>  MainBookDetails { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<BookAuthorMap> BookAuthorMap { get; set; }
    public DbSet<BookDetail> BookDetails { get; set; }

    // Rename to Fluent_BookDetails
    public DbSet<Fluent_BookDetail> BookDetail_fluent { get; set; }
    public DbSet<Fluent_Book> Fluent_Books { get; set; }
    public DbSet<Fluent_Author> Fluent_Authors { get; set; }
    public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }
    public DbSet<Fluent_BookAuthorMap> Fluent_BookAuthorMaps { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer("Server=LAPTOP-18553NB0;Database=CodingWiki;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
        //optionsBuilder.UseSqlServer("Server=LAPTOP-18553NB0;Database=CodingWiki;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True")
        //.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name },LogLevel.Information);

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Fluent_BookDetail>().ToTable("Fluent_BookDetails");
        //modelBuilder.Entity<Fluent_BookDetail>().Property(u => u.NumberOfChapters).HasColumnName("NoOfChapters");
        //modelBuilder.Entity<Fluent_BookDetail>().HasKey(u => u.BookDetail_Id);
        //modelBuilder.Entity<Fluent_BookDetail>().Property(u => u.NumberOfChapters).IsRequired();
        //modelBuilder.Entity<Fluent_BookDetail>().HasOne(b => b.Book).WithOne(b => b.BookDetail)
        //        .HasForeignKey<Fluent_BookDetail>(u => u.Book_Id);

        //modelBuilder.Entity<Fluent_Book>().Property(u => u.ISBN).HasMaxLength(50);
        //modelBuilder.Entity<Fluent_Book>().Property(u => u.ISBN).IsRequired();
        //modelBuilder.Entity<Fluent_Book>().HasKey(u => u.BookId);
        //modelBuilder.Entity<Fluent_Book>().Ignore(u => u.PriceRange);
        //modelBuilder.Entity<Fluent_Book>().HasOne(u => u.Publisher).WithMany(u => u.Books)
        //    .HasForeignKey(u => u.Publisher_Id);

        //modelBuilder.Entity<Fluent_Author>().Property(u => u.FirstName).HasMaxLength(50);
        //modelBuilder.Entity<Fluent_Author>().Property(u => u.FirstName).IsRequired();
        //modelBuilder.Entity<Fluent_Author>().Property(u => u.LastName).IsRequired();
        //modelBuilder.Entity<Fluent_Author>().HasKey(u => u.Author_Id);
        //modelBuilder.Entity<Fluent_Author>().Ignore(u => u.FullName);

        //modelBuilder.Entity<Fluent_Publisher>().Property(u => u.Name).IsRequired();
        //modelBuilder.Entity<Fluent_Publisher>().HasKey(u => u.Publisher_Id);

        //modelBuilder.Entity<Fluent_BookAuthorMap>().HasKey(u => new { u.Author_Id, u.Book_Id });
        //modelBuilder.Entity<Fluent_BookAuthorMap>().HasOne(u => u.Book).WithMany(u => u.BookAuthorMap)
        //    .HasForeignKey(u => u.Book_Id);
        //modelBuilder.Entity<Fluent_BookAuthorMap>().HasOne(u => u.Author).WithMany(u => u.BookAuthorMap)
        //    .HasForeignKey(u => u.Author_Id);

        modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
        modelBuilder.ApplyConfiguration(new FluentBookAuthorMapConfig());
        modelBuilder.ApplyConfiguration(new FluentBookConfig());
        modelBuilder.ApplyConfiguration(new FluentBookDetailConfig());
        modelBuilder.ApplyConfiguration(new FluentPublisherConfig());

        modelBuilder.Entity<Book>().Property(p => p.Price).HasPrecision(10,5);

        modelBuilder.Entity<BookAuthorMap>().HasKey(u => new { u.Author_Id, u.Book_Id });

        modelBuilder.Entity<Book>().HasData(
            new Book { BookId = 1, Title = "Spider without Duty", ISBN = "123B12", Price = 10.99m, Publisher_Id = 1 },
            new Book { BookId = 2, Title = "Fortune of time", ISBN = "12123B12", Price = 11.99m, Publisher_Id = 1 }
        );

        var bookList = new Book[]
            {
                new Book { BookId = 3, Title = "Fake Sunday", ISBN = "77652", Price = 20.99m, Publisher_Id=2 },
                new Book { BookId = 4, Title = "Cookie Jar", ISBN = "CC12B12", Price = 25.99m , Publisher_Id=3},
                new Book { BookId = 5, Title = "Cloudy Forest", ISBN = "90392B33", Price = 40.99m , Publisher_Id=3}
            };

        modelBuilder.Entity<Book>().HasData(bookList);

        modelBuilder.Entity<Publisher>().HasData(
            new Publisher { Publisher_Id = 1, Name = "Pub 1 Jimmy", Location = "Chicago" },
            new Publisher { Publisher_Id = 2, Name = "Pub 2 John", Location = "New York" },
            new Publisher { Publisher_Id = 3, Name = "Pub 3 Ben", Location = "Hawaii" }
            );

        modelBuilder.Entity<MainBookDetails>().HasNoKey().ToView("GetOnlyBookDetails");

        base.OnModelCreating(modelBuilder);
    }
}
