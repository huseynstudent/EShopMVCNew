namespace EShopp.Aplication.Abstacts;

public interface IOrderService
{
    Task RemoveProductFromCart(int id);
}
