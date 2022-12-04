using AI;
using UnityEngine;

namespace Actions
{
    [CreateAssetMenu(fileName = "Assets/Resources/Actions/Summon Angry Janitor", menuName = "Summon Angry Janitor", order = 0)]
    public class SummonAngryJanitorAction : Action
    {

        [SerializeField]
        private GameObject angryJanitorPrefab;

        [SerializeField]
        private Vector3 spawnPos;
        
        public override void Run(GameObject context)
        {
            Instantiate(angryJanitorPrefab, spawnPos, Quaternion.identity);
        }
    }
}