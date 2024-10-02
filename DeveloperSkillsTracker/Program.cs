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
            //Create variables that will be used throughout the program
            var context = new MyDbContext();
            bool exitProgram = false;
            bool backPressed = false;            
            string currentUsername;
            int currentUserID;

            //A large ascii art header
            AnsiConsole.Write(
                new FigletText("Developer Skills Tracker").Centered().Color(Color.RosyBrown));            

            //The primary loop stopping the program from ending
            while (!exitProgram)
            {
                //The landing page that asks for login details until correct details are provided
                DimUser userDetails = Menus.MainMenu(context);

                //Creating the initial user profile with data from the database
                currentUsername = userDetails.Username;
                currentUserID = userDetails.User_ID;
                List<DimSkill> skillsList = context.Skills.Where(s => s.User_ID == currentUserID).ToList();
                List<DimExperience> experiencesList = context.Experiences.Where(e => e.User_ID == currentUserID).ToList();
                List<DimCertification> certificationsList = context.Certifications.Where(c => c.User_ID == currentUserID).ToList();
                UserProfile profile = new UserProfile(userDetails.Username, userDetails.User_ID, skillsList, experiencesList, certificationsList);

                Console.Clear();

                bool inTableViewer = true;

                //Loop allowing the user to go back to viewing all of the tables when going back from the data viewer menu
                while (inTableViewer)
                {
                    //Refresh user profile with data from the database in case of changes
                    skillsList = context.Skills.Where(s => s.User_ID == currentUserID).ToList();
                    experiencesList = context.Experiences.Where(e => e.User_ID == currentUserID).ToList();
                    certificationsList = context.Certifications.Where(c => c.User_ID == currentUserID).ToList();
                    profile.Skills = skillsList;
                    profile.Experiences = experiencesList;
                    profile.Certifications = certificationsList;

                    string attributeChoice = Menus.TableViewer(context, profile);

                    //Ends the main loop when the user chooses to exit, going back to the landing page
                    if (attributeChoice == "Exit")
                    {                      
                        exitProgram = true;
                        Console.Clear();
                        break;
                    }

                    bool inDataViewer = true;

                    //Loop allowing the user to go back to viewing specific attribute data when going back from altering the table
                    while (inDataViewer)
                    {
                        ////Refresh Lists in case of changes
                        skillsList = context.Skills.Where(s => s.User_ID == currentUserID).ToList();
                        experiencesList = context.Experiences.Where(e => e.User_ID == currentUserID).ToList();
                        certificationsList = context.Certifications.Where(c => c.User_ID == currentUserID).ToList();
                        profile.Skills = skillsList;
                        profile.Experiences = experiencesList;
                        profile.Certifications = certificationsList;

                        Console.Clear();

                        string changeChoice = Menus.DataViewer(context, profile, attributeChoice);

                        Console.Clear();

                        //Checks users latest choice and performs the appropriate action before going back to the start of the loop
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
