using UnityEngine;

namespace Actions
{
    public abstract class Action : ScriptableObject
    {

        public abstract void Run(GameObject context);

    }
}