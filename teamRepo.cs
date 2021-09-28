using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Insurance
{
    class TeamRepo
    {
        public List<DevRepo> TeamMembers { get; set; }
        public string TeamName { get; set; }
        public short TeamID { get; set; }

        public TeamRepo() { }
        public TeamRepo(string teamName, short teamId)
        {
            TeamMembers = new List<DevRepo>();
            TeamName = teamName;
            TeamID = teamId;
        }
        private List<TeamRepo> _listOfTeam = new List<TeamRepo>();
        //create
        public void AddTeamToList(TeamRepo Team)
        {
            _listOfTeam.Add(Team);
        }

        //read
        public List<TeamRepo> GetTeam()
        {
            return _listOfTeam;
        }

        //update
        public bool UpdateExistingTeam(short originalTeam, TeamRepo newTeam)
        {
            //find
            TeamRepo oldTeam = GetTeamById(originalTeam);

            //update
            if (oldTeam != null)
            {
                oldTeam.TeamMembers = newTeam.TeamMembers;
                oldTeam.TeamName = newTeam.TeamName;
                oldTeam.TeamID = newTeam.TeamID;                
                return true;
            }
            else
            {
                return false;
            }
        }


        //delete
        public bool RemoveTeamFromList(short id)
        {
            TeamRepo content = GetTeamById(id);

            if (content == null)
            {
                return false;
            }
            int initialCount = _listOfTeam.Count;
            _listOfTeam.Remove(content);
            if (initialCount > _listOfTeam.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //helper
        private TeamRepo GetTeamById(short id)
        {
            foreach (TeamRepo content in _listOfTeam)
            {
                if (content.TeamID == id)
                {
                    return content;
                }
            }
            return null;
        }

    }
}

