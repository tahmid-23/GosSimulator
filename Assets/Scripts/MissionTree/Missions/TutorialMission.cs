namespace MissionTree.Missions
{
    public class TutorialMission : MissionNode
    {
        public TutorialMission() : base("Tutorial Mission", "The tutorial mission", "None")
        {
            
        }

        public override bool conditionMet()
        {
            return true;
        }
    }
}