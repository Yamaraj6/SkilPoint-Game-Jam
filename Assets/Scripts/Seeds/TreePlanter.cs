using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace SkilPoint_Game_Jam.Assets.Scripts.Seeds
{
    public class TreePlanter : MonoBehaviour
    {
        [SerializeField]
        private GameObject _seed;
        [SerializeField]
        private int _verticalPower;
        [SerializeField]
        private int _horizontalPower;
        public void Update ()
        {
            if (Input.GetKeyDown ("1"))
                PlantTrees (10);
        }
        public void PlantTrees (int numberOfTrees)
        {
            for (int i = 0; i < numberOfTrees; i++)
            {
                var seed = Instantiate (_seed, new Vector3(this.transform.position.x, this.transform.position.y+1, this.transform.position.z) , _seed.transform.rotation);
                AddForceToSeed (seed);
            }

        }

        private void AddForceToSeed (GameObject seed)
        {
            var forceVector = new Vector3 ();
            var rand = Random.Range (0, 5);
            if (rand < 1)
                forceVector = new Vector3 (0, _verticalPower, _horizontalPower*10) * 100;
            else if (rand < 2)
                forceVector = new Vector3 (0,_verticalPower , -_horizontalPower*10) * 100;
            else if (rand < 3)
                forceVector = new Vector3 (_horizontalPower, _verticalPower, 0) * 100;
            else if (rand < 4)
                forceVector = new Vector3 (-_horizontalPower, _verticalPower, 0) * 100;

            seed.GetComponent<Rigidbody> ().AddForce (forceVector);

        }

    }
}