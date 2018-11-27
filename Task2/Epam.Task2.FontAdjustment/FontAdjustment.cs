using System;

namespace Epam.Task2.FontAdjustment
{
    [Flags]
    public enum FontAdjustment
    {
        none,
        bold,
        italic,
        underline = 4,
    }
}
