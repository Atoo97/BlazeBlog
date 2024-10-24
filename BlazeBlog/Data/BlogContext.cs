using BlazeBlog.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace BlazeBlog.Data
{
    public class BlogContext :DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) 
        { 
        
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }


        /* Override this method to configure the database (and other options) to be used for this context. 
         * This method is called for each instance of the context that is created. 
         * The base implementation does nothing.
         */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //Logs all events in the specified categories using the supplied action.
            //each log message being written to the console.
#if DEBUG   //->preprocessor directive
            optionsBuilder.LogTo(Console.WriteLine);
#endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        Id = 1,
                        Email = "kunhalmia@gmail.com",
                        FirstName="Attila",
                        LastName="Kunhalmi",
                        Salt="sdarsfgrtd",
                        Hash= "sdarsfgrtdsaasewdarsfgrtd/="
                    }
                );
        }
    }
}
