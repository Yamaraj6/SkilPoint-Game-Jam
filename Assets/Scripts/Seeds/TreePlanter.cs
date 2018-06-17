using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace SkilPoint_Game_Jam.Assets.Scripts.Seeds
{
    public class TreePlanter : Skill
    {
        [SerializeField]
        private GameObject _sound;
        [SerializeField]
        private GameObject _seed;
        [SerializeField]
        private int _verticalPower;
        [SerializeField]
        private int _horizontalPower;

        private void AddForceToSeed (GameObject seed)
        {
            var forceVector = transform.forward*1000;
            seed.GetComponent<Rigidbody> ().AddForce (forceVector);

        }

        protected override void ActiveSkill()
        {
            for (int i = 0; i < 1; i++)
            {
                var seed = Instantiate(_seed, this.transform.Find("SeedSpawnPoint").position, _seed.transform.rotation);
                AddForceToSeed(seed);
            }
        }
    }
}