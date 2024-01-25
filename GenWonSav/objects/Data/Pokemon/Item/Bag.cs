using System.Text;

public class Bag
{
    private List<Item> bagItems;
    public ushort count {get;}

    public Bag(List<Item> contents)
    {
        this.bagItems = contents;
        this.count = (ushort)bagItems.Count;
    }

    public string GetInfo()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("----------");
        sb.AppendLine("Bag Items:");
        sb.AppendLine("----------");
        sb.AppendLine();
        for(ushort i = 0; i < bagItems.Count; ++i)
        {
            sb.AppendLine($"{"Slot #:",10}{i + 1, 14}");
            sb.Append(bagItems[i].GetInfo());
            for(ushort j = 0; j < 24; ++j)
            {
                sb.Append("-");
            }
            sb.AppendLine();
        }

        return sb.ToString();
    }
}