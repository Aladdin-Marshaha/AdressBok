using AdressBok.Interfaces;
using AdressBok.Models;
using AdressBok.Service;

namespace AdressBok.Tests;

public class ContactService_Tests
{
    [Fact]
    public void AddContactToList_ShouldAddOneContactToList_ThenReturenTrue()
    {
        // Arrange
        IContact contact = new Contact();
        IContactService contactService = new ContactService();


        // Act

        bool result = contactService.AddContactToList(contact);

        // Assert

        Assert.True(result);
    }

    [Fact]
    
    public void Remove()
    {
        IContact contact = new Contact();
        IContactService contactService = new ContactService();

        bool result = contactService.RemoveContactFromList(contact.Email);

        Assert.True(result);

    }
}
