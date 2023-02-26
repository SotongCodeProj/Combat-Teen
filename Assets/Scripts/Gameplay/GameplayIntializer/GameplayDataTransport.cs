using UnityEngine;

namespace CombTeen.Gameplay.DataTransport
{
    public class GameplayDataTransport : MonoBehaviour
    {
        public static GameplayDataTransport Instance;
        private void Awake()
        {
            if (Instance != null) Destroy(this);
            else
            {
                DontDestroyOnLoad(this);
                Instance = this;
            }
        }
    }
}
