using System.Text;

public struct IV
{
    public ushort Attack;
    public ushort Defense;
    public ushort Speed;
    public ushort Special;
    public ushort Hp;



}

public class Pokemon
{
    internal string name { get; set; }
    internal ushort level { get; set; }

    internal IV ivs { get; set; }

    internal string otName { get; set; }
    internal string nickname { get; set; }
    internal string type1 { get; set; }
    internal string type2 { get; set; }

    public byte heldItem { get; set; }
    public ushort generation { get; set; }

    // public Pokemon(string name, ushort level, IV ivs)
    // {
    //     this._name = name;
    //     this._level = level;
    //     this._ivs = ivs;
    //     this._otName = "Unknown";
    //     this._nickname = name;


    // }

    internal Pokemon(string name, ushort level, IV ivs, string otName, string nickname, string type1, string type2, ushort generation, byte heldItem = 0)
    {
        this.name = name;
        this.level = level;
        this.ivs = ivs;
        this.otName = otName;
        this.nickname = nickname;
        this.type1 = type1;
        this.type2 = type2;
        this.generation = generation;
        if (generation != 1)
        {
            this.heldItem = heldItem;
        }
    }

    public string GetInfo()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{"Name:",12}{name,14}");
        sb.AppendLine($"{"Level:",12}{level,14}");
        if (generation != 1)
        {
            ItemData itemData = new ItemData(2);
            if (heldItem != 0)
            {
                sb.AppendLine($"{"Held Item:",12}{itemData.GetName(heldItem),14}");
            }
            else
            {
                sb.AppendLine($"{"Held Item:",12}{"None",14}");
            }
            sb.AppendLine();
            sb.AppendLine($"{"",13}{"IV Data",7}{"",13}");
            sb.AppendLine($"{"HP:",12}{ivs.Hp,14}");
            sb.AppendLine($"{"Attack:",12}{ivs.Attack,14}");
            sb.AppendLine($"{"Defense:",12}{ivs.Defense,14}");
            sb.AppendLine($"{"Special:",12}{ivs.Special,14}");
            sb.AppendLine($"{"Speed:",12}{ivs.Speed,14}");
            sb.AppendLine($"{"Score:",12}{this.GetIvScore(),14}");

        }
        sb.AppendLine($"{"OT Name:",12}{otName,14}");
        sb.AppendLine($"{"Nickname:",12}{nickname,14}");
        sb.AppendLine($"{"Type:",12}{type1,14}");
        if (type1 != type2)
        {
            sb.AppendLine($"{"Type2:",12}{type2,14}");
        }


        return sb.ToString();
    }

    public override string ToString()
    {
        return name;
    }

    public ushort GetIvScore()
    {
        if (generation == 1)
        {
            return (ushort)(this.ivs.Hp + this.ivs.Attack + this.ivs.Defense + this.ivs.Speed + ivs.Special);
        }

        else
        {
            return (ushort)(this.ivs.Hp + this.ivs.Attack + this.ivs.Defense + this.ivs.Speed + (ivs.Special * 2));
        }

    }





}