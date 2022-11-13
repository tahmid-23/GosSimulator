using UnityEngine;

namespace NPC
{
    public abstract class NPCBase: MonoBehaviour
    {
        private Classification _classification;
        private double _hp;
        private int _schoolbookFollowers;

        protected NPCBase(Classification classification, double hp, int schoolbookFollowers)
        {
            this._classification = classification;
            this._hp = hp;
            this._schoolbookFollowers = schoolbookFollowers;
        }

        public double GetHP()
        {
            return _hp;
        }

        public void ChangeSchoolbookFollowers(int delta)
        {
            _schoolbookFollowers += delta;
        }
    }
}