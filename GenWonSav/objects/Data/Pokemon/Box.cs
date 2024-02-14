using System.Text;

public class Box
{
    private List<Pokemon> pokemonList;
    internal ushort boxNumber {get;}
    internal ushort boxCount {get;}


    public Box(GameData gameData, ushort boxNumber)
    {
        if (boxNumber < 1 || boxNumber > 12) {
            boxNumber = 1;
        }

        boxCount = gameData.GetBoxSize(boxNumber);
        if(boxCount == 255)
        {
            boxCount = 0;
        }
        if (boxCount > 0)
        {
            pokemonList = gameData.GetBoxPokemon(boxNumber);
        }
        else
        {
            pokemonList = new List<Pokemon>();
        }

        this.boxNumber = boxNumber;
    }

    public string GetInfo()
    {
        StringBuilder sb = new StringBuilder();
        ushort count = 0;

        foreach (Pokemon current in pokemonList)
        {
            sb.AppendLine($"Slot #{++count}:");
            sb.AppendLine();
            sb.AppendLine(current.GetInfo());
        }

        return sb.ToString();
    }
}