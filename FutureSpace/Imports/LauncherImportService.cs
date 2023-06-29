namespace FutureSpace.Imports
{
    public class LauncherImportService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public LauncherImportService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                const int totalExecutionsPerDay = 10;
                TimeSpan interval = TimeSpan.FromHours(24);

                var timer = new Timer(async _ =>
                {
                    for (int i = 0; i < totalExecutionsPerDay; i++)
                    {
                        using (var scope = _serviceProvider.CreateScope())
                        {
                            var launcherImportRoutine = scope.ServiceProvider.GetRequiredService<LauncherImportRoutine>();
                            await launcherImportRoutine.ImportLaunchers();
                        }

                        await Task.Delay(TimeSpan.FromMinutes(3));
                    }
                }, null, TimeSpan.FromSeconds(10), interval);

                while (!stoppingToken.IsCancellationRequested)
                {
                    await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Houve um erro: {ex.Message}");
            }
        }
    }
}
