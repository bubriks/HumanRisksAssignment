using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HumanRisks.Models
{
    /*Id (string/guid - primary key)
    Title (string)
    Latitude (double)
    Longitude (double)
    Threats (list of Threats - below)*/

    public class RiskAssessment
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }
        
        [Required]
        public List<Threat> Threats { get; set; }
    }
}
