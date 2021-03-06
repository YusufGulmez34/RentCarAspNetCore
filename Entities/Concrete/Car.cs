using Entities.Abstract;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        //Id, BrandId, ColorId, ModelYear, DailyPrice, Description
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string  Description { get; set; }
        public string Name { get; set; }

    }
}