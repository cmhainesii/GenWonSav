public static class PokemonUtil
{
    public static string GCSTimeResetPassword(string playerName, int id, int money)
    {
        int nameValue = 0;
        int moneyValue = 0;
        int idValue = 0;

        for(int i = 0; i < 5 && i < playerName.Count(); ++i)
        {
            nameValue += TextEncoding.GetHexValue(playerName[i]);
        }

        while (money > 65535) {
            money -= 65535;
        }
        Console.WriteLine($"Money: {money}");

        moneyValue = (money % 256) + (money / 256);

        while(id > 65535)
        {
            id -= 65535;
        }
        idValue = (id % 256) + (id / 256);
 
        Console.WriteLine($"MV: {moneyValue}");
        Console.WriteLine($"NV: {nameValue}");
        Console.WriteLine($"IV: {idValue}");

        return (nameValue + moneyValue + idValue).ToString("D5");
        
    }
}