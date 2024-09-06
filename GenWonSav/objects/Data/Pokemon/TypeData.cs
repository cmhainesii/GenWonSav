using System.Runtime.CompilerServices;

public static class TypeData
{
    private static readonly Dictionary<byte, string> _hexCodeToString = new Dictionary<byte, string>();
    private static readonly Dictionary<string, byte> _typeStringToHexCode = new Dictionary<string, byte>();

    static TypeData()
    {
        AddMapping("Normal", 0x00);
        AddMapping("Fighting", 0x01);
        AddMapping("Flying", 0x02);
        AddMapping("Poison", 0x03);
        AddMapping("Ground", 0x04);
        AddMapping("Rock", 0x05);
        AddMapping("Bug", 0x07);
        AddMapping("Ghost", 0x08);
        AddMapping("Steel", 0x09);
        AddMapping("Fire", 0x14);
        AddMapping("Water", 0x15);
        AddMapping("Grass", 0x16);
        AddMapping("Electric", 0x17);
        AddMapping("Psychic", 0x18);
        AddMapping("Ice", 0x19);
        AddMapping("Dragon", 0x1A);
        AddMapping("Dark", 0x1B);
    }

    private static void AddMapping(string name, byte hexValue)
    {
        _hexCodeToString[hexValue] = name;
        _typeStringToHexCode[name] = hexValue;
    }

    public static string GetName(byte hexValue)
    {
        if(_hexCodeToString.TryGetValue(hexValue, out string? name))
        {
            return name;
        }
        else
        {
            throw new KeyNotFoundException($"Unable to find '{hexValue}'.");
        }
    }

    public static byte GetHexValue(string name)
    {
        if(_typeStringToHexCode.TryGetValue(name, out byte hexValue))
        {
            return hexValue;
        }
        else
        {
            throw new KeyNotFoundException($"Unable to find '{name}'.");
        }
    }
}