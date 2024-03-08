namespace PoC_Process.Helper;


public interface IGateway3 : IGateway
{
}
public class Gateway3 : IGateway3
{
    public Task ExecuteAsync()
    {
        throw new Exception("Error Gateway3");
    }
}