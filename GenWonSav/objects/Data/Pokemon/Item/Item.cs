using System.Text;

public class Item
{
    private const int BAG_SIZE_BYTES = 0x2A;
    public byte hexCode {get;}
    public ushort quantity {get;}
    public string itemName {get;}

    public Item(byte hexCode, ushort quantity, string itemName)
    {
        this.hexCode = hexCode;
        this.quantity = quantity;
        this.itemName = itemName;
    }

    public byte getQuantityHex()
    {
        return (byte)quantity;
    }

    public string GetInfo()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{"Item Name:",10}{itemName,14}");
        sb.AppendLine($"{"Qty:",10}{quantity,14}");

        return sb.ToString();
    }
}