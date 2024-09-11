using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.XPath;

public class GameData
{
    // Constants - Hex Data Offset Locations
    internal const ushort BOX_SIZE_TO_FIRST_POKEMON_OFFSET = 0x16;
    internal const ushort BOX_ONE_BEGIN = 0x4000;    
    internal const ushort BOX_SEVEN_BEGIN = 0x6000;
    
    internal const ushort OT_NICK_NEXT_NAME_OFFSET = 0x0B;
    public const ushort PARTY_SIZE_TO_FIRST_POKEMON_OFFSET = 0x08;
    public const ushort PARTY_SIZE_TO_FIRST_OT_OFFSET = 0x110;
    public const ushort partySizeToFirstNickOffset = 0x152;
    private const ushort partyOtIdOffset = 0x0C;
    
    private readonly static ushort[] genderAndShadowOffsetCrystal = {0x3E3D, 0x206A};
    

    
    
    

    internal const int boxItemsSizeOffset = 0x27E6;
    internal const int boxFirstItemOffset = boxItemsSizeOffset + 0x01;


    // Fields
    private byte[] fileData;
    public string fileName { get; set; }
    public int generation { get; set; }
    internal bool crystal { get; set; }
    public Party partyPokemon;
    public PokemonPC pcPokemon;
    public Bag items { get; set; }
    public ItemBox boxItems { get; }

    internal Offsets offsets;
    internal ItemData itemData;
    internal PokemonData pokemonData;

    // Constructor
    public GameData(string fileName)
    {
        fileData = File.ReadAllBytes(fileName);
        this.fileName = fileName;
        this.generation = determineGeneration();
        offsets = new Offsets(this.generation, this.crystal);
        itemData = new ItemData(generation);
        pokemonData = new PokemonData(generation);



        partyPokemon = new Party(this);
        pcPokemon = new PokemonPC(this);
        if(generation == 1) {
            items = new Bag(GetBagItems(offsets.bagSizeOffset, 20));
        }
        else
        {
            items = new Bag(GetBagItems(offsets.bagSizeOffset, 20),
            GetBagItems(offsets.ballsPocketOffset, 12),
             GetBagItems(offsets.keyItemsPocketOffset, 26, false),
             GetTMPocketItems(offsets.tmPocketOffset));
        }
        
        this.boxItems = new ItemBox(GetBoxItems());


    }

    // Returns 1 if generation 1, 2 if generation 2.


    // Function to insert data to the game save file
    // newData = byte array of data to insert
    // startOffset = where to begin insertion
    public void PatchHexBytes(byte[] newData, int startOffset)
    {
        if (newData.Length <= 0)
        {
            Console.WriteLine("Error: New data size is zero.");
            return;
        }
        for (int i = 0; i < newData.Length; ++i)
        {
            fileData[startOffset + i] = newData[i];
        }
    }

    internal void SetGender(byte gender)
    {
        if(!crystal)
        {
            Console.WriteLine("Error, changing gender is only supported for Pokemon Crystal saves. Aborting.");
            return;
        }
        if(gender > 1 || gender < 0)
        {
            Console.WriteLine("Error: Gender must be set to either 0 (male) or 1 (female). Aborting");
            return;
        }
        
        PatchHexByte(gender, genderAndShadowOffsetCrystal[0]);
        PatchHexByte(gender, genderAndShadowOffsetCrystal[1]);
    }

