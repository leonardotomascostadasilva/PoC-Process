using Microsoft.FeatureManagement;

namespace PoC_Process.Process;

public class Process3 : AbstractProcess
{
    private readonly IFeatureManager _featureManager;

    public Process3(IFeatureManager featureManager)
    {
        _featureManager = featureManager;
    }

    protected override async Task<bool> IsEnabledAsync()
    {
        return await _featureManager.IsEnabledAsync("Process3");
    }

    protected override async Task HandlerAsync(ContextResult contextResult)
    {
        await Task.Delay(100);
        contextResult.ConcurrentBag.Add(new InfoProcess("Process3"));
        
    }
}