using System.ComponentModel.DataAnnotations.Schema;

namespace DroneMonitoramento.Models
{
    [Table("sis_drone")]
    public class Drone
    {
        
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
    }
}
