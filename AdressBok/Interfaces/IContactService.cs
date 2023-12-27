
namespace AdressBok.Interfaces;

public interface IContactService
{
    public bool AddContactToList(IContact contact);
    IContact GetContactByEmail(string email);
    List<IContact> GetContactsFromList();
    bool RemoveContactFromList(string email);



}