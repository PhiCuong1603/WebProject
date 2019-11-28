using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Borrowed> Borrowed { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Process> Process { get; set; }
        public DbSet<Reader> Reader { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
