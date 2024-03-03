using Microsoft.FeatureManagement;

namespace PoC_Process.Process;

public class Process2 : AbstractProcess
{
    private readonly IFeatureManager _featureManager;

    public Process2(IFeatureManager featureManager)
    {
        _featureManager = featureManager;
    }

    protected override async Task<bool> IsEnabledAsync()
    {
        return await _featureManager.IsEnabledAsync("Process2");
    }

    protected override async Task HandlerAsync(ContextResult contextResult)
    {
        await Task.Delay(100);
        contextResult.ConcurrentBag.Add(new InfoProcess("Process2"));
    }
}