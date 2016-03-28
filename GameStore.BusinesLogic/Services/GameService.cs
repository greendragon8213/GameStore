using System;
using System.Collections.Generic;
using AutoMapper;
using GameStore.BusinesLogic.BLModels;
using GameStore.BusinesLogic.Services.Interfaces;
using GameStore.Data.Entities;
using GameStore.Data.UnitOfWork.Interfaces;

namespace GameStore.BusinesLogic.Services
{
    public class GameService : IGameService
    {
        private IUnitOfWork _unitOfWork;

        public GameService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<GameBLModel> GetAllGames()
        {
            IEnumerable<GameDataModel> games = _unitOfWork.GameRepository.GetAll();
            return Mapper.Map<IEnumerable<GameBLModel>>(games);

        }

        public IEnumerable<GameBLModel> GetAllByGenre(int genreId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GameBLModel> GetAllByPlatform(int platformId)
        {
            throw new NotImplementedException();
        }

        public GameBLModel GetById(int gameId)
        {
            //ToDo return comments...
            GameDataModel game = _unitOfWork.GameRepository.GetById(gameId);
            return Mapper.Map<GameBLModel>(game);
        }

        public void Update(GameBLModel game)
        {
            if (string.IsNullOrWhiteSpace(game.Name)
                || string.IsNullOrWhiteSpace(game.Key)
                )
            {
                return;
            }

            GameDataModel gameToUpdate = _unitOfWork.GameRepository.GetById(game.Id);
            if (gameToUpdate == null)
            {
                Create(game);
                return;
            }
            gameToUpdate.Name = game.Name;
            gameToUpdate.Description = game.Description;
            gameToUpdate.Key = game.Key;
            //ToDo if genres or platforms changed
            _unitOfWork.GameRepository.Update(gameToUpdate);
            _unitOfWork.Save();
        }

        public void Create(GameBLModel game)
        {
            if (string.IsNullOrWhiteSpace(game.Name)
                || string.IsNullOrWhiteSpace(game.Key)
                )
            {
                return;
            }

            GameDataModel gameToCreate = Mapper.Map<GameDataModel>(game);

            _unitOfWork.GameRepository.Create(gameToCreate);
            
        }

        public void Remove(int gameId)
        {
            if (_unitOfWork.GameRepository.GetById(gameId) == null)
            {
                return;
            }
            
            _unitOfWork.GameRepository.Remove(gameId);
            _unitOfWork.Save();
        }
    }
}
