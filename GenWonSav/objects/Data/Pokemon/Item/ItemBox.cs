using System.Text;
using System.Transactions;

public class ItemBox
{

    private const int BAG_SIZE_BYTES = 0x2A;
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


    public void WriteToFile(string filename)
    {
        byte[] data = new byte[BAG_SIZE_BYTES];
        ushort dataIndex = 0;

        data[dataIndex++] = (byte)this.count; // Write list count

        foreach(Item current in items) // Write list entires
        {
            data[dataIndex++] = current.hexCode;            // Item index
            data[dataIndex++] = current.getQuantityHex();   // Quantity
        }

        data[dataIndex] = 0xFF; // List terminator

        File.WriteAllBytes(filename, data);
    }


}