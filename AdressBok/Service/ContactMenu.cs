using AdressBok.Interfaces;
using AdressBok.Models;

namespace AdressBok.Service;

public interface IContactMenu
{
    void ShowMainMenu();
}

public class ContactMenu : IContactMenu
{
    private readonly ContactService _contactService = new ContactService();
    private IEnumerable<object>? contactList;

    public void ShowMainMenu()

    {
        while (true)
        {
            DisplayMenuTitle("MENU OPTIONS");
            Console.WriteLine($"{"1.",-4} Add New Contact to list.");
            Console.WriteLine($"{"2.",-4} Show all Contacts.");
            Console.WriteLine($"{"3.",-4} Show a specific contact.");
            Console.WriteLine($"{"4.",-4} Delete a contact.");
            Console.WriteLine($"{"0.",-4} Exit Application");
            Console.WriteLine();
            Console.Write("Enter Menu Option: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ShowAddContactOption(); break;
                case "2":
                    ShowAllContactsOption(); break;
                case "3":
                    ShowSpecificContactOption(); break;
                case "4":
                    ShowDeleteSpecificContactOption(); break;
                case "0":
                    ShowExitApplicationOption(); break;
                default:
                    Console.WriteLine("\nInvalid option selected. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void ShowAddContactOption()
    {
        IContact contact = new Contact();

        DisplayMenuTitle("Add New Contact");

        Console.Write("First Name:");
        contact.FirstName = Console.ReadLine()!;

        Console.Write("Last Name:");
        contact.LastName = Console.ReadLine()!;

        Console.Write("Email:");
        contact.Email = Console.ReadLine()!;

        Console.Write("Phone Number:");
        contact.PhoneNumber = Console.ReadLine()!;

        Console.Write("Address:");
        contact.Address = Console.ReadLine()!;

        _contactService.AddContactToList(contact);

    }

    private void ShowAllContactsOption()
    {
        DisplayMenuTitle("All Contacts");

        contactList = _contactService.GetContactsFromList();

        if (contactList.Any())
        {
            foreach (Contact contact in contactList)
            {
                Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine($"Phone: {contact.PhoneNumber}");
                Console.WriteLine($"Address: {contact.Address}");
                Console.WriteLine("-----------------------");
            }
        }
        else
        {
            Console.WriteLine("No contacts available.");

        }

        DisplayPressAnyKey();
    }

    private void ShowSpecificContactOption()
    {
        DisplayMenuTitle("Show Specific Contact");

        Console.Write("Enter the email of the contact to view details: ");
        var emailToView = Console.ReadLine();

        var contactToShow = _contactService.GetContactByEmail(emailToView);

        if (contactToShow != null)
        {
            DisplayContactDetails(contactToShow);
        }
        else
        {
            Console.WriteLine("Contact not found.");
        }

        DisplayPressAnyKey();

    }
    private void DisplayContactDetails(Contact contact)
    {
        DisplayMenuTitle($"Contact Details for {contact.FirstName} {contact.LastName}");

        Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
        Console.WriteLine($"Email: {contact.Email}");
        Console.WriteLine($"Phone: {contact.PhoneNumber}");
        Console.WriteLine($"Address: {contact.Address}");


    }

    private void ShowDeleteSpecificContactOption()
    {
        DisplayMenuTitle("Delete Contact");

        Console.Write("Enter the email of the contact to delete: ");
        var emailToDelete = Console.ReadLine();

        if (_contactService.RemoveContactFromList(emailToDelete!))
        {
            Console.WriteLine("Contact successfully deleted.");
        }
        else
        {
            Console.WriteLine("Contact not found or unable to delete.");
        }

        DisplayPressAnyKey();

    }

    private void ShowExitApplicationOption()
    {
        Console.Clear();
        Console.Write("Are you sure you want to vlose this application? (y/n): ");
        var option = Console.ReadLine() ?? "";

        if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
            Environment.Exit(0);
    }

    private void DisplayMenuTitle(string title)
    {
        Console.Clear();
        Console.WriteLine($"*¤*¤ {title} ¤*¤*");
        Console.WriteLine();
    }

    private void DisplayPressAnyKey()
    {
        Console.WriteLine();
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
}


// 1*  att lägga till en kontakt i en lista **
// 2*  att lista upp samtliga kontakter på ett snyggt och prydligt sätt **
// 3*  att sen detaljerad information om en specifik kontakt ska visas.
// 4*  att kunna ta bort en kontakt genom att ange kontaktens e-postadress**

// crud  ,, creat read uppdate delete