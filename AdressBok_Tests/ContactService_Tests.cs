using AdressBok.Interfaces;
using AdressBok.Models;
using AdressBok.Service;
using Moq;

namespace AdressBok.Tests;

public class ContactService_Tests
{
    [Fact]
    public void AddContactToList_ShouldAddOneContactToList_ThenReturenTrue()
    {
        // Arrange
        IContact contact = new Contact();
        var mockFileService = new Mock<IFileService>();
        mockFileService.Setup(x=>x.SaveContentToFile(It.IsAny<string>())).Returns(true);

        IContactService contactService = new ContactService(mockFileService.Object);

        // Act

        bool result = contactService.AddContactToList(contact);

        // Assert

        Assert.True(result);
    }

    [Fact]
    
    public void RemoveContactFromList()
    {
        IContact contact = new Contact();
        var mockFileService = new Mock<IFileService>();
        mockFileService.Setup(x => x.SaveContentToFile(It.IsAny<string>())).Returns(true);

        IContactService contactService = new ContactService(mockFileService.Object);

        bool result = contactService.RemoveContactFromList(contact.Email);

        Assert.True(result);

    }
}
