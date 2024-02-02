using UnityEngine;

public enum ColorChannels
{
    R,
    G,
    B,
    A
}

public static class ColorExtensions
{
    public static Color ChangeChannel(this Color target, ColorChannels channel, float value)
    {
        if (channel.Equals(ColorChannels.R))
            target.r = value;
        else if (channel.Equals(ColorChannels.G))
            target.g = value;
        else if (channel.Equals(ColorChannels.B))
            target.b = value;
        else if (channel.Equals(ColorChannels.A))
            target.a = value;

        return target;
    }
}