namespace PoC_Process.Helper;


public interface IGateway4
{
    Task ExecuteAsync();
}
public class Gateway4 : IGateway4
{
    public Task ExecuteAsync()
    {
        throw new Exception("Error Gateway4");
    }
}