using AdressBok.Interfaces;
using AdressBok.Models;
using AdressBok.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddSingleton<IContactMenu, ContactMenu>();
    services.AddSingleton<IContactService, ContactService>();
    services.AddSingleton<IFileService>(new FileService(@"C:\Weddutveckling\CSharp\Adressbok\content.json"));

}).Build();

builder.Start();
Console.Clear();

var contactMenu = builder.Services.GetRequiredService<IContactMenu>();
contactMenu.ShowMainMenu();



