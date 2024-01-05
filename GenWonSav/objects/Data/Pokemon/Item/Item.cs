using System.Text;

public class Item
{
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

        sb.AppendLine($"Item Name: {itemName}");
        sb.AppendLine($"Qty: {quantity}");

        return sb.ToString();
    }
}