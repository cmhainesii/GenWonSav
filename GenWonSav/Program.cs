using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using static HexFunctions;
class Program
{
    static void Main()
    {
        //GameData xferData;
        GameData gameData;
        try
        {
            // // Specify the file path
            // string filePath = "rat_race_final.sav";
            // xferData = new GameData(filePath);

            string filePath = "data.sav";
            gameData = new GameData(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return;
        }
        // Read all bytes from the file


        // int moneyOffset = 0x25F3;

        // byte[] newMoney = { 0x86, 0x75, 0x30 };

        // gameData.PatchHexBytes(newMoney, moneyOffset);



        // Xfer pokemon from another save code

        // try
        // {
        //     int start = GameData.partyFirstPokemonOffset + (3 * GameData.partyNextPokemonOffset);
        //     int end = start + 43;
        //     byte[] pokemonData = xferData.GetData(start, end);

        //     start = GameData.partyFirstOtNameOffset;
        //     end = start + 0x0A;
        //     byte[] pokemonOtName = gameData.GetData(start, end);

        //     start = GameData.partyFirstNickOffset + (GameData.otNickNextNameOffset * 3);
        //     end = start + 0x0A;
        //     byte[] pokemonName = xferData.GetData(start, end);

        //     start = GameData.partyFirstPokemonOffset + 0x0C;
        //     end = start + 0x01;
        //     byte[] otId = gameData.GetData(start, end);

        //     PokemonHexData ratData = new PokemonHexData(pokemonData, pokemonOtName, pokemonName, otId);
        //     gameData.AddPartyPokemon(ratData);
        // }
        // catch (ArgumentException ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }



        // int nameOffset = 0x2598;
        // StringBuilder name2 = new StringBuilder();
        // for (int i = 0; i < 11; ++i)
        // {
        //     byte currentByte = gameData.getData(nameOffset + i);
        //     if (currentByte == 0x50)
        //     {
        //         break;
        //     }
        //     name2.Append(TextEncoding.GetCharacter(currentByte));
        // }

        // Console.WriteLine($"File Character Name: {name2.ToString()}");

        // int rivalNameOffset = 0x25F6;
        // name2.Clear();

        // for (int i = 0; i < 11; ++i)
        // {
        //     byte currentByte = gameData.getData(rivalNameOffset + i);
        //     if (currentByte == 0x50)
        //     {
        //         break;
        //     }
        //     name2.Append(TextEncoding.GetCharacter(currentByte));
        // }

        // Console.WriteLine($"Rival Name: {name2.ToString()}");

        // Console.WriteLine($"Party Size: {gameData.getPartySize()}");

        // // Name pokemon in party:
        // for (ushort i = 1; i <= gameData.getPartySize(); ++i)
        // {
        //     Console.WriteLine($"{i}) {gameData.getPartyPokemonName(i)}");
        // }

        // List<Pokemon> myPokemon = gameData.GetPartyPokemon();

        // Console.WriteLine($"List Size: {myPokemon.Count}");
        // foreach (Pokemon current in myPokemon)
        // {
        //     Console.WriteLine(current.GetInfo());
        // }

        // int bagOffset = 0x25C9;

        // byte[] newItem = { 0x04, 0x63, 0x04, 0x63, 0x04, 0x63, 0xFF};

        // gameData.PatchHexBytes(newItem, bagOffset + 3);
        // gameData.PatchHexByte(0x04, bagOffset);

        





        // startOffset = 0x4000;
        // endOffset = 0x5A4B;

        // checksum = gameData.CalculateChecksum(startOffset, endOffset);
        // hexChecksum = (checksum & 0xFF).ToString("X2");
        // Console.WriteLine($"All Box Checksum: {hexChecksum}.");


        // startOffset = GameData.boxOneBegin;
        // endOffset = GameData.boxOneBegin + (GameData.nextBoxOffset - 0x01);
        // checksum = gameData.CalculateChecksum(startOffset, endOffset);
        // hexChecksum = (checksum & 0xFF).ToString("X2");
        // Console.WriteLine($"Box One Checksum: {hexChecksum}.");

        // List<Pokemon> boxPokemon = gameData.GetBoxPokemon(1);
        // ushort lineNumber = 1;
        // foreach (Pokemon current in boxPokemon)
        // {
        //     Console.WriteLine($"#{lineNumber++}");
        //     Console.WriteLine(current.GetInfo());
        // }

        // myPokemon.AddRange(boxPokemon);


        // boxPokemon = gameData.GetBoxPokemon(2);
        // lineNumber = 0;
        // foreach (Pokemon current in boxPokemon)
        // {
        //     Console.WriteLine($"#{lineNumber++}");
        //     Console.WriteLine(current.GetInfo());
        // }
        // myPokemon.AddRange(boxPokemon);
        // boxPokemon = gameData.GetBoxPokemon(3);
        // lineNumber = 0;
        // foreach (Pokemon current in boxPokemon)
        // {
        //     Console.WriteLine($"#{lineNumber++}");
        //     Console.WriteLine(current.GetInfo());
        // }
        // myPokemon.AddRange(boxPokemon);

        // GameData.writeCSV("rat_lottery.csv", myPokemon);

        List<Pokemon> partyPokemon = gameData.GetPartyPokemon();

        foreach (Pokemon pokemon in partyPokemon)
        {
            Console.WriteLine(pokemon.GetInfo());
        }




        // int lineNumber = 0;
        // foreach (Pokemon current in boxPokemon)
        // {
        //     Console.WriteLine($"#{++lineNumber}");
        //     Console.WriteLine(current.GetInfo());
        // }

        //GameData.WriteCSV("red_box.csv", boxPokemon);
        GameData.WriteCSV("red_party.csv", partyPokemon);

        gameData.changeRivalName("Dickwad");



        // Item newItem = new Item(ItemData.GetHexCode("Great Ball"), (ushort) 20, "Great Ball");
        // gameData.AddItemToBag(newItem);

        // Item anotherItem = new Item(ItemData.GetHexCode("TM07"), (ushort)255, "TM07");
        // gameData.AddItemToBag(anotherItem);

        

        Console.WriteLine($"Pokemon Owned: {gameData.GetNumberOwned()}");
        Console.WriteLine($"Pokemon Seen: {gameData.GetNumberSeen()}");
        Console.WriteLine($"Trainer Name: {gameData.GetTrainerName()}");
        Console.WriteLine($"Rival Name: {gameData.GetRivalName()}");
        byte[] encodedTextTexst = GameData.EncodeText("BLUE", 0x50);

        foreach (byte character in encodedTextTexst)
        {
            Console.Write($"{character:X2}");
        }
        
        Console.WriteLine();


        Badges badges = gameData.GetBadges();
        Console.WriteLine(badges.getBadgesInfo());

        uint money = gameData.GetMoney();
        Console.WriteLine($"Money from data: ${money}");
        byte[] moneyBytes = HexFunctions.ConvertIntToByteArray(money);
        foreach (byte current in moneyBytes)
        {
            Console.Write($"0x{current:X2} ");
        }
        Console.WriteLine();

        moneyBytes = HexFunctions.ConvertIntToByteArray(999999);
        foreach (byte current in moneyBytes)
        {
            Console.Write($"0x{current:X2} ");
        }
        Console.WriteLine();

        // Calculate the checksum
        try
        {
            int checksum = gameData.CalculateChecksum(GameData.checksumStartOffset, GameData.checksumEndOffset);
            // Get the least significant 2 hex digits of the result
            string hexChecksum = (checksum & 0xFF).ToString("X2");

            // Convert the hex string to bytes
            byte[] checksumBytes = new byte[] { Convert.ToByte(hexChecksum, 16) };

            gameData.PatchHexByte(checksumBytes[0], GameData.checksumLocationOffset);

            gameData.WriteToFile();

            // Print the hex checksum to the console
            Console.WriteLine("Checksum: 0x" + hexChecksum);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        uint testMoney = gameData.TestGetMoney();
        Console.WriteLine($"TestMoney: ₽{testMoney:N0}");
        Console.WriteLine();
        Console.WriteLine(gameData.GenerateGameReport());

        const string gameReportFilename = "GameSaveReport.txt";
        File.WriteAllText(gameReportFilename, gameData.GenerateGameReport());

        //List<Pokemon> boxSeven = gameData.GetBoxPokemon(7);


        Console.WriteLine($"{gameData.pcPokemon.GetPcPokemonInfo()}");
        Console.WriteLine($"Total Pokemon Stored in PC: {gameData.pcPokemon.count:D3}");

        Console.WriteLine(gameData.items.GetInfo());

        Console.WriteLine($"Number of bag items: {gameData.items.count}");

        Console.WriteLine(gameData.boxItems.GetInfo());
        Console.WriteLine($"Number of box items: {gameData.boxItems.count}");


    }
}