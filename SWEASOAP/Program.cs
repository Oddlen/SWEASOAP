using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace SWEASOAP
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var mainForm = serviceProvider.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }
        }
        
        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<ICurrencyConverter, SweaService>()
                    .AddScoped<MainForm>();
        }
    }
}
