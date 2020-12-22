namespace MicroApp.Location.Application.Vehicles.Commands.CreateVehicle
{
     public class CreateVehicleModel
     {
          public string Name { get; set; }
          public string RegNo { get; set; }
          public decimal Latitude { get; set; }
          public decimal Longitude { get; set; }
     }
}