    private int determineGeneration()
    {
        ReadOnlySpan<byte> save = GetSaveData();
        bool valid = false;
        valid = ValidateList(save, 0x2F2C, 6) && ValidateList(save, 0x30C0, 20);
        Console.WriteLine($"Found valid gen 1 lists (US): {valid}");
        if (valid)
        {
            this.generation = 1;
            this.crystal = false;
            return this.generation;
        }


        valid = ValidateList(save, 0x2ED5, 6) && ValidateList(save, 0x302D, 30);
        Console.WriteLine($"Found valid gen 1 lists (J): {valid}");
        if (valid)
        {
            this.generation = 1;
            this.crystal = false;
            return this.generation;
        }

        valid = ValidateList(save, 0x288A, 6) && ValidateList(save, 0x2D6C, 20);
        Console.WriteLine($"Found valid gen 2 (GS) lists (US): {valid}");
        if (valid)
        {
            this.generation = 2;
            this.crystal = false;
            return this.generation;
        }

        valid = ValidateList(save, 0x2865, 6) && ValidateList(save, 0x2D10, 20);
        Console.WriteLine($"Found valid gen 2 (C) lists (US): {valid}");
        if (valid)
        {
            this.generation = 2;
            this.crystal = true;
            return this.generation;
        }

        valid = ValidateList(save, 0x283E, 6) && ValidateList(save, 0x2D10, 30);
        Console.WriteLine($"Found valid gen 2 (GS) lists (J): {valid}");
        if (valid)
        {
            this.generation = 2;
            this.crystal = false;
            return this.generation;
        }
        valid = ValidateList(save, 0x281A, 6) && ValidateList(save, 0x2D10, 30);
        Console.WriteLine($"Found valid gen 2 (C) lists (J): {valid}");
        if (valid)
        {
            this.generation = 2;
            this.crystal = true;
            return this.generation;
        }

        return -1;
    }

    private bool ValidateList(ReadOnlySpan<byte> data, int offset, int maxEntries)
    {
        byte listLength = data[offset];
        return listLength <= maxEntries && data[offset + listLength + 1] == 0xFF;
    }

    public ReadOnlySpan<byte> GetSaveData()
    {
        return fileData;
    }
    // Insert a single byte of data at a given offset
    public void PatchHexByte(byte newData, int offset)
    {
        fileData[offset] = newData;
    }

    // Calculate checksum for generation 1 save file
    internal int CalculateChecksum()
    {
        ushort startOffset = (ushort)offsets.checksumStart;
        ushort endOffset = (ushort)offsets.checksumEnd;

        if (startOffset < 0 || endOffset >= GetSaveData().Length || startOffset > endOffset)
        {
            throw new ArgumentException("Invalid start or end offset.");
        }

        int checksum = 0;

        if (generation == 1)
        {

            // Iterate through the specified range and calculate the checksum
            for (ushort i = startOffset; i <= endOffset; i++)
            {
                checksum += fileData[i];
            }

            return ~checksum;
        }
        else
        {
            for(ushort i = startOffset; i <= endOffset; ++i)
            {
                checksum += fileData[i];
            }
            
            checksum = checksum & 0xFFFF; // Isolate checksum to least significant two bytes
            checksum = (checksum >> 8) | ((checksum & 0xFF) << 8); // Swap the high and low bytes
            return checksum;

            
        }
    }

    // Fetch a byte of data from a given offset
    public byte GetData(int offset)
    {
        if (offset < 0 || offset >= fileData.Length)
        {
            throw new ArgumentException("Invalid offset provided. Aborting data retrevial.");
        }
        return fileData[offset];
    }

    // Fetch a byte array from fileData between the start and end offset (inclusive).
    public byte[] GetData(int startOffset, int endOffset)
    {
        if (startOffset < 0 || endOffset < startOffset || endOffset >= fileData.Length)
        {
            throw new ArgumentException("Invalid start or end offset.");
        }

        int length = endOffset - startOffset + 1;
        byte[] result = new byte[length];
        Array.Copy(fileData, startOffset, result, 0, length);

        return result;
    }

    public int GetDataSize()
    {
        return fileData.Length;
    }

    public void EmptyBag()
    {
        items.ClearBag();

        byte[] bagClear = { 0x00, 0xFF };
        PatchHexBytes(bagClear, offsets.bagSizeOffset);
    }

    public void WriteToFile()
    {
        UpdateChecksum(CalculateChecksum());
        File.WriteAllBytes(fileName, fileData);
    }

    public string GetTrainerName()
    {
        return GetEncodedText(offsets.trainerNameOffset, 0x50, offsets.trainerNameSize);
    }

