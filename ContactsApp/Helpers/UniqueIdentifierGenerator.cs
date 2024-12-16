namespace ContactsApp.Helpers;

public static class UniqueIdentifierGenerator
{
    public static string GenerateUniqueId()
    {
        try
        {
            return Guid.NewGuid().ToString();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null!;
        }

    }
}