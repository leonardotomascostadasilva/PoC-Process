namespace PoC_Process.Process;

public abstract class AbstractProcess
{
    public async Task ExecuteAsync(ContextResult contextResult)
    {
        try
        {
            if (await IsEnabledAsync())
                await HandlerAsync(contextResult);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error {nameof(AbstractProcess)}");
        }
    }

    protected abstract Task<bool> IsEnabledAsync();
    protected abstract Task HandlerAsync(ContextResult contextResult);
}