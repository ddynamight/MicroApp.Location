namespace MicroApp.Location.Application.Bicycles.Models
{
     public class BicycleResponseModel
     {
          public int Id { get; set; }
          public string Name { get; set; }
          public string Type { get; set; }
          public decimal Latitude { get; set; }
          public decimal Longitude { get; set; }
     }
}
