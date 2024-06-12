using Microsoft.EntityFrameworkCore;

namespace FAQ.Models
{
    public class FaqDbContext : DbContext
    {
        public FaqDbContext(DbContextOptions<FaqDbContext> options)
            : base(options)
        {
        }

        // These are the tables in our database
        public DbSet<Question> Questions { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Category> Categories { get; set; }

        // This method is used to configure the relationships between tables and to seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Each topic can have many questions
            modelBuilder.Entity<Topic>()
                .HasMany(t => t.Questions)
                .WithOne(q => q.Topic)
                .HasForeignKey(q => q.TopicId);

            // Each category can have many questions as well
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Questions)
                .WithOne(q => q.Category)
                .HasForeignKey(q => q.CategoryId);

            // Seed data for Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Name = "General" },
                new Category { Name = "Maintenance" },
                new Category { Name = "History" }
            );

            // Seed data for Topics
            modelBuilder.Entity<Topic>().HasData(
                new Topic { Name = "Retriever" },
                new Topic { Name = "Chihuahua" },
                new Topic { Name = "Pomeranian" }
            );

            // Seed data for Questions
            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    Id = 1,
                    QuestionText = "How intellegent are Retreivers?",
                    Answer = "They are very intelligent..",
                    TopicId = "Retriever",
                    CategoryId = "General"
                },
                new Question
                {
                    Id = 2,
                    QuestionText = "How do I maintain my Retriever?",
                    Answer = "Regular grooming and vet check-ups are essential...",
                    TopicId = "Retriever",
                    CategoryId = "Maintenance"
                },
                new Question
                {
                    Id = 3,
                    QuestionText = "What is the history of the Retriever breed?",
                    Answer = "Retrievers were originally bred as hunting dogs...",
                    TopicId = "Retriever",
                    CategoryId = "History"
                },
                new Question
                {
                    Id = 4,
                    QuestionText = "How big do Chihuahuas get?",
                    Answer = "Chihuahuas typically weigh between 2-6 pounds...",
                    TopicId = "Chihuahua",
                    CategoryId = "General"
                },
                new Question
                {
                    Id = 5,
                    QuestionText = "How often should I feed my Chihuahua?",
                    Answer = "Adult Chihuahuas should be fed 2-3 times a day...",
                    TopicId = "Chihuahua",
                    CategoryId = "Maintenance"
                },
                new Question
                {
                    Id = 6,
                    QuestionText = "What is the origin of the Chihuahua breed?",
                    Answer = "Chihuahuas are believed to have originated in Mexico...",
                    TopicId = "Chihuahua",
                    CategoryId = "History"
                },
                new Question
                {
                    Id = 7,
                    QuestionText = "Are Pomeranians good with kids?",
                    Answer = "Pomeranians can be good with kids if socialized early...",
                    TopicId = "Pomeranian",
                    CategoryId = "General"
                },
                new Question
                {
                    Id = 8,
                    QuestionText = "How do I groom my Pomeranian?",
                    Answer = "Regular brushing and occasional baths are recommended...",
                    TopicId = "Pomeranian",
                    CategoryId = "Maintenance"
                },
                new Question
                {
                    Id = 9,
                    QuestionText = "What is the history of the Pomeranian breed?",
                    Answer = "Pomeranians are descended from large sled dogs...",
                    TopicId = "Pomeranian",
                    CategoryId = "History"
                }
            );
        }
    }
}