using Microsoft.AspNetCore.Mvc;
using BrokerManagementApp.DAL.Interface;
using BrokerManagementApp.Models;

namespace BrokerManagementApp.Controllers
{
    public class BrokerController : Controller
    {
        private readonly IBrokerInterface _brokerRepository;

        public BrokerController(IBrokerInterface brokerRepository)
        {
            _brokerRepository = brokerRepository;
        }

        // GET: /Broker/Index
        public IActionResult Index()
        {
            var brokers = _brokerRepository.GetAllBrokers();
            return View(brokers);
        }

        // GET: /Broker/Details/{id}
        public IActionResult Details(int id)
        {
            var broker = _brokerRepository.GetBrokerById(id);

            if (broker == null)
            {
                return NotFound(); // 404 Not Found
            }

            return View(broker);
        }

        // GET: /Broker/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Broker/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Broker broker)
        {
            if (ModelState.IsValid)
            {
                _brokerRepository.AddBroker(broker);
                return RedirectToAction("Index");
            }

            return View(broker);
        }

        // GET: /Broker/Edit/{id}
        public IActionResult Edit(int id)
        {
            var broker = _brokerRepository.GetBrokerById(id);

            if (broker == null)
            {
                return NotFound(); // 404 Not Found
            }

            return View(broker);
        }

        // POST: /Broker/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Broker updatedBroker)
        {
            if (id != updatedBroker.BrokerId)
            {
                return BadRequest(); // 400 Bad Request
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _brokerRepository.UpdateBroker(updatedBroker);
                }
                catch (ArgumentException)
                {
                    return NotFound(); // 404 Not Found
                }

                return RedirectToAction("Index");
            }

            return View(updatedBroker);
        }

        // GET: /Broker/Delete/{id}
        public IActionResult Delete(int id)
        {
            var broker = _brokerRepository.GetBrokerById(id);

            if (broker == null)
            {
                return NotFound(); // 404 Not Found
            }

            return View(broker);
        }

        // POST: /Broker/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var deletedBroker = _brokerRepository.DeleteBroker(id);

            if (deletedBroker == null)
            {
                return NotFound(); // 404 Not Found
            }

            return RedirectToAction("Index");
        }
    }
}
