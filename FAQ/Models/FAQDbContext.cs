using Microsoft.EntityFrameworkCore;

namespace FAQ.Models
{
    public class FaqDbContext : DbContext
    {
        public FaqDbContext(DbContextOptions<FaqDbContext> options)
            : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>()
                .HasMany(t => t.Questions)
                .WithOne(q => q.Topic)
                .HasForeignKey(q => q.TopicId);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Questions)
                .WithOne(q => q.Category)
                .HasForeignKey(q => q.CategoryId);

            // Seed data for Topics
            modelBuilder.Entity<Topic>().HasData(
                new Topic { Name = "Getting Started" },
                new Topic { Name = "Orders" },
                new Topic { Name = "Customer Service" }
            );

            // Seed data for Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Name = "General" },
                new Category { Name = "Account" },
                new Category { Name = "Shipping" }
            );

            // Seed data for Questions
            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    Id = 1,
                    QuestionText = "What is Contoso University?",
                    Answer = "Contoso University is a sample application that...",
                    TopicId = "Getting Started",
                    CategoryId = "General"
                }
            // Add more Questions as needed
            );
        }
    }
}