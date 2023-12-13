namespace AdressBok.Interfaces;

public interface IContactService
{
    IServiceResult AddContactToList(IContact contact);
    IServiceResult GetContactFromList();
    bool RemoveContact(string email);
}