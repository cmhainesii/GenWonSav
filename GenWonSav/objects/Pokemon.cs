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
    private string _name {get; set;}
    private ushort _level {get; set;}
    
    private IV _ivs {get; set;}

    public Pokemon(string name, ushort level, IV ivs)
    {
        this._name = name;
        this._level = level;
        this._ivs = ivs;

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

        return sb.ToString();
    }

    

    

}