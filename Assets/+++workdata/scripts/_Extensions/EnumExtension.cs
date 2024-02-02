using System;

public static class EnumExtension
{
    public static int GetIndex(this Enum _enum)
    {
        Array enumValues = Enum.GetValues(_enum.GetType());

        int index = Array.IndexOf(enumValues, _enum);

        return index;
    }
}

