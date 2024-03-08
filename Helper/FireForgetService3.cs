namespace PoC_Process.Helper;


public class FireForgetService3 : IGateway4
{
    private readonly IGateway4 _gateway4;

    public FireForgetService3(IGateway4 gateway4)
    {
        _gateway4 = gateway4;
    }

    public async Task ExecuteAsync()
    {
        try
        {
            await _gateway4.ExecuteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine($"{_gateway4.GetType().Name}  {e}");
        }
    }
}