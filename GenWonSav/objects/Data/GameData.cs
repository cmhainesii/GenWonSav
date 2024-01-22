using System.Text;
using System.Xml.XPath;

public class GameData
{
    private byte[] fileData;
    private string fileName;

    public const int partySizeOffset = 0x2F2C;
    public const int boxOneBegin = 0x4000;
    public const int boxSizeToFirstPokemonOffset = 0x16;
    public const int boxOneFirstPokemon = boxOneBegin + boxSizeToFirstPokemonOffset;
    public const int nextBoxOffset = 0x462;
    public const int nextBoxPokemonOffset = 0x21;
    public const int boxOtNameOffset = 0x2AA;
    public const int boxNicknameOffset = 0x386;
    public const int otNickNextNameOffset = 0x0B;
    public const int partySizeToFirstOffset = 0x08;
    public const int partySizeToFirstOtOffset = 0x110;
    public const int partySizeToFirstNickOffset = 0x152;
    public const int currentBoxDataBegin = 0x30C0;
    public const int currentlySetBoxOffset = 0x284C;
    internal const int partyFirstPokemonOffset = partySizeOffset + partySizeToFirstOffset;
    internal const int partyFirstOtNameOffset = partySizeOffset + partySizeToFirstOtOffset;
    internal const int partyFirstNickOffset = partySizeOffset + partySizeToFirstNickOffset;
    internal const int partyNextPokemonOffset = 0x2C;
    internal const int partyOtIdOffset = 0x0C;

    internal const int bagSizeOffset = 0x25C9;
    internal const int bagFirstItemOffset = bagSizeOffset + 0x01;

    internal const int ownedOffset = 0x25A3;

    internal const int seenOffset = 0x25B6;

    internal const int ownedSeenSize = 0x13;

    internal const int trainerNameOffset = 0x2598;
    internal const int trainerNameSize = 0x0B;

    internal const int rivalNameOffset = 0x25F6;

    internal const int badgesOffset = 0x2602;

    internal const int moneyOffset = 0x25F3;
    internal const int moneyOffsetEnd = moneyOffset + 0x02;
    internal const int checksumStartOffset = 0x2598;
    internal const int  checksumEndOffset = 0x3522;
    internal const int checksumLocationOffset = 0x3523;

    public GameData(string fileName)
    {
        fileData = File.ReadAllBytes(fileName);
        this.fileName = fileName;
    }

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

    public void PatchHexByte(byte newData, int offset)
    {
        fileData[offset] = newData;
    }

    public int CalculateChecksum(int startOffset, int endOffset)
    {
        if (startOffset < 0 || endOffset >= fileData.Length || startOffset > endOffset)
        {
            throw new ArgumentException("Invalid start or end offset.");
        }

        int checksum = 0;

        // Iterate through the specified range and calculate the checksum
        for (int i = startOffset; i <= endOffset; i++)
        {
            checksum += fileData[i];
        }

        return ~checksum;
    }

    public byte GetData(int offset)
    {
        if (offset < 0 || offset >= fileData.Length)
        {
            throw new ArgumentException("Invalid offset provided. Aborting data retrevial.");
        }
        return fileData[offset];
    }

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

    public void WriteToFile()
    {
        File.WriteAllBytes(fileName, fileData);
    }

    public string GetTrainerName()
    {
        return GetEncodedText(trainerNameOffset, 0x50, 11);
    }

    public string GetRivalName()
    {
        return GetEncodedText(rivalNameOffset, 0x50, 11);
    }

    public void changeRivalName(string name)
    {
        if (name.Length > 7 || name.Length <= 0)
        {
            Console.WriteLine("Error: Name must be between 1 and 7 characters.");
            return;
        }

        byte[] encodedName = EncodeText(name, 0x50);
        if (encodedName.Length > 11)
        {
            Console.WriteLine("Error: Encoded name text too long.");
            return;
        }
        PatchHexBytes(encodedName, rivalNameOffset);
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
        bool boulder = false;
        bool cascade = false;
        bool thunder = false;
        bool rainbow = false;
        bool soul = false;
        bool marsh = false;
        bool volcano = false;
        bool earth = false;

        byte data = fileData[badgesOffset];
        if ((data & (1 << 0)) != 0)
        {
            boulder = true;
        }
        if ((data & (1 << 1)) != 0)
        {
            cascade = true;
        }
        if ((data & (1 << 2)) != 0)
        {
            thunder = true;
        }
        if ((data & (1 << 3)) != 0)
        {
            rainbow = true;
        }
        if ((data & (1 << 4)) != 0)
        {
            soul = true;
        }
        if ((data & (1 << 5)) != 0)
        {
            marsh = true;
        }
        if ((data & (1 << 6)) != 0)
        {
            volcano = true;
        }
        if ((data & (1 << 7)) != 0)
        {
            earth = true;
        }
        Badges badges = new Badges(boulder, cascade, thunder, rainbow,
            soul, marsh, volcano, earth);

        return badges;


    }

    public uint GetMoney()
    {
        uint result = 0;     
        int high, low;   
        int count = 0;
        byte[] money = GetData(moneyOffset, moneyOffset + 0x02);    
        byte current = money[count++];

        high = current >> 4;
        low = current & 0xF;
        result += (uint)(100000 * high);
        result += (uint)(10000 * low);

        current = money[count++];
        high = current >> 4;
        low = current & 0xF;
        result += (uint)(1000 * high);
        result += (uint)(100 * low);

        current = money[count];
        high = current >> 4;
        low = current & 0xF;
        result += (uint)(10 * high);
        result += (uint)(1 * low);

        return result;
    }

    private int DecodeBCD(byte bcdByte)
    {
        return (bcdByte >> 4) * 10 + (bcdByte & 0xF);
    }

    public uint TestGetMoney()
    {
        byte[] money = GetData(moneyOffset, moneyOffsetEnd);

        return (uint)(DecodeBCD(money[0]) * 10000 + DecodeBCD(money[1]) * 100 + DecodeBCD(money[2]) * 1);
    }


    public ushort GetNumberOwned()
    {
        ushort sum = 0;
        for (int i = ownedOffset; i <  ownedOffset + ownedSeenSize; ++i)
        {
            sum += getSumBits(fileData[i]);
        }

        return sum;
    }

    public ushort GetNumberSeen()
    {
        ushort sum = 0;
        for (int i = seenOffset; i < seenOffset + ownedSeenSize; ++i)
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
            if((input & (1 << i)) != 0)
            {
                count++;
            }
        }

        return count;
    }

    public ushort GetPartySize()
    {

        return (ushort)GetData(partySizeOffset);

    }

    public ushort GetBoxSize(ushort boxNum)
    {
        if ((GetData(currentlySetBoxOffset) & 0x7F) + 1 == boxNum)
        {
            return (ushort)GetData(currentBoxDataBegin);
        }
        else
        {
            return (ushort)GetData(boxOneBegin + ((boxNum - 1) * nextBoxOffset));
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
            string result = PokemonData.GetPokemonName(GetData(partySizeOffset + num));
            return result;
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return "Undefined";
        }
    }


    public List<Pokemon> GetBoxPokemon(ushort boxNumber)
    {
        List<Pokemon> boxPokemon = new List<Pokemon>();
        Pokemon current;
        string name;
        ushort level;
        byte ad, ss;
        ushort attack, defense, speed, special;
        IV ivs;
        int currentBoxOffset;
        int currentPokemonOffset;
        int otNameOffset;
        int nickNameOffset;
        string otName;
        string nickname;
        string type;
        string type2;
        if ((GetData(currentlySetBoxOffset) & 0x7F) + 1 == boxNumber)
        {
            currentBoxOffset = currentBoxDataBegin;
            currentPokemonOffset = currentBoxOffset + boxSizeToFirstPokemonOffset;
        }
        else
        {
            currentBoxOffset = boxOneBegin + ((boxNumber - 1) * nextBoxOffset);
            currentPokemonOffset = currentBoxOffset + boxSizeToFirstPokemonOffset;
        }

        switch (boxNumber)
        {
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
                for (ushort i = 1; i <= GetBoxSize(boxNumber); ++i)
                {

                    
                    name = PokemonData.GetPokemonName(GetData(currentPokemonOffset));
                    level = (ushort)GetData(currentPokemonOffset + 0x03);
                    ad = GetData(currentPokemonOffset + 0x1B);
                    ss = GetData(currentPokemonOffset + 0x1C);
                    attack = (ushort)(ad >> 4);
                    defense = (ushort)(ad & 0x0F);
                    speed = (ushort)(ss >> 4);
                    special = (ushort)(ss & 0x0F);
                    type = TypeData.GetName(GetData(currentPokemonOffset + 0x05));
                    type2 = TypeData.GetName(GetData(currentPokemonOffset + 0x06));

                    ivs = new IV
                    {
                        Hp = CalculateHpIv(attack, defense, special, speed),
                        Attack = attack,
                        Defense = defense,
                        Speed = speed,
                        Special = special
                    };

                    // Get OT name
                    
                    otNameOffset = currentBoxOffset + boxOtNameOffset + (otNickNextNameOffset * (i - 1));
                    otName = GetEncodedText(otNameOffset, 0x50, 11);

                    nickNameOffset = currentBoxOffset + boxNicknameOffset + (otNickNextNameOffset * (i - 1));
                    nickname = GetEncodedText(nickNameOffset, 0x50, 11);

                    current = new Pokemon(name, level, ivs, otName, nickname, type, type2);
                    boxPokemon.Add(current);
                    currentPokemonOffset += nextBoxPokemonOffset;
                    //otName.Clear();

                }
                break;

        }

        return boxPokemon;
    }

    public List<Pokemon> GetPartyPokemon()
    {
        List<Pokemon> partyPokemon = new List<Pokemon>();
        Pokemon current;
        string name;
        ushort level;
        byte ad;
        byte ss;
        ushort attack;
        ushort defense;
        ushort speed;
        ushort special;
        IV ivs;
        int currentPokemonOffset = partyFirstPokemonOffset;
        string otName;
        string nickname;
        string type;
        string type2;
        int otNameOffset;
        int nickOffset;
    



        for (ushort i = 1; i <= GetPartySize(); ++i)
        {
            try
            {
                name = GetPartyPokemonName(i);
                level = (ushort)GetData(currentPokemonOffset + 0x21);
                ad = GetData(currentPokemonOffset + 0x1B);
                ss = GetData(currentPokemonOffset + 0x1C);
                attack = (ushort)(ad >> 4);
                defense = (ushort)(ad & 0x0F);
                speed = (ushort)(ss >> 4);
                special = (ushort)(ss & 0x0F);
                type = TypeData.GetName(GetData(currentPokemonOffset + 0x05));
                type2 = TypeData.GetName(GetData(currentPokemonOffset + 0x06));
                ivs = new IV
                {
                    Hp = CalculateHpIv(attack, defense, special, speed),
                    Attack = attack,
                    Defense = defense,
                    Speed = speed,
                    Special = special
                };

                otNameOffset = partyFirstOtNameOffset + (otNickNextNameOffset * (i - 1));
                otName = GetEncodedText(otNameOffset, 0x50, 11);

                nickOffset = partyFirstNickOffset + (otNickNextNameOffset * (i - 1));
                nickname = GetEncodedText(nickOffset, 0x50, 11);

                current = new Pokemon(name, level, ivs, otName, nickname, type, type2);
                partyPokemon.Add(current);
                currentPokemonOffset += partyNextPokemonOffset; // increment by 44 bytes to get to next party pokemon
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
        int insertOffset = partyFirstPokemonOffset + (partyNextPokemonOffset * (slotNumber - 1));
        PatchHexBytes(data.data, insertOffset);

        PatchHexByte((byte)(partySize + 1), partySizeOffset);
        PatchHexByte(data.data[0], partySizeOffset + slotNumber);

        // Null terminator after party size (0xFF)
        PatchHexByte(0xFF, partySizeOffset + slotNumber + 1);

        insertOffset = partyFirstOtNameOffset + (otNickNextNameOffset * (slotNumber - 1));
        PatchHexBytes(data.otName, insertOffset);

        insertOffset = partyFirstNickOffset + (otNickNextNameOffset * (slotNumber - 1));
        PatchHexBytes(data.nickname, insertOffset);

        insertOffset = partyFirstPokemonOffset + (partyNextPokemonOffset * (slotNumber - 1)) + partyOtIdOffset;
        PatchHexBytes(data.otId, insertOffset);


    }

    public static void WriteCSV(string filename, List<Pokemon> pokemon)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            // Write the header row
            writer.WriteLine("name,level,hp,attack,defense,special,speed,ot name,nickname");

            foreach (Pokemon current in pokemon)
            {
                writer.WriteLine($"{current._name},{current._level}," +
                $"{current._ivs.Hp},{current._ivs.Attack},{current._ivs.Defense}," +
                $"{current._ivs.Special},{current._ivs.Speed},{current._otName},{current._nickname}");
            }
        }
        Console.WriteLine("CSV File created.");
    }


    public static byte[] EncodeText(string text, byte terminator)
    {
        byte[] encodedText = new byte[text.Length + 1];
        for(int i = 0; i < text.Length; ++i)
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

    public List<Item> GetBagItems()
    {
        List<Item> items = new List<Item>();
        try
        {
            ushort bagQty = (ushort)GetData(bagSizeOffset);
            int currentOffset = bagFirstItemOffset;
            byte itemHexCode;
            byte itemQty;
            string itemName;
            Item currentItem;
            
            for (ushort i = 1; i <= 20; i++)
            {
                if (GetData(currentOffset) == 0xFF)
                {
                    break;
                }
                itemHexCode = GetData(currentOffset);
                itemQty = GetData(currentOffset + 0x01);
                itemName = ItemData.GetName(itemHexCode);
                currentItem = new Item(itemHexCode, itemQty, itemName);
                items.Add(currentItem);
                currentOffset += 0x02;
            }

            return items;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        return items;
    }

    public void AddItemToBag(Item item)
    {
        ushort bagSize = (ushort)GetData(bagSizeOffset);

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
        PatchHexByte((byte)(bagSize + 1), bagSizeOffset);

        int offset = bagFirstItemOffset + (0x02 * bagSize);
        byte[] hexBytes = { item.hexCode, item.getQuantityHex(), 0xFF};
        PatchHexBytes(hexBytes, offset);
        
    }


    public string GenerateGameReport()
    {
        StringBuilder sb = new StringBuilder();


        sb.AppendLine("Game Summary Report");
        sb.AppendLine();
        sb.AppendLine("--------------------");
        sb.AppendLine();
        sb.AppendLine();
        sb.AppendLine($"{"Trainer Name: ",16} {GetTrainerName(),7}");
        sb.AppendLine();
        sb.AppendLine($"{"Pokemon Seen: ",16} {GetNumberSeen(),7:D3}");
        sb.AppendLine($"{"Pokemon Caught: ",16} {GetNumberOwned(),7:D3}");

        sb.AppendLine();
        
        Badges badges = GetBadges();

        sb.AppendLine(badges.getBadgesInfo());

        sb.AppendLine("Party Info:");
        sb.AppendLine();

        List<Pokemon> myParty = GetPartyPokemon();
        ushort count = 0;
        foreach(Pokemon current in myParty)
        {
            sb.AppendLine($"Party Pokemon #{++count}:");
            sb.AppendLine();
            sb.AppendLine(current.GetInfo());
        }

        

        return sb.ToString();
    }
}