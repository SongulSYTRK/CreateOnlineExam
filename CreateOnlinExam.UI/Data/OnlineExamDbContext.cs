using CreateOnlineExam.Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CreateOnlinExam.UI.Data
{
    public class OnlineExamDbContext : DbContext
    {
        public OnlineExamDbContext(DbContextOptions<OnlineExamDbContext> options) : base(options)
        {
        }

        public DbSet<Document> Documents { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}
