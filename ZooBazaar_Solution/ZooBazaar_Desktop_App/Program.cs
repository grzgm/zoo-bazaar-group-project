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


builder.Services.AddSingleton<IAnimalMenager, AnimalManager>();
builder.Services.AddSingleton<IAnimalRepository, AnimalRepository>();
builder.Services.AddSingleton<IEmployeeMenager, EmployeeManager>();
builder.Services.AddSingleton<IEmployeeRepositroty, EmployeeRepository>();
builder.Services.AddSingleton<IZoneRepository, ZoneRepository>();
builder.Services.AddSingleton<IZoneMenager, ZoneManager>();
builder.Services.AddSingleton<IHabitatMenager, HabitatManager>();
builder.Services.AddSingleton<IHabitatRepository, HabitatRepository>();
builder.Services.AddSingleton<ITimeBlockRepository, TimeblockRepository>();
builder.Services.AddSingleton<ITimeBlockMenager, TimeblockMenager>();
builder.Services.AddSingleton<IStaticScheduleRepository, StaticScheduleRepository>();
builder.Services.AddSingleton<IStaticScheduleManager, StaticScheduleManager>();
builder.Services.AddSingleton<ITaskRepository, TaskRepository>();
builder.Services.AddSingleton<ITaskManager, TaskMenager>();
builder.Services.AddSingleton<IAutomaticScheduleManager, AutomaticScheduleManager>();
builder.Services.AddSingleton<IScheduleManager, ScheduleManager>();
builder.Services.AddSingleton<IScheduleRepository, ScheduleRepository>();






string fileName = "C:\\Users\\Michal\\Documents\\Repos\\School\\ZooBazzar\\s2_prj_zoobazaar\\ZooBazaar_Solution\\ZooBazaar_Desktop_App\\wwwroot\\Images\\ScheduleIcon.png";


if (HybridSupport.IsElectronActive)
{
    var options = new BrowserWindowOptions()
    {
        AutoHideMenuBar = false,
        DarkTheme = true,
        Resizable = true,
        Icon = fileName

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



