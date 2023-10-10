﻿using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

using System.ComponentModel.DataAnnotations;

namespace CodeFirstNewDatabaseSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                //Create and save a new Blog
                Console.WriteLine("Enter a name for a new Blog: ");
                var name = Console.ReadLine();

                var blog = new Blog { Name = name };
                db.Blogs.Add(blog);
                db.SaveChanges();


                //Display all the Blogs from the database
                var query = from b in db.Blogs
                            orderby b.Name
                            select b;

                Console.WriteLine("All Blogs in the database");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();

            }

        }
    }
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public virtual List<Post> Posts { get; set; }
        public string Url { get; set; }
    }
    public class User
    {   
        [Key]
        public string Username { get; set; }
        public string DisplayName { get; set; }
    }
    public class Post
    {
        public int PostId { get; set; }
        public string Tiltle { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.DisplayName).HasColumnName("display_name");

        }
    }
}
