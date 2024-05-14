using Zavalinka.DB.Entities;
using Zavalinka.DB.Repository.Base;

namespace Zavalinka.DB.Repository.AnswerRepository;

public class AnswerRepository : BaseRepository<AnswerEntity>, IAnswerRepository
{
    public AnswerRepository(AppDbContext context) : base(context)
    {
    }
}