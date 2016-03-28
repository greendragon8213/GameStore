using System;
using System.Collections.Generic;
using AutoMapper;
using GameStore.BusinesLogic.BLModels;
using GameStore.BusinesLogic.Services.Interfaces;
using GameStore.Data.Entities;
using GameStore.Data.UnitOfWork.Interfaces;

namespace GameStore.BusinesLogic.Services
{
    public class CommentService : ICommentService
    {
        private IUnitOfWork _unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<CommentBLModel> GetCommentsTreeByGameId(int gameId)
        {
            var game = _unitOfWork.GameRepository.GetById(gameId);
            if (game == null)
            {
                return null;
            }

            IEnumerable<CommentDataModel> comments = game.Comments;
            MakeCommentsHierarchicalStructure(comments);
            return Mapper.Map<IEnumerable<CommentBLModel>>(comments); ;
        }

        private void MakeCommentsHierarchicalStructure(IEnumerable<CommentDataModel> comments)
        {
            if (comments == null)
            {
                return;
            }

            foreach (var item in comments)
            {
                item.ChildComments = _unitOfWork.CommentRepository.GetById(item.Id).ChildComments;
                if (item.ChildComments != null)
                {
                    MakeCommentsHierarchicalStructure(item.ChildComments);
                }
            }
        }

        public void AddNewComment(string content, int gameId, int? parentCommentId, string name = "testName")
        {
            if (string.IsNullOrEmpty(content) 
                || string.IsNullOrEmpty(name)
                ||_unitOfWork.GameRepository.GetById(gameId) == null)
            {
                return;
            }

            //check if we can find comment with commentId == parentCommentId
            if (parentCommentId != null && _unitOfWork.CommentRepository.GetById(parentCommentId) == null)
                parentCommentId = null;

            //ToDo do it by using Mapper
            var commentToAdd = new CommentDataModel()
            {
                Body = content,
                CreationDate = DateTime.Now,
                GameId = gameId,
                Name = name,
                ParentCommentId = parentCommentId
            };
            
            _unitOfWork.CommentRepository.Create(commentToAdd);
            _unitOfWork.Save();
        }
    }
}
