namespace PoC_Process.Helper;

public class MyGateway : IGateway
{
   public  Task ExecuteAsync()
   {
      throw new Exception("Error gateway1");
   }
}