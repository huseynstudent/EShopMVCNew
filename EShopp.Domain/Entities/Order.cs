namespace EShopp.Domain.Entities;

public class Order : BaseEntity
{
    // Foreign key
    public int ProductId { get; set; }

    // Navigation property
    public Product Product { get; set; }
    public int Quantity { get; set; } = 1;

}
