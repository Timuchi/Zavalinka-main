using Zavalinka.DB.Entities;
using Zavalinka.DB.Repository.AnswerRepository;
using Zavalinka.DB.Repository.Base;

namespace Zavalinka.DB.Repository.Game;

public class GameRepository : BaseRepository<GameEntity>, IGameRepository
{
    public GameRepository(AppDbContext context) : base(context)
    {
    }
}