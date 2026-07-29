namespace MiniHide.Models;

public sealed class ManagedWindow
{
    public required IntPtr Handle { get; init; }

    public required string Title { get; init; }

    public required uint ProcessId { get; init; }

    public required string ProcessName { get; init; }

    public required string ClassName { get; init; }

    public Image? Icon { get; init; }
}


