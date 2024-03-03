using System.Collections.Concurrent;

namespace PoC_Process.Process;

public interface IExecuteProcess
{
    Task<IEnumerable<InfoProcess>> ExecuteAllProcessAsync();
}

public class ExecuteProcess : IExecuteProcess
{
    private readonly IEnumerable<AbstractProcess> _process;

    public ExecuteProcess(IEnumerable<AbstractProcess> process)
    {
        _process = process;
    }

    public async Task<IEnumerable<InfoProcess>> ExecuteAllProcessAsync()
    {
        var context = new ContextResult();

        await Task.WhenAll(
            _process
                .Select(e => e.ExecuteAsync(context))
        );

        return context
            .ConcurrentBag
            .OrderByDefinitionHash();
    }
}

public static class Order
{
    private static readonly HashSet<string> ProcessOrder =
    [
        "Process2",
        "Process3",
        "Process1"
    ];

    public static IOrderedEnumerable<InfoProcess> OrderByDefinitionHash(this ConcurrentBag<InfoProcess> list)
    {
        var orderedEnumerable = list.OrderBy(process =>
            ProcessOrder.Contains(process.Name) ? ProcessOrder.ToList().IndexOf(process.Name) : ProcessOrder.Count);

        return orderedEnumerable;
    }

    public static IEnumerable<InfoProcess> OrderByDefinitionQueue(this ConcurrentBag<InfoProcess> list)
    {
        var process2 = new ConcurrentQueue<InfoProcess>();
        var process3 = new ConcurrentQueue<InfoProcess>();
        var process1 = new ConcurrentQueue<InfoProcess>();
        var otherProcesses = new ConcurrentQueue<InfoProcess>();

        Parallel.ForEach(list, process =>
        {
            switch (process.Name)
            {
                case "Process2":
                    process2.Enqueue(process);
                    break;
                case "Process3":
                    process3.Enqueue(process);
                    break;
                case "Process1":
                    process1.Enqueue(process);
                    break;
                default:
                    otherProcesses.Enqueue(process);
                    break;
            }
        });
        return process2
            .Concat(process3)
            .Concat(process1)
            .Concat(otherProcesses);
    }
}
