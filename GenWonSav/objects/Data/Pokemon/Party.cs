using System.Text;

public class Party
{
    private List<Pokemon> pokemonList;

    public Party(GameData gameData)
    {
        if (gameData.generation == 1) 
        {
            pokemonList = gameData.GetGen1PartyPokemon();
        }
        else
        {
            pokemonList = gameData.GetGen2PartyPokemon();
        }

        
    }

    public string GetInfo()
    {
        StringBuilder sb = new StringBuilder();
        string notFancyLine = "----------------------------------------";

        sb.AppendLine("Party Information:");
        sb.AppendLine();
        sb.AppendLine(notFancyLine);
        

        ushort count = 0;

        foreach(Pokemon current in pokemonList)
        {
            sb.AppendLine($"Party Pokemon #{++count}");
            sb.AppendLine();
            sb.AppendLine(current.GetInfo());   
            sb.AppendLine(notFancyLine);
        }

        return sb.ToString();

    }
}