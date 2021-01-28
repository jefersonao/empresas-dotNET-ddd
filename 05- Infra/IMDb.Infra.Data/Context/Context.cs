using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDb.Infra.Data.Context
{
    public class DB : DbContext
    {   
        public DbSet<Actor> actors { get; set; }
        public DbSet<Movie> movies { get; set; }
        public DbSet<MovieGenre> movieGenres { get; set; }
        public DbSet<Rating> ratings { get; set; }
        public DbSet<User> users { get; set; }        


        public IDbContextTransaction Transaction { get; private set; }

        public DB(DbContextOptions<DB> options)
            : base(options)
        {
            if (Database.GetPendingMigrations().Count() > 0)
                Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        public IDbContextTransaction InitTransaction()
        {
            if (Transaction == null) Transaction = this.Database.BeginTransaction();
            return Transaction;
        }


        private void RollBack()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
            }
        }

        private void Save()
        {
            try
            {
                ChangeTracker.DetectChanges();
                SaveChangesAsync();


            }
            catch (Exception e)
            {
                RollBack();
                throw new Exception(e.Message);
            }
        }


        private void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
            }
        }

        public void SendChanges()
        {
            Save();
            Commit();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
