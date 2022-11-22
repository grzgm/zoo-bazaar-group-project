using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_ClassLibrary.Menagers;
using ZooBazaar_Repositories.Interfaces;
using ZooBazaar_Repositories.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddElectron();
builder.WebHost.UseElectron(args);

builder.Services.AddElectron();
builder.WebHost.UseElectron(args);


builder.Services.AddElectron();
builder.WebHost.UseElectron(args);


builder.Services.AddSingleton<IAnimalMenager, AnimalManager>();
builder.Services.AddSingleton<IAnimalRepository, AnimalRepository>();
builder.Services.AddSingleton<IEmployeeMenager, EmployeeManager>();
builder.Services.AddSingleton<IEmployeeRepositroty, EmployeeRepository>();





if (HybridSupport.IsElectronActive)
{
    var options = new BrowserWindowOptions()
    {
        AutoHideMenuBar = false,
        DarkTheme = true,
        Resizable = true,
    };


    // Open the Electron-Window here
    Task.Run(async () =>
    {
        BrowserWindow window = await Electron.WindowManager.CreateWindowAsync(options);


        window.OnClosed += () =>
        {
            Electron.App.Quit();
        };

    });
    
}



// Add services to the container.
builder.Services.AddRazorPages();








var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();



