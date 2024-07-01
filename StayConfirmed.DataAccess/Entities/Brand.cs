namespace StayConfirmed.DataAccess.Entities;

public class Brand : BaseEntity
{
    public string Name { get; set; }
    public string Logo { get; set; }
    public ICollection<string> Emails { get; set; } = [];
    public int IdStakeholder { get; set; }
    public bool IdDefault { get; set; } // IsDefaultBrandForStakeholder

    public void AddEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return;
        }
        Emails.Add(email);
    }

    public void AddEmails(IEnumerable<string> emails)
    {
        foreach (var email in emails)
        {
            AddEmail(email);
        }
    }

    public void RemoveEmails()
    {
        Emails.Clear();
    }
}
