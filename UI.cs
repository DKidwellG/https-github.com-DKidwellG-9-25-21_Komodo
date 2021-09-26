using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Insurance
{
    class UI
    {
        private DevRepo _devRepo = new DevRepo();
        public void Run()
        {
            SeedDevList();
            Menu();
        }
        // menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {


                //list of menu
                Console.WriteLine("selsct an option from the menu then press enter:\n" +
                    "1. Enter a new Developer\n" +
                    "2. List of all Developers\n" +
                    "3. list of Developers by ID\n" +
                    "4. Update Developer\n" +
                    "5. Delete Developer\n" +
                    "6. Create a Team\n" +
                    "7. list of teams\n" +
                    "8. Update team\n" +
                    "8. Delete team\n" +
                    "10. Exit");

                //get input
                string input = Console.ReadLine();

                //evaluate input
                switch (input)
                {
                    case "1.":
                        //create
                        CreatNewDev();
                        break;
                    case "2.":
                        //list of all dev
                        ViewAllDev();
                        break;

                    case "3.":
                        //list of dev by id
                        ViewDevById();
                        break;
                    case "4.":
                        //update dev
                        UpdateDev();
                        break;
                    case "5.":
                        //delete dev
                        DeleteDev();
                        break;
                    case "6.":
                        //create a team
                        CreateTeam();
                        break;
                    case "7.":
                        //list of teams
                        ViewAllTeams();
                        break;
                    case "8.":
                        //update team
                        UpdateTeam();
                        break;
                    case "9.":
                        //delete team
                        DeleteTeam();
                        break;
                    case "10.":
                        //exit
                        Console.WriteLine("Bu-by");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("pleas enter a number from the menu");
                        break;




                }
                Console.WriteLine("Press any key to continue.....");
                Console.ReadKey();
                Console.Clear();
            }

        }
        //new dev
        private void CreatNewDev()
        {
            Console.Clear();
            DevRepo newDev = new DevRepo();
            //FirstName
            Console.WriteLine(" enter first name");
            newDev.FirstName = Console.ReadLine();

            //LastName
            Console.WriteLine(" enter first name");
            newDev.LastName = Console.ReadLine();

            //ID
            Console.WriteLine(" enter developers ID number");
            string idAsString = Console.ReadLine();
            newDev.ID = short.Parse(idAsString);

            //AccessToPluralsight
            Console.WriteLine(" has permission? (y/n)");
            string accessToPluralString = Console.ReadLine().ToLower();

            if(accessToPluralString == "y")
            {
                newDev.AccessToPluralsight = true;
            }
            else
            {
                newDev.AccessToPluralsight = false;
            }
            _devRepo.AddDevToList(newDev);
        }
        //view all devs
        private void ViewAllDev()
        {
            Console.Clear();
            List<DevRepo> listOfDevs = _devRepo.GetDev();
            foreach(DevRepo content in listOfDevs)
            {
                Console.WriteLine($"ID: {content.ID}\n" +
                    $"first name: {content.FirstName}, last name: {content.LastName}\n" +
                    $"access to pluralsite {content.AccessToPluralsight}");
            }
        }
        //view dev by id
        private void ViewDevById()
        {
            Console.Clear();
            Console.WriteLine("enter developers ID");
            short devId = Console.ReadLine();
            DevRepo content = _devRepo.GetDevById(devId);
            if(content != null)
            {
                Console.WriteLine($"ID: {content.ID}\n" +
                   $"first name: {content.FirstName}, last name: {content.LastName}\n" +
                   $"access to pluralsite {content.AccessToPluralsight}");
            }
            else
            {
                Console.WriteLine(" no developer found");
            }

        }
        //update dev
        private void UpdateDev()
        {
            ViewAllDev();
            Console.WriteLine(" enter the name of the developer tha you want to update:");
            string oldName = Console.ReadLine();

            DevRepo newDev = new DevRepo();
            //FirstName
            Console.WriteLine(" enter first name");
            newDev.FirstName = Console.ReadLine();

            //LastName
            Console.WriteLine(" enter first name");
            newDev.LastName = Console.ReadLine();

            //ID
            Console.WriteLine(" enter developers ID number");
            string idAsString = Console.ReadLine();
            newDev.ID = short.Parse(idAsString);

            //AccessToPluralsight
            Console.WriteLine(" has permission? (y/n)");
            string accessToPluralString = Console.ReadLine().ToLower();

            if (accessToPluralString == "y")
            {
                newDev.AccessToPluralsight = true;
            }
            else
            {
                newDev.AccessToPluralsight = false;

            }

            bool wasUpdated = _devRepo.UpdateExistingDev(oldName, newDev);
        }
        //delete dev
        private void DeleteDev()
        {
            ViewAllDev();
            Console.WriteLine("\n enter the name of the developer that you want to delete:");
            string input = Console.ReadLine();
            bool wasDeleted = _devRepo.RemoveDevFromList(input);
            if (wasDeleted)
            {
                Console.WriteLine("they are removed form the list");
            }
            else
            {
                Console.WriteLine("oops try agin");
            }
        }
        //create a team
        private void CreateTeam()
        {
            Console.Clear();
            TeamRepo newTeam = new TeamRepo();
            //FirstName
            Console.WriteLine(" enter team name");
            newTeam.TeamName = Console.ReadLine();

            //LastName
            Console.WriteLine(" enter team member");
            newTeam.TeamMembers = Console.ReadLine();

            //ID
            Console.WriteLine(" enter teams ID number");
            string idAsString = Console.ReadLine();
            newTeam.TeamID = short.Parse(idAsString);

           
            _listOfTeam.AddTeamToList(newTeam);
        }
        //view teams
        private void ViewAllTeams()
        {
            Console.Clear();
            List<TeamRepo> listOfDevs = _teamRepo.GetTeam();
            foreach (TeamRepo content in listOfTeams)
            {
                Console.WriteLine($"ID: {content.TeamID}\n" +
                    $"first name: {content.TeamName},\n" +
                    $" last name: {content.TeamMembers}");
            }
        }
        //update team
        private void UpdateTeam()
        {
            ViewAllTeams();
            Console.WriteLine(" enter the name of the team tha you want to update:");
            string oldTeam = Console.ReadLine();

            TeamRepo newTeam = new TeamRepo();
            //FirstName
            Console.WriteLine(" enter team name");
            newTeam.TeamName = Console.ReadLine();          
            //ID
            Console.WriteLine(" enter teams ID number");
            string teamIdAsString = Console.ReadLine();
            newTeam.TeamID = short.Parse(teamIdAsString);        

            bool wasUpdated = _devRepo.UpdateExistingDev(oldTeam, newTeam);
        }
        //delete team
        private void DeleteTeam()
        {
            ViewAllTeams();
            Console.WriteLine("\n enter the name of the team that you want to delete:");
            string input = Console.ReadLine();
            bool wasDeleted = _teamRepo.RemoveTeamFromList(input);
            if (wasDeleted)
            {
                Console.WriteLine("team is removed form the list");
            }
            else
            {
                Console.WriteLine("oops try agin");
            }
        }
        //seed
        private void SeedDevList()
        {
            DevRepo johnDoe = new DevRepo("john", "doe", 001, "y");
            DevRepo janeDoe = new DevRepo("jane", "doe", 001, "y");

            _devRepo.AddDevToList(johnDoe);
            _devRepo.AddDevToList(janeDoe);
        }

    }
}
