using System.Text;

internal struct IV
{
    internal ushort Attack;
    internal ushort Defense;
    internal ushort Speed;
    internal ushort Special;
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

internal struct EVs
{
    internal ushort HP;
    internal ushort Attack;
    internal ushort Defense;
    internal ushort Speed;
    internal ushort Special;
}



internal class Pokemon
{
    internal string name { get; set; }
    internal ushort level { get; set; }

    internal readonly IV ivs;
    internal readonly Stats stats;
    internal readonly EVs evs;

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

    internal Pokemon(string name, ushort level, IV ivs, Stats stats, EVs evs, string otName, string nickname, string type1, string type2, ushort generation, byte heldItem = 0)
    {
        this.name = name;
        this.level = level;
        this.ivs = ivs;
        this.stats = stats;
        this.evs = evs;
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

        sb.AppendLine($"{"Name:",16}{name,14}");
        sb.AppendLine($"{"Level:",16}{level,14}");
        if (generation != 1)
        {
            ItemData itemData = new ItemData(2);
            if (heldItem != 0)
            {
                sb.AppendLine($"{"Held Item:",16}{itemData.GetName(heldItem),14}");
            }
            else
            {
                sb.AppendLine($"{"Held Item:",16}{"None",14}");
            }
        }
        sb.AppendLine();
        sb.AppendLine($"{"",16}{"IV Data",7}{"",13}");
        sb.AppendLine($"{"HP:",16}{ivs.HP,14}");
        sb.AppendLine($"{"Attack:",16}{ivs.Attack,14}");
        sb.AppendLine($"{"Defense:",16}{ivs.Defense,14}");
        sb.AppendLine($"{"Special:",16}{ivs.Special,14}");
        sb.AppendLine($"{"Speed:",16}{ivs.Speed,14}");
        sb.AppendLine($"{"Score:",16}{GetIvScore(),14}");
        sb.AppendLine($"{"Percentile:",16}{getIvPercentile(),13}{"%",1}");
        
        if(GetStatScore() > 0)
        {
            sb.AppendLine();
            sb.AppendLine($"{"",16}{"Stats",5}{"",12}");
            sb.AppendLine($"{"HP:",16}{stats.HP,14}");
            sb.AppendLine($"{"Attack:",16}{stats.Attack,14}");
            sb.AppendLine($"{"Defense:",16}{stats.Defense,14}");
            sb.AppendLine($"{"Special Attack:",16}{stats.SpecialAttack,14}");
            sb.AppendLine($"{"Special Defense:",16}{stats.SpecialDefense,14}");
            sb.AppendLine($"{"Speed:",16}{stats.Speed,14}");
            sb.AppendLine($"{"Score:",16}{GetStatScore(),14}");
        }

        if(GetEvScore() > 0) 
        {
            sb.AppendLine();
            sb.AppendLine($"{"",16}{"EV Data",7}{"",15}");
            sb.AppendLine($"{"HP:",16}{evs.HP,14:N0}");
            sb.AppendLine($"{"Attack:",16}{evs.Attack,14:N0}");
            sb.AppendLine($"{"Defense:",16}{evs.Defense,14:N0}");
            sb.AppendLine($"{"Special:",16}{evs.Special,14:N0}");
            sb.AppendLine($"{"Speed:",16}{evs.Speed,14:N0}");
            sb.AppendLine($"{"Score:",16}{GetEvScore(),14:N0}");
            sb.AppendLine();
        }
        else
        {
            sb.AppendLine();
            sb.AppendLine($"{"All Evs:",16}{"0",14}");
            sb.AppendLine();
        }

        sb.AppendLine($"{"OT Name:",16}{otName,14}");
        sb.AppendLine($"{"Nickname:",16}{nickname,14}");
        sb.AppendLine($"{"Type:",16}{type1,14}");
        if (type1 != type2)
        {
            sb.AppendLine($"{"Type2:",16}{type2,14}");
        }


        return sb.ToString();
    }

    public override string ToString()
    {
        return name;
    }

    public ushort GetIvScore()
    {
        return (ushort)(this.ivs.HP + this.ivs.Attack + this.ivs.Defense + this.ivs.Speed + (ivs.Special * 2));

    }

    public ushort GetEvScore()
    {
        return (ushort)(evs.HP + evs.Attack + evs.Defense + evs.Speed + (evs.Special * 2));
    }

    public ushort GetStatScore()
    {
        return (ushort)(stats.HP + stats.Attack + stats.Defense + stats.Speed + stats.SpecialAttack + stats.SpecialDefense);
    }

    public double getIvPercentile()
    {
        return Math.Round(GetIvScore() / 90.0 * 100.0, 2);
    }





}