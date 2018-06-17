using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace SkilPoint_Game_Jam.Assets.Scripts.Trees
{

	public class TreeDisappearer : MonoBehaviour
	{
        public GameObject main;
        private Timer t = new Timer();
		
		// Update is called once per frame
		void Update ()
		{

            if(t.isReady(2.5f) && main.GetComponent<Rigidbody>() != null)
            {
                var collider = main.GetComponentsInChildren<Collider>();

                var rgs = main.GetComponent<Rigidbody>();
                collider.ToList().ForEach(f => 
                    f.isTrigger = true
               );

                rgs.mass = 20;
                rgs.drag = 1;
                rgs.AddForce(Vector3.right + Vector3.down);
                if(t.isReady(5))
                    Destroy(main);
            }
		}

        public void OnDeath(HealthController.DamageData data)
        {
            if (main.GetComponent<Rigidbody>() == null)
            {
                main.AddComponent<Rigidbody>();
                Destroy(GetComponentInChildren<AiPerceiveUnit>());
                t.restart();
            }
        }
    }

    
}