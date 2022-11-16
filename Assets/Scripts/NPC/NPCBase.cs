using UnityEngine;

namespace NPC
{
    public abstract class NPCBase: MonoBehaviour
    {
        private Classification _classification;
        private float _hp;
        private int _schoolbookFollowers;

        protected NPCBase(Classification classification, float hp, int schoolbookFollowers)
        {
            _classification = classification;
            _hp = hp;
            _schoolbookFollowers = schoolbookFollowers;
        }

        public float GetHP()
        {
            return _hp;
        }

        public void ChangeSchoolbookFollowers(int delta)
        {
            _schoolbookFollowers += delta;
        }
    }
}