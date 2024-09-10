using System.Diagnostics;

internal class PokemonData {
    private  readonly Dictionary<String, byte> _stringToHexMap = new Dictionary<String, byte>();
    private  readonly Dictionary<byte, String> _hexToStringMap = new Dictionary<byte, string>();
    private readonly Dictionary<byte, PokemonType> pokemonTypeData = new Dictionary<byte, PokemonType>();

    [Flags]
    internal enum PokemonType : uint
    {
        None = 0,
        Normal = 1 << 0,
        Fire = 1 << 1,
        Water = 1 << 2,
        Grass = 1 << 3,
        Electric = 1 << 4,
        Ice = 1 << 5,
        Fighting = 1 << 6,
        Poison = 1 << 7,
        Ground = 1 << 8,
        Flying = 1 << 9,
        Psychic = 1 << 10,
        Bug = 1 << 11,
        Rock = 1 << 12,
        Ghost = 1 << 13,
        Dragon = 1 << 14,
        Dark = 1 << 15,
        Steel = 1 << 16
    }

    internal PokemonData(int generation) {

        // generation 1 dex
        if(generation == 1) {
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
        else // generation 2 dex
        {
            AddMapping("Blubasaur", 0x01);
            AddMapping("Ivysaur", 0x02);
            AddMapping("Venusaur", 0x03);
            AddMapping("Charmander", 4);
            AddMapping("Charmeleon", 5);
            AddMapping("Charizard", 6);
            AddMapping("Squirtle", 7);
            AddMapping("Wartortle", 8);
            AddMapping("Blastoise", 9);
            AddMapping("Caterpie", 10);

            pokemonTypeData.Add(1, PokemonType.Grass | PokemonType.Poison);
            pokemonTypeData.Add(2, PokemonType.Grass | PokemonType.Poison);
            pokemonTypeData.Add(3, PokemonType.Grass | PokemonType.Poison);
            pokemonTypeData.Add(4, PokemonType.Fire);
            pokemonTypeData.Add(5, PokemonType.Fire);
            pokemonTypeData.Add(6, PokemonType.Fire | PokemonType.Flying);
            pokemonTypeData.Add(7, PokemonType.Water);
            pokemonTypeData.Add(8, PokemonType.Water);
            pokemonTypeData.Add(9, PokemonType.Water);
            pokemonTypeData.Add(10, PokemonType.Bug);            

            AddMapping("Metapod", 11);
            AddMapping("Buterfree", 12);
            AddMapping("Weedle", 13);
            AddMapping("Kakuna", 14);
            AddMapping("Beedrill", 15);
            AddMapping("Pidgey", 16);
            AddMapping("Pidgeotto", 17);
            AddMapping("Pidgeot", 18);
            AddMapping("Rattata", 19);
            AddMapping("Raticate", 20);

            pokemonTypeData.Add(11, PokemonType.Bug);
            pokemonTypeData.Add(12, PokemonType.Bug | PokemonType.Flying);
            pokemonTypeData.Add(13, PokemonType.Bug | PokemonType.Poison);
            pokemonTypeData.Add(14, PokemonType.Bug | PokemonType.Poison);
            pokemonTypeData.Add(15, PokemonType.Bug | PokemonType.Poison);
            pokemonTypeData.Add(16, PokemonType.Normal | PokemonType.Flying);
            pokemonTypeData.Add(17, PokemonType.Normal | PokemonType.Flying);
            pokemonTypeData.Add(18, PokemonType.Normal | PokemonType.Flying);
            pokemonTypeData.Add(19, PokemonType.Normal);
            pokemonTypeData.Add(20, PokemonType.Normal);
            
            AddMapping("Spearow",21);
            AddMapping("Fearow", 22);
            AddMapping("Ekans", 23);
            AddMapping("Arbok", 24);
            AddMapping("Pikachu", 25);
            AddMapping("Raichu", 26);
            AddMapping("Sandshrew", 27);
            AddMapping("Sandslash", 28);
            AddMapping("Nidoran♀", 29);
            AddMapping("Nidorina", 30);

            pokemonTypeData.Add(21, PokemonType.Normal | PokemonType.Flying);
            pokemonTypeData.Add(22, PokemonType.Normal | PokemonType.Flying);
            pokemonTypeData.Add(23, PokemonType.Poison);
            pokemonTypeData.Add(24, PokemonType.Poison);
            pokemonTypeData.Add(25, PokemonType.Electric);
            pokemonTypeData.Add(26, PokemonType.Electric);
            pokemonTypeData.Add(27, PokemonType.Ground);
            pokemonTypeData.Add(28, PokemonType.Ground);
            pokemonTypeData.Add(29, PokemonType.Poison);
            pokemonTypeData.Add(30, PokemonType.Poison);
            
            AddMapping("Nidoqueen", 31);
            AddMapping("Nidoran♂", 32);
            AddMapping("Nidorino", 33);
            AddMapping("Nidoking", 34);
            AddMapping("Clefairy", 35);
            AddMapping("Clefable", 36);
            AddMapping("Vulpix", 37);
            AddMapping("Ninetails", 38);
            AddMapping("Jigglypuff", 39);
            AddMapping("Wigglytuff", 40);

            pokemonTypeData.Add(31, PokemonType.Poison | PokemonType.Ground);
            pokemonTypeData.Add(32, PokemonType.Poison);
            pokemonTypeData.Add(33, PokemonType.Poison);
            pokemonTypeData.Add(34, PokemonType.Poison | PokemonType.Ground);
            pokemonTypeData.Add(35, PokemonType.Normal);
            pokemonTypeData.Add(36, PokemonType.Normal);
            pokemonTypeData.Add(37, PokemonType.Fire);
            pokemonTypeData.Add(38, PokemonType.Fire);
            pokemonTypeData.Add(39, PokemonType.Normal);
            pokemonTypeData.Add(40, PokemonType.Normal);

            AddMapping("Zubat", 41);
            AddMapping("Golbat", 42);
            AddMapping("Oddish", 43);
            AddMapping("Gloom", 44);
            AddMapping("Vileplume", 45);
            AddMapping("Paras", 46);
            AddMapping("Parasect", 47);
            AddMapping("Venonat", 48);
            AddMapping("Venomoth", 49);
            AddMapping("Diglett", 50);

            pokemonTypeData.Add(41, PokemonType.Poison | PokemonType.Flying);
            pokemonTypeData.Add(42, PokemonType.Poison | PokemonType.Flying);
            pokemonTypeData.Add(43, PokemonType.Grass | PokemonType.Poison);
            pokemonTypeData.Add(44, PokemonType.Grass | PokemonType.Poison);
            pokemonTypeData.Add(45, PokemonType.Grass | PokemonType.Poison);
            pokemonTypeData.Add(46, PokemonType.Bug | PokemonType.Grass);
            pokemonTypeData.Add(47, PokemonType.Bug | PokemonType.Grass);
            pokemonTypeData.Add(48, PokemonType.Bug | PokemonType.Poison);
            pokemonTypeData.Add(49, PokemonType.Bug | PokemonType.Poison);
            pokemonTypeData.Add(50, PokemonType.Ground);

            AddMapping("Dugtrio", 51);
            AddMapping("Meowth", 52);
            AddMapping("Persian", 53);
            AddMapping("Psyduck", 54);
            AddMapping("Golduck", 55);
            AddMapping("Mankey", 56);
            AddMapping("Primeape", 57);
            AddMapping("Growlithe", 58);
            AddMapping("Arcanine", 59);
            AddMapping("Poliwag", 60);

            pokemonTypeData.Add(51, PokemonType.Ground);
            pokemonTypeData.Add(52, PokemonType.Normal);
            pokemonTypeData.Add(53, PokemonType.Normal);
            pokemonTypeData.Add(54, PokemonType.Water);
            pokemonTypeData.Add(55, PokemonType.Water);
            pokemonTypeData.Add(56, PokemonType.Fighting);
            pokemonTypeData.Add(57, PokemonType.Fighting);
            pokemonTypeData.Add(58, PokemonType.Fire);
            pokemonTypeData.Add(59, PokemonType.Fire);
            pokemonTypeData.Add(60, PokemonType.Water);

            AddMapping("Poliwhirl", 61);
            AddMapping("Poliwrath", 62);
            AddMapping("Abra", 63);
            AddMapping("Kadabra", 64);
            AddMapping("Alakazam", 65);
            AddMapping("Machop", 66);
            AddMapping("Machoke", 67);
            AddMapping("Machamp", 68);
            AddMapping("Bellsprout", 69);
            AddMapping("Weepinbell", 70);

            pokemonTypeData.Add(61, PokemonType.Water);
            pokemonTypeData.Add(62, PokemonType.Water | PokemonType.Fighting);
            pokemonTypeData.Add(63, PokemonType.Psychic);
            pokemonTypeData.Add(64, PokemonType.Psychic);
            pokemonTypeData.Add(65, PokemonType.Psychic);
            pokemonTypeData.Add(66, PokemonType.Fighting);
            pokemonTypeData.Add(67, PokemonType.Fighting);
            pokemonTypeData.Add(68, PokemonType.Fighting);
            pokemonTypeData.Add(69, PokemonType.Grass | PokemonType.Poison);
            pokemonTypeData.Add(70, PokemonType.Grass | PokemonType.Poison);

            AddMapping("Victreebel", 71);
            AddMapping("Tentacool", 72);
            AddMapping("Tentacruel", 73);
            AddMapping("Geodude", 74);
            AddMapping("Graveler", 75);
            AddMapping("Golem", 76);
            AddMapping("Ponyta", 77);
            AddMapping("Rapidash", 78);
            AddMapping("Slowpoke", 79);
            AddMapping("Slowbro", 80);

            pokemonTypeData.Add(71, PokemonType.Grass | PokemonType.Poison);
            pokemonTypeData.Add(72, PokemonType.Water | PokemonType.Poison);
            pokemonTypeData.Add(73, PokemonType.Water | PokemonType.Poison);
            pokemonTypeData.Add(74, PokemonType.Rock | PokemonType.Ground);
            pokemonTypeData.Add(75, PokemonType.Rock | PokemonType.Ground);
            pokemonTypeData.Add(76, PokemonType.Rock | PokemonType.Ground);
            pokemonTypeData.Add(77, PokemonType.Fire);
            pokemonTypeData.Add(78, PokemonType.Fire);
            pokemonTypeData.Add(79, PokemonType.Water | PokemonType.Psychic);
            pokemonTypeData.Add(80, PokemonType.Water | PokemonType.Psychic);          
            
            AddMapping("Magnemite", 81);
            AddMapping("Magneton", 82);
            AddMapping("Farfetch'd", 83);
            AddMapping("Doduo", 84);
            AddMapping("Dodrio", 85);
            AddMapping("Seel", 86);
            AddMapping("Dewgong", 87);
            AddMapping("Grimer", 88);
            AddMapping("Muk", 89);
            AddMapping("Shelder", 90);

            pokemonTypeData.Add(81, PokemonType.Electric | PokemonType.Steel);
            pokemonTypeData.Add(82, PokemonType.Electric | PokemonType.Steel);
            pokemonTypeData.Add(83, PokemonType.Normal | PokemonType.Flying);
            pokemonTypeData.Add(84, PokemonType.Normal | PokemonType.Flying);
            pokemonTypeData.Add(85, PokemonType.Normal | PokemonType.Flying);
            pokemonTypeData.Add(86, PokemonType.Water);
            pokemonTypeData.Add(87, PokemonType.Water | PokemonType.Ice);
            pokemonTypeData.Add(88, PokemonType.Poison);
            pokemonTypeData.Add(89, PokemonType.Poison);
            pokemonTypeData.Add(90, PokemonType.Water);

            AddMapping("Cloyster", 91);
            AddMapping("Gastly", 92);
            AddMapping("Haunter", 93);
            AddMapping("Gengar", 94);
            AddMapping("Onix", 95);
            AddMapping("Drowzee", 96);
            AddMapping("Hypno", 97);
            AddMapping("Krabby", 98);
            AddMapping("Kingler", 99);
            AddMapping("Voltorb", 100);

            pokemonTypeData.Add(91, PokemonType.Water | PokemonType.Ice);
            pokemonTypeData.Add(92, PokemonType.Ghost | PokemonType.Poison);
            pokemonTypeData.Add(93, PokemonType.Ghost | PokemonType.Poison);
            pokemonTypeData.Add(94, PokemonType.Ghost | PokemonType.Poison);
            pokemonTypeData.Add(95, PokemonType.Rock | PokemonType.Ground);
            pokemonTypeData.Add(96, PokemonType.Psychic);
            pokemonTypeData.Add(97, PokemonType.Psychic);
            pokemonTypeData.Add(98, PokemonType.Water);
            pokemonTypeData.Add(99, PokemonType.Water);
            pokemonTypeData.Add(100, PokemonType.Electric);

            AddMapping("Electrode", 101);
            AddMapping("Exeggcute", 102);
            AddMapping("Exeggutor", 103);
            AddMapping("Cubone", 104);
            AddMapping("Marowak", 105);
            AddMapping("Hitmonlee", 106);
            AddMapping("Hitmonchan", 107);
            AddMapping("Lickitung", 108);
            AddMapping("Koffing", 109);
            AddMapping("Weezing", 110);

            pokemonTypeData.Add(101, PokemonType.Electric);
            pokemonTypeData.Add(102, PokemonType.Grass | PokemonType.Psychic);
            pokemonTypeData.Add(103, PokemonType.Grass | PokemonType.Psychic);
            pokemonTypeData.Add(104, PokemonType.Ground);
            pokemonTypeData.Add(105, PokemonType.Ground);
            pokemonTypeData.Add(106, PokemonType.Fighting);
            pokemonTypeData.Add(107, PokemonType.Fighting);
            pokemonTypeData.Add(108, PokemonType.Normal);
            pokemonTypeData.Add(109, PokemonType.Poison);
            pokemonTypeData.Add(110, PokemonType.Poison);

            AddMapping("Rhyhorn", 111);
            AddMapping("Rhydon", 112);
            AddMapping("Chansey", 113);
            AddMapping("Tangela", 114);
            AddMapping("Kangaskhan", 115);
            AddMapping("Horsea", 116);
            AddMapping("Seadra", 117);
            AddMapping("Goldeen", 118);
            AddMapping("Seaking", 119);
            AddMapping("Staryu", 120);

            pokemonTypeData.Add(111, PokemonType.Ground | PokemonType.Rock);
            pokemonTypeData.Add(112, PokemonType.Ground | PokemonType.Rock);
            pokemonTypeData.Add(113, PokemonType.Normal);
            pokemonTypeData.Add(114, PokemonType.Grass);
            pokemonTypeData.Add(115, PokemonType.Normal);
            pokemonTypeData.Add(116, PokemonType.Water);
            pokemonTypeData.Add(117, PokemonType.Water);
            pokemonTypeData.Add(118, PokemonType.Water);
            pokemonTypeData.Add(119, PokemonType.Water);
            pokemonTypeData.Add(120, PokemonType.Water);

            AddMapping("Starmie", 121);
            AddMapping("Mr. Mime", 122);
            AddMapping("Scyther", 123);
            AddMapping("Jynx", 124);
            AddMapping("Electabuzz", 125);
            AddMapping("Magmar", 126);
            AddMapping("Pinsir", 127);
            AddMapping("Tauros", 128);
            AddMapping("Magikarp", 129);
            AddMapping("Gyarados", 130);

            pokemonTypeData.Add(121, PokemonType.Water | PokemonType.Psychic);
            pokemonTypeData.Add(122, PokemonType.Psychic);
            pokemonTypeData.Add(123, PokemonType.Bug | PokemonType.Flying);
            pokemonTypeData.Add(124, PokemonType.Ice | PokemonType.Psychic);
            pokemonTypeData.Add(125, PokemonType.Electric);
            pokemonTypeData.Add(126, PokemonType.Fire);
            pokemonTypeData.Add(127, PokemonType.Bug);
            pokemonTypeData.Add(128, PokemonType.Normal);
            pokemonTypeData.Add(129, PokemonType.Water);
            pokemonTypeData.Add(130, PokemonType.Water | PokemonType.Flying);

            AddMapping("Lapras", 131);
            AddMapping("Ditto", 132);
            AddMapping("Eevee", 133);
            AddMapping("Vaporeon", 134);
            AddMapping("Jolteon", 135);
            AddMapping("Flareon", 136);
            AddMapping("Porygon", 137);
            AddMapping("Omanyte", 138);
            AddMapping("Omastar", 139);
            AddMapping("Kabuto", 140);

            pokemonTypeData.Add(131, PokemonType.Water | PokemonType.Ice);
            pokemonTypeData.Add(132, PokemonType.Normal);
            pokemonTypeData.Add(133, PokemonType.Normal);
            pokemonTypeData.Add(134, PokemonType.Water);
            pokemonTypeData.Add(135, PokemonType.Electric);
            pokemonTypeData.Add(136, PokemonType.Electric);
            pokemonTypeData.Add(137, PokemonType.Normal);
            pokemonTypeData.Add(138, PokemonType.Rock | PokemonType.Water);
            pokemonTypeData.Add(139, PokemonType.Rock | PokemonType.Water);
            pokemonTypeData.Add(140, PokemonType.Rock | PokemonType.Water);

            AddMapping("Kabutops", 141);
            AddMapping("Aerodactyl", 142);
            AddMapping("Snorlax", 143);
            AddMapping("Articuno", 144);
            AddMapping("Zapdos", 145);
            AddMapping("Moltres", 146);
            AddMapping("Dratini", 147);
            AddMapping("Dragonair", 148);
            AddMapping("Dragonite", 149);
            AddMapping("Mewtwo", 150);

            pokemonTypeData.Add(141, PokemonType.Rock | PokemonType.Water);
            pokemonTypeData.Add(142, PokemonType.Rock | PokemonType.Flying);
            pokemonTypeData.Add(143, PokemonType.Normal);
            pokemonTypeData.Add(144, PokemonType.Ice | PokemonType.Flying);
            pokemonTypeData.Add(145, PokemonType.Electric | PokemonType.Flying);
            pokemonTypeData.Add(146, PokemonType.Fire | PokemonType.Flying);
            pokemonTypeData.Add(147, PokemonType.Dragon);
            pokemonTypeData.Add(148, PokemonType.Dragon);
            pokemonTypeData.Add(149, PokemonType.Dragon | PokemonType.Flying);
            pokemonTypeData.Add(150, PokemonType.Psychic);

            AddMapping("Mew", 151);
            AddMapping("Chikorita", 152);
            AddMapping("Bayleef", 153);
            AddMapping("Meganium", 154);
            AddMapping("Cyndaquil", 155);
            AddMapping("Quilava", 156);
            AddMapping("Typhlosion", 157);
            AddMapping("Totodile", 158);
            AddMapping("Croconaw", 159);
            AddMapping("Feraligatr", 160);

            pokemonTypeData.Add(151, PokemonType.Psychic);
            pokemonTypeData.Add(152, PokemonType.Grass);
            pokemonTypeData.Add(153, PokemonType.Grass);
            pokemonTypeData.Add(154, PokemonType.Grass);
            pokemonTypeData.Add(155, PokemonType.Fire);
            pokemonTypeData.Add(156, PokemonType.Fire);
            pokemonTypeData.Add(157, PokemonType.Fire);
            pokemonTypeData.Add(158, PokemonType.Water);
            pokemonTypeData.Add(159, PokemonType.Water);
            pokemonTypeData.Add(160, PokemonType.Water);

            AddMapping("Sentret", 161);
            AddMapping("Furret", 162);
            AddMapping("Hoothoot", 163);
            AddMapping("Noctowl", 164);
            AddMapping("Ledyba", 165);
            AddMapping("Ledian", 166);
            AddMapping("Spinarak", 167);
            AddMapping("Ariados", 168);
            AddMapping("Crobat", 169);
            AddMapping("Chinchou", 170);

            pokemonTypeData.Add(161, PokemonType.Normal);
            pokemonTypeData.Add(162, PokemonType.Normal);
            pokemonTypeData.Add(163, PokemonType.Normal | PokemonType.Flying);
            pokemonTypeData.Add(164, PokemonType.Normal | PokemonType.Flying);
            pokemonTypeData.Add(165, PokemonType.Bug | PokemonType.Flying);
            pokemonTypeData.Add(166, PokemonType.Bug | PokemonType.Flying);
            pokemonTypeData.Add(167, PokemonType.Bug | PokemonType.Poison);
            pokemonTypeData.Add(168, PokemonType.Bug | PokemonType.Poison);
            pokemonTypeData.Add(169, PokemonType.Poison | PokemonType.Flying);
            pokemonTypeData.Add(170, PokemonType.Water | PokemonType.Electric);

            AddMapping("Lanturn", 171);
            AddMapping("Pichu", 172);
            AddMapping("Cleffa", 173);
            AddMapping("Igglybuff", 174);
            AddMapping("Togepi", 175);
            AddMapping("Togetic", 176);
            AddMapping("Natu", 177);
            AddMapping("Xatu", 178);
            AddMapping("Mareep", 179);
            AddMapping("Flaffy", 180);

            pokemonTypeData.Add(171, PokemonType.Water | PokemonType.Electric);
            pokemonTypeData.Add(172, PokemonType.Electric);
            pokemonTypeData.Add(173, PokemonType.Normal);
            pokemonTypeData.Add(174, PokemonType.Normal);
            pokemonTypeData.Add(175, PokemonType.Normal);
            pokemonTypeData.Add(176, PokemonType.Normal | PokemonType.Flying);
            pokemonTypeData.Add(177, PokemonType.Psychic | PokemonType.Flying);
            pokemonTypeData.Add(178, PokemonType.Psychic | PokemonType.Flying);
            pokemonTypeData.Add(179, PokemonType.Electric);
            pokemonTypeData.Add(180, PokemonType.Electric);
            
            AddMapping("Ampharos", 181);
            AddMapping("Bellossom", 182);
            AddMapping("Marill", 183);
            AddMapping("Azumarill", 184);
            AddMapping("Sudowoodo", 185);
            AddMapping("Politoed", 186);
            AddMapping("Hoppip", 187);
            AddMapping("Skiploom", 188);
            AddMapping("Jumpluff", 189);
            AddMapping("Aipom", 190);

            pokemonTypeData.Add(181, PokemonType.Electric);
            pokemonTypeData.Add(182, PokemonType.Grass);
            pokemonTypeData.Add(183, PokemonType.Water);
            pokemonTypeData.Add(184, PokemonType.Water);
            pokemonTypeData.Add(185, PokemonType.Rock);
            pokemonTypeData.Add(186, PokemonType.Water);
            pokemonTypeData.Add(187, PokemonType.Grass | PokemonType.Flying);
            pokemonTypeData.Add(188, PokemonType.Grass | PokemonType.Flying);
            pokemonTypeData.Add(189, PokemonType.Grass | PokemonType.Flying);
            pokemonTypeData.Add(190, PokemonType.Normal);

            AddMapping("Sunkern", 191);
            AddMapping("Sunflora", 192);
            AddMapping("Yanma", 193);
            AddMapping("Wooper", 194);
            AddMapping("Quagsire", 195);
            AddMapping("Espeon", 196);
            AddMapping("Umbreon", 197);
            AddMapping("Murkrow", 198);
            AddMapping("Slowking", 199);
            AddMapping("Misdreavus", 200);

            pokemonTypeData.Add(191, PokemonType.Grass);
            pokemonTypeData.Add(192, PokemonType.Grass);
            pokemonTypeData.Add(193, PokemonType.Bug | PokemonType.Flying);
            pokemonTypeData.Add(194, PokemonType.Water | PokemonType.Ground);
            pokemonTypeData.Add(195, PokemonType.Water | PokemonType.Ground);
            pokemonTypeData.Add(196, PokemonType.Psychic);
            pokemonTypeData.Add(197, PokemonType.Dark);
            pokemonTypeData.Add(198, PokemonType.Dark | PokemonType.Flying);
            pokemonTypeData.Add(199, PokemonType.Water | PokemonType.Psychic);
            pokemonTypeData.Add(200, PokemonType.Ghost);
            
            AddMapping("Unown", 201);
            AddMapping("Wobbuffet", 202);
            AddMapping("Girafarig", 203);
            AddMapping("Pineco", 204);
            AddMapping("Forretress", 205);
            AddMapping("Dunsparce", 206);
            AddMapping("Gligar", 207);
            AddMapping("Steelix", 208);
            AddMapping("Snubbull", 209);
            AddMapping("Granbull", 210);

            pokemonTypeData.Add(201, PokemonType.Psychic);
            pokemonTypeData.Add(202, PokemonType.Psychic);
            pokemonTypeData.Add(203, PokemonType.Normal | PokemonType.Psychic);
            pokemonTypeData.Add(204, PokemonType.Bug);
            pokemonTypeData.Add(205, PokemonType.Bug | PokemonType.Steel);
            pokemonTypeData.Add(206, PokemonType.Normal);
            pokemonTypeData.Add(207, PokemonType.Ground | PokemonType.Flying);
            pokemonTypeData.Add(208, PokemonType.Steel | PokemonType.Ground);
            pokemonTypeData.Add(209, PokemonType.Normal);
            pokemonTypeData.Add(210, PokemonType.Normal);

            AddMapping("Qwilfish", 211);
            AddMapping("Scizor", 212);
            AddMapping("Shuckle", 213);
            AddMapping("Heracross", 214);
            AddMapping("Sneasel", 215);
            AddMapping("Teddiursa", 216);
            AddMapping("Ursaring", 217);
            AddMapping("Slugma", 218);
            AddMapping("Magcargo", 219);
            AddMapping("Swinub", 220);

            pokemonTypeData.Add(211, PokemonType.Water | PokemonType.Poison);
            pokemonTypeData.Add(212, PokemonType.Bug | PokemonType.Steel);
            pokemonTypeData.Add(213, PokemonType.Bug | PokemonType.Rock);
            pokemonTypeData.Add(214, PokemonType.Bug | PokemonType.Fighting);
            pokemonTypeData.Add(215, PokemonType.Dark | PokemonType.Ice);
            pokemonTypeData.Add(216, PokemonType.Normal);
            pokemonTypeData.Add(217, PokemonType.Normal);
            pokemonTypeData.Add(218, PokemonType.Fire);
            pokemonTypeData.Add(219, PokemonType.Fire | PokemonType.Rock);
            pokemonTypeData.Add(220, PokemonType.Ice | PokemonType.Ground);

            AddMapping("Piloswine", 221);
            AddMapping("Corsola", 222);
            AddMapping("Remoraid", 223);
            AddMapping("Octillery", 224);
            AddMapping("Delibird", 225);
            AddMapping("Mantine", 226);
            AddMapping("Skarmory", 227);
            AddMapping("Houndour", 228);
            AddMapping("Houndoom", 229);
            AddMapping("Kingdra", 230);

            pokemonTypeData.Add(221, PokemonType.Ice | PokemonType.Ground);
            pokemonTypeData.Add(222, PokemonType.Water | PokemonType.Rock);
            pokemonTypeData.Add(223, PokemonType.Water);
            pokemonTypeData.Add(224, PokemonType.Water);
            pokemonTypeData.Add(225, PokemonType.Ice | PokemonType.Flying);
            pokemonTypeData.Add(226, PokemonType.Water | PokemonType.Flying);
            pokemonTypeData.Add(227, PokemonType.Steel | PokemonType.Flying);
            pokemonTypeData.Add(228, PokemonType.Dark | PokemonType.Fire);
            pokemonTypeData.Add(229, PokemonType.Dark | PokemonType.Fire);
            pokemonTypeData.Add(230, PokemonType.Water | PokemonType.Dragon);

            AddMapping("Phanpy", 231);
            AddMapping("Donphan", 232);
            AddMapping("Porygon2", 233);
            AddMapping("Stantler", 234);
            AddMapping("Smeargle", 235);
            AddMapping("Tyrogue", 236);
            AddMapping("Hitmontop", 237);
            AddMapping("Smoochum", 238);
            AddMapping("Elekid", 239);
            AddMapping("Magby", 240);

            pokemonTypeData.Add(231, PokemonType.Ground);
            pokemonTypeData.Add(232, PokemonType.Ground);
            pokemonTypeData.Add(233, PokemonType.Normal);
            pokemonTypeData.Add(234, PokemonType.Normal);
            pokemonTypeData.Add(235, PokemonType.Normal);
            pokemonTypeData.Add(236, PokemonType.Fighting);
            pokemonTypeData.Add(237, PokemonType.Fighting);
            pokemonTypeData.Add(238, PokemonType.Ice | PokemonType.Psychic);
            pokemonTypeData.Add(239, PokemonType.Electric);
            pokemonTypeData.Add(240, PokemonType.Fire);

            AddMapping("Miltank", 241);
            AddMapping("Blissey", 242);
            AddMapping("Raikou", 243);
            AddMapping("Entei", 244);
            AddMapping("Suicune", 245);
            AddMapping("Larvitar", 246);
            AddMapping("Pupitar", 247);
            AddMapping("Tyranitar", 248);
            AddMapping("Lugia", 249);
            AddMapping("Ho-Oh", 250);

            pokemonTypeData.Add(241, PokemonType.Normal);
            pokemonTypeData.Add(242, PokemonType.Normal);
            pokemonTypeData.Add(243, PokemonType.Electric);
            pokemonTypeData.Add(244, PokemonType.Fire);
            pokemonTypeData.Add(245, PokemonType.Water);
            pokemonTypeData.Add(246, PokemonType.Rock | PokemonType.Ground);
            pokemonTypeData.Add(247, PokemonType.Rock | PokemonType.Ground);
            pokemonTypeData.Add(248, PokemonType.Rock | PokemonType.Dark);
            pokemonTypeData.Add(249, PokemonType.Psychic | PokemonType.Flying);
            pokemonTypeData.Add(250, PokemonType.Fire | PokemonType.Flying);

            AddMapping("Celebi", 251);
            AddMapping("Glitch", 252);
            AddMapping("Glitch Egg", 253);
            AddMapping("Glitch", 254);
            AddMapping("Glitch", 255);

            pokemonTypeData.Add(251, PokemonType.Psychic | PokemonType.Grass);
            pokemonTypeData.Add(252, PokemonType.Normal);
            pokemonTypeData.Add(253, PokemonType.Normal);
            pokemonTypeData.Add(254, PokemonType.Normal);
            pokemonTypeData.Add(255, PokemonType.Normal);

        }
    }

    private void AddMapping(string name, byte hexCode) {
        _stringToHexMap[name] = hexCode;
        _hexToStringMap[hexCode] = name;
    }


    internal string GetPokemonName(byte hexCode) {
        if (_hexToStringMap.TryGetValue(hexCode, out string? name))
        {
            return name;
        }
        else {
            throw new KeyNotFoundException($"Hex value!! '{(ushort)hexCode}' not found.");
        }
    }

    public PokemonType[] GetPokemonType(byte pokemonId)
    {
        
        if (pokemonTypeData.TryGetValue(pokemonId, out PokemonType typeFromData))
        {
            PokemonType[] types = new PokemonType[2];
            int index = 0;
            foreach(PokemonType type in Enum.GetValues(typeof(PokemonType)))
            {
                if (type != PokemonType.None && typeFromData.HasFlag(type))
                {
                    types[index++] = type;

                    if(index == 2)
                    {
                        break;
                    }
                }
            }
            if (index == 1)
            {
                types[1] = PokemonType.None;
            }
            return types;
        }
        else
        {
            throw new KeyNotFoundException($"Error, type data not found for specified pokemon ID.");
        }
    }

    public byte GetHexCode(string name) 
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