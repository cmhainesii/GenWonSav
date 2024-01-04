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

        sb.AppendLine($"Name: {_name}");
        sb.AppendLine($"Level: {_level}");
        sb.AppendLine($"\nIVs:");
        sb.AppendLine($"HP: {_ivs.Hp}");
        sb.AppendLine($"Attack: {_ivs.Attack}");
        sb.AppendLine($"Defense: {_ivs.Defense}");
        sb.AppendLine($"Special: {_ivs.Special}");
        sb.AppendLine($"Speed: {_ivs.Speed}");
        sb.AppendLine($"OT Name: {_otName}");
        sb.AppendLine($"Nickname: {_nickname}");
        sb.AppendLine($"Type: {_type1}");
        if (_type1 != _type2)
        {
            sb.AppendLine($"Type2: {_type2}");
        }
        

        return sb.ToString();
    }

    
    
    

}