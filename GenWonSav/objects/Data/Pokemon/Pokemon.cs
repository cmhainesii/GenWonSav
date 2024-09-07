using System.Text;

internal struct IV
{
    internal ushort Attack;
    internal ushort Defense;
    internal ushort Speed;
    internal ushort SpecialAttack;
    internal ushort SpecialDefense;
    internal ushort HP;



}

internal struct Stats
{
    internal ushort Attack;
    internal ushort Defense;
    internal ushort SpecialAttack;
    internal ushort SpecialDefense;
    internal ushort Speed;
    internal ushort HP;

}



internal class Pokemon
{
    internal string name { get; set; }
    internal ushort level { get; set; }

    internal readonly IV IVs;
    internal readonly Stats Stats;

    internal string otName { get; set; }
    internal string nickname { get; set; }
    internal string type1 { get; set; }
    internal string type2 { get; set; }

    internal byte heldItem { get; set; }
    internal ushort generation { get; set; }

    // public Pokemon(string name, ushort level, IV ivs)
    // {
    //     this._name = name;
    //     this._level = level;
    //     this._ivs = ivs;
    //     this._otName = "Unknown";
    //     this._nickname = name;


    // }

    internal Pokemon(string name, ushort level, IV ivs, Stats stats, string otName, string nickname, string type1, string type2, ushort generation, byte heldItem = 0)
    {
        this.name = name;
        this.level = level;
        IVs = ivs;
        this.Stats = stats;
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
        }
        sb.AppendLine();
        sb.AppendLine($"{"",13}{"IV Data",7}{"",13}");
        sb.AppendLine($"{"HP:",12}{IVs.HP,14}");
        sb.AppendLine($"{"Attack:",12}{IVs.Attack,14}");
        sb.AppendLine($"{"Defense:",12}{IVs.Defense,14}");
        sb.AppendLine($"{"Special Atk:",12}{IVs.SpecialAttack,14}");
        sb.AppendLine($"{"Special Def:",12}{IVs.SpecialDefense,14}");
        sb.AppendLine($"{"Speed:",12}{IVs.Speed,14}");
        sb.AppendLine($"{"Score:",12}{GetIvScore(),14}");
        sb.AppendLine($"{"Percentile:",12}{getIvPercentile(),13}{"%",1}");
        
        sb.AppendLine();
        sb.AppendLine($"{"",12}{"Stats",5}{"",12}");
        sb.AppendLine($"{"HP:",12}{Stats.HP,14}");
        sb.AppendLine($"{"Attack:",12}{Stats.Attack,14}");
        sb.AppendLine($"{"Defense:",12}{Stats.Defense,14}");
        if (generation == 1)
        {
            sb.AppendLine($"{"Special:",12}{Stats.SpecialAttack,14}");
        }
        else
        {
            sb.AppendLine($"{"Special Atk:",12}{Stats.SpecialAttack,14}");
            sb.AppendLine($"{"Special Def:",12}{Stats.SpecialDefense,14}");
        }
        sb.AppendLine($"{"Speed:",12}{Stats.Speed,14}");
        sb.AppendLine($"{"Score:",12}{GetStatScore(),14}");
        sb.AppendLine();

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
        return (ushort)(this.IVs.HP + this.IVs.Attack + this.IVs.Defense + this.IVs.Speed + IVs.Attack + IVs.SpecialDefense);

    }

    public ushort GetStatScore()
    {
        return (ushort)(Stats.HP + Stats.Attack + Stats.Defense + Stats.Speed + Stats.SpecialAttack + Stats.SpecialDefense);
    }

    public double getIvPercentile()
    {
        return Math.Round(GetIvScore() / 90.0 * 100.0, 2);
    }





}