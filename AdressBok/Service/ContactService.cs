using AdressBok.Interfaces;
using AdressBok.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace AdressBok.Service;

public class ContactService
{
    private readonly FileService _fileService = new FileService(@"C:\Weddutveckling\CSharp\Adressbok\content.json");

    private List<Contact> _contactList = [];

    public void AddContactToList(IContact contact)
    {
        try
        {
            if (!_contactList.Any(x => x.Email == contact.Email))
            {
                _contactList.Add((Contact)contact);
                _fileService.SaveContentToFile(JsonConvert.SerializeObject(_contactList));
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
    }

    public bool RemoveContactFromList(string email)
    {

        try
        {
            var contactToRemove = _contactList.FirstOrDefault(c => c.Email == email);

            if (contactToRemove != null)
            {
                _contactList.Remove(contactToRemove);
                _fileService.SaveContentToFile(JsonConvert.SerializeObject(_contactList));
                return true;
            }

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;


    }

    public List<Contact> GetContactsFromList()
    {
        try
        {
            var content = _fileService.GetContentFromFile();
            if (!string.IsNullOrEmpty(content))
            {
                _contactList = JsonConvert.DeserializeObject<List<Contact>>(content)!;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return _contactList;
    }

    public Contact GetContactByEmail(string email)
    {
        try
        {
            var contact = _contactList.FirstOrDefault(c => c.Email == email);
            return contact;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null; // Returnera null om något går fel
        }
    }
}
