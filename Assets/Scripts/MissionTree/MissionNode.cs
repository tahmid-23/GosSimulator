using System;
using System.Collections.Generic;

namespace MissionTree
{
    public abstract class MissionNode
    {
        private String _missionTitle;
        private String _missionText;
        private String _rewards;
        private bool _missionCompleted = false;

        private List<MissionNode> _nextMissions;

        public MissionNode(String missionTitle, String missionText, String rewards)
        {
            this._missionTitle = missionTitle;
            this._missionText = missionText;
            this._rewards = rewards;
        }

        public void AddMissions(MissionNode missionNode)
        {
            _nextMissions.Add(missionNode);
        }

        public String GetMissionText()
        {
            return _missionText;
        }

        public String GetRewards()
        {
            return _rewards;
        }

        public String GetMissionTitle()
        {
            return _missionTitle;
        }

        public List<MissionNode> GetChildrenNodes()
        {
            return _nextMissions;
        }

        public abstract bool conditionMet();
    }
}