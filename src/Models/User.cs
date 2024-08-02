namespace Opcion1SaletGutierrez.src.Models;

public class User
{
    private int _memberNumber;

    private string _name;

    private string _contactInfo;

    public int MemberNumber
    {
        get { return _memberNumber; }
        set { _memberNumber = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string ContactInfo
    {
        get { return _contactInfo; }
        set { _contactInfo = value; }
    }
}
