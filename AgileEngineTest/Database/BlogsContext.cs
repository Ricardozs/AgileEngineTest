using AgileEngineTest.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileEngineTest.Database
{
    public class BlogsContext : DbContext
    {
        public DbSet<BlogEntity> BlogsEntities { get; set; }
        public DbSet<PostEntity> PostsEntities { get; set; }

        public BlogsContext(DbContextOptions<BlogsContext> options)
            : base(options)
        {
            // Do not remove
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Table mapping
            modelBuilder.Entity<BlogEntity>().ToTable("blogs");
            modelBuilder.Entity<PostEntity>().ToTable("articles");

            // Primary Keys.
            modelBuilder.Entity<BlogEntity>().HasKey(b => b.BlogId).HasName("blog_id");
            modelBuilder.Entity<PostEntity>().HasKey(p => p.PostId).HasName("post_id");

            // Columns config.
            // BlogEntity
            modelBuilder.Entity<BlogEntity>().Property(b => b.BlogId).HasColumnType("int").IsRequired();
            modelBuilder.Entity<BlogEntity>().Property(b => b.Name).HasColumnType("varchar(50)").IsRequired();
            modelBuilder.Entity<BlogEntity>().Property(b => b.IsActiveString).HasColumnName("IsActive").HasColumnType("varchar(20)").IsRequired();
            // PostEntiry
            modelBuilder.Entity<PostEntity>().Property(p => p.PostId).HasColumnType("int").IsRequired();
            modelBuilder.Entity<PostEntity>().Property(p => p.ParentId).HasColumnType("int").IsRequired();
            modelBuilder.Entity<PostEntity>().Property(p => p.Name).HasColumnType("varchar(50)").IsRequired();
            modelBuilder.Entity<PostEntity>().Property(p => p.Content).HasColumnType("varchar(1000)").IsRequired();
            modelBuilder.Entity<PostEntity>().Property(p => p.Created).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<PostEntity>().Property(p => p.Updated).HasColumnType("datetime");

            // Ignore
            modelBuilder.Entity<BlogEntity>().Ignore(b => b.IsActive);

            // Foreing Keys.
            //BlogEntity
            modelBuilder.Entity<PostEntity>()
                .HasOne<BlogEntity>()
                .WithMany()
                .HasPrincipalKey(n => n.BlogId)
                .HasForeignKey(p => p.ParentId);
            modelBuilder.Entity<BlogEntity>()
                .HasOne<PostEntity>()
                .WithMany()
                .HasPrincipalKey(n => n.ParentId)
                .HasForeignKey(p => p.BlogId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        public async Task<List<T>> GetListAsnyc<T>() where T : class
        {
            try
            {
                return await Set<T>().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> GetEntityAsnyc<T>(int id) where T : class
        {
            try
            {
                var entity = await Set<T>().FindAsync(id);
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> AddAsync<T>(T entity) where T : class
        {
            try
            {
                Set<T>().Add(entity);
                await SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateAsync<T>(T entity) where T : class
        {
            try
            {
                Set<T>().Update(entity);
                return (await SaveChangesAsync()) > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync<T>(int id) where T : class
        {
            try
            {
                var entity = Set<T>().Find(id);
                Set<T>().Remove(entity);
                return (await SaveChangesAsync()) > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
