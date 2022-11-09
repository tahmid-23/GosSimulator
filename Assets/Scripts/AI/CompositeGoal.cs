using System.Collections;
using System.Collections.Generic;

namespace AI
{
    public class CompositeGoal : IAIGoal
    {

        private readonly IEnumerable<IAIGoal> _subGoals;

        public CompositeGoal(IEnumerable<IAIGoal> subGoals)
        {
            _subGoals = subGoals;
        }

        public void Start()
        {
            foreach (IAIGoal aiGoal in _subGoals)
            {
                aiGoal.Start();
            }
        }

        public void Update()
        {
            foreach (IAIGoal aiGoal in _subGoals)
            {
                aiGoal.Update();
            }
        }

        public void End()
        {
            foreach (IAIGoal aiGoal in _subGoals)
            {
                aiGoal.End();
            }
        }
    }
}