using ContactsApp.Helpers;
using Xunit;

public class UniqueIdentifierGeneratorTests
{
    [Fact]
    public void GenerateUniqueId_ShouldReturnUniqueString()
    {
        //Arrange
        string id1;
        string id2;
        string id3;
        //Act
        id1 = UniqueIdentifierGenerator.GenerateUniqueId();
        id2 = UniqueIdentifierGenerator.GenerateUniqueId();
        id3 = UniqueIdentifierGenerator.GenerateUniqueId();

        //Assert
        Assert.NotNull(id1);
        Assert.NotNull(id2);
        Assert.NotNull(id3);
        Assert.NotEqual(id1, id2);
        Assert.NotEqual(id1, id3);
        Assert.NotEqual(id2, id3);
    }
    
}
