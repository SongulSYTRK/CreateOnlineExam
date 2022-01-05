using CreateOnlinExam.UI.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreateOnlinExam.UI.Services
{
    public class QuestionServices
    {
        private readonly OnlineExamDbContext _context;
        public QuestionServices(OnlineExamDbContext context)
        {
            _context = context;
        }

        public async Task Add(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
        }

        public async Task<Question?> GetById(int id)
        {
            return await _context.Questions.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task Delete(Question question)
        {
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Question>> GetAll()
        {
            return await _context.Questions.ToListAsync();
        }

    }
}
