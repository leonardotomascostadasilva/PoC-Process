namespace PoC_Process.Helper;

public interface IFireForgetService2<TGateway> where TGateway : IGateway
{
    Task ExecuteAsync();
}
public class FireForgetService2<TGateway> : IFireForgetService2<TGateway> where TGateway : IGateway
{
    private readonly TGateway _gateway;

    public FireForgetService2(TGateway gateway)
    {
        _gateway = gateway;
    }

    public async Task ExecuteAsync()
    {
        try
        {
            await _gateway.ExecuteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine($"{_gateway.GetType().Name} {e}");
        }
    }
}