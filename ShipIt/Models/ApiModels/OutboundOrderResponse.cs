using System.Collections.Generic;
using System.Linq;

namespace ShipIt.Models.ApiModels
{
    public class OutboundOrderResponse
    {
        public IEnumerable<Truck> Trucks { get; set;}
        public double NumberOfTrucks => Trucks.Count();
    }

    public class Truck
    {
        public List<Batch> Batches { get; set; }
        public double TotalWeight => Batches.Sum(batch => batch.TotalWeight);
    }

    public class Batch
    {
        public string Gtin { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set;}
        public double WeightPerItem { get; set;}
        public double TotalWeight => WeightPerItem * Quantity;
    }
}