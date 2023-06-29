using FutureSpace.Context;
using FutureSpace.Models;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using System.Net;

namespace FutureSpace.Imports
{
    public class LauncherImportRoutine
    {
        private readonly HttpClient _httpClient;
        private readonly AppDbContext _context;

        public LauncherImportRoutine(AppDbContext context)
        {
            _httpClient = new HttpClient();
            _context = context;
        }

        public async Task ImportLaunchers(string nextPage = "https://ll.thespacedevs.com/2.0.0/launch/")
        {
            try
            {
                var next = await _context.LaunchResults.OrderBy(l => l.Id).Select(l => l.Next).LastOrDefaultAsync();
                if (!string.IsNullOrEmpty(next))
                    nextPage = next;

                if (_context.Launchers.ToList().Count() <= 2000)
                {
                    var response = await _httpClient.GetAsync(nextPage);
                    response = await CheckRequestOk(nextPage, response);

                    var json = await response.Content.ReadAsStringAsync();

                    var launchResult = JsonConvert.DeserializeObject<LaunchResult>(json);

                    foreach (var launch in launchResult.Results)
                    {
                        CheckEntitiesLocal(launch);

                        launch.Imported_t = DateTime.Now;
                        launch.Status_t = Enums.Status.Draft.ToString();

                        CheckEntitiesDataBase(launch);
                    }
                    _context.LaunchResults.Add(launchResult);

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao importar lançadores: {ex.Message}");
            }
        }

        private async Task<HttpResponseMessage> CheckRequestOk(string nextPage, HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                Thread.Sleep(TimeSpan.FromSeconds(response.Headers.RetryAfter.Delta.Value.Seconds + 60));
                response = await _httpClient.GetAsync(nextPage);

                Console.WriteLine($"Muitas requisições: {response.ToString()}");

                if (response.StatusCode == HttpStatusCode.TooManyRequests)
                    await CheckRequestOk(nextPage, response);
            }

            response.EnsureSuccessStatusCode();

            return response;
        }

        private void DetachEntity<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
        }

        private void CheckEntitiesLocal(Launch launch)
        {
            if (launch != null)
            {
                var location = _context.Locations.Local.FirstOrDefault(o => o.Id == launch.Pad?.Location?.Id);
                DetachEntity(location);
                var pad = _context.Pads.Local.FirstOrDefault(o => o.Id == launch.Pad?.Id);
                DetachEntity(pad);
                var orbit = _context.Orbits.Local.FirstOrDefault(o => o.Id == launch.Mission?.Orbit?.Id);
                DetachEntity(orbit);
                var mission = _context.Missions.Local.FirstOrDefault(o => o.Id == launch.Mission?.Id);
                DetachEntity(mission);
                var configuration = _context.Configurations.Local.FirstOrDefault(o => o.Id == launch.Rocket?.Configuration?.Id);
                DetachEntity(configuration);
                var rocket = _context.Rockets.Local.FirstOrDefault(o => o.Id == launch.Rocket?.Id);
                DetachEntity(rocket);
                var launch_service_provider = _context.LaunchServiceProviders.Local.FirstOrDefault(o => o.Id == launch.Launch_Service_Provider?.Id);
                DetachEntity(launch_service_provider);
                var status = _context.Status.Local.FirstOrDefault(o => o.Id == launch.Status?.Id);
                DetachEntity(status);
                var launcher = _context.Launchers.Local.FirstOrDefault(o => o.Id == launch.Id);
                DetachEntity(launcher);
                foreach (var prog in launch.Program)
                {
                    foreach (var agenc in prog.Agencies)
                    {
                        var agencia = _context.Agencies.Local.FirstOrDefault(o => o.Id == agenc.Id);
                        DetachEntity(agencia);
                    }

                    var program = _context.Programs.Local.FirstOrDefault(o => o.Id == prog.Id);
                    DetachEntity(program);
                }
            }
        }

        private void CheckEntitiesDataBase(Launch launch)
        {
            var launcher = _context.Launchers.FirstOrDefault(s => s.Id == launch.Id) != null ? _context.Launchers.Update(launch) : _context.Launchers.Add(launch);
            var launch_service_provider = _context.LaunchServiceProviders.FirstOrDefault(s => s.Id == launch.Launch_Service_Provider.Id) != null ? _context.LaunchServiceProviders.Update(launch.Launch_Service_Provider) : _context.LaunchServiceProviders.Add(launch.Launch_Service_Provider);
            var status = _context.Status.FirstOrDefault(s => s.Id == launch.Status.Id) != null ? _context.Status.Update(launch.Status) : _context.Status.Add(launch.Status);
            var location = _context.Locations.FirstOrDefault(s => s.Id == launch.Pad.Location.Id) != null ? _context.Locations.Update(launch.Pad.Location) : _context.Locations.Add(launch.Pad.Location);
            var pad = _context.Pads.FirstOrDefault(s => s.Id == launch.Pad.Id) != null ? _context.Pads.Update(launch.Pad) : _context.Pads.Add(launch.Pad);
            var orbit = _context.Orbits.FirstOrDefault(s => s.Id == launch.Mission.Orbit.Id) != null ? _context.Orbits.Update(launch.Mission.Orbit) : _context.Orbits.Add(launch.Mission.Orbit);
            var mission = _context.Missions.FirstOrDefault(s => s.Id == launch.Mission.Id) != null ? _context.Missions.Update(launch.Mission) : _context.Missions.Add(launch.Mission);
            var configuration = _context.Configurations.FirstOrDefault(s => s.Id == launch.Rocket.Configuration.Id) != null ? _context.Configurations.Update(launch.Rocket.Configuration) : _context.Configurations.Add(launch.Rocket.Configuration);
            var rocket = _context.Rockets.FirstOrDefault(s => s.Id == launch.Rocket.Id) != null ? _context.Rockets.Update(launch.Rocket) : _context.Rockets.Add(launch.Rocket);
            foreach (var prog in launch.Program)
            {
                var program = _context.Programs.FirstOrDefault(s => s.Id == prog.Id) != null ? _context.Programs.Update(prog) : _context.Programs.Add(prog);

                foreach (var agenc in prog.Agencies)
                {
                    var agencia = _context.Agencies.FirstOrDefault(s => s.Id == agenc.Id) != null ? _context.Agencies.Update(agenc) : _context.Agencies.Add(agenc);
                }
            }
        }
    }
}
