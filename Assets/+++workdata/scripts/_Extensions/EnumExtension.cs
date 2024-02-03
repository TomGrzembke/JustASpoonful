using System;

public static class EnumExtension
{
    public static int GetIndex(this Enum _enum)
    {
        return Array.IndexOf(Enum.GetValues(_enum.GetType()), _enum);
    }
}

