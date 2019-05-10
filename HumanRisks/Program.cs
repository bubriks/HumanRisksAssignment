using System;
using System.Collections.Generic;
using HumanRisks.DataAccess;
using HumanRisks.Models;

namespace HumanRisks
{
    public class Program
    {
        private static RiskAssessmentDA riskAssessmentDa;
        private static ThreatsDA threatsDa;

        static void Main(string[] args)
        {
            /*
             To Run:
             "Update-Database" in Package Manager Console
            */

            riskAssessmentDa = new RiskAssessmentDA();
            threatsDa = new ThreatsDA();
            QuestionsRiskAssessment();
        }

        #region RiskAssessment
        private static void QuestionsRiskAssessment()
        {
            Console.WriteLine("What would you like to do:" +
                              "\n1- Create Risk Assessment" +
                              "\n2- Update Risk Assessment" +
                              "\n3- Get all Risk Assessments" +
                              "\n4- Get Risk Assessment");

            switch(Console.ReadKey().Key) {
                case ConsoleKey.D1:
                    Console.Clear();
                    CreateRiskAssessment();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    UpdateRiskAssessment();
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    ReadRiskAssessments();
                    break;
                case ConsoleKey.D4:
                    Console.Clear();
                    GetRiskAssessment();
                    break;
                default:
                    Console.Clear();
                    break;
            }
            
            QuestionsRiskAssessment();
        }

        private static void CreateRiskAssessment()
        {
            try
            {
                Text(riskAssessmentDa.AddRiskAssessments(RiskAssessmentInfo()));
            }
            catch
            {
                Text(false);
            }
        }
        
        private static void UpdateRiskAssessment()
        {
            try
            {
                Text(riskAssessmentDa.UpdateRiskAssessments(RiskAssessmentInfo()));
            }
            catch
            {
                Text(false);
            }
        }

        private static RiskAssessment RiskAssessmentInfo()
        {
            Console.WriteLine("Enter risk assessment info:");
            RiskAssessment riskAssessment = new RiskAssessment();
            Console.WriteLine("Id:");
            riskAssessment.Id = Console.ReadLine();
            Console.WriteLine("Latitude:");
            riskAssessment.Latitude = double.Parse(Console.ReadLine());
            Console.WriteLine("Longitude:");
            riskAssessment.Longitude = double.Parse(Console.ReadLine());
            Console.WriteLine("Title:");
            riskAssessment.Title = Console.ReadLine();
            return riskAssessment;
        }
        
        private static void ReadRiskAssessments()
        {
            List<RiskAssessment> riskAssessments = riskAssessmentDa.GetRiskAssessments();
            Console.WriteLine("Total number of risk assessments in database: " + riskAssessments.Count + "\n");
            riskAssessments.ForEach(x => Console.WriteLine("ID:" + x.Id +
                                                           "\nLatitude: " + x.Latitude +
                                                           "\nLongitude: " + x.Longitude +
                                                           "\nTitle: " + x.Title + "\n"));
            Text(true);
        }

        private static void GetRiskAssessment()
        {
            try
            {
                Console.WriteLine("Id:");
                RiskAssessment riskAssessment = riskAssessmentDa.GetRiskAssessment(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("ID:" + riskAssessment.Id +
                                  "\nLatitude: " + riskAssessment.Latitude +
                                  "\nLongitude: " + riskAssessment.Longitude +
                                  "\nTitle: " + riskAssessment.Title + "\n");
                QuestionsThreats(riskAssessment);
            }
            catch
            {
                Text(false);
            }
        }
        #endregion

        #region Threat
        private static void QuestionsThreats(RiskAssessment riskAssessment)
        {
            Console.WriteLine("What would you like to do:" +
                              "\n1- Add threat to Risk Assessment" +
                              "\n2- Remove threat to Risk Assessment" +
                              "\n3- Get all threats");

            switch(Console.ReadKey().Key) {
                case ConsoleKey.D1:
                    Console.Clear();
                    CreateThreat(riskAssessment.Id);
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    RemoveThreat(riskAssessment.Id);
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    ReadThreats(riskAssessment.Id);
                    break;
            }
        }

        private static void CreateThreat(string RiskAssessmentId)
        {
            try
            {
                Text(threatsDa.AddThreat(ThreatInfo(RiskAssessmentId)));
            }
            catch
            {
                Text(false);
            }
        }
        
        private static void RemoveThreat(string RiskAssessmentId)
        {
            try
            {
                int i = 0;
                List<Threat> threats = threatsDa.GetThreats(RiskAssessmentId);
                Console.WriteLine("Total number of threats for risk assessment in database: " + threats.Count + "\n");
                threats.ForEach(x =>
                {
                    Console.WriteLine("Index: " + i +
                                      "\n   ID: " + x.Id +
                                      "\n   Level: " + x.Level +
                                      "\n   Title: " + x.Title + "\n");
                    i = i + 1;
                });
                
                Console.WriteLine("\nEnter Index you would like to remove: ");
                Text(threatsDa.RemoveThreat(threats[Int32.Parse(Console.ReadLine())]));
            }
            catch
            {
                Text(false);
            }
        }

        private static Threat ThreatInfo(string RiskAssessmentId)
        {
            Console.WriteLine("Enter threat info:");
            Threat threat = new Threat
            {
                RiskAssessmentId = RiskAssessmentId
            };
            Console.WriteLine("Level:");
            threat.Level = int.Parse(Console.ReadLine());
            Console.WriteLine("Title:");
            threat.Title = Console.ReadLine();
            return threat;
        }
        
        private static void ReadThreats(string RiskAssessmentId)
        {
            List<Threat> threats = threatsDa.GetThreats(RiskAssessmentId);
            Console.WriteLine("Total number of threats for risk assessment in database: " + threats.Count + "\n");
            threats.ForEach(x => Console.WriteLine("ID: " + x.Id +
                                                   "\nLevel: " + x.Level +
                                                   "\nTitle: " + x.Title + "\n"));
            Text(true);
        }
        #endregion

        private static void Text(bool success)
        {
            if (success)
            {
                Console.BackgroundColor = ConsoleColor.Green; 
                Console.WriteLine("\nAction performed");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red; 
                Console.WriteLine("\nAction failed");
            }
            Console.BackgroundColor = ConsoleColor.Black; 
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
