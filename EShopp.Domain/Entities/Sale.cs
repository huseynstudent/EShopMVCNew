namespace EShopp.Domain.Entities;

class Sale : BaseEntity
{
    // Foreign Key
    public int OrderId { get; set; }
    // Navigation Property
    public Order Order { get; set; }

}
