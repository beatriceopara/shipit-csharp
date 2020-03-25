using System.Collections.Generic;
using Mono.Security.X509;
using ShipIt.Models.ApiModels;
using ShipIt.Repositories;

namespace ShipIt.Services
{
    public interface ITrucksService
    {
        IEnumerable<Truck> GetTrucksForOrder(List<StockAlteration> lineItems);
    }
    
    public class TrucksService : ITrucksService
    {
        private readonly IProductRepository _productRepository;

        public TrucksService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        


        public IEnumerable<Truck> GetTrucksForOrder(List<StockAlteration> lineItems)
        {
            var batches = new List<Batch>();
            
            foreach (var item in lineItems)
            {
                var product = _productRepository.GetProductById(item.ProductId);
                var batch = new Batch
                {
                    Name = product.Name,
                    Gtin = product.Gtin,
                    Quantity = item.Quantity,
                    WeightPerItem = product.Weight
                };
            }

            return new List<Truck>
            {
                new Truck
                {
                    Batches = batches
                    //not sure about this part 
                }
            };
        }
    }
}