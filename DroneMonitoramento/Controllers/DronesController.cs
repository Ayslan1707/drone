using DroneMonitoramento.Models;
using DroneMonitoramento.Services;
using Microsoft.AspNetCore.Mvc;

namespace DroneMonitoringAPI.Controllers
{
    public static class DronesController
    {
        public static void MapDroneEndpoints(this WebApplication app)
        {
            app.MapGet("/drones", async (IDroneService droneService) =>
            {
                return Results.Ok(await droneService.GetDronesAsync());
            });

            app.MapGet("/drones/{id}", async (int id, IDroneService droneService) =>
            {
                var drone = await droneService.GetDroneByIdAsync(id);
                return drone is not null ? Results.Ok(drone) : Results.NotFound();
            });

            app.MapPost("/drones", async ([FromBody] Drone drone, IDroneService droneService) =>
            {
                await droneService.AddDroneAsync(drone);
                return Results.Created($"/drones/{drone.Id}", drone);
            });

            app.MapPut("/drones/{id}", async (int id, [FromBody] Drone drone, IDroneService droneService) =>
            {
                if (id != drone.Id)
                    return Results.BadRequest();

                await droneService.UpdateDroneAsync(drone);
                return Results.NoContent();
            });

            app.MapDelete("/drones/{id}", async (int id, IDroneService droneService) =>
            {
                await droneService.DeleteDroneAsync(id);
                return Results.NoContent();
            });
        }
    }
}
