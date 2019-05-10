using HumanRisks.Models;
using System.Collections.Generic;
using System.Linq;

namespace HumanRisks.DataAccess
{
    public class ThreatsDA
    {
        public bool AddThreat(Threat threat)
        {
            using (var db = new DatabaseContext())
            {
                if (0 <= threat.Level && threat.Level <= 2)
                {
                    db.Threats.Add(threat);
                }
                return db.SaveChanges() > 0;
            }
        }

        public bool RemoveThreat(Threat threat)
        {
            using (var db = new DatabaseContext())
            {
                db.Threats.Remove(threat);
                return db.SaveChanges() > 0;
            }
        }

        public List<Threat> GetThreats(string RiskAssessmentId)
        {
            using (var db = new DatabaseContext())
            {
                return db.Threats.Where(x => x.RiskAssessmentId.Equals(RiskAssessmentId)).ToList();
            }
        }
    }
}
