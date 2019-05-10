using HumanRisks.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HumanRisks.DataAccess
{
    public class RiskAssessmentDA
    {
        public bool AddRiskAssessments(RiskAssessment riskAssessment)
        {
            using (var db = new DatabaseContext())
            {
                db.RiskAssessments.Add(riskAssessment);
                return db.SaveChanges() > 0;
            }
        }

        public bool UpdateRiskAssessments(RiskAssessment riskAssessment)
        {
            using (var db = new DatabaseContext())
            {
                db.RiskAssessments.Update(riskAssessment);
                return db.SaveChanges() > 0;
            }
        }

        public RiskAssessment GetRiskAssessment(string id)
        {
            using (var db = new DatabaseContext())
            {
                return db.RiskAssessments.Include(x => x.Threats).Single(x => x.Id == id);
            }
        }

        public List<RiskAssessment> GetRiskAssessments()
        {
            using (var db = new DatabaseContext())
            {
                return db.RiskAssessments.ToList();
            }
        }
    }
}
