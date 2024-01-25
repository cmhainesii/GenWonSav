using System.Text;

public class ItemBox
{
    private List<Item> items;
    public ushort count;

    public ItemBox(List<Item> contents)
    {
        this.items = contents;
        this.count = (ushort)contents.Count;
    }

    public string GetInfo()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("----------");
        sb.AppendLine("Box Items:");
        sb.AppendLine("----------");
        sb.AppendLine();

        for (ushort i = 0; i < items.Count; ++i)
        {
            sb.AppendLine($"{"Slot #:",10}{i + 1,14}");
            sb.Append(items[i].GetInfo());
            for (ushort j = 0; j < 24; ++j)
            {
                sb.Append("-");
            }
            sb.AppendLine();
        }

        return sb.ToString();
    }
}