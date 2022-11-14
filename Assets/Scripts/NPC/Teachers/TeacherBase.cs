using UnityEngine;

namespace NPC.Teachers
{
    public abstract class TeacherBase: MonoBehaviour
    {
        private Classification _opinion;

        public TeacherBase(Classification favorability)
        {
            this._opinion = favorability;
        }

        public Classification GetClassification()
        {
            return _opinion;
        }

        public void SetClassification(Classification classification)
        {
            _opinion = classification;
        }
    }
}