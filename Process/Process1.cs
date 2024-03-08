using Microsoft.FeatureManagement;
using PoC_Process.Helper;

namespace PoC_Process.Process;

public class Process1 : AbstractProcess
{
    private readonly IFeatureManager _featureManager;
    private readonly IFireForgetService _fireForgetService;
    private readonly IFireForgetService2<IGateway3> _fireForgetService2;
    private readonly IGateway4 _gateway4;
    public Process1(IFeatureManager featureManager, IFireForgetService fireForgetService, IFireForgetService2<IGateway3> fireForgetService2, IGateway4 gateway4)
    {
        _featureManager = featureManager;
        _fireForgetService = fireForgetService;
        _fireForgetService2 = fireForgetService2;
        _gateway4 = gateway4;
    }

    protected override async Task<bool> IsEnabledAsync()
    {
        return await _featureManager.IsEnabledAsync("Process1");
    }

    protected override async Task HandlerAsync(ContextResult contextResult)
    {
        await Task.Delay(100);
        contextResult.ConcurrentBag.Add(new InfoProcess("Process1"));
        //await _gateway4.ExecuteAsync();
        FireForgetAsync();
    }

    private void FireForgetAsync()
    {
        Task.Run(async () =>
        {
            try
            {
                await _gateway4.ExecuteAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error!!!!!");
                
            }
        });
    }
}