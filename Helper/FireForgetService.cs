namespace PoC_Process.Helper;

public interface IFireForgetService
{
    Task ExecuteAllAsync();
}
public class FireForgetService : IFireForgetService
{
    private readonly IEnumerable<IGateway> _gateways;

    public FireForgetService(IEnumerable<IGateway> gateways)
    {
        _gateways = gateways;
    }

    public async Task ExecuteAllAsync()
    {
        foreach (var gateway in _gateways)
        {
            await Task.Run(async () =>
            {
                try
                {
                    await gateway.ExecuteAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{gateway.GetType().Name}  {e}");
                }
            });
        }
    }
}