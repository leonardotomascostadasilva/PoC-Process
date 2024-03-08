namespace PoC_Process.Helper;

public class MyGateway2 : IGateway
{
    public Task ExecuteAsync()
    {
        throw new Exception("Error gateway2");
    }
}
