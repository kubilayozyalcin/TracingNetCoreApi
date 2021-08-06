using TracingNetCore.Core.Abstractions;

namespace TracingNetCore.Entities.Concrete
{
    public class Region : EntityBase, IEntity
    {
        public string AddressTitle { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string FullAddress { get; set; }
    }
}