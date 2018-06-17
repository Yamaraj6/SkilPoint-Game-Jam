using System.Collections;
using System.Linq;
using UnityEngine;

namespace SkilPoint_Game_Jam.Assets.Scripts
{

    public class SeedController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _floor;
        [SerializeField]
        private GameObject[] _treeObject;
        [SerializeField]
        private float _growingSpeed = 2;
        private GameObject _instantiatedTree;

        void Update ()
        {
            //  if (Vector3.Distance (this.transform.position, _floor.transform.position) < 5)
        }
   /*     void OnTriggerEnter (Collider other)
        {
            if (other.gameObject.tag == "tree")
                Destroy (gameObject);

        }*/
        private IEnumerator OnCollisionEnter (Collision other)
        {
            if (other.gameObject.tag == "ground")
            {
                //      yield return new WaitForSeconds(2);
                this.GetComponent<Rigidbody> ().velocity = Vector3.zero;
                CreateTree ();
                this.GetComponent<MeshRenderer>().enabled = false;
                yield return StartCoroutine (ScaleOverTime (_growingSpeed));
            }
            else
            {
                yield return null;
            }

        }

        private void CreateTree ()
        {
            CheckNearestTree();
            var treeVariant = Random.Range (0, 3);
            _treeObject[treeVariant].transform.localScale = new Vector3 (0, 0, 0);
            _instantiatedTree = Instantiate (_treeObject[treeVariant], this.transform.position, _treeObject[treeVariant].transform.rotation);
        }

        private void CheckNearestTree()
        {
            if(GameObject.FindGameObjectsWithTag("tree").ToList().Where(w => Vector3.Distance(this.transform.position, w.transform.position)<2).Count() >0)
            {
                Destroy(gameObject);
            } 
        }

        public IEnumerator ScaleOverTime (float time)
        {
            AudioSource audio = GetComponent<AudioSource> ();
            audio.Play ();
            audio.Play (44100);

            var originalScale = _instantiatedTree.transform.localScale;
            var destinationScale = new Vector3 (1.0f, 1.0f, 1.0f);

            float currentTime = 0.0f;
            do
            {
                _instantiatedTree.transform.localScale = Vector3.Lerp (originalScale, destinationScale, currentTime / time);
                currentTime += Time.deltaTime;
                yield return null;
            } while (currentTime <= time);

            DestroyImmediate (gameObject);
        }

    }
}