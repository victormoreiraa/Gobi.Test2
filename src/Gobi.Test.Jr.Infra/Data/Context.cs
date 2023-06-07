using Gobi.Test.Jr.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gobi.Test.Jr.Infra.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TodoItem> todoItems { get; set; }

        //public Context(DbContextOptions options) : base(options)
        //{
           
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder
            optionsBuilder)
        {
             
            optionsBuilder.UseSqlite($"Data Source = Gobi.Db"); // Nome do arquivo do banco de dados SQLite

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<TodoItem>().HasKey(u => u.Id); // Definindo chave primária

        }
    }

}


