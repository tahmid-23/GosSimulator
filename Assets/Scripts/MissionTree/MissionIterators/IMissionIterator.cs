using System.Collections.Generic;

namespace MissionTree.MissionIterators
{
    public interface IMissionIterator
    {
        public List<MissionNode> GetAllMissions();
    }
}