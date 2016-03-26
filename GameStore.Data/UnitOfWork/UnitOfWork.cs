using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Data.Abstract;
using GameStore.Data.Concrete;
using GameStore.Data.Entities;
using GameStore.Data.UnitOfWork.Interfaces;

namespace GameStore.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        static UnitOfWork()
        {
            //ToDo it by EF!!!
            //Database.SetInitializer(new StoreInitializer());
        }

        private DbContext context;
        private IBaseRepository<Game> _gameRepository;
        private IBaseRepository<Genre> _genreRepository;
        private IBaseRepository<PlatformType> _platformRepository;
        private IBaseRepository<Comment> _commentRepository;

        public UnitOfWork(GameStoreDbContext context)
        {
            this.context = context;
        }

        public IBaseRepository<Game> GameRepository
        {
            get
            {

                if (_gameRepository == null)
                {
                    _gameRepository = new BaseRepository<Game>(context);
                }
                return _gameRepository;
            }
        }

        public IBaseRepository<Genre> GenreRepository
        {
            get
            {

                if (this._genreRepository == null)
                {
                    this._genreRepository = new BaseRepository<Genre>(context);
                }
                return _genreRepository;
            }
        }

        public IBaseRepository<PlatformType> PlatformRepository
        {
            get
            {

                if (this._platformRepository == null)
                {
                    this._platformRepository = new BaseRepository<PlatformType>(context);
                }
                return _platformRepository;
            }
        }

        public IBaseRepository<Comment> CommentRepository
        {
            get
            {

                if (this._commentRepository == null)
                {
                    this._commentRepository = new BaseRepository<Comment>(context);
                }
                return _commentRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
