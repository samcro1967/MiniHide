using System.Windows.Forms;

namespace MiniHide.Helpers;

/// <summary>
/// Represents a selectable hotkey item.
/// </summary>
public sealed class HotkeyItem
{
    public string Name { get; }

    public uint Value { get; }

    public HotkeyItem(
        string name,
        uint value)
    {
        Name = name;
        Value = value;
    }

    public override string ToString()
    {
        return Name;
    }
}

/// <summary>
/// Provides the supported modifier and key lists for MiniHide.
/// </summary>
public static class HotkeyDefinitions
{
    // RegisterHotKey modifier flags
    private const uint MOD_ALT = 0x0001;
    private const uint MOD_CONTROL = 0x0002;
    private const uint MOD_SHIFT = 0x0004;
    private const uint MOD_WIN = 0x0008;

    public static IReadOnlyList<HotkeyItem> Modifiers { get; } =
    [
        new("Control", MOD_CONTROL),
        new("Alt", MOD_ALT),
        new("Shift", MOD_SHIFT),

        new("Control + Alt",
            MOD_CONTROL | MOD_ALT),

        new("Control + Shift",
            MOD_CONTROL | MOD_SHIFT),

        new("Alt + Shift",
            MOD_ALT | MOD_SHIFT),

        new("Control + Alt + Shift",
            MOD_CONTROL | MOD_ALT | MOD_SHIFT),

        // Optional Windows-key combinations
        new("Windows", MOD_WIN),
        new("Windows + Control",
            MOD_WIN | MOD_CONTROL),

        new("Windows + Alt",
            MOD_WIN | MOD_ALT),

        new("Windows + Shift",
            MOD_WIN | MOD_SHIFT)
    ];

    public static IReadOnlyList<HotkeyItem> SupportedKeys { get; } =
    [
        // Letters
        new("A", (uint)Keys.A),
        new("B", (uint)Keys.B),
        new("C", (uint)Keys.C),
        new("D", (uint)Keys.D),
        new("E", (uint)Keys.E),
        new("F", (uint)Keys.F),
        new("G", (uint)Keys.G),
        new("H", (uint)Keys.H),
        new("I", (uint)Keys.I),
        new("J", (uint)Keys.J),
        new("K", (uint)Keys.K),
        new("L", (uint)Keys.L),
        new("M", (uint)Keys.M),
        new("N", (uint)Keys.N),
        new("O", (uint)Keys.O),
        new("P", (uint)Keys.P),
        new("Q", (uint)Keys.Q),
        new("R", (uint)Keys.R),
        new("S", (uint)Keys.S),
        new("T", (uint)Keys.T),
        new("U", (uint)Keys.U),
        new("V", (uint)Keys.V),
        new("W", (uint)Keys.W),
        new("X", (uint)Keys.X),
        new("Y", (uint)Keys.Y),
        new("Z", (uint)Keys.Z),

        // Numbers
        new("0", (uint)Keys.D0),
        new("1", (uint)Keys.D1),
        new("2", (uint)Keys.D2),
        new("3", (uint)Keys.D3),
        new("4", (uint)Keys.D4),
        new("5", (uint)Keys.D5),
        new("6", (uint)Keys.D6),
        new("7", (uint)Keys.D7),
        new("8", (uint)Keys.D8),
        new("9", (uint)Keys.D9),

        // Function keys
        new("F1", (uint)Keys.F1),
        new("F2", (uint)Keys.F2),
        new("F3", (uint)Keys.F3),
        new("F4", (uint)Keys.F4),
        new("F5", (uint)Keys.F5),
        new("F6", (uint)Keys.F6),
        new("F7", (uint)Keys.F7),
        new("F8", (uint)Keys.F8),
        new("F9", (uint)Keys.F9),
        new("F10", (uint)Keys.F10),
        new("F11", (uint)Keys.F11),
        new("F12", (uint)Keys.F12),

        // Navigation
        new("Home", (uint)Keys.Home),
        new("End", (uint)Keys.End),
        new("Insert", (uint)Keys.Insert),
        new("Delete", (uint)Keys.Delete),
        new("Page Up", (uint)Keys.PageUp),
        new("Page Down", (uint)Keys.PageDown),

        // Arrow keys
        new("Up", (uint)Keys.Up),
        new("Down", (uint)Keys.Down),
        new("Left", (uint)Keys.Left),
        new("Right", (uint)Keys.Right)
    ];
}


