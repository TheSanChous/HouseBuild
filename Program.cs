using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuild
{
    class Program
    {
        static int buildersCount;
        static int teamLeadresCount;

        static void Main(string[] args)
        {
            List<IPart> houseParts = GetHouserPartRandomList();
            IEnumerable<IWorker> builders = new List<Builder>();
            List<TeamLeader> teamLeaders = new List<TeamLeader>();

            AskUserWorkersCount();
            
            House house = new House(houseParts);

            Team team = new Team(builders, teamLeaders);
            team.ReportStream = Console.Out;

            house = team.Build(house);
        }

        private static List<IPart> GetHouserPartRandomList()
        {
            var randomList = new List<IPart>()
            {
                new HouseParts.Basement(),
                new HouseParts.Wall(),
                new HouseParts.Wall(),
                new HouseParts.Wall(),
                new HouseParts.Wall(),
                new HouseParts.Window(),
                new HouseParts.Window(),
                new HouseParts.Window(),
                new HouseParts.Window(),
                new HouseParts.Door(),
                new HouseParts.Roof()
            };

            var random = new Random();

            for(int i = 0; i < randomList.Count; i++)
                randomList.Flip(random.Next(randomList.Count), random.Next(randomList.Count));

            return randomList;
        }

        private static void AskUserWorkersCount()
        {
            try
            {
                Console.Write("Please, enter count of builders > 0 (for example: 5) => ");
                buildersCount = int.Parse(Console.ReadLine());

                Console.Write("Also, enter the count of team leaders => ");
                teamLeadresCount = int.Parse(Console.ReadLine());

                if (buildersCount < 1 || teamLeadresCount < 1) throw new ArgumentException($"The count of workers must be greater than zero. Your input: {buildersCount}, {teamLeadresCount}");
            }
            catch (ArgumentNullException)
            {
                Console.Write("Error: Empty input. Try again.");
                AskUserWorkersCount();
            }
            catch(FormatException e)
            {
                Console.WriteLine("Error: " + e.Message + " Try again.");
                AskUserWorkersCount();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Error: " + e.Message + " Try again.");
                AskUserWorkersCount();
            }
        }
    }
}
