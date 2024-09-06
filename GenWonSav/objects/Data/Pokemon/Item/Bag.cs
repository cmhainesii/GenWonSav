using System.Text;

public class Bag
{
    private List<Item> bagItems;
    private List<Item> ballsPocket;
    private List<Item> keyItemsPocket;
    private List<Item> tmPocket;
    public ushort itemCount {get; set;}
    public ushort ballsCount {get; set;}
    public ushort keyItemsCount {get; set;}
    public ushort tmCount {get; set;}

    public const int BAG_SIZE_BYTES = 0x2A;

    public Bag(List<Item> contents)
    {
        this.bagItems = contents;
        this.itemCount = (ushort)bagItems.Count;
        ballsPocket = new List<Item>();
        ballsCount = 0;
        keyItemsPocket = new List<Item>();
        keyItemsCount = 0;
        tmPocket = new List<Item>();
        tmCount = 0;
    }

    public Bag(List<Item> itemsPocket, List<Item> ballsPocket, List<Item> keyItems, List<Item> tms) {
        this.bagItems = itemsPocket;
        itemCount = (ushort)bagItems.Count;

        this.ballsPocket = ballsPocket;
        ballsCount = (ushort)ballsPocket.Count;

        this.keyItemsPocket = keyItems;
        keyItemsCount = (ushort)keyItemsPocket.Count;

        tmPocket = tms;
        tmCount = (ushort)tmPocket.Count;
    }

    // public static bool ValidateBagChecksum(byte[] data, byte checksum)
    // {
    //     byte checksumCalculation = 0;
    //     foreach(byte current in data)
    //     {
    //         checksumCalculation += current;
    //     }

    //     return checksum == checksumCalculation;

    // }

    // internal Bag(byte[] bagHex, ItemData itemData)
    // {
    //     this.bagItems = new List<Item>();
        
    //     if(bagHex.Length != BAG_SIZE_BYTES + 1) {
    //         this.itemCount = 0;
    //     }
    //     else
    //     {
    //         byte[] data = new byte[BAG_SIZE_BYTES];
    //         for(uint i = 0; i < BAG_SIZE_BYTES - 1; ++i)
    //         {
    //             data[i] = bagHex[i];
    //         }

    //         byte checksum = bagHex[BAG_SIZE_BYTES];
    //         if(ValidateBagChecksum(data, checksum))
    //         {
    //             Console.WriteLine("Checksum accepted.");
    //         }
    //         else
    //         {
    //             Console.WriteLine("Checksum invalid.");
    //             return;
    //         }

    //         ushort dataIndex = 0;
    //         this.itemCount = data[dataIndex++];

    //         while(data[dataIndex] != 0xFF)
    //         {
    //             bagItems.Add(new Item(data[dataIndex], data[dataIndex+1], itemData.GetName(data[dataIndex])));
    //             dataIndex += 2;
    //         }
    //     }
    // }

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

        

        if (ballsCount > 0) {
            sb.AppendLine();
            sb.AppendLine("Balls Pocket");
            sb.AppendLine();
            for(ushort i = 0; i < ballsCount; ++i)
            {
                sb.AppendLine($"{"Slot #:",10}{i + 1, 14}");
                sb.Append(ballsPocket[i].GetInfo());
                for(ushort j = 0; j < 24; ++j)
                {
                    sb.Append("-");
                }
                sb.AppendLine();
            }
        }
        if(keyItemsCount > 0) {
            sb.AppendLine();
            sb.AppendLine("Key Items Pocket");
            sb.AppendLine();
            for(ushort i = 0; i < keyItemsCount; ++i)
            {
                sb.AppendLine($"{"Slot #:",10}{i + 1, 14}");
                sb.Append(keyItemsPocket[i].GetInfo());
                for(ushort j = 0; j < 24; ++j)
                {
                    sb.Append("-");
                }
                sb.AppendLine();
            }
        }
        if(tmCount > 0) {
            ItemData itemData = new ItemData(2);
            sb.AppendLine();
            sb.AppendLine("TM/HM Pocket");
            sb.AppendLine();
            for(ushort i = 0; i < tmCount; ++i)
            {
                sb.AppendLine($"{"Slot #:",10}{i + 1, 14}");
                sb.Append(tmPocket[i].GetInfo());
                sb.AppendLine($"{"TM/HM:",10}{itemData.genTwoTMNames[(string)tmPocket[i].itemName], 14}");
                for(ushort j = 0; j < 24; ++j)
                {
                    sb.Append("-");
                }
                sb.AppendLine();
            }
        }

        return sb.ToString();
    }
    

    public void WriteToFile(string filename)
    {
        byte[] data = new byte[BAG_SIZE_BYTES + 1];
        ushort dataIndex = 0;
        byte checksum = 0;

        data[dataIndex++] = (byte)this.itemCount; // Write list count

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
        this.itemCount = 0;

        ballsPocket.Clear();
        ballsCount = 0;

        keyItemsPocket.Clear();
        keyItemsCount = 0;

        tmPocket.Clear();
        tmCount = 0;
    }

}