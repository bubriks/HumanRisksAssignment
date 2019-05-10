using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanRisks.Models
{
    /*Id (string/guid - primary key)
    Title (string)
    Level (integer 0-2)
    RiskAssessmentId (string - foreign key to the Risk Assessment)*/

    public class Threat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        //[Range(2, 0)]
        public int Level { get; set; }

        [Required]
        [ForeignKey("RiskAssessmentId")]
        public virtual RiskAssessment RiskAssessment { get; set; }
        public string RiskAssessmentId { get; set; }
    }
}
