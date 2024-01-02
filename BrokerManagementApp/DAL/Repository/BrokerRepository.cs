using BrokerManagementApp.DAL.Interface;
using BrokerManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BrokerManagementApp.DAL.Repository
{
    public class BrokerRepository : IBrokerRepository
    {
        private BrokerDbContext _context;
        public BrokerRepository(BrokerDbContext Context)
        {
            this._context = Context;
        }
      
        public Broker GetBrokerById(int brokerId)
        {
            return _context.Brokers.Find(brokerId);
        }

        public IEnumerable<Broker> GetAllBrokers()
        {
            return _context.Brokers.ToList();
        }

        public Broker AddBroker(Broker broker)
        {
            if (broker != null)
            {
                _context.Brokers.Add(broker);
                _context.SaveChanges(); // Save changes to the database
                return broker; // Return the added broker with the updated Id
            }
            else
            {
                // Handle the case where the input broker is null
                throw new ArgumentNullException(nameof(broker), "Broker object cannot be null");
            }
        }


        public Broker UpdateBroker(Broker updatedBroker)
        {
            if (updatedBroker != null)
            {
                var existingBroker = _context.Brokers.Find(updatedBroker.BrokerId);

                if (existingBroker != null)
                {
                    // Update properties of the existing broker with the new values
                    _context.Entry(existingBroker).CurrentValues.SetValues(updatedBroker);
                    _context.SaveChanges(); // Save changes to the database
                    return existingBroker;
                }
                else
                {
                    // Handle the case where the broker with the given Id is not found
                    throw new ArgumentException($"Broker with Id {updatedBroker.BrokerId} not found", nameof(updatedBroker));
                }
            }
            else
            {
                // Handle the case where the input broker is null
                throw new ArgumentNullException(nameof(updatedBroker), "Updated broker object cannot be null");
            }
        }

        public Broker DeleteBroker(int brokerId)
        {
            var brokerToDelete = _context.Brokers.Find(brokerId);

            if (brokerToDelete != null)
            {
                _context.Brokers.Remove(brokerToDelete);
                _context.SaveChanges(); // Save changes to the database
                return brokerToDelete;
            }
            else
            {
                // Handle the case where the broker with the given Id is not found
                throw new ArgumentException($"Broker with Id {brokerId} not found", nameof(brokerId));
            }
        }
    }
}
