using ContactsApp.Model;
using ContactsApp.Services;
using Xunit;

public class ContactServiceTests
{
    [Fact]
    public void Create_ShouldAddContactSuccessfully()
    {
        var service = new ContactService();
        var form = new ContactRegistrationForm
        {
            _FirstName = "test",
            _LastName = "test",
            _Email = "test.test@test.com",
            _Phone = "1234567890",
            _Address = "test address",
            _City = "test city",
            _Street = "test street",
            _PostalCode = "12345"
        };


        var result = service.Create(form);

        Assert.True(result);
        Assert.Single(service.GetAll());
    }

    [Fact]
    public void GetAll_ShouldReturnAllContacts()
    {
        // Arrange
        var service = new ContactService();
        service.ClearList();

        var form1 = new ContactRegistrationForm
        {
            _FirstName = "test",
            _LastName = "test",
            _Email = "test.test@test.com"
        };
        service.Create(form1);

        var form2 = new ContactRegistrationForm
        {
            _FirstName = "test2",
            _LastName = "test2",
            _Email = "test2.test2@test.com"
        };
        service.Create(form2);

        // Act
        var contacts = service.GetAll();

        // Assert
        Assert.Equal(2, contacts.Count());
    }
}
