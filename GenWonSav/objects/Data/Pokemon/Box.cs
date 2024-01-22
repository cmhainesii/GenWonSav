using System.Text;

public class Box
{
    private List<Pokemon> pokemonList;


    public Box(GameData gameData, ushort boxNumber = 1)
    {
        if (boxNumber < 1 || boxNumber > 6) {
            boxNumber = 1;
        }

        pokemonList = gameData.GetBoxPokemon(boxNumber);
    }

    public string GetInfo()
    {
        StringBuilder sb = new StringBuilder();
        ushort count = 0;

        foreach (Pokemon current in pokemonList)
        {
            sb.AppendLine("Box Pokemon Information:");
            sb.AppendLine();
            sb.AppendLine($"Box Pokemon #{++count}:");
            sb.AppendLine();
            sb.AppendLine(current.GetInfo());
        }

        return sb.ToString();
    }
}