    public string GetRivalName()
    {
        return GetEncodedText(offsets.rivalNameOffset, 0x50, offsets.trainerNameOffset);
    }

    public void ChangeRivalName(string name)
    {
        if (name.Length > 7 || name.Length <= 0)
        {
            Console.WriteLine("Error: Name must be between 1 and 7 characters.");
            return;
        }

        byte[] encodedName = EncodeText(name, 0x50);
        if (encodedName.Length > offsets.trainerNameSize)
        {
            Console.WriteLine("Error: Encoded name text too long.");
            return;
        }
        PatchHexBytes(encodedName, offsets.rivalNameOffset);
    }

    public void ChangePartyPokemonOtId(int newID)
    {
        int idOffset = 0x2605;

        byte[] newId = HexFunctions.ConvertIntToHexBytes(54321);

        for (int i = 0; i < newId.Length; ++i)
        {
            fileData[idOffset + i] = newId[i];
        }

        int partyOffset = 0x2F2C;
        int firstPokemon = partyOffset + 0x08;
        int firstPokemonOtId = firstPokemon + partyOtIdOffset;

        Console.WriteLine("Total Pokemon in Party: " + fileData[partyOffset]);
        int currentOffset = firstPokemonOtId;
        for (int j = 0; j < fileData[partyOffset]; ++j)
        {
            PatchHexBytes(newId, currentOffset);
            currentOffset += 0x2C;
        }
    }

    public Badges GetBadges()
    {
        bool[] values = new bool[8];

        byte data = GetSaveData()[offsets.badgesOffset];

        for(byte index = 0; index < 8; ++index)
        {
            if(HexFunctions.BitIsSet(data, index))
            {
                values[index] = true;
            }
        }

        Badges badges = new Badges(values);

        return badges;
    }


    private int DecodeBCD(byte bcdByte)
    {
        return (bcdByte >> 4) * 10 + (bcdByte & 0xF);
    }

    // Returns 32bit integer representing how much money the player has in decimal.
    public uint GetMoney()
    {
        byte[] money = GetData(offsets.moneyOffset, offsets.moneyOffset + 2);

        if (generation == 1)
        {
            uint result = (uint)(DecodeBCD(money[0]) * 10000 +
                         DecodeBCD(money[1]) * 100 +
                         DecodeBCD(money[2]));
            return result;
        }
        else
        {

            // Combine bytes (big-endian)
            uint result = (uint)(money[2] | (money[1] << 8) | (money[0] << 16));
            return result;
        }
    }


    public ushort GetNumberOwned()
    {
        ushort sum = 0;
        for (int i = offsets.ownedOffset; i < offsets.ownedOffset + offsets.ownedSeenSize; ++i)
        {
            sum += getSumBits(fileData[i]);
        }

        return sum;
    }

    public ushort GetNumberSeen()
    {
        ushort sum = 0;
        for (int i = offsets.seenOffset; i < offsets.seenOffset + offsets.ownedSeenSize; ++i)
        {
            sum += getSumBits(fileData[i]);
        }

        return sum;
    }

    private ushort getSumBits(byte input)
    {
        ushort count = 0;

        for (int i = 0; i < 8; ++i)
        {
            if ((input & (1 << i)) != 0)
            {
                count++;
            }
        }

        return count;
    }

    public ushort GetPartySize()
    {

        return (ushort)GetData(offsets.partySizeOffset);

    }

    internal ushort GetBoxSize(ushort boxNum)
    {
        if (GetData(offsets.currentlySetBoxOffset) + 1 == boxNum)
        {
            return (ushort)GetData(offsets.currentBoxDataBegin);
            
        }
        else
        {
            if(generation == 1)
            {
                if (boxNum < 7)
                {
                    return (ushort)GetData(BOX_ONE_BEGIN + ((boxNum - 1) * offsets.nextBoxOffset));
                }
                else
                {
                    return (ushort)GetData(BOX_SEVEN_BEGIN + ((boxNum - 7) * offsets.nextBoxOffset));
                }
            }
            else
            {
             return GetData(BOX_ONE_BEGIN + ((boxNum - 1) * offsets.nextBoxOffset));   
            }
        }
    }

