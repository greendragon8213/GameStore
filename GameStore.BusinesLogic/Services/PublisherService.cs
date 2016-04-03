using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.BusinesLogic.BLModels;
using GameStore.BusinesLogic.Services.Interfaces;
using GameStore.Data.Entities;
using GameStore.Data.UnitOfWork.Interfaces;

namespace GameStore.BusinesLogic.Services
{
    public class PublisherService : IPublisherService
    {
        private IUnitOfWork _unitOfWork;

        public PublisherService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PublisherBLModel GetPuplisherByCompanyName(string companyName)
        {
            PublisherDataModel publisher = _unitOfWork.PublisherRepository.GetAll()
                .FirstOrDefault(p => p.CompanyName == companyName);
            return Mapper.Map<PublisherBLModel>(publisher);
        }

        public PublisherBLModel GetById(int publisherId)
        {
            PublisherDataModel publisher = _unitOfWork.PublisherRepository.GetById(publisherId);
            return Mapper.Map<PublisherBLModel>(publisher);
        }

        public void AddNewPublisher(PublisherBLModel publisher)
        {
            if (string.IsNullOrWhiteSpace(publisher.CompanyName)
                && string.IsNullOrWhiteSpace(publisher.Description))
            {
                return;
            }

            PublisherDataModel publisherToAdd = Mapper.Map<PublisherDataModel>(publisher);

            _unitOfWork.PublisherRepository.Create(publisherToAdd);
        }
    }
}
