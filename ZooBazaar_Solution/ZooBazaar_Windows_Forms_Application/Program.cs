using System;
using System.ComponentModel.Design;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_ClassLibrary.Menagers;
using ZooBazaar_Repositories.Interfaces;
using ZooBazaar_Repositories.Repositories;
using ZooBazaar_Windows_Forms_Application.AnimalAddControls;



namespace ZooBazaar_Windows_Forms_Application
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            ConfigureServices();
            Application.Run(new Form1());
            
        }
        public static IServiceProvider ServiceProvider { get; set; }

        static void ConfigureServices()
        {
            var services = new ServiceCollection();

            //::begin:: User Services
            services.AddScoped<IAnimalRepository, AnimalRepository>();
            services.AddScoped<IZoneRepository, ZoneRepository>();
            services.AddScoped<IHabitatRepository, HabitatRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<ITimePreferenceRepository, TimePreferenceRepository>();
            services.AddScoped<ITimeBlockRepository, TimeblockRepository>();
            services.AddScoped<IEmployeeRepositroty, EmployeeRepository>();
            services.AddScoped<IEmployeeMenager, EmployeeManager>();
            services.AddScoped<IHabitatMenager, HabitatManager>();
            services.AddScoped<ITimeBlockMenager, TimeblockMenager>();
            services.AddScoped<IZoneMenager, ZoneManager>();
            services.AddScoped<IAnimalMenager, AnimalManager>();

            //::end:: User Services

            ServiceProvider = services.BuildServiceProvider();
        }

        public static T? GetService<T>() where T : class
        {
            return (T?)ServiceProvider.GetService(typeof(T));
        }

    }
}