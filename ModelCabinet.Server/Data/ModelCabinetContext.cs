using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ModelCabinet.Server.Models;

namespace ModelCabinet.Server.Data
{
    public class ModelCabinetContext : DbContext
    {
        public ModelCabinetContext(DbContextOptions<ModelCabinetContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    ProjectId = 1,
                    Name = "Test Project",
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Description = "Description",
                    Author = "Author",
                    Version = "0.0.1",
                    ShortDescription = "Desc",
                    Slug = "nomen est omen",
                },
                new Project
                {
                    ProjectId = 2,
                    Name = "Test Project Two",
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Description = "Description",
                    Author = "Author",
                    Version = "0.0.1",
                    ShortDescription = "Desc",
                    Slug = "nomen est omen",
                }
            );

            modelBuilder.Entity<Asset>().HasData(
                new Asset
                {
                    AssetId = 1,
                    Name = "Test Asset",
                    Path = Path.Combine(AppContext.BaseDirectory, "Assets", "TestProject", "HelloWorld.stl"),
                    DateCreation = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    FileSize = 446684,
                    ProjectId = 1
                },
                new Asset
                {
                    AssetId = 2,
                    Name = "Benchy",
                    Path = Path.Combine(AppContext.BaseDirectory, "Assets", "TestProject", "3DBenchy.stl"),
                    DateCreation = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    FileSize = 11285384,
                    ProjectId = 1
                }
            );

            modelBuilder.Entity<Tag>().HasData(
                new Tag
                {
                    TagID = 1,
                    TagName = "Testing"
                },
                new Tag
                {
                    TagID = 2,
                    TagName = "In Development"
                },
                new Tag
                {
                    TagID = 3,
                    TagName = "Ready To Print"
                },
                new Tag
                {
                    TagID = 4,
                    TagName = "Modular"
                }
            );

            // auto load any navigation properties using this pattern
            modelBuilder.Entity<Project>().Navigation(p => p.Assets).AutoInclude();
            modelBuilder.Entity<Project>().Navigation(p => p.ProjectTags).AutoInclude();

            modelBuilder.Entity<Asset>().Navigation(a => a.AssetTags).AutoInclude();

            modelBuilder.Entity<Tag>().HasIndex(t => t.TagName).IsUnique();
            modelBuilder.Entity<Tag>()
                .HasMany(t => t.TaggedAssets)
                .WithMany(t => t.AssetTags);
            modelBuilder.Entity<Tag>()
                .HasMany(t => t.TaggedProjects)
                .WithMany(t => t.ProjectTags);
        }

        public DbSet<ModelCabinet.Server.Models.Project> Project { get; set; } = default!;
        public DbSet<ModelCabinet.Server.Models.Asset> Asset { get; set; } = default!;
        public DbSet<ModelCabinet.Server.Models.Tag> Tag { get; set; } = default!;
    }
}
