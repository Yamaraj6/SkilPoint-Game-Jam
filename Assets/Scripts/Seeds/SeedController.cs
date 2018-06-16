using System.Collections;
using UnityEngine;

namespace SkilPoint_Game_Jam.Assets.Scripts
{

    public class SeedController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _floor;
        [SerializeField]
        private GameObject _treeObject;
        [SerializeField]
        private float _growingSpeed = 2;
        private GameObject _instantiatedTree;

        void Update ()
        {
            //  if (Vector3.Distance (this.transform.position, _floor.transform.position) < 5)
        }
        private IEnumerator OnCollisionEnter (Collision other)
        {
            if (other.gameObject.tag == "ground")
            {
                CreateTree ();
                yield return StartCoroutine (ScaleOverTime (_growingSpeed));
            }
            else
            {
                yield return null;
            }
        }

        private void CreateTree ()
        {
            _treeObject.transform.localScale = new Vector3 (0, 0, 0);
            _instantiatedTree = Instantiate (_treeObject, this.transform.position, _treeObject.transform.rotation);
        }

        public IEnumerator ScaleOverTime (float time)
        {
            var originalScale = _instantiatedTree.transform.localScale;
            var destinationScale = new Vector3 (1.0f, 1.0f, 1.0f);

            float currentTime = 0.0f;
            do
            {
                _instantiatedTree.transform.localScale = Vector3.Lerp (originalScale, destinationScale, currentTime / time);
                currentTime += Time.deltaTime;
                yield return null;
            } while (currentTime <= time);

            gameObject.SetActive(false);
            DestroyImmediate (gameObject);
        }

    }
}