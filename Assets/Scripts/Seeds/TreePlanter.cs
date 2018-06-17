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

        override protected void Start()
        {
            base.Start();
            coolDown = GameObject.FindGameObjectWithTag("SeedSkill").GetComponent<CoolDown>();
        }


        public void PlantTrees(int numberOfTrees)
        {
            for (int i = 0; i < numberOfTrees; i++)
            {
                gameObject.GetComponent<CharacterControllerAction>().ThrowObject();
                var seed = Instantiate(_seed, this.transform.Find("SeedSpawnPoint").position, _seed.transform.rotation);
                AddForceToSeed(seed);
            }

        }

        private void AddForceToSeed(GameObject seed)
        {
            var forceVector = transform.forward * 1000;
            seed.GetComponent<Rigidbody>().AddForce(forceVector);
        }

        protected override void ActiveSkill()
        {
            PlantTrees(1);
        }
    }
}