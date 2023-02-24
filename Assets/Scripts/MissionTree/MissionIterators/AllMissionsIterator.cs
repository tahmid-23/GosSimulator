using System.Collections.Generic;

namespace MissionTree.MissionIterators
{
    public class AllMissionsIterator : IMissionIterator
    {
        private MissionNode _rootNode;
        private List<MissionNode> _allMissions = new List<MissionNode>();

        public AllMissionsIterator(MissionNode rootNode)
        {
            _rootNode = rootNode;
        }
        
        public List<MissionNode> GetAllMissions()
        {
            GetAllMissions(_rootNode);
            return _allMissions;
        }

        private void GetAllMissions(MissionNode tempNode)
        {
            _allMissions.Add(tempNode);

            foreach (var missionNode in tempNode.GetChildrenNodes())
            {
                GetAllMissions(missionNode);
            }
        }
    }
}