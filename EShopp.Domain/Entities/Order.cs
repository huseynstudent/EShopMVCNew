
namespace EShopp.Domain.Entities;

class Order : BaseEntity
{
    List<Product> Products { get; set; }
    int TotalAmount { get; set; } = 0;
}
