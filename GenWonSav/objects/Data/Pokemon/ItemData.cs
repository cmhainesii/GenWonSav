public static class ItemData
{
    private static readonly Dictionary<byte, string> _keyToString = new Dictionary<byte, string>();
    private static readonly Dictionary<string, byte> _stringToKey = new Dictionary<string, byte>();

    static ItemData()
    {
        AddMapping(0x01, "Master Ball");
        AddMapping(0x02, "Ultra Ball");
        AddMapping(0x03, "Great Ball");
        AddMapping(0x04, "Pokémon Ball");
    }

    private static void AddMapping(byte hexCode, string name)
    {
        _keyToString[hexCode] = name;
        _stringToKey[name] = hexCode;
    }

}