using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using NUnit.Framework;
using ShipIt.Models.ApiModels;
using ShipIt.Models.DataModels;
using ShipIt.Repositories;
using ShipIt.Services;

namespace ShipItTest
{
    public class TrucksServiceTest
    {
        private TrucksService _trucksService;
        private IProductRepository _productRepository;

        private readonly ProductDataModel TestProduct = new ProductDataModel
        {
            Id = 17,
            Weight = 100,
            Name = "tester-id",
            Gtin = "test-id"
        };
        
        [SetUp]
        public void SetUp()
        {
            _productRepository = A.Fake<IProductRepository>();
            A.CallTo(() => _productRepository.GetProductById(17)).Returns(TestProduct);
            _trucksService = new TrucksService(_productRepository);
        }

        [Test]
        public void SmallOrderGetsPlacedOnSingleTruck()
        {
            
            var lineItems = new List<StockAlteration>
            {
                new StockAlteration(17, 3)
            };
            
            var trucks = _trucksService.GetTrucksForOrder(lineItems);

            var truckList = trucks.ToList();
            
            Assert.AreEqual(truckList.Count(), 1);
            Assert.AreEqual(truckList[0].TotalWeight, 300);
            Assert.AreEqual(truckList[0].Batches.Count, 1);
            Assert.AreEqual(truckList[0].Batches[0].Name, "tester-id");
            Assert.AreEqual(truckList[0].Batches[0].Gtin, "test-id");

        }
        
    }
}