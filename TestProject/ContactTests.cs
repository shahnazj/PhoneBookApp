using ContactsApp.Model;
using Xunit;
using System.IO;

public class ContactTests
{
    [Fact]
    public void PrintContact_ShouldOutputCorrectFormat()
    {

        var contact = new Contact
        {
            _Id = "1",
            _FirstName = "test",
            _LastName = "test",
            _Email = "test.test@test.com"
        };

        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        contact.printContact();

        var output = stringWriter.ToString();
        Assert.Contains("Id:            1", output);
        Assert.Contains("Name:          test", output);
        Assert.Contains("Last Name:     test", output);
        Assert.Contains("Email:         test.test@test.com", output);
    }
}
