using System.Net;
using System.Reflection.Metadata.Ecma335;

public class GameData
{
    private byte[] fileData;
    private string fileName;

    const int partySizeOffset = 0x2F2C;
    const int partyFirstPokemonOffset = partySizeOffset + 0x08;  

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

    public byte getData(int offset) {
        return fileData[offset];
    }

    public void writeToFile() {
        File.WriteAllBytes(fileName, fileData);
    }

    public void changePartyPokemonOtId(int newID)
    {
        int idOffset = 0x2605;

        byte[] newId = HexFunctions.ConvertIntToHexBytes(54321);

        for (int i = 0; i < newId.Length; ++i)
        {
            fileData[idOffset + i] = newId[i];
        }

        int partyOffset = 0x2F2C;
        int firstPokemon = partyOffset + 0x08;
        int firstPokemonOtId = firstPokemon + 0x0C;

        Console.WriteLine("Total Pokemon in Party: " + fileData[partyOffset]);
        int currentOffset = firstPokemonOtId;
        for (int j = 0; j < fileData[partyOffset]; ++j)
        {
            PatchHexBytes(newId, currentOffset);
            currentOffset += 0x2C;
        }
    }

    public ushort getPartySize() {

        return (ushort)getData(partySizeOffset);
        
    }

    public string getPartyPokemonName(ushort num) {
        if (num <= 0 || num >= 7) {
            throw new ArgumentException("Invalid party index! Must be 1 - 6");
        }

        if (num > getPartySize()) {
            throw new ArgumentException($"Invalid party index. Exceeds party size of {getPartySize()}.");
        }

        return PokemonData.GetPokemonName(getData(partySizeOffset + num));
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
        
        
        for (ushort i = 1; i <= getPartySize(); ++i) {
            name = getPartyPokemonName(i);
            level = (ushort)getData(currentPokemonOffset + 0x21);
            ad = getData(currentPokemonOffset + 0x1B);
            ss = getData(currentPokemonOffset + 0x1C);
            attack = (ushort)(ad >> 4);
            defense = (ushort)(ad & 0x0F);
            speed = (ushort)(ss >> 4);
            special = (ushort)(ss & 0x0F);
            ivs = new IV
            {
                Hp = CalculateHpIv(attack, defense, special, speed),
                Attack = attack,
                Defense = defense,
                Speed = speed,
                Special = special
            };

            current = new Pokemon(name, level, ivs);
            partyPokemon.Add(current);
            currentPokemonOffset += 0x2C; // increment by 44 bytes to get to next party pokemon
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
}