using System;
using System.Data.Entity;
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
            Database.SetInitializer(new DbInitializer());
        }

        private readonly DbContext _context;
        private IBaseRepository<GameDataModel> _gameRepository;
        private IBaseRepository<GenreDataModel> _genreRepository;
        private IBaseRepository<PlatformTypeDataModel> _platformRepository;
        private IBaseRepository<CommentDataModel> _commentRepository;

        public UnitOfWork(DbContext context)
        {
            _context = context;
            
        }

        public IBaseRepository<GameDataModel> GameRepository
        {
            get
            {

                if (_gameRepository == null)
                {
                    _gameRepository = new BaseRepository<GameDataModel>(_context);
                }
                return _gameRepository;
            }
        }

        public IBaseRepository<GenreDataModel> GenreRepository
        {
            get
            {

                if (_genreRepository == null)
                {
                    _genreRepository = new BaseRepository<GenreDataModel>(_context);
                }
                return _genreRepository;
            }
        }

        public IBaseRepository<PlatformTypeDataModel> PlatformRepository
        {
            get
            {

                if (_platformRepository == null)
                {
                    _platformRepository = new BaseRepository<PlatformTypeDataModel>(_context);
                }
                return _platformRepository;
            }
        }

        public IBaseRepository<CommentDataModel> CommentRepository
        {
            get
            {

                if (_commentRepository == null)
                {
                    _commentRepository = new BaseRepository<CommentDataModel>(_context);
                }
                return _commentRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
