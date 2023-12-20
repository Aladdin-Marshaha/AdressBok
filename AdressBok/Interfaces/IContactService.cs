namespace AdressBok.Interfaces;

public interface IContactService
{
    public bool AddContactToList(IContact contact);
    bool RemoveContactFromList(string email);

}