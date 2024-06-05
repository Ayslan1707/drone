using System.ComponentModel.DataAnnotations.Schema;

namespace DroneMonitoramento.Models
{
    [Table("sis_ocean_waste")]
    public class OceanWaste
    {
        public int Id { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DetectedAt { get; set; }

    }
}