    public string GetPartyPokemonName(ushort num)
    {
        if (num <= 0 || num >= 7)
        {
            throw new ArgumentException("Invalid party index! Must be 1 - 6");
        }

        if (num > GetPartySize())
        {
            throw new ArgumentException($"Invalid party index. Exceeds party size of {GetPartySize()}.");
        }
        try
        {
            string result = pokemonData.GetPokemonName(GetData(offsets.partySizeOffset + num));
            return result;
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return "Undefined";
        }
    }


    internal List<Pokemon> GetBoxPokemon(ushort boxNumber)
    {
        List<Pokemon> boxPokemon = new List<Pokemon>();
        if (boxNumber < 1 || boxNumber > 12)
        {
            throw new ArgumentException("Error: Invalid box number. Aborting.");
        }

        Pokemon current;
        string name;
        ushort level;
        byte ad, ss;
        ushort attack, defense, speed, special, hp;
        IV ivs;
        EVs evs;
        int currentBoxOffset;
        int currentPokemonOffset;
        int otNameOffset;
        int nickNameOffset;
        string otName;
        string nickname;
        string[] types = new string[2];
        byte[] hexIn = new byte[2];
        ushort cursor;
        if (GetData(offsets.currentlySetBoxOffset) + 1 == boxNumber)
        {
            currentBoxOffset = offsets.currentBoxDataBegin;
            currentPokemonOffset = currentBoxOffset + BOX_SIZE_TO_FIRST_POKEMON_OFFSET;
        }
        else
        {
            if(generation == 1)
            {
                if (boxNumber < 7)
                {
                    currentBoxOffset = BOX_ONE_BEGIN + ((boxNumber - 1) * offsets.nextBoxOffset);
                }
                else
                {
                    currentBoxOffset = BOX_SEVEN_BEGIN + ((boxNumber - 7) * offsets.nextBoxOffset);
                }
            }
            else
            {
                currentBoxOffset = BOX_ONE_BEGIN + ((boxNumber - 1) * offsets.nextBoxOffset);
            }

            currentPokemonOffset = currentBoxOffset + BOX_SIZE_TO_FIRST_POKEMON_OFFSET;

        }
        int boxSize = GetBoxSize(boxNumber);

        if (boxSize < 1 || boxSize == 255)
        {
            return boxPokemon;
        }


        for (ushort i = 1; i <= boxSize; ++i)
        {


            name = pokemonData.GetPokemonName(GetData(currentPokemonOffset));
            level = (ushort)GetData(currentPokemonOffset + offsets.boxLevelOffset);
            ad = GetData(currentPokemonOffset + offsets.boxIvOffset);
            ss = GetData(currentPokemonOffset + offsets.boxIvOffset + 1);
            attack = (ushort)(ad >> 4);
            defense = (ushort)(ad & 0x0F);
            speed = (ushort)(ss >> 4);
            special = (ushort)(ss & 0x0F);
            hp = CalculateHpIv(attack, defense, special, speed);
            if(generation == 1)
            {
                types[0] = TypeData.GetName(GetData(currentPokemonOffset + 0x05));
                types[1] = TypeData.GetName(GetData(currentPokemonOffset + 0x06));
            }
            else {
                PokemonData.PokemonType[] typeData = pokemonData.GetPokemonType(GetData(currentPokemonOffset));
                types[0] = typeData[0].ToString();
                types[1] = typeData[1].ToString();
            }

            ivs = new IV
            {
                HP = hp,
                Attack = attack,
                Defense = defense,
                Speed = speed,
                Special = special,
                
            };

            cursor = (ushort)(currentPokemonOffset + offsets.boxEvOffset);
            ushort[] values = new ushort[5];
            for (ushort index = 0; index < 5; ++index)
            {
                hexIn = GetData(cursor++, cursor++);
                values[index] = (ushort)((hexIn[0] << 8) | hexIn[1]);
            }

            evs = new EVs
            {
                HP = values[0],
                Attack = values[1],
                Defense = values[2],
                Speed = values[3],
                Special = values[4]
            };

            cursor = (ushort)(currentPokemonOffset + offsets.otIdOffset);
            hexIn = GetData(cursor++, cursor++);
            int id = hexIn[0] << 8 | hexIn[1];

            
            // Get OT name

            otNameOffset = currentBoxOffset + offsets.boxOtNameOffset + (OT_NICK_NEXT_NAME_OFFSET * (i - 1));
            otName = GetEncodedText(otNameOffset, 0x50, offsets.trainerNameSize);

            nickNameOffset = currentBoxOffset + offsets.boxNicknameOffset + (OT_NICK_NEXT_NAME_OFFSET * (i - 1));
            nickname = GetEncodedText(nickNameOffset, 0x50, offsets.trainerNameSize);

            current = new Pokemon(name, level, ivs, new Stats(), evs, otName, nickname, types, id, 1);
            boxPokemon.Add(current);
            currentPokemonOffset += offsets.nextBoxPokemonOffset;
            //otName.Clear();

        }

        return boxPokemon;
    }

    internal List<Pokemon> GetPartyPokemon()
    {
        List<Pokemon> partyPokemon = new List<Pokemon>();
        Pokemon current;
        string speciesName;
        byte speciesId;
        ushort level;
        byte ad;
        byte ss;
        ushort attack;
        ushort defense;
        ushort speed;
        ushort special;
        IV ivs;
        Stats stats;
        EVs evs;
        ushort currentPokemonOffset = (ushort)(offsets.partySizeOffset + PARTY_SIZE_TO_FIRST_POKEMON_OFFSET);
        string otName;
        string nickname;
        string[] types = new string[2];
        int otNameOffset;
        int nickOffset;




        for (ushort i = 1; i <= GetPartySize(); ++i)
        {
            try
            {
                speciesId = GetData(currentPokemonOffset);
                speciesName = GetPartyPokemonName(i);
                level = (ushort)GetData(currentPokemonOffset + offsets.levelOffset);
                ad = GetData(currentPokemonOffset + offsets.attackDefenseOffset);
                ss = GetData(currentPokemonOffset + offsets.speedSpecialOffset);
                attack = (ushort)(ad >> 4);
                defense = (ushort)(ad & 0x0F);
                speed = (ushort)(ss >> 4);
                special = (ushort)(ss & 0x0F);
                if(generation == 1)
                {
                    types[0] = TypeData.GetName(GetData(currentPokemonOffset + offsets.genOneType1Offset));
                    types[1] = TypeData.GetName(GetData(currentPokemonOffset + offsets.genOneType1Offset + 1));
                }
                else
                {
                    PokemonData.PokemonType[] type = pokemonData.GetPokemonType(speciesId);
                    types[0] = type[0].ToString();
                    types[1] = type[1].ToString();
                }
                ivs = new IV
                {
                    HP = CalculateHpIv(attack, defense, special, speed),
                    Attack = attack,
                    Defense = defense,
                    Speed = speed,
                    Special = special
                };
                
                ushort cursor = (ushort)(currentPokemonOffset + offsets.statsOffset);
                stats = new Stats {
                    HP = (ushort)(GetData(cursor++) + GetData(cursor++)),
                    Attack = (ushort)(GetData(cursor++) + GetData(cursor++)),
                    Defense = (ushort)(GetData(cursor++) + GetData(cursor++)),
                    Speed = (ushort)(GetData(cursor++) + GetData(cursor++)),
                    SpecialAttack = (ushort)(GetData(cursor) + GetData(cursor + 1)),
                    SpecialDefense = (ushort)(GetData(cursor++) + GetData(cursor++))
                };

                cursor = (ushort)(currentPokemonOffset + offsets.evOffset);
                ushort[] values = new ushort[5];
                byte[] hexIn = new byte[2];
                for ( ushort index = 0; index < 5; ++index)
                {
                    hexIn[0] = GetData(cursor++);
                    hexIn[1] = GetData(cursor++);
                    values[index] = (ushort)((hexIn[0] << 8) | hexIn[1]);
                }
                evs = new EVs {
                    HP = values[0],
                    Attack = values[1],
                    Defense = values[2],
                    Speed = values[3],
                    Special = values[4]
                };

                cursor = (ushort)(currentPokemonOffset + offsets.otIdOffset);
                hexIn = GetData(cursor++, cursor++);
                int id = hexIn[0] << 8 | hexIn[1];


                otNameOffset = (offsets.partySizeOffset + PARTY_SIZE_TO_FIRST_OT_OFFSET) + (OT_NICK_NEXT_NAME_OFFSET * (i - 1));
                otName = GetEncodedText(otNameOffset, 0x50, offsets.trainerNameSize);

                nickOffset = (offsets.partySizeOffset + partySizeToFirstNickOffset) + (OT_NICK_NEXT_NAME_OFFSET * (i - 1));
                nickname = GetEncodedText(nickOffset, 0x50, offsets.trainerNameSize);

                current = new Pokemon(speciesName, level, ivs, stats, evs, otName, nickname, types, id, 1);
                partyPokemon.Add(current);
                currentPokemonOffset += (ushort)offsets.partyNextPokemonOffset; // increment by 44 bytes to get to next party pokemon
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        return partyPokemon;
    }

    private static ushort CalculateHpIv(ushort attack, ushort defense, ushort special, ushort speed)
    {
        ushort hpIv = 0;
        if (attack % 2 == 1)
        {
            hpIv += 8;
        }
        if (defense % 2 == 1)
        {
            hpIv += 4;
        }
        if (speed % 2 == 1)
        {
            hpIv += 2;
        }
        if (special % 2 == 1)
        {
            hpIv += 1;
        }
        return hpIv;
    }

    public void AddPartyPokemon(PokemonHexData data)
    {
        ushort partySize = GetPartySize();
        if (partySize >= 6)
        {
            throw new ArgumentException("Error: Party is full. Must have an empty slot to add a pokemon to the party. Aborting.");
        }

        ushort slotNumber = (ushort)(partySize + 1);

        //PatchHexByte(0x01, partySizeOffset); debug only

        // 
        int insertOffset = offsets.partySizeOffset + PARTY_SIZE_TO_FIRST_POKEMON_OFFSET + (offsets.partyNextPokemonOffset * (slotNumber - 1));
        PatchHexBytes(data.data, insertOffset);

        PatchHexByte((byte)(partySize + 1), offsets.partySizeOffset);
        PatchHexByte(data.data[0], offsets.partySizeOffset + slotNumber);

        // Null terminator after party size (0xFF)
        PatchHexByte(0xFF, offsets.partySizeOffset + slotNumber + 1);

        insertOffset = (offsets.partySizeOffset + PARTY_SIZE_TO_FIRST_OT_OFFSET) + (OT_NICK_NEXT_NAME_OFFSET * (slotNumber - 1));
        PatchHexBytes(data.otName, insertOffset);

        insertOffset = (offsets.partySizeOffset + partySizeToFirstNickOffset) + (OT_NICK_NEXT_NAME_OFFSET * (slotNumber - 1));
        PatchHexBytes(data.nickname, insertOffset);

        insertOffset = (offsets.partySizeOffset + PARTY_SIZE_TO_FIRST_POKEMON_OFFSET) + (offsets.partyNextPokemonOffset * (slotNumber - 1)) + partyOtIdOffset;
        PatchHexBytes(data.otId, insertOffset);


    }

    internal void WriteCSV(string filename, List<Pokemon> pokemon)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            if(generation == 1)
            {
            // Write the header row
            writer.WriteLine("Species,Level,HP,Attack,Defense,Special Attack,Special Defense,Speed,IV Score,Percentile,Original Trainer,OT Id,Nickname");

                foreach (Pokemon current in pokemon)
                {
                    writer.WriteLine($"{current.speciesName},{current.level}," +
                    $"{current.ivs.HP},{current.ivs.Attack},{current.ivs.Defense}," +
                    $"{current.ivs.Special}, {current.ivs.Special},{current.ivs.Speed}," +
                    $"{current.GetIvScore()}, {current.getIvPercentile()/100},{current.otName}," +
                    $"{current.otId:D5},{current.nickname}");
                }
            }
            else {
                writer.WriteLine("Species,Level,Held Item,HP,Attack,Defense,Special Attack,Special Defense,Speed,IV Score,Percentile,Original Trainer, OT Id,Nickname");
                foreach (Pokemon current in pokemon) {
                    writer.Write($"{current.speciesName},{current.level},");
                    if(current.heldItem == 0) {
                        writer.Write("None,");
                    }
                    else
                    {
                        writer.Write($"{itemData.GetName(current.heldItem)},");
                    }
                    writer.Write($"{current.ivs.HP},{current.ivs.Attack},{current.ivs.Defense},");
                    writer.Write($"{current.ivs.Special},{current.ivs.Special},");
                    writer.Write($"{current.ivs.Speed},");
                    writer.Write($"{current.GetIvScore()},{current.getIvPercentile()/100},");
                    writer.Write($"{current.otName},{current.otId:D5},");
                    writer.WriteLine($"{current.nickname}");
                }
                

            }
        }
        Console.WriteLine("CSV File created.");
    }


    public static byte[] EncodeText(string text, byte terminator)
    {
        byte[] encodedText = new byte[text.Length + 1];
        for (int i = 0; i < text.Length; ++i)
        {
            encodedText[i] = TextEncoding.GetHexValue(text[i]);
        }

        encodedText[text.Length] = terminator;

        return encodedText;
    }
    public string GetEncodedText(int startOffset, int delimiter, int max)
    {
        StringBuilder sb = new StringBuilder();
        for (ushort i = 0; i < max; ++i)
        {
            byte currentChar = GetData(startOffset + i);

            if (currentChar == delimiter)
            {
                break;
            }

            try
            {
                sb.Append(TextEncoding.GetCharacter(currentChar));
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        return sb.ToString();

    }


    public List<Item> GetBoxItems()
    {
        List<Item> items = new List<Item>();

        if (generation == 2)
        {
            return items;
        }

        try
        {
            ushort bagQty = (ushort)GetData(boxItemsSizeOffset);
            int currentOffset = boxFirstItemOffset;
            byte itemHexCode;
            byte itemQty;
            string itemName;
            Item currentItem;

            for (ushort i = 1; i <= 50; i++)
            {
                if (GetData(currentOffset) == 0xFF)
                {
                    break;
                }
                itemHexCode = GetData(currentOffset++);
                itemQty = GetData(currentOffset++);
                itemName = itemData.GetName(itemHexCode);
                currentItem = new Item(itemHexCode, (ushort)itemQty, itemName);
                items.Add(currentItem);
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        return items;
    }

    public List<Item> GetTMPocketItems(int offset) {
        List<Item> tms = new List<Item>();

        byte[] tmOffsets = {
            0xBF, 0xC0, 0XC1, 0xC2, 0xC4,
            0xC5, 0xC6, 0xC7, 0xC8, 0xC9,
            0xCA, 0xCB, 0xCC, 0xCD, 0xCE,
            0xCF, 0xD0, 0xD1, 0xD2, 0xD3,
            0xD4, 0xD5, 0xD6, 0xD7, 0xD8,
            0xD9, 0xDA, 0xDB, 0xDD, 0xDE,
            0xDF, 0xE0, 0xE1, 0xE2, 0xE3,
            0xE4, 0xE5, 0xE6, 0xE7, 0xE8,
            0xE9, 0xEA, 0xEB, 0xEC, 0xED,
            0xEE, 0xEF, 0xF0, 0xF1, 0xF2, 
            0xF3, 0xF4, 0xF5, 0xF6, 0xF7, 
            0xF8, 0xF9, 0xFA, 0xFB, 0xFC,
            0xFD, 0xFE
            
        }; 

        try
        {
            byte itemQty;
            Item currentItem;

            for (ushort i = 0; i < 57; ++i)
            {
                itemQty = GetData(offset++);
                if(itemQty > 0)
                {
                    currentItem = new Item(tmOffsets[i], itemQty, itemData.GetName(tmOffsets[i]));
                    tms.Add(currentItem);
                }
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        return tms;
    }
    public List<Item> GetBagItems(int offset, ushort pocketMax, bool qtys = true)
    {
        List<Item> items = new List<Item>();

        
        try
        {
            ushort bagQty = GetData(offset);
            int currentOffset = offset + 0x01;
            byte itemHexCode;
            byte itemQty;
            string itemName;
            Item currentItem;

            for (ushort i = 1; i <= pocketMax; i++)
            {
                if (GetData(currentOffset) == 0xFF)
                {
                    break;
                }
                itemHexCode = GetData(currentOffset);
                if(!qtys) {
                    itemQty = 1;
                }
                else
                {
                    itemQty = GetData(currentOffset + 0x01);
                }
                
                itemName = itemData.GetName(itemHexCode);
                currentItem = new Item(itemHexCode, itemQty, itemName);
                items.Add(currentItem);
                if(!qtys) {
                    currentOffset++;
                }
                else 
                {
                    currentOffset += 0x02;
                }
            }


        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        return items;
    }

    public void AddItemToBag(Item item)
    {
        ushort bagSize = (ushort)GetData(offsets.bagSizeOffset);

        if (bagSize >= 20)
        {
            Console.WriteLine("Unable to add item to bag. Bag is full. Aborting.");
            return;
        }

        if (item.quantity <= 0 || item.quantity > 255)
        {
            Console.WriteLine("Unable to add to bag. Invalid quantity. (Range 1 - 255) Aborting.");
            return;
        }

        // Increment bag size in save data
        PatchHexByte((byte)(bagSize + 1), offsets.bagSizeOffset);

        int offset = (offsets.bagSizeOffset + 0x01) + (0x02 * bagSize);
        byte[] hexBytes = { item.hexCode, item.getQuantityHex(), 0xFF };
        PatchHexBytes(hexBytes, offset);

    }


    public string GenerateGameReport()
    {
        StringBuilder sb = new StringBuilder();


        sb.AppendLine("-------------------");
        sb.AppendLine("Game Summary Report");
        sb.AppendLine("--------------------");
        sb.AppendLine();
        sb.AppendLine();
        sb.AppendLine($"{"Trainer Name: ",16} {GetTrainerName(),7}");
        sb.AppendLine();
        sb.AppendLine($"{"Pokemon Seen: ",16} {GetNumberSeen(),7:D3}");
        sb.AppendLine($"{"Pokemon Caught: ",16} {GetNumberOwned(),7:D3}");

        sb.AppendLine();

        Badges badges = GetBadges();

        sb.AppendLine(badges.getBadgesInfo(generation));

        sb.AppendLine("-----------");
        sb.AppendLine("Party Info:");
        sb.AppendLine("___________");
        sb.AppendLine();

        sb.AppendLine(partyPokemon.GetInfo());

        sb.AppendLine();
        sb.AppendLine(pcPokemon.GetPcPokemonInfo());

        sb.AppendLine();

        // sb.AppendLine("----------");
        // sb.AppendLine("Bag Items:");
        // sb.AppendLine("----------");
        // sb.AppendLine();


        sb.AppendLine(items.GetInfo());


        return sb.ToString();
    }

    public Party GetParty()
    {
        return partyPokemon;
    }

    private void UpdateChecksum(int checksum)
    {
        try
        {
            // Convert the hex string to bytes
            byte highByte = (byte)((checksum >> 8) & 0xFF);
            byte lowByte = (byte)(checksum & 0xFF);
            byte[] checksumBytes = new byte[] { highByte, lowByte};

            PatchHexBytes(checksumBytes, offsets.checksumLocation);


        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}