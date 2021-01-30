using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HouseBuild
{
    public class Team
    {
        public TextWriter ReportStream { protected get; set; } = Console.Out;

        public IEnumerable<IWorker> Workers { get; protected set; }

        public IEnumerable<TeamLeader> TeamLeaders { get; protected set; }

        public Team(IEnumerable<IWorker> workers, IEnumerable<TeamLeader> teamLeaders)
        {
            Workers = workers;
            TeamLeaders = teamLeaders;
        }

        public House Build(House house)
        {
            ReportStream.Write("Start building a house with: {");
            house.Parts.ForEach(part => ReportStream.Write(" " + part.GetType().Name));
            ReportStream.Write(" }");

            //TODO: Build house

            return house;
        }
    }
}
