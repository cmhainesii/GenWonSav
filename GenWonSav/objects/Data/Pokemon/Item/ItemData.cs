public static class ItemData
{
    private static readonly Dictionary<byte, string> _keyToString = new Dictionary<byte, string>();
    private static readonly Dictionary<string, byte> _stringToKey = new Dictionary<string, byte>();

    static ItemData()
    {
        AddMapping(0x01, "Master Ball");
        AddMapping(0x02, "Ultra Ball");
        AddMapping(0x03, "Great Ball");
        AddMapping(0x04, "Poké Ball");
        AddMapping(0x05, "Town Map");
        AddMapping(0x06, "Bicycle");
        AddMapping(0x07, "?????");
        AddMapping(0x08, "Safari Ball");
        AddMapping(0x09, "Pokédex");
        AddMapping(0x0A, "Moon Stone");
        AddMapping(0x0B, "Antidote");
        AddMapping(0x0C, "Burn Heal");
        AddMapping(0x0D, "Ice Heal");
        AddMapping(0x0E, "Awakening");
        AddMapping(0x0F, "Parlyz Heal");

        AddMapping(0x10, "Full Restore");
        AddMapping(0x11, "Max Potion");
        AddMapping(0x12, "Hyper Potion");
        AddMapping(0x13, "Super Potion");
        AddMapping(0x14, "Potion");
        AddMapping(0x15, "BoulderBadge");
        AddMapping(0x16, "CascadeBadge");
        AddMapping(0x17, "ThunderBadge");
        AddMapping(0x18, "RainbowBadge");
        AddMapping(0x19, "SoulBadge");
        AddMapping(0x1A, "MarshBadge");
        AddMapping(0x1B, "VolcanoBadge");
        AddMapping(0x1C, "EarthBadge");
        AddMapping(0x1D, "Escape Rope");
        AddMapping(0x1E, "Repel");
        AddMapping(0x1F, "Old Amber");

        AddMapping(0x20, "Fire Stone");
        AddMapping(0x21, "Thunderstone");
        AddMapping(0x22, "Water Stone");
        AddMapping(0x23, "HP Up");
        AddMapping(0x24, "Protein");
        AddMapping(0x25, "Iron");
        AddMapping(0x26, "Carbos");
        AddMapping(0x27, "Calcium");
        AddMapping(0x28, "Rare Candy");
        AddMapping(0x29, "Dome Fossil");
        AddMapping(0x2A, "Helix Fossil");
        AddMapping(0x2B, "Secret Key");
        AddMapping(0x2C, "??????");
        AddMapping(0x2D, "Bike Voucher");
        AddMapping(0x2E, "X Accuracy");
        AddMapping(0x2F, "Leaf Stone");

        AddMapping(0x30, "Card Key");
        AddMapping(0x31, "Nugget");
        AddMapping(0x32, "PP Up*");
        AddMapping(0x33, "Poké Doll");
        AddMapping(0x34, "Full Heal");
        AddMapping(0x35, "Revive");
        AddMapping(0x36, "Max Revive");
        AddMapping(0x37, "Guard Spec.");
        AddMapping(0x38, "Super Repel");
        AddMapping(0x39, "Max Repel");
        AddMapping(0x3A, "Dire Hit");
        AddMapping(0x3B, "Coin");
        AddMapping(0x3C, "Fresh Water");
        AddMapping(0x3D, "Soda Pop");
        AddMapping(0x3E, "Lemonade");
        AddMapping(0x3F, "S.S. Ticket");
        
        AddMapping(0x40, "Gold Teeth");
        AddMapping(0x41, "X Attack");
        AddMapping(0x42, "X Defend");
        AddMapping(0x43, "X Speed");
        AddMapping(0x44, "X Special");
        AddMapping(0x45, "Coin Case");
        AddMapping(0x46, "Oak's Parcel");
        AddMapping(0x47, "Itemfinder");
        AddMapping(0x48, "Silph Scope");
        AddMapping(0x49, "Poké Flute");
        AddMapping(0x4A, "Lift Key");
        AddMapping(0x4B, "Exp. All");
        AddMapping(0x4C, "Old Rod");
        AddMapping(0x4D, "Good Rod");
        AddMapping(0x4E, "Super Rod");
        AddMapping(0x4F, "PP Up");

        AddMapping(0x50, "Ether");
        AddMapping(0x51, "Max Ether");
        AddMapping(0x52, "Elixer");
        AddMapping(0x53, "Max Elixer");
        
        AddMapping(0xC4, "HM01");
        AddMapping(0xC5, "HM02");
        AddMapping(0xC6, "HM03");
        AddMapping(0xC7, "HM04");
        AddMapping(0xC8, "HM05");
        AddMapping(0xC9, "TM01");
        AddMapping(0xCA, "TM02");
        AddMapping(0xCB, "TM03");
        AddMapping(0xCC, "TM04");
        AddMapping(0xCD, "TM05");
        AddMapping(0xCE, "TM06");
        AddMapping(0xCF, "TM07");

        AddMapping(0xD0, "TM08");
        AddMapping(0xD1, "TM09");
        AddMapping(0xD2, "TM10");
        AddMapping(0xD3, "TM11");
        AddMapping(0xD4, "TM12");
        AddMapping(0xD5, "TM13");
        AddMapping(0xD6, "TM14");
        AddMapping(0xD7, "TM15");
        AddMapping(0xD8, "TM16");
        AddMapping(0xD9, "TM17");
        AddMapping(0xDA, "TM18");
        AddMapping(0xDB, "TM19");
        AddMapping(0xDC, "TM20");
        AddMapping(0xDD, "TM21");
        AddMapping(0xDE, "TM22");
        AddMapping(0xDF, "TM23");
        
        AddMapping(0xE0, "TM24");
        AddMapping(0xE1, "TM25");
        AddMapping(0xE2, "TM26");
        AddMapping(0xE3, "TM27");
        AddMapping(0xE4, "TM28");
        AddMapping(0xE5, "TM29");
        AddMapping(0xE6, "TM30");
        AddMapping(0xE7, "TM31");
        AddMapping(0xE8, "TM32");
        AddMapping(0xE9, "TM33");
        AddMapping(0xEA, "TM34");
        AddMapping(0xEB, "TM35");
        AddMapping(0xEC, "TM36");
        AddMapping(0xED, "TM37");
        AddMapping(0xEE, "TM38");
        AddMapping(0xEF, "TM39");
        
        AddMapping(0xF0, "TM40");
        AddMapping(0xF1, "TM41");
        AddMapping(0xF2, "TM42");
        AddMapping(0xF3, "TM43");
        AddMapping(0xF4, "TM44");
        AddMapping(0xF5, "TM45");
        AddMapping(0xF6, "TM46");
        AddMapping(0xF7, "TM47");
        AddMapping(0xF8, "TM48");
        AddMapping(0xF9, "TM49");
        AddMapping(0xFA, "TM50");
        AddMapping(0xFB, "TM51");
        AddMapping(0xFC, "TM52");
        AddMapping(0xFD, "TM53");
        AddMapping(0xFE, "TM54");
        AddMapping(0xFF, "TM55");

    }

    private static void AddMapping(byte hexCode, string name)
    {
        _keyToString[hexCode] = name;
        _stringToKey[name] = hexCode;
    }

    public static byte GetHexCode(string name)
    {
        if (_stringToKey.TryGetValue(name, out byte hexCode))
        {
            return hexCode;
        }
        else
        {
            throw new ArgumentException($"Unable to locate item name: {name}.");
        }
    }

    public static string GetName(byte hexCode)
    {
        if (_keyToString.TryGetValue(hexCode, out string? name))
        {
            return name;
        }
        else
        {
            throw new ArgumentException($"Unable to locate item hex code: {hexCode}.");
        }
    }

}