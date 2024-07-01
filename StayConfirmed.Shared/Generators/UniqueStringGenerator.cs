namespace StayConfirmed.Shared.Generators;

public static class UniqueStringGenerator
{
    public static string GenerateUniqueString()
    {
        long milliseconds = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        string combined = milliseconds.ToString() + Guid.NewGuid().ToString("N");
        byte[] combinedBytes = System.Text.Encoding.UTF8.GetBytes(combined);
        string base64String = Convert.ToBase64String(combinedBytes);
        string uniqueString = base64String.Replace("=", "").Replace("+", "").Replace("/", "").Substring(0, 20);

        return uniqueString;
    }
}