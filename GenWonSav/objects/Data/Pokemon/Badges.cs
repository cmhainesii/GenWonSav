using System.Security;
using System.Text;

public class Badges
{
    private bool[] badges;

    public Badges()
    {
        badges = new bool[8];
    }

    public Badges(bool[] values)
    {
        badges = new bool[8];
        for(ushort i = 0; i < 8; ++i)
        {
            badges[i] = values[i];
        }
    }

    public string getBadgesInfo(int generation)
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("Badge Status:");
        sb.AppendLine();
        sb.AppendLine($"Obtained {GetNumBadges():D1}/8 badges");
        sb.AppendLine();
        sb.AppendLine("Badges Obtained:");

        if(generation == 1)
        {

            if(badges[0])
            {
                sb.AppendLine("Boulder Badge");
            }
            if (badges[1])
            {
                sb.AppendLine("Cascade Badge");
            }
            if (badges[2])
            {
                sb.AppendLine("Thunder Badge");
            }
            if (badges[3])
            {
                sb.AppendLine("Rainbow Badge");
            }
            if (badges[4])
            {
                sb.AppendLine("Soul Badge");
            }
            if (badges[5])
            {
                sb.AppendLine("Marsh Badge");
            }
            if (badges[6])
            {
                sb.AppendLine("Volcano Badge");
            }
            if (badges[7])
            {
                sb.AppendLine("Earth Badge");
            }
        }
        else
        {
            if(badges[0])
            {
                sb.AppendLine("Zephyr Badge");
            }
            if(badges[1])
            {
                sb.AppendLine("Insect Badge");
            }
            if(badges[2])
            {
                sb.AppendLine("Plain Badge");
            }
            if(badges[3])
            {
                sb.AppendLine("Fog Badge");
            }
            if(badges[4])
            {
                sb.AppendLine("Storm Badge");
            }
            if(badges[5])
            {
                sb.AppendLine("Mineral Badge");
            }
            if(badges[6])
            {
                sb.AppendLine("Glacier Badge");
            }
            if(badges[7])
            {
                sb.AppendLine("Rising Badge");
            }
        }


        return sb.ToString();
    }

    public byte GetNumBadges()
    {
        byte sum = 0;

        foreach (bool badge in badges)
        {
            if (badge)
            {
                sum++;
            }
        }

        return sum;
    }

}