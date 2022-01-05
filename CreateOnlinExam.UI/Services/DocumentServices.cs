using CreateOnlinExam.UI.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreateOnlinExam.UI.Services
{
    public class DocumentServices
    {
        private readonly OnlineExamDbContext _context;
        public DocumentServices(OnlineExamDbContext context)
        {
            _context = context;
        }

        public async Task Add(Document document)
        {
            await _context.Documents.AddAsync(document);
            await _context.SaveChangesAsync();
        }

        public async Task<Document?> GetById(int id)
        {
            return await _context.Documents.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Document>> GetAll()
        {
            return await _context.Documents.ToListAsync();
        }
        public async Task Delete(Document document)
        {
            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();
        }
    }
}
