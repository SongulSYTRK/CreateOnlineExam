using CreateOnlinExam.UI.Pages;
using OnlineExam.UI.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreateOnlinExam.UI.Services
{
    public class AnswerServices
    {
        private readonly OnlineExamDbContext _context;
        public AnswerServices(OnlineExamDbContext context)
        {
            _context = context;
        }

        public async Task Add(Answer answer)
        {
            await _context.Answers.AddAsync(answer);
            _context.SaveChanges();
        }

        public async Task<Answer?> GetById(int id)
        {
            return await _context.Answers.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Answer>> GetAll()
        {
            return await _context.Answers.ToListAsync();
        }
        public async Task Delete(Answer answer)
        {
            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();
        }

    }
}
