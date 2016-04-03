using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.BusinesLogic.BLModels;

namespace GameStore.BusinesLogic.Services.Interfaces
{
    public interface IPublisherService
    {
        PublisherBLModel GetPuplisherByCompanyName(string companyName);
        void AddNewPublisher(PublisherBLModel publisher);
        PublisherBLModel GetById(int publisherId);
    }
}
