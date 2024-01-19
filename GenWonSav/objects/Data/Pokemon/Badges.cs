using System.Text;

public class Badges
{
    public bool boulder { get; set; }
    public bool cascade { get; set; }
    public bool thunder { get; set; }
    public bool rainbow { get; set; }
    public bool soul { get; set; }
    public bool marsh { get; set; }
    public bool volcano { get; set; }
    public bool earth { get; set; }

    public Badges(bool boulder, bool cascade, bool thunder, bool rainbow,
        bool soul, bool marsh, bool volcano, bool earth)
    {
        this.boulder = boulder;
        this.cascade = cascade;
        this.thunder = thunder;
        this.rainbow = rainbow;
        this.soul = soul;
        this.marsh = marsh;
        this.volcano = volcano;
        this.earth = earth;
    }

    public string getBadgesInfo()
    {
        StringBuilder sb = new StringBuilder();

        if(boulder)
        {
            sb.AppendLine("Boulder Badge");
        }
        if (cascade)
        {
            sb.AppendLine("Cascade Badge");
        }
        if (thunder)
        {
            sb.AppendLine("Thunder Badge");
        }
        if (rainbow)
        {
            sb.AppendLine("Rainbow Badge");
        }
        if (soul)
        {
            sb.AppendLine("Soul Badge");
        }
        if (marsh)
        {
            sb.AppendLine("Marsh Badge");
        }
        if (volcano)
        {
            sb.AppendLine("Volcano Badge");
        }
        if (earth)
        {
            sb.AppendLine("Earth Badge");
        }

        return sb.ToString();
    }

}