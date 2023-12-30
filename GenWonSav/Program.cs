using System.Runtime.CompilerServices;
using System.Text;
using static HexFunctions;
class Program
{
    static void Main()
    {
        GameData gameData;
        try
        {
            // Specify the file path
            string filePath = "data.sav";
            gameData = new GameData(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return;
        }
        // Read all bytes from the file


        int moneyOffset = 0x25F3;

        byte[] newMoney = { 0x86, 0x75, 0x30 };

        gameData.PatchHexBytes(newMoney, moneyOffset);


        // Check if converter works
        int newIDHere = 54321;
        byte[] newBytes = HexFunctions.ConvertIntToHexBytes(newIDHere);
        Console.WriteLine($"1: 0x{newBytes[0]:X2}");
        Console.WriteLine($"2: 0x{newBytes[1]:X2}");
        Console.WriteLine();


        string name = "ASH";
        byte[] nameHex = new byte[3];
        for (int i = 0; i < 3; ++i)
        {
            nameHex[i] = TextEncoding.GetHexValue(name.ElementAt(i));
        }
        Console.WriteLine($"1: 0x{nameHex[0]:X2}");
        Console.WriteLine($"2: 0x{nameHex[1]:X2}");
        Console.WriteLine($"3: 0x{nameHex[2]:X2}");

        int nameOffset = 0x2598;
        StringBuilder name2 = new StringBuilder();
        for (int i = 0; i < 11; ++i)
        {
            byte currentByte = gameData.getData(nameOffset + i);
            if (currentByte == 0x50)
            {
                break;
            }
            name2.Append(TextEncoding.GetCharacter(currentByte));
        }

        Console.WriteLine($"File Character Name: {name2.ToString()}");

        int rivalNameOffset = 0x25F6;
        name2.Clear();

        for (int i = 0; i < 11; ++i)
        {
            byte currentByte = gameData.getData(rivalNameOffset + i);
            if (currentByte == 0x50)
            {
                break;
            }
            name2.Append(TextEncoding.GetCharacter(currentByte));
        }

        Console.WriteLine($"Rival Name: {name2.ToString()}");

        Console.WriteLine($"Party Size: {gameData.getPartySize()}");
        
        // Name pokemon in party:
        for (ushort i = 1; i <= gameData.getPartySize(); ++i)
        {
            Console.WriteLine($"{i}) {gameData.getPartyPokemonName(i)}");
        }

        List<Pokemon> myPokemon = gameData.GetPartyPokemon();

        Console.WriteLine($"List Size: {myPokemon.Count}");
        foreach (Pokemon current in myPokemon)
        {
            Console.WriteLine(current.GetInfo());
        }

        // Define the range for checksum calculation
        int startOffset = 0x2598;
        int endOffset = 0x3522;

        // Calculate the checksum
        int checksum = gameData.CalculateChecksum(startOffset, endOffset);

        // Get the least significant 2 hex digits of the result
        string hexChecksum = (checksum & 0xFF).ToString("X2");

        // Convert the hex string to bytes
        byte[] checksumBytes = new byte[] { Convert.ToByte(hexChecksum, 16) };

        int checksumOffset = 0x3523;

        //fileData[checksumOffset] = checksumBytes[0];
        gameData.PatchHexByte(checksumBytes[0], checksumOffset);

        //File.WriteAllBytes(filePath, fileData);
        gameData.writeToFile();

        // Print the hex checksum to the console
        Console.WriteLine("Checksum: 0x" + hexChecksum);
    }
    


}