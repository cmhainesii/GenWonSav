using System.Text;

public class Bag
{
    private List<Item> bagItems;
    public ushort count {get; set;}

    public const int BAG_SIZE_BYTES = 0x2A;

    public Bag(List<Item> contents)
    {
        this.bagItems = contents;
        this.count = (ushort)bagItems.Count;
    }

    public static bool ValidateBagChecksum(byte[] data, byte checksum)
    {
        byte checksumCalculation = 0;
        foreach(byte current in data)
        {
            checksumCalculation += current;
        }

        return checksum == checksumCalculation;

    }

    public Bag(byte[] bagHex)
    {
        this.bagItems = new List<Item>();
        
        if(bagHex.Length != BAG_SIZE_BYTES + 1) {
            this.count = 0;
        }
        else
        {
            byte[] data = new byte[BAG_SIZE_BYTES];
            for(uint i = 0; i < BAG_SIZE_BYTES - 1; ++i)
            {
                data[i] = bagHex[i];
            }

            byte checksum = bagHex[BAG_SIZE_BYTES];
            if(ValidateBagChecksum(data, checksum))
            {
                Console.WriteLine("Checksum accepted.");
            }
            else
            {
                Console.WriteLine("Checksum invalid.");
                return;
            }

            ushort dataIndex = 0;
            this.count = data[dataIndex++];

            while(data[dataIndex] != 0xFF)
            {
                bagItems.Add(new Item(data[dataIndex], data[dataIndex+1], ItemData.GetName(data[dataIndex])));
                dataIndex += 2;
            }
        }
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

        if(bagItems.Count == 0) {
            sb.AppendLine("Bag is empty.");
        }

        return sb.ToString();
    }
    

    public void WriteToFile(string filename)
    {
        byte[] data = new byte[BAG_SIZE_BYTES + 1];
        ushort dataIndex = 0;
        byte checksum = 0;

        data[dataIndex++] = (byte)this.count; // Write list count

        foreach(Item current in bagItems) // Write list entires
        {
            data[dataIndex++] = current.hexCode;            // Item index
            data[dataIndex++] = current.getQuantityHex();   // Quantity
        }

        data[dataIndex] = 0xFF; // List terminator

        // Calculate checksum
        foreach (byte current in data)
        {
            checksum += current;
        }

        // Insert checksum:
        data[data.Length - 1] = checksum;
        Console.WriteLine($"Checksum: 0x{checksum:X2}");

        File.WriteAllBytes(filename, data);
    }

    public void ClearBag()
    {
        bagItems.Clear();
        this.count = 0;
    }

}