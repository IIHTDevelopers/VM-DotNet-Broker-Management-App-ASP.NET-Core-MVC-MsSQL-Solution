using BrokerManagementApp.DAL.Interface;
using BrokerManagementApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrokerManagementApp.DAL.Repository
{
    public class BrokerManagementService : IBrokerInterface
    {
        private IBrokerRepository _repo;
        public BrokerManagementService(IBrokerRepository repo)
        {
            this._repo = repo;
        }

        public Broker AddBroker(Broker broker)
        {
            return _repo.AddBroker(broker);
        }

        public Broker DeleteBroker(int brokerId)
        {
            return _repo.DeleteBroker(brokerId);
        }

        public IEnumerable<Broker> GetAllBrokers()
        {
            return _repo.GetAllBrokers();
        }

        public Broker GetBrokerById(int brokerId)
        {
            return _repo.GetBrokerById(brokerId);
        }

        public Broker UpdateBroker(Broker broker)
        {
            return _repo.UpdateBroker(broker);
        }
    }
}