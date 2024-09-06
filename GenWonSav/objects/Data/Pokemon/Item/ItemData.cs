internal class ItemData
{
    private readonly Dictionary<byte, string> _keyToString = new Dictionary<byte, string>();
    private readonly Dictionary<string, byte> _stringToKey = new Dictionary<string, byte>();
    internal readonly Dictionary<string, string> genTwoTMNames = new Dictionary<string, string>();

    internal ItemData(int generation)
    {
        if(generation == 1) 
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

        else
        {
            AddMapping(0x00, "Unknown Item");
            AddMapping(0x01, "Master Ball");
            AddMapping(0x02, "Ultra Ball");
            AddMapping(0x03, "Bright Powder");
            AddMapping(0x04, "Great Ball");
            AddMapping(0x05, "Pokè Ball");
            AddMapping(0x06, "Teru-sama");
            AddMapping(0x07, "Bicycle");
            AddMapping(0X08, "Moon Stone");
            AddMapping(0x09, "Antidote");
            AddMapping(0x0A, "Burn Heal");
            AddMapping(0x0B, "Ice Heal");
            AddMapping(0x0C, "Awakening");
            AddMapping(0x0D, "Parlyz Heal");
            AddMapping(0x0E, "Full Restore");
            AddMapping(0x0F, "Max Potion");
            
            AddMapping(0x10, "Hyper Potion");
            AddMapping(0x11, "Super Potion");
            AddMapping(0x12, "Potion");
            AddMapping(0x13, "Escape Rope");
            AddMapping(0x14, "Repel");
            AddMapping(0x15, "Max Elixer");
            AddMapping(0x16, "Fire Stone");
            AddMapping(0x17, "ThunderStone");
            AddMapping(0x18, "Water Stone");
            AddMapping(0x19, "Teru-sama");
            AddMapping(0x1A, "HP Up");
            AddMapping(0x1B, "Protein");
            AddMapping(0x1C, "Iron");
            AddMapping(0x1D, "Carbos");
            AddMapping(0x1E, "Lucky Punch");
            AddMapping(0x1F, "Calcium");

            AddMapping(0x20, "Rare Candy");
            AddMapping(0x21, "X Accuracy");
            AddMapping(0x22, "Leaf Stone");
            AddMapping(0x23, "Metal Powder");
            AddMapping(0x24, "Nugget");
            AddMapping(0x25, "Pokè Doll");
            AddMapping(0x26, "Full Heal");
            AddMapping(0x27, "Revive");
            AddMapping(0x28, "Max Revive");
            AddMapping(0x29, "Guard Spec.");
            AddMapping(0x2A, "Super Repel");
            AddMapping(0x2B, "Max Repel");
            AddMapping(0x2C, "Dire Hit");
            AddMapping(0x2D, "Teru-sama");
            AddMapping(0x2E, "Fresh Water");
            AddMapping(0x2F, "Soda Pop");

            AddMapping(0x30, "Lemonade");
            AddMapping(0x31, "X Attack");
            AddMapping(0x32, "Teru-sama");
            AddMapping(0x33, "X Defend");
            AddMapping(0x34, "X Speed");
            AddMapping(0x35, "X Special");
            AddMapping(0x36, "Coin Case");
            AddMapping(0x37, "Itemfinder");
            AddMapping(0x38, "Teru-sama");
            AddMapping(0x39, "Exp. Share");
            AddMapping(0x3A, "Old Rod");
            AddMapping(0x3B, "Good Rod");
            AddMapping(0x3C, "Silver Leaf");
            AddMapping(0x3D, "Super Rod");
            AddMapping(0x3E, "PP Up");
            AddMapping(0x3F, "Ether");

            AddMapping(0x40, "Max Ether");
            AddMapping(0x41, "Elixer");
            AddMapping(0x42, "Red Scale");
            AddMapping(0x43, "SecretPotion");
            AddMapping(0x44, "S.S. Ticket");
            AddMapping(0x45, "Mystery Egg");
            AddMapping(0x46, "Clear Bell");
            AddMapping(0x47, "Silver Wing");
            AddMapping(0x48, "Moomoo Milk");
            AddMapping(0x49, "Quick Claw");
            AddMapping(0x4A, "PSNCureBerry");
            AddMapping(0x4B, "Gold Leaf");
            AddMapping(0x4C, "Soft Sand");
            AddMapping(0x4D, "Sharp Beak");
            AddMapping(0x4E, "PRZCureBerry");
            AddMapping(0x4F, "Burnt Berry");
            
            AddMapping(0x50, "Ice Berry");
            AddMapping(0x51, "Poison Barb");
            AddMapping(0x52, "King's Rock");
            AddMapping(0x53, "Bitter Berry");
            AddMapping(0x54, "Mint Berry");
            AddMapping(0x55, "Red Apricorn");
            AddMapping(0x56, "TinyMushroom");
            AddMapping(0x57, "BigMushroom");
            AddMapping(0x58, "SilverPowder");
            AddMapping(0x59, "Blu Apricorn");
            AddMapping(0x5A, "Teru-sama");
            AddMapping(0x5B, "Amulet Coin");
            AddMapping(0x5C, "Ylw Apricorn");
            AddMapping(0x5D, "Grn Apricorn");
            AddMapping(0x5E, "Cleanse Tag");
            AddMapping(0x5F, "Mystic Water");

            AddMapping(0x60, "TwistedSpoon");
            AddMapping(0x61, "Wht Apricorn");
            AddMapping(0x62, "Blackbelt");
            AddMapping(0x63, "Blk Apricorn");
            AddMapping(0x64, "Teru-sama");
            AddMapping(0x65, "Pnk Apricorn");
            AddMapping(0x66, "BlackGlasses");
            AddMapping(0x67, "SlowpokeTail");
            AddMapping(0x68, "Pink Bow");
            AddMapping(0x69, "Stick");
            AddMapping(0x6A, "Smoke Ball");
            AddMapping(0x6B, "NeverMeltIce");
            AddMapping(0x6C, "Magnet");
            AddMapping(0x6D, "MiracleBerry");
            AddMapping(0x6E, "Pearl");
            AddMapping(0x6F, "Big Pearl");

            AddMapping(0x70, "Everstone");
            AddMapping(0x71, "Spell Tag");
            AddMapping(0x72, "RageCandyBar");
            AddMapping(0x73, "GS Ball");
            AddMapping(0x74, "Blue Card");
            AddMapping(0x75, "Miracle Seed");
            AddMapping(0x76, "Thick Club");
            AddMapping(0x77, "Focus Band");
            AddMapping(0x78, "Teru-sama");
            AddMapping(0x79, "EnergyPowder");
            AddMapping(0x7A, "Energy Root");
            AddMapping(0x7B, "Heal Powder");
            AddMapping(0x7C, "Revival Herb");
            AddMapping(0x7D, "Hard Stone");
            AddMapping(0x7E, "Lucky Egg");
            
            AddMapping(0x80, "Machine Part");
            AddMapping(0x81, "Egg Ticket");
            AddMapping(0x82, "Lost Item");
            AddMapping(0x83, "Stardust");
            AddMapping(0x84, "Star Piece");
            AddMapping(0x85, "Basement Key");
            AddMapping(0x86, "Pass");
            AddMapping(0x87, "Teru-sama");
            AddMapping(0x88, "Teru-sama");
            AddMapping(0x89, "Teru-sama");
            AddMapping(0x8A, "Charcoal");
            AddMapping(0x8B, "Berry Juice");
            AddMapping(0x8C, "Scope Lens");
            AddMapping(0x8D, "Teru-sama");
            AddMapping(0x8E, "Teru-sama");
            AddMapping(0x8F, "Metal Coat");

            AddMapping(0x90, "Dragon Fang");
            AddMapping(0x91, "Teru-sama");
            AddMapping(0x92, "Leftovers");
            AddMapping(0x93, "Teru-sama");
            AddMapping(0x94, "Teru-sama");
            AddMapping(0x95, "Teru-sama");
            AddMapping(0x96, "MysteryBerry");
            AddMapping(0x97, "Dragon Scale");
            AddMapping(0x98, "Berserk Gene");
            AddMapping(0x99, "Teru-sama");
            AddMapping(0x9A, "Teru-sama");
            AddMapping(0x9B, "Teru-sama");
            AddMapping(0x9C, "Sacred Ash");
            AddMapping(0x9D, "Heavy Ball");
            AddMapping(0x9E, "Flower Mail");
            AddMapping(0x9F, "Level Ball");
            
            AddMapping(0xA0, "Lure Ball");
            AddMapping(0xA1, "Fast Ball");
            AddMapping(0xA2, "Teru-sama");
            AddMapping(0xA3, "Light Ball");
            AddMapping(0xA4, "Friend Ball");
            AddMapping(0xA5, "Moon Ball");
            AddMapping(0xA6, "Love Ball");
            AddMapping(0xA7, "Normal Box");
            AddMapping(0xA8, "Gorgeous Box");
            AddMapping(0xA9, "Sun Stone");
            AddMapping(0xAA, "Polkadot Brow");
            AddMapping(0xAB, "Teru-sama");
            AddMapping(0xAC, "Up-Grade");
            AddMapping(0xAD, "Berry");
            AddMapping(0xAE, "Gold Berry");
            AddMapping(0xAF, "SquirtBottle");
            
            AddMapping(0xB0, "Teru-sama");
            AddMapping(0xB1, "Park Ball");
            AddMapping(0xB2, "Rainbow Wing");
            AddMapping(0xB3, "Teru-sama");
            AddMapping(0xB4, "Brick Piece");
            AddMapping(0xB5, "Surf Mail");
            AddMapping(0xB6, "Litebluemail");
            AddMapping(0xB7, "Portraitmail");
            AddMapping(0xB8, "Lovely Mail");
            AddMapping(0xB9, "Eon Mail");
            AddMapping(0xBA, "Morph Mail");
            AddMapping(0xBB, "Bluesky Mail");
            AddMapping(0xBC, "Music Mail");
            AddMapping(0xBD, "Mirage Mail");
            AddMapping(0xBE, "Teru-sama");
            AddMapping(0xBF, "TM01");

            AddMapping(0xC0, "TM02");
            AddMapping(0xC1, "TM03");
            AddMapping(0xC2, "TM04");
            AddMapping(0xC3, "TM04");
            AddMapping(0xC4, "TM05");
            AddMapping(0xC5, "TM06");
            AddMapping(0xC6, "TM07");
            AddMapping(0xC7, "TM08");
            AddMapping(0xC8, "TM09");
            AddMapping(0xC9, "TM10");
            AddMapping(0xCA, "TM11");
            AddMapping(0xCB, "TM12");
            AddMapping(0xCC, "TM13");
            AddMapping(0xCD, "TM14");
            AddMapping(0xCE, "TM15");
            AddMapping(0xCF, "TM16");
            
            AddMapping(0xD0, "TM17");
            AddMapping(0xD1, "TM18");
            AddMapping(0xD2, "TM19");
            AddMapping(0xD3, "TM20");
            AddMapping(0xD4, "TM21");
            AddMapping(0xD5, "TM22");
            AddMapping(0xD6, "TM23");
            AddMapping(0xD7, "TM24");
            AddMapping(0xD8, "TM25");
            AddMapping(0xD9, "TM26");
            AddMapping(0xDA, "TM27");
            AddMapping(0xDB, "TM28");
            AddMapping(0xDC, "TM28");
            AddMapping(0xDD, "TM29");
            AddMapping(0xDE, "TM30");
            AddMapping(0xDF, "TM31");
            
            AddMapping(0xE0, "TM32");
            AddMapping(0xE1, "TM33");
            AddMapping(0xE2, "TM34");
            AddMapping(0xE3, "TM35");
            AddMapping(0xE4, "TM36");
            AddMapping(0xE5, "TM37");
            AddMapping(0xE6, "TM38");
            AddMapping(0xE7, "TM39");
            AddMapping(0xE8, "TM40");
            AddMapping(0xE9, "TM41");
            AddMapping(0xEA, "TM42");
            AddMapping(0xEB, "TM43");
            AddMapping(0xEC, "TM44");
            AddMapping(0xED, "TM45");
            AddMapping(0xEE, "TM46");
            AddMapping(0xEF, "TM47");

            AddMapping(0xF0, "TM48");
            AddMapping(0xF1, "TM49");
            AddMapping(0xF2, "TM50");
            AddMapping(0xF3, "HM01");
            AddMapping(0xF4, "HM02");
            AddMapping(0xF5, "HM03");
            AddMapping(0xF6, "HM04");
            AddMapping(0xF7, "HM05");
            AddMapping(0xF8, "HM06");
            AddMapping(0xF9, "HM07");
            AddMapping(0xFA, "HM08");
            AddMapping(0xFB, "HM09");
            AddMapping(0xFC, "HM10");
            AddMapping(0xFD, "HM11");
            AddMapping(0xFE, "HM12");
            AddMapping(0xFF, "Cancel");

            // Map Gen 2 TM Names to their string identifiers
            genTwoTMNames["TM01"] = "DynamicPunch";
            genTwoTMNames["TM02"] = "Headbutt";
            genTwoTMNames["TM03"] = "Curse";
            genTwoTMNames["TM04"] = "Rollout";
            genTwoTMNames["TM05"] = "Roar";
            genTwoTMNames["TM06"] = "Toxic";
            genTwoTMNames["TM07"] = "Zap Cannon";
            genTwoTMNames["TM08"] = "Rock Smash";
            genTwoTMNames["TM09"] = "Psych Up";
            genTwoTMNames["TM10"] = "Hidden Power";
            genTwoTMNames["TM11"] = "Sunny Day";
            genTwoTMNames["TM12"] = "Sweet Scent";
            genTwoTMNames["TM13"] = "Snore";
            genTwoTMNames["TM14"] = "Blizzard";
            genTwoTMNames["TM15"] = "Hyper Beam";
            genTwoTMNames["TM16"] = "Icy Wind";
            genTwoTMNames["TM17"] = "Protect";
            genTwoTMNames["TM18"] = "Rain Dance";
            genTwoTMNames["TM19"] = "Giga Drain";
            genTwoTMNames["TM20"] = "Endure";
            genTwoTMNames["TM21"] = "Frustration";
            genTwoTMNames["TM22"] = "SolarBeam";
            genTwoTMNames["TM23"] = "Tron Tail";
            genTwoTMNames["TM24"] = "DragonBreath";
            genTwoTMNames["TM25"] = "Thunder";
            genTwoTMNames["TM26"] = "Earthquake";
            genTwoTMNames["TM27"] = "Return";
            genTwoTMNames["TM28"] = "Dig";
            genTwoTMNames["TM29"] = "Psychic";
            genTwoTMNames["TM30"] = "Shadow Ball";
            genTwoTMNames["TM31"] = "Mud-Slap";
            genTwoTMNames["TM32"] = "Double Team";
            genTwoTMNames["TM33"] = "Ice Punch";
            genTwoTMNames["TM34"] = "Swagger";
            genTwoTMNames["TM35"] = "Sleep Talk";
            genTwoTMNames["TM36"] = "Sludge Bomb";
            genTwoTMNames["TM37"] = "Sandstorm";
            genTwoTMNames["TM38"] = "Fire Blast";
            genTwoTMNames["TM39"] = "Swift";
            genTwoTMNames["TM40"] = "Defense Curl";
            genTwoTMNames["TM41"] = "ThunderPunch";
            genTwoTMNames["TM42"] = "Dream Eater";
            genTwoTMNames["TM43"] = "Detect";
            genTwoTMNames["TM44"] = "Rest";
            genTwoTMNames["TM45"] = "Attract";
            genTwoTMNames["TM46"] = "Thief";
            genTwoTMNames["TM47"] = "Steel Wing";
            genTwoTMNames["TM48"] = "Fire Punch";
            genTwoTMNames["TM49"] = "Fury Cutter";
            genTwoTMNames["TM50"] = "Nightmare";
            
            genTwoTMNames["HM01"] = "Cut";
            genTwoTMNames["HM02"] = "Fly";
            genTwoTMNames["HM03"] = "Surf";
            genTwoTMNames["HM04"] = "Strength";
            genTwoTMNames["HM05"] = "Flash";
            genTwoTMNames["HM06"] = "Whirlpool";
            genTwoTMNames["HM07"] = "Waterfall";
        }


    }

    private void AddMapping(byte hexCode, string name)
    {
        _keyToString[hexCode] = name;
        _stringToKey[name] = hexCode;
    }

    internal byte GetHexCode(string name)
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

    internal string GetName(byte hexCode)
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