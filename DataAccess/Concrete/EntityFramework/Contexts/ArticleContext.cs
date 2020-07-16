using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class ArticleContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ENGIN\SQLEXPRESS;Initial Catalog=ArticleDb;Integrated Security=True");
        }
        public DbSet<Article> Articles { get; set; }
    }
}
