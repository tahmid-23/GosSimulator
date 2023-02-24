using System.Collections.Generic;
using MissionTree.MissionIterators;

namespace MissionTree
{
    public static class MissionTreeFacade
    {
        private static IMissionIterator _iterator;
        private static MissionTree _missionTree;

        public static List<MissionNode> GetAllMissions()
        {
            _iterator = new AllMissionsIterator(_missionTree.rootNode);
            return _iterator.GetAllMissions();
        }

        public static void SetMissionTree(MissionTree missionTree)
        {
            _missionTree = missionTree;
        }
    }
}