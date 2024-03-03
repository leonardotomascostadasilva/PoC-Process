using System.Collections.Concurrent;

namespace PoC_Process.Process;

public class ContextResult
{
    public ConcurrentBag<InfoProcess> ConcurrentBag = [];
}

public record InfoProcess(string Name);