using UnityEngine;

namespace Actions
{
    [CreateAssetMenu(fileName = "Assets/Resources/Actions/SpawnPrefab", menuName = "Spawn Prefab Action")]
    public class SpawnPrefabAction : Action
    {

        [field: SerializeField]
        private GameObject prefab;
        
        public override void Run(GameObject context)
        {
            GameObject created = Instantiate(prefab);
            created.transform.position = context.transform.position;
        }
    }
}