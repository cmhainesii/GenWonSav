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
    internal string _name {get; set;}
    internal ushort _level {get; set;}
    
    internal IV _ivs {get; set;}

    internal string _otName {get; set;}
    internal string _nickname {get; set;}
    public string _type1 {get; set;}
    public string _type2 {get; set;}

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
        this._name = name;
        this._level = level;
        this._ivs = ivs;
        this._otName = otName;
        this._nickname = nickname;
        this._type1 = type;
        this._type2 = type2;
    }

    public string GetInfo()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{"Name:",9}{_name,14}");
        sb.AppendLine($"{"Level:",9}{_level,14}");
        sb.AppendLine();
        sb.AppendLine($"{"IVs:",9}");
        sb.AppendLine($"{"HP:",9}{_ivs.Hp,14}");
        sb.AppendLine($"{"Attack:",9}{_ivs.Attack,14}");
        sb.AppendLine($"{"Defense:",9}{_ivs.Defense,14}");
        sb.AppendLine($"{"Special:",9}{_ivs.Special,14}");
        sb.AppendLine($"{"Speed:",9}{_ivs.Speed,14}");
        sb.AppendLine($"{"OT Name:",9}{_otName,14}");
        sb.AppendLine($"{"Nickname:"}{_nickname,14}");
        sb.AppendLine($"{"Type:",9}{_type1,14}");
        if (_type1 != _type2)
        {
            sb.AppendLine($"{"Type2:",9}{_type2,14}");
        }
        

        return sb.ToString();
    }

    public override string ToString()
    {
        return _name;
    }





}