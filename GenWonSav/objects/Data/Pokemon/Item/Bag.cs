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
            sb.AppendLine(bagItems[i].GetInfo());
            sb.AppendLine();
        }

        return sb.ToString();
    }
}