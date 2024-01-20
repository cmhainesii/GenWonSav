using System.Security;
using System.Text;

public class Badges
{
    private bool[] badges;

    public Badges(bool boulder, bool cascade, bool thunder, bool rainbow,
        bool soul, bool marsh, bool volcano, bool earth)
    {
        badges = new bool[8];

        this.badges[0] = boulder;
        this.badges[1] = cascade;
        this.badges[2] = thunder;
        this.badges[3] = rainbow;
        this.badges[4] = soul;
        this.badges[5] = marsh;
        this.badges[6] = volcano;
        this.badges[7] = earth;
    }

    public Badges()
    {
        badges = new bool[8];
    }

    public string getBadgesInfo()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("Badge Status:");
        sb.AppendLine();
        sb.AppendLine($"Obtained {GetNumBadges():D1}/8 badges");
        sb.AppendLine();
        sb.AppendLine("Badges Obtained:");

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

        return sb.ToString();
    }

    public ushort GetNumBadges()
    {
        ushort sum = 0;

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