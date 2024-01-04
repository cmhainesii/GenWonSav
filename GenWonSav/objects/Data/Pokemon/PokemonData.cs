using System.Diagnostics;

public static class PokemonData {
    private static readonly Dictionary<String, byte> _stringToHexMap = new Dictionary<String, byte>();
    private static readonly Dictionary<byte, String> _hexToStringMap = new Dictionary<byte, string>();

    static PokemonData() {
        AddMapping("Rhydon", 0x01);
        AddMapping("Kangaskhan", 0x02);
        AddMapping("Nidoran♂", 0x03);
        AddMapping("Clefairy", 0x04);
        AddMapping("Spearow", 0x05);
        AddMapping("Voltorb", 0x06);
        AddMapping("Nidoking", 0x07);
        AddMapping("Slowbro", 0x08);
        AddMapping("Ivysaur", 0x09);
        AddMapping("Exeggutor", 0x0A);
        AddMapping("Lickitung", 0x0B);
        AddMapping("Exeggcute", 0x0C);
        AddMapping("Grimer", 0x0D);
        AddMapping("Gengar", 0x0E);
        AddMapping("Nidoran♀", 0x0F);

        AddMapping("Nidoqueen", 0x10);
        AddMapping("Cubone", 0x11);
        AddMapping("Rhyhorn", 0x12);
        AddMapping("Lapras", 0x13);
        AddMapping("Arcanine", 0x14);
        AddMapping("Mew", 0x15);
        AddMapping("Gyarados", 0x16);
        AddMapping("Shellder", 0x17);
        AddMapping("Tentacool", 0x18);
        AddMapping("Gastly", 0x19);
        AddMapping("Scyther", 0x1A);
        AddMapping("Staryu", 0x1B);
        AddMapping("Blastoise", 0x1C);
        AddMapping("Pinsir", 0x1D);
        AddMapping("Tangela", 0x1E);
        AddMapping("MissingNo (Scizor)", 0x1F);

        AddMapping("MissingNo (Shuckle)", 0x20);
        AddMapping("Growlithe", 0x21);
        AddMapping("Onix", 0x22);
        AddMapping("Fearow", 0x23);
        AddMapping("Pidgey", 0x24);
        AddMapping("Slowpoke", 0x25);
        AddMapping("Kadabra", 0x26);
        AddMapping("Graveler", 0x27);
        AddMapping("Chansey", 0x28);
        AddMapping("Machoke", 0x29);
        AddMapping("Mr. Mime", 0x2A);
        AddMapping("Hitmonlee", 0x2B);
        AddMapping("Hitmonchan", 0x2C);
        AddMapping("Arbok", 0x2D);
        AddMapping("Parasect", 0x2E);
        AddMapping("Psyduck", 0x2F);

        AddMapping("Drowzee", 0x30);
        AddMapping("Golem", 0x31);
        AddMapping("MissingNo (Heracross)", 0x32);
        AddMapping("Magmar", 0x33);
        AddMapping("MissingNo (Ho-Oh)", 0x34);
        AddMapping("Electabuzz", 0x35);
        AddMapping("Magneton", 0x36);
        AddMapping("Koffing", 0x37);
        AddMapping("MissingNo (Sneasel)", 0x38);
        AddMapping("Mankey", 0x39);
        AddMapping("Seel", 0x3A);
        AddMapping("Diglett", 0x3B);
        AddMapping("Tauros", 0x3C);
        AddMapping("MissingNo (Teddiursa)", 0x3D);
        AddMapping("MissingNo (Ursaring)", 0x3E);
        AddMapping("MissingNo (Slugma)", 0x3F);

        AddMapping("Farfetch'd", 0x40);
        AddMapping("Venonat", 0x41);
        AddMapping("Dragonite", 0x42);
        AddMapping("MissingNo (Magcargo)", 0x43);
        AddMapping("MissingNo (Swinub)", 0x44);
        AddMapping("MissingNo (Piloswine)", 0x45);
        AddMapping("Doduo", 0x46);
        AddMapping("Poliwag", 0x47);
        AddMapping("Jynx", 0x48);
        AddMapping("Moltres", 0x49);
        AddMapping("Articuno", 0x4A);
        AddMapping("Zapdos", 0x4B);
        AddMapping("Ditto", 0x4C);
        AddMapping("Meowth", 0x4D);
        AddMapping("Krabby", 0x4E);
        AddMapping("MissingNo (Corsola)", 0x4F);

        AddMapping("MissingNo (Remoraid)", 0x50);
        AddMapping("MissingNo (Octillery)", 0x51);
        AddMapping("Vulpix", 0x52);
        AddMapping("Ninetales", 0x53);
        AddMapping("Pikachu", 0x54);
        AddMapping("Raichu", 0x55);
        AddMapping("MissingNo (Delibird)", 0x56);
        AddMapping("MissingNo (Mantine)", 0x57);
        AddMapping("Dratini", 0x58);
        AddMapping("Dragonair", 0x59);
        AddMapping("Kabuto", 0x5A);
        AddMapping("Kabutops", 0x5B);
        AddMapping("Horsea", 0x5C);
        AddMapping("Seadra", 0x5D);
        AddMapping("MissingNo (Skarmory)", 0x5E);
        AddMapping("MissingNo (Houndour)", 0x5F);

        AddMapping("Sandshrew", 0x60);
        AddMapping("Sandslash", 0x61);
        AddMapping("Omanyte", 0x62);
        AddMapping("Omastar", 0x63);
        AddMapping("Jigglypuff", 0x64);
        AddMapping("Wigglytuff", 0x65);
        AddMapping("Eevee", 0x66);
        AddMapping("Flareon", 0x67);
        AddMapping("Jolteon", 0x68);
        AddMapping("Vaporeon", 0x69);
        AddMapping("Machop", 0x6A);
        AddMapping("Zubat", 0x6B);
        AddMapping("Ekans", 0x6C);
        AddMapping("Paras", 0x6D);
        AddMapping("Poliwhirl", 0x6E);
        AddMapping("Poliwrath", 0x6F);

        AddMapping("Weedle", 0x70);
        AddMapping("Kakuna", 0x71);
        AddMapping("Beedrill", 0x72);
        AddMapping("MissingNo (Houndoom)", 0x73);
        AddMapping("Dodrio", 0x74);
        AddMapping("Primape", 0x75);
        AddMapping("Dugtrio", 0x76);
        AddMapping("Venomoth", 0x77);
        AddMapping("Dewgong", 0x78);
        AddMapping("MissingNo (Kingdra)", 0x79);
        AddMapping("MissingNo (Phanpy)", 0x7A);
        AddMapping("Caterpie", 0x7B);
        AddMapping("Metapod", 0x7C);
        AddMapping("Butterfree", 0x7D);
        AddMapping("Machamp", 0x7E);
        AddMapping("MissingNo (Donphan)", 0x7F);

        AddMapping("Golduck", 0x80);
        AddMapping("Hypno", 0x81);
        AddMapping("Golbat", 0x82);
        AddMapping("Mewtwo", 0x83);
        AddMapping("Snorlax", 0x84);
        AddMapping("Marikarp", 0x85);
        AddMapping("MissingNo (Porygon2)", 0x86);
        AddMapping("MissingNo (Stantler)", 0x87);
        AddMapping("Muk", 0x88);
        AddMapping("MissingNo (Smeargle)", 0x89);
        AddMapping("Kingler", 0x8A);
        AddMapping("Cloyster", 0x8B);
        AddMapping("MissingNo (Tyrogue)", 0x8C);
        AddMapping("Electrode", 0x8D);
        AddMapping("Clefable", 0x8E);
        AddMapping("Weezing", 0x8F);

        AddMapping("Persian", 0x90);
        AddMapping("Marowak", 0x91);
        AddMapping("MissingNo (Hitmontop)", 0x92);
        AddMapping("Haunter", 0x93);
        AddMapping("Abra", 0x94);
        AddMapping("Alakazam", 0x95);
        AddMapping("Pidgeotto", 0x96);
        AddMapping("Pidgeot", 0x97);
        AddMapping("Starmie", 0x98);
        AddMapping("Bulbasaur", 0x99);
        AddMapping("Venusaur", 0x9A);
        AddMapping("Tentacruel", 0x9B);
        AddMapping("MissingNo (Smoochum)", 0x9C);
        AddMapping("Goldeen", 0x9D);
        AddMapping("Seaking", 0x9E);
        AddMapping("MissingNo (Elekid)", 0x9F);

        AddMapping("MissingNo (Magby)", 0xA0);
        AddMapping("MissingNo (Miltank)", 0xA1);
        AddMapping("MissingNo (Blissey)", 0xA2);
        AddMapping("Ponyta", 0xA3);
        AddMapping("Rapidash", 0xA4);
        AddMapping("Rattata", 0xA5);
        AddMapping("Raticate", 0xA6);
        AddMapping("Nidorino", 0xA7);
        AddMapping("Nidorina", 0xA8);
        AddMapping("Geodude", 0xA9);
        AddMapping("Porygon", 0xAA);
        AddMapping("Aerodactyl", 0xAB);
        AddMapping("MissingNo (Raikou)", 0xAC);
        AddMapping("Magnemite", 0xAD);
        AddMapping("MissingNo (Entei)", 0xAE);
        AddMapping("MissingNo (Suicune)", 0xAF);

        AddMapping("Charmander", 0xB0);
        AddMapping("Squirtle", 0xB1);
        AddMapping("Charmeleon", 0xB2);
        AddMapping("Wartortle", 0xB3);
        AddMapping("Charizard", 0xB4);
        AddMapping("MissingNo (Larvitar)", 0xB5);
        AddMapping("MissingNo (Pupitar)", 0xB6);
        AddMapping("MissingNo (Tyranitar)", 0xB7);
        AddMapping("MissingNo (Lugia)", 0xB8);
        AddMapping("Oddish", 0xB9);
        AddMapping("Gloom", 0xBA);
        AddMapping("Vileplume", 0xBB);
        AddMapping("Bellsprout", 0xBC);
        AddMapping("Weepinbell", 0xBD);
        AddMapping("Victreebel", 0xBE);
    }

    private static void AddMapping(string name, byte hexCode) {
        _stringToHexMap[name] = hexCode;
        _hexToStringMap[hexCode] = name;
    }


    public static string GetPokemonName(byte hexCode) {
        if (_hexToStringMap.TryGetValue(hexCode, out string? name))
        {
            return name;
        }
        else {
            throw new KeyNotFoundException($"Hex value '{hexCode}' not found.");
        }
    }

    public static byte GetHexCode(string name) 
    {
        if (_stringToHexMap.TryGetValue(name, out byte hexValue))
        {
            return hexValue;
        }
        else {
            throw new KeyNotFoundException($"Pokemon '{name}' not found.");
        }
    }
}