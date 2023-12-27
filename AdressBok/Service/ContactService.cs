using AdressBok.Interfaces;
using AdressBok.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace AdressBok.Service;

public class ContactService : IContactService
{
    private readonly IFileService _fileService ;

    private List<IContact> _contactList = [];

    public ContactService(IFileService fileService)
    {
        _fileService = fileService;
    }

    /// <summary>
    /// Lägger till contact till contact list
    /// </summary>
    /// <param name="contact"> contact typ av IContact </param>
    /// <returns> Retunerar true om den lyckas annars retunerar false </returns>
    public bool AddContactToList(IContact contact)
    {
        try
        {
            if (!_contactList.Any(x => x.Email == contact.Email))
            {
                _contactList.Add((IContact)contact);
                _fileService.SaveContentToFile(JsonConvert.SerializeObject(_contactList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All }));
            }
        }
        catch 
        (Exception ex) 
        { 
            Debug.WriteLine(ex.Message); 
            return false;
        }
        return true;
    }
    /// <summary>
    /// tar bort contact från contact listen, basserat på email adressen
    /// </summary>
    /// <param name="email">tar emot string email</param>
    /// <returns> Retunerar true om den lyckas annars retunerar false </returns>
    public bool RemoveContactFromList(string email)
    {
        try
        {
            var contactToRemove = _contactList.FirstOrDefault(c => c.Email == email);

            if (contactToRemove != null)
            {
                _contactList.Remove(contactToRemove);
                _fileService.SaveContentToFile(JsonConvert.SerializeObject(_contactList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All }));
                return true;
            }

        }
        catch (Exception ex) 
        { 
            Debug.WriteLine(ex.Message);
            return false;
        }
        return true;
    }

    public List<IContact> GetContactsFromList()
    {
        try
        {
            var content = _fileService.GetContentFromFile();
            if (!string.IsNullOrEmpty(content))
            {
                _contactList = JsonConvert.DeserializeObject<List<IContact>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All})!;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return _contactList;
    }

    public IContact GetContactByEmail(string email)
    {
        try
        {
            var contact = _contactList.FirstOrDefault(c => c.Email == email);
            return contact!;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!; // Returnera null om något går fel
        }
    }
}