using MiniHide.Models;

namespace MiniHide.Managers;

public sealed class ManagedWindowEventArgs : EventArgs
{
    public ManagedWindow Window { get; }

    public ManagedWindowEventArgs(ManagedWindow window)
    {
        Window = window;
    }
}


