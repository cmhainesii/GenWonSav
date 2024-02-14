using System.Text;

public class Party
{
    private List<Pokemon> pokemonList;

    public Party(GameData gameData)
    {
        if (gameData.generation == 1) 
        {
            pokemonList = gameData.GetPartyPokemon();
        }
        else
        {
            pokemonList = new List<Pokemon>();
        }

        
    }

    public string GetInfo()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("Party Information:");
        sb.AppendLine();

        ushort count = 0;

        foreach(Pokemon current in pokemonList)
        {
            sb.AppendLine($"Party Pokemon #{++count}");
            sb.AppendLine();
            sb.AppendLine(current.GetInfo());   
        }

        return sb.ToString();

    }
}