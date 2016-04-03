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
        private IBaseRepository<OrderDataModel> _orderRepository;
        private IBaseRepository<OrderDetailsDataModel> _orderDetailsRepository;
        private IBaseRepository<PublisherDataModel> _publisherRepository;
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

        public IBaseRepository<OrderDataModel> OrderRepository
        {
            get
            {

                if (_orderRepository == null)
                {
                    _orderRepository = new BaseRepository<OrderDataModel>(_context);
                }
                return _orderRepository;
            }
        }

        public IBaseRepository<OrderDetailsDataModel> OrderDetailsRepository
        {
            get
            {

                if (_orderDetailsRepository == null)
                {
                    _orderDetailsRepository = new BaseRepository<OrderDetailsDataModel>(_context);
                }
                return _orderDetailsRepository;
            }
        }

        public IBaseRepository<PublisherDataModel> PublisherRepository
        {
            get
            {

                if (_publisherRepository == null)
                {
                    _publisherRepository = new BaseRepository<PublisherDataModel>(_context);
                }
                return _publisherRepository;
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
