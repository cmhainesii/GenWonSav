using System.Text;

public class PokemonPC
{
    private Box[] boxes;
    public int count {get;}

    public PokemonPC(GameData gameData)
    {
        boxes = new Box[12];

        
        

        for(ushort i = 0; i < 12; ++i)
        {
            boxes[i] = new Box(gameData, (ushort)(i + 1));
        }

        int sum = 0;
        foreach(Box current in boxes)
        {
            sum += current.boxCount;
        }
        count = sum;
        
    }

    public string GetPcPokemonInfo()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("-----------------------");
        sb.AppendLine("PC Pokemon Information:");
        sb.AppendLine("-----------------------");
        sb.AppendLine();
        for (ushort i = 0; i < 12; ++i)
        {
            sb.AppendLine($"Pokemon Box #{i + 1:D2}");
            sb.AppendLine();
            if (boxes[i].boxCount == 0)
            {
                sb.AppendLine("Box is Empty");
                sb.AppendLine();
                continue;
            }

            sb.AppendLine(boxes[i].GetInfo());
        }

        return sb.ToString();
    }
}