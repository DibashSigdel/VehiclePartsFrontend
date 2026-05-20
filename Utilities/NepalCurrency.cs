using System.Globalization;

namespace VehiclePartsFrontend.Utilities;

public static class NepalCurrency
{
    private static readonly CultureInfo Culture = CultureInfo.GetCultureInfo("en-NP");

    public static string Npr(decimal amount)
    {
        return $"NPR {amount.ToString("N2", Culture)}";
    }
}
