using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Data.Abstract;
using GameStore.Data.Entities;

namespace GameStore.Data.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        IBaseRepository<Comment> CommentRepository { get; }
        IBaseRepository<Game> GameRepository { get; }
        IBaseRepository<Genre> GenreRepository { get; }
        IBaseRepository<PlatformType> PlatformRepository { get; }
        void Save();
    }
}
