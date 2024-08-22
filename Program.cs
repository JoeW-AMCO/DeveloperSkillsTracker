using System.Runtime.CompilerServices;
using DeveloperSkillsTracker.Database;
using System.Data;
using System.Linq;
using Spectre.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;
[assembly: InternalsVisibleTo("DeveloperSkillsTracker.Tests")]

namespace DeveloperSkillsTracker
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var context = new MyDbContext();
            bool exitProgram = false;
            bool backPressed = false;            

            string currentUsername;
            int currentUserID;
            AnsiConsole.Write(
                new FigletText("Developer Skills Tracker").Centered().Color(Color.RosyBrown));            

            while (!exitProgram)
            {
                DimUser userDetails = Menus.MainMenu(context);

                currentUsername = userDetails.Username;
                currentUserID = userDetails.User_ID;

                List<DimSkill> skillsList = context.Skills.Where(s => s.User_ID == currentUserID).ToList();
                List<DimExperience> experiencesList = context.Experiences.Where(e => e.User_ID == currentUserID).ToList();
                List<DimCertification> certificationsList = context.Certifications.Where(c => c.User_ID == currentUserID).ToList();

                UserProfile profile = new UserProfile(userDetails.Username, userDetails.User_ID, skillsList, experiencesList, certificationsList);

                Console.Clear();

                bool inTableViewer = true;

                while (inTableViewer)
                {
                    //Refresh Lists
                    skillsList = context.Skills.Where(s => s.User_ID == currentUserID).ToList();
                    experiencesList = context.Experiences.Where(e => e.User_ID == currentUserID).ToList();
                    certificationsList = context.Certifications.Where(c => c.User_ID == currentUserID).ToList();
                    profile.Skills = skillsList;
                    profile.Experiences = experiencesList;
                    profile.Certifications = certificationsList;
                    string attributeChoice = Menus.TableViewer(context, profile);

                    if (attributeChoice == "Exit")
                    {                      
                        exitProgram = true;
                        Console.Clear();
                        break;
                    }

                    bool inDataViewer = true;

                    while (inDataViewer)
                    {
                        ////Refresh Lists
                        skillsList = context.Skills.Where(s => s.User_ID == currentUserID).ToList();
                        experiencesList = context.Experiences.Where(e => e.User_ID == currentUserID).ToList();
                        certificationsList = context.Certifications.Where(c => c.User_ID == currentUserID).ToList();
                        profile.Skills = skillsList;
                        profile.Experiences = experiencesList;
                        profile.Certifications = certificationsList;

                        Console.Clear();

                        string changeChoice = Menus.DataViewer(context, profile, attributeChoice);

                        Console.Clear();

                        if (changeChoice == "Add")
                        {
                            Menus.AddMenu(context, profile, attributeChoice, changeChoice);
                        }
                        else if (changeChoice == "Delete")
                        {
                            Menus.DeleteMenu(context, profile, attributeChoice, changeChoice);
                        }
                        else if (changeChoice == "Edit")
                        {
                            Menus.EditMenu(context, profile, attributeChoice, changeChoice);
                        }
                        else if (changeChoice == "Back")
                        {
                            Console.Clear();
                            inDataViewer = false;
                        }
                    }
                }                
                exitProgram = false;
            }            
        }
    }
}
