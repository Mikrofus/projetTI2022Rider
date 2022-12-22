namespace Domain;

public class User
{
    public int Id { get; set; }
    public string Pseudo { get; set; }
    public string Mail { get; set; }
    public string Pass{ get; set; } 
    
    public bool isPseudovalid()
    {
        const int MIN_LENGTH = 3;
        const int MAX_LENGTH = 25;
        if (Pseudo.Length < MIN_LENGTH || Pseudo.Length > MAX_LENGTH)
        {
            return false;
        }

        return true;
    } 
    
    public bool IsEmailValid()
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(Mail);
            return addr.Address == Mail;
        }
        catch
        {
            return false;
        }
    }
    public bool IsPasswordGood()
    {
        // Check papsword length
        if (Pass.Length < 8)
        {
            return false;
        }

        // Check for uppercase letters
        if (!Pass.Any(char.IsUpper))
        {
            return false;
        }

        // Check for lowercase letters
        if (!Pass.Any(char.IsLower))
        {
            return false;
        }

        // Check for digits
        if (!Pass.Any(char.IsDigit))
        {
            return false;
        }

        // Check for special characters
        if (!Pass.Any(char.IsSymbol))
        {
            return false;
        }

        return true;
    }

  }