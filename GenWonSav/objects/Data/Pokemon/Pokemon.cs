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
    internal string name {get; set;}
    internal ushort level {get; set;}
    
    internal IV ivs {get; set;}

    internal string otName {get; set;}
    internal string nickname {get; set;}
    public string type1 {get; set;}
    public string type2 {get; set;}

    // public Pokemon(string name, ushort level, IV ivs)
    // {
    //     this._name = name;
    //     this._level = level;
    //     this._ivs = ivs;
    //     this._otName = "Unknown";
    //     this._nickname = name;
        

    // }

    public Pokemon(string name, ushort level, IV ivs, string otName, string nickname, string type, string type2)
    {
        this.name = name;
        this.level = level;
        this.ivs = ivs;
        this.otName = otName;
        this.nickname = nickname;
        this.type1 = type;
        this.type2 = type2;
    }

    public string GetInfo()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{"Name:",9}{name,14}");
        sb.AppendLine($"{"Level:",9}{level,14}");
        sb.AppendLine();
        sb.AppendLine($"{"IVs:",9}");
        sb.AppendLine($"{"HP:",9}{ivs.Hp,14}");
        sb.AppendLine($"{"Attack:",9}{ivs.Attack,14}");
        sb.AppendLine($"{"Defense:",9}{ivs.Defense,14}");
        sb.AppendLine($"{"Special:",9}{ivs.Special,14}");
        sb.AppendLine($"{"Speed:",9}{ivs.Speed,14}");
        sb.AppendLine($"{"Score:",9}{this.GetIvScore(),14}");
        sb.AppendLine($"{"OT Name:",9}{otName,14}");
        sb.AppendLine($"{"Nickname:"}{nickname,14}");
        sb.AppendLine($"{"Type:",9}{type1,14}");
        if (type1 != type2)
        {
            sb.AppendLine($"{"Type2:",9}{type2,14}");
        }
        

        return sb.ToString();
    }

    public override string ToString()
    {
        return name;
    }

    public ushort GetIvScore()
    {
        return (ushort)(this.ivs.Hp + this.ivs.Attack + this.ivs.Defense + this.ivs.Speed + this.ivs.Special);
    }





}