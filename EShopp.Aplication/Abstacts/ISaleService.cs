namespace EShopp.Aplication.Abstacts;

public interface ISaleService
{
    Task<bool> BuyAsync(int id);
}
