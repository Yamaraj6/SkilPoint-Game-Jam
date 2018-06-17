using UnityEngine;

namespace SkilPoint_Game_Jam.Assets.Scripts
{
    public class ScoreController : MonoBehaviour
    {
        private int _killCount = 0;

        public void AddToKillCount(int kills)
        {
            _killCount += kills;
            Debug.Log($"Kill count: {kills}");
        }
    }
}