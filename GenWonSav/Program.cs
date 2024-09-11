class Program
{

    static void Main(string[] args)
    {
        string fileName = "data5.sav";

        if(args.Length > 0) {
            fileName = args[0];
        }
        List<GameData> saveCollection = new List<GameData>();
        GameData gameData;  

        gameData = new GameData(fileName);
        saveCollection.Add(gameData);

        String trainerName = gameData.GetTrainerName();
        String rivalName = gameData.GetRivalName();

        Console.WriteLine($"Generation: {gameData.generation}");
        if(gameData.generation != 1) {
            Console.WriteLine($"Crystal: {gameData.crystal}");
        }
        Console.WriteLine($"Trainer Name: {trainerName}");
        Console.WriteLine($"Rival Name: {rivalName}");

        Console.WriteLine($"Money: ${gameData.GetMoney():N0}");
        Console.WriteLine($"Owned: {gameData.GetNumberOwned()}");
        Console.WriteLine($"Seen: {gameData.GetNumberSeen()}");
        Console.WriteLine($"Party Size: {gameData.GetPartySize()}");


        for (ushort index = 1; index <= gameData.GetPartySize(); ++index)
        {
            Console.WriteLine($"{index}) {gameData.GetPartyPokemonName(index)}");
        }
        Console.WriteLine();

        Console.WriteLine(gameData.partyPokemon.GetInfo());

        gameData.SetGender(1);
        byte[] money = HexFunctions.IntToMoneyByte(867530);
        gameData.PatchHexBytes(money, gameData.offsets.moneyOffset);
        gameData.WriteToFile();
        Console.WriteLine($"Money ${gameData.GetMoney():N0}");
        

        // gameData.WriteCSV("gen2test.csv", gameData.GetGen2PartyPokemon());
        // for(ushort index = 1; index <= 12; ++index~)
        // {
        //     gameData.WriteCSV($"gen2boxtest{index}.csv", gameData.GetBoxPokemon(index));
        // }


        //Console.WriteLine(gameData.GetBadges().getBadgesInfo(gameData.generation));
        


        //Console.WriteLine(gameData.pcPokemon.GetPcPokemonInfo());


        // Console.WriteLine($"{gameData.items.GetInfo()}");
        // byte[] newMoney = HexFunctions.IntToMoneyByte(987654);
        // gameData.PatchHexBytes(newMoney, gameData.offsets.moneyOffset);
        //gameData.WriteToFile();
        // string hexChecksum = (checksum & 0xFF).ToString("X2");
        //Console.WriteLine($"Calculated Checksum: {gameData.CalculateChecksum()}");
    }
}


    // static void Main()
    // {
    //     //GameData xferData;
    //     GameData gameData;
    //     GameData oneData;
    //     GameData twoData;
    //     try
    //     {
    //         // // Specify the file path
    //         // string filePath = "rat_race_final.sav";
    //         // xferData = new GameData(filePath);

    //         string filePath = "data.sav";
    //         gameData = new GameData(filePath);

    //         filePath = "oneData.sav";
    //         oneData = new GameData(filePath);

    //         filePath = "twoData.sav";
    //         twoData = new GameData(filePath);

    //     }
    //     catch (Exception ex)
    //     {
    //         Console.WriteLine("Error: " + ex.Message);
    //         return;
    //     }
    //     // Read all bytes from the file


    //     // int moneyOffset = 0x25F3;

    //     // byte[] newMoney = { 0x86, 0x75, 0x30 };

    //     // gameData.PatchHexBytes(newMoney, moneyOffset);



    //     // Xfer pokemon from another save code

    //     // try
    //     // {
    //     //     int start = GameData.partyFirstPokemonOffset + (3 * GameData.partyNextPokemonOffset);
    //     //     int end = start + 43;
    //     //     byte[] pokemonData = xferData.GetData(start, end);

    //     //     start = GameData.partyFirstOtNameOffset;
    //     //     end = start + 0x0A;
    //     //     byte[] pokemonOtName = gameData.GetData(start, end);

    //     //     start = GameData.partyFirstNickOffset + (GameData.otNickNextNameOffset * 3);
    //     //     end = start + 0x0A;
    //     //     byte[] pokemonName = xferData.GetData(start, end);

    //     //     start = GameData.partyFirstPokemonOffset + 0x0C;
    //     //     end = start + 0x01;
    //     //     byte[] otId = gameData.GetData(start, end);

    //     //     PokemonHexData ratData = new PokemonHexData(pokemonData, pokemonOtName, pokemonName, otId);
    //     //     gameData.AddPartyPokemon(ratData);
    //     // }
    //     // catch (ArgumentException ex)
    //     // {
    //     //     Console.WriteLine(ex.Message);
    //     // }



    //     // int nameOffset = 0x2598;
    //     // StringBuilder name2 = new StringBuilder();
    //     // for (int i = 0; i < 11; ++i)
    //     // {
    //     //     byte currentByte = gameData.getData(nameOffset + i);
    //     //     if (currentByte == 0x50)
    //     //     {
    //     //         break;
    //     //     }
    //     //     name2.Append(TextEncoding.GetCharacter(currentByte));
    //     // }

    //     // Console.WriteLine($"File Character Name: {name2.ToString()}");

    //     // int rivalNameOffset = 0x25F6;
    //     // name2.Clear();

    //     // for (int i = 0; i < 11; ++i)
    //     // {
    //     //     byte currentByte = gameData.getData(rivalNameOffset + i);
    //     //     if (currentByte == 0x50)
    //     //     {
    //     //         break;
    //     //     }
    //     //     name2.Append(TextEncoding.GetCharacter(currentByte));
    //     // }

    //     // Console.WriteLine($"Rival Name: {name2.ToString()}");

    //     // Console.WriteLine($"Party Size: {gameData.getPartySize()}");

    //     // // Name pokemon in party:
    //     // for (ushort i = 1; i <= gameData.getPartySize(); ++i)
    //     // {
    //     //     Console.WriteLine($"{i}) {gameData.getPartyPokemonName(i)}");
    //     // }

    //     // List<Pokemon> myPokemon = gameData.GetPartyPokemon();

    //     // Console.WriteLine($"List Size: {myPokemon.Count}");
    //     // foreach (Pokemon current in myPokemon)
    //     // {
    //     //     Console.WriteLine(current.GetInfo());
    //     // }

    //     // int bagOffset = 0x25C9;

    //     // byte[] newItem = { 0x04, 0x63, 0x04, 0x63, 0x04, 0x63, 0xFF};

    //     // gameData.PatchHexBytes(newItem, bagOffset + 3);
    //     // gameData.PatchHexByte(0x04, bagOffset);







    //     // startOffset = 0x4000;
    //     // endOffset = 0x5A4B;

    //     // checksum = gameData.CalculateChecksum(startOffset, endOffset);
    //     // hexChecksum = (checksum & 0xFF).ToString("X2");
    //     // Console.WriteLine($"All Box Checksum: {hexChecksum}.");


    //     // startOffset = GameData.boxOneBegin;
    //     // endOffset = GameData.boxOneBegin + (GameData.nextBoxOffset - 0x01);
    //     // checksum = gameData.CalculateChecksum(startOffset, endOffset);
    //     // hexChecksum = (checksum & 0xFF).ToString("X2");
    //     // Console.WriteLine($"Box One Checksum: {hexChecksum}.");

    //     // List<Pokemon> boxPokemon = gameData.GetBoxPokemon(1);
    //     // ushort lineNumber = 1;
    //     // foreach (Pokemon current in boxPokemon)
    //     // {
    //     //     Console.WriteLine($"#{lineNumber++}");
    //     //     Console.WriteLine(current.GetInfo());
    //     // }

    //     // myPokemon.AddRange(boxPokemon);


    //     // boxPokemon = gameData.GetBoxPokemon(2);
    //     // lineNumber = 0;
    //     // foreach (Pokemon current in boxPokemon)
    //     // {
    //     //     Console.WriteLine($"#{lineNumber++}");
    //     //     Console.WriteLine(current.GetInfo());
    //     // }
    //     // myPokemon.AddRange(boxPokemon);
    //     // boxPokemon = gameData.GetBoxPokemon(3);
    //     // lineNumber = 0;
    //     // foreach (Pokemon current in boxPokemon)
    //     // {
    //     //     Console.WriteLine($"#{lineNumber++}");
    //     //     Console.WriteLine(current.GetInfo());
    //     // }
    //     // myPokemon.AddRange(boxPokemon);

    //     // GameData.writeCSV("rat_lottery.csv", myPokemon);

    //     List<Pokemon> partyPokemon = gameData.GetPartyPokemon();

    //     foreach (Pokemon pokemon in partyPokemon)
    //     {
    //         Console.WriteLine(pokemon.GetInfo());
    //     }




    //     // int lineNumber = 0;
    //     // foreach (Pokemon current in boxPokemon)
    //     // {
    //     //     Console.WriteLine($"#{++lineNumber}");
    //     //     Console.WriteLine(current.GetInfo());
    //     // }

    //     //GameData.WriteCSV("red_box.csv", boxPokemon);
    //     GameData.WriteCSV("red_party.csv", partyPokemon);

    //     gameData.ChangeRivalName("Dickwad");




    //     // Item newItem = new Item(ItemData.GetHexCode("Great Ball"), (ushort) 20, "Great Ball");
    //     // gameData.AddItemToBag(newItem);

    //     // Item anotherItem = new Item(ItemData.GetHexCode("TM07"), (ushort)255, "TM07");
    //     // gameData.AddItemToBag(anotherItem);



    //     Console.WriteLine($"Pokemon Owned: {gameData.GetNumberOwned()}");
    //     Console.WriteLine($"Pokemon Seen: {gameData.GetNumberSeen()}");
    //     Console.WriteLine($"Trainer Name: {gameData.GetTrainerName()}");
    //     Console.WriteLine($"Rival Name: {gameData.GetRivalName()}");
    //     byte[] encodedTextTexst = GameData.EncodeText("BLUE", 0x50);

    //     foreach (byte character in encodedTextTexst)
    //     {
    //         Console.Write($"{character:X2}");
    //     }

    //     Console.WriteLine();


    //     Badges badges = gameData.GetBadges();
    //     Console.WriteLine(badges.getBadgesInfo());

    //     uint money = gameData.GetMoney();
    //     Console.WriteLine($"Money from data: ${money}");
    //     byte[] moneyBytes = HexFunctions.ConvertIntToByteArray(money);
    //     foreach (byte current in moneyBytes)
    //     {
    //         Console.Write($"0x{current:X2} ");
    //     }
    //     Console.WriteLine();

    //     moneyBytes = HexFunctions.ConvertIntToByteArray(999999);
    //     foreach (byte current in moneyBytes)
    //     {
    //         Console.Write($"0x{current:X2} ");
    //     }
    //     Console.WriteLine();

    //     //gameData.EmptyBag();

    //     // Calculate the checksum
    //     // try
    //     // {
    //     //     int checksum = gameData.CalculateChecksum(GameData.checksumStartOffset, GameData.checksumEndOffset);
    //     //     // Get the least significant 2 hex digits of the result
    //     //     string hexChecksum = (checksum & 0xFF).ToString("X2");

    //     //     // Convert the hex string to bytes
    //     //     byte[] checksumBytes = new byte[] { Convert.ToByte(hexChecksum, 16) };

    //     //     gameData.PatchHexByte(checksumBytes[0], GameData.checksumLocationOffset);

    //     //     gameData.WriteToFile();

    //     //     // Print the hex checksum to the console
    //     //     Console.WriteLine("Checksum: 0x" + hexChecksum);
    //     // }
    //     // catch (ArgumentException ex)
    //     // {`
    //     //     Console.WriteLine($"Error: {ex.Message}");
    //     // }
    //     gameData.WriteToFile();

    //     // uint testMoney = gameData.TestGetMoney();
    //     // Console.WriteLine($"TestMoney: ₽{testMoney:N0}");        
    //     // Console.WriteLine();
    //     // Console.WriteLine(gameData.GenerateGameReport());

    //     // const string gameReportFilename = "GameSaveReport.txt";
    //     // File.WriteAllText(gameReportFilename, gameData.GenerateGameReport());

    //     //List<Pokemon> boxSeven = gameData.GetBoxPokemon(7);


    //     // Console.WriteLine($"{gameData.pcPokemon.GetPcPokemonInfo()}");
    //     // Console.WriteLine($"Total Pokemon Stored in PC: {gameData.pcPokemon.count:D3}");

    //     // Console.WriteLine(gameData.items.GetInfo());

    //     // Console.WriteLine($"Number of bag items: {gameData.items.count}");

    //     // Console.WriteLine(gameData.boxItems.GetInfo());
    //     // Console.WriteLine($"Number of box items: {gameData.boxItems.count}");


    //     // string? name;
    //     // int id;
    //     // int moneyInput;
    //     // do
    //     // {
    //     //     Console.Write("Player Name: ");
    //     //     name = Console.ReadLine();

    //     //     if (string.IsNullOrEmpty(name))
    //     //     {
    //     //         Console.WriteLine("Error pasring name. Try again.");
    //     //     }
    //     // } while (string.IsNullOrEmpty(name));

    //     // Console.Write("Trainer ID: ");
    //     // while(!int.TryParse(Console.ReadLine(), out id))
    //     // {
    //     //     Console.WriteLine("Invalid input. Please enter a valid ID number.");
    //     // }

    //     // Console.Write("Money: ");
    //     // while(!int.TryParse(Console.ReadLine(), out moneyInput))
    //     // {
    //     //     Console.WriteLine("Invalid input. Please enter a valid amount of money.");
    //     // }

    //     // string password = PokemonUtil.GCSTimeResetPassword(name, id, moneyInput);
    //     // Console.WriteLine($"Time Reset Password: {password}");


    //     // Check for gen 1 data:
    //     // Further testing needed but it appears gen 1 data byte array length is 32768
    //     // and gen 2 data byte array length is 32816
    //     if (oneData.GetDataSize() == 32768)
    //     {
    //         Console.WriteLine("oneData.sav is generation 1.");
    //     }
    //     else
    //     {
    //         Console.WriteLine("oneData.sav is generation 2.");
    //     }

    //     if(twoData.GetDataSize() == 32768)
    //     {
    //         Console.WriteLine("twoData.sav is generation 1.");
    //     }
    //     else
    //     {
    //         Console.WriteLine("twoData.sav is generation 2.");
    //     }




    //     // gameData.items.WriteToFile("bank_01.dat");
    //     // gameData.items.WriteToFile("bank_02.dat");


    //     // byte[] bankData = File.ReadAllBytes("bank_01.dat");
    //     // if(bankData.Length == 0x2A) {
    //     //     Console.WriteLine("Data size appears to be valid. Proceeding.");
    //     // }

    //     // gameData.PatchHexBytes(bankData, GameData.bagSizeOffset);
    //     // gameData.WriteToFile();


    //     // gameData.EmptyBag();


    //     // gameData.WriteToFile();

    //     //gameData.items.WriteToFile("test_bank.dat");
    //     byte[] testData = File.ReadAllBytes("test_bank.dat");
    //     if(testData.Length == 0x2B) {
    //         Console.WriteLine("Crude check ok.");

    //         byte[] data = new byte[Bag.BAG_SIZE_BYTES];
    //         for(uint i = 0; i < Bag.BAG_SIZE_BYTES; ++i)
    //         {
    //             data[i] = testData[i];
    //         }
    //         byte checksum = testData[Bag.BAG_SIZE_BYTES];

    //         // Verify checksum is valid
    //         if(!Bag.ValidateBagChecksum(data, checksum))
    //         {
    //             Console.WriteLine("Bag checksum invalid. Aborting.");
    //         }
    //         else
    //         {
    //             Console.WriteLine("Bag checksum validated. Patching hex bytes.");
    //             gameData.EmptyBag();
    //             gameData.PatchHexBytes(data, GameData.bagSizeOffset);
    //         }
    //     }


    //     GameData blue = new GameData("blue.sav");
    //     GameData.WriteCSV("blue_party.csv", blue.GetPartyPokemon());



    //     // GameData red1, red2, yellow, silver, crystal;
    //     // red1 = new GameData("red1.sav");
    //     // red2 = new GameData("red2.sav");
    //     // yellow = new GameData("yellow.sav");
    //     // silver = new GameData("silver.sav");
    //     // crystal = new GameData("crystal.sav");

    //     // List<GameData> testData = new List<GameData>();
    //     // testData.Add(red1);
    //     // testData.Add(red2);
    //     // testData.Add(yellow);
    //     // testData.Add(silver);
    //     // testData.Add(crystal);

    //     // foreach(GameData current in testData)
    //     // {
    //     //     string generation;
    //     //     if (current.generation == 1)
    //     //     {
    //     //         generation = "gen1";
    //     //     }
    //     //     else
    //     //     {
    //     //         generation = "gen2";
    //     //     }
    //     //     Console.WriteLine($"Name: {current.fileName} Generation: {generation}");

    //     //     // Console.WriteLine(red2.GenerateGameReport());
    //     // }

    //     Console.WriteLine($"Length: {gameData.GetDataSize()}");
