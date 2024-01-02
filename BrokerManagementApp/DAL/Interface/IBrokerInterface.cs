using BrokerManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerManagementApp.DAL.Interface
{
    public interface IBrokerInterface 
    {
        Broker GetBrokerById(int brokerId);
        IEnumerable<Broker> GetAllBrokers();
        Broker AddBroker(Broker broker);
        Broker UpdateBroker(Broker broker);
        Broker DeleteBroker(int brokerId);
    }
}