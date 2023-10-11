﻿using System;
using System.Data;
using System.Drawing.Text;
using System.Windows.Forms;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Resolution;
using zk4500.Abstractions.Interfaces;
using zk4500.Abstractions.IRepositories;
using zk4500.Abstractions.IServices;
using zk4500.ApiClient;
using zk4500.DataContext;
using zk4500.Extensions;
using zk4500.Forms;
using zk4500.Implementations.Interfaces;
using zk4500.Implementations.Repositories;
using zk4500.Implementations.Services;
using zk4500.Shared.Requests;

namespace zk4500
{
    static class Program
    {

        public static IServiceProvider serviceProvider { get; set; }

        private static void ConfigureContainer()
        {
            
        }


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //var container = new UnityContainer();
            //container.RegisterType<IConfigurationService, ConfigurationService>(new ContainerControlledLifetimeManager());
            //container.RegisterType<IServiceManager, ServiceManager>(new ContainerControlledLifetimeManager());
            //container.RegisterType<IUnitOfWork, UnitOfWork>(new ContainerControlledLifetimeManager());
            //container.RegisterType(typeof(IBaseRepository<>), typeof(BaseRepository<>), new ContainerControlledLifetimeManager());
            //container.RegisterType<IPatientRepository, PatientRepository>(new ContainerControlledLifetimeManager());
            //container.RegisterType<IFingerPrintRepository, FingerPrintRepository>(new ContainerControlledLifetimeManager());
            //container.RegisterType<IPatientService, PatientService>(new ContainerControlledLifetimeManager());
            //container.RegisterType<IFingerPrintService, FingerPrintService>(new ContainerControlledLifetimeManager());
            //container.RegisterType<IAuthApiClient, AuthApiClient>(new ContainerControlledLifetimeManager());

            //container.RegisterType<IDbConnection>(new InjectionFactory(c => new DapperContext(c.Resolve<IConfigurationService>()).CreateConnection()));

            // Initialize the Unity container and register components
            IUnityContainer container = UnityConfig.RegisterComponents();

            var registerFingerPrintRequest = new RegisterFingerPrintRequest();
            // Resolve the Form1 instance with dependencies
            var form1 = container.Resolve<Form1>(new DependencyOverride<RegisterFingerPrintRequest>(registerFingerPrintRequest));
            Login form = container.Resolve<Login>();
            Main main = container.Resolve<Main>();

            Application.Run(main);


        }
    }
}
