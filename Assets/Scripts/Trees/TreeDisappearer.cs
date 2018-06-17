using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace SkilPoint_Game_Jam.Assets.Scripts.Trees
{

	public class TreeDisappearer : MonoBehaviour
	{

		private float _timeNow = 0;

		// Update is called once per frame
		void Update ()
		{
			if (gameObject.GetComponent<Rigidbody> () != null)
			{
				_timeNow += Time.deltaTime;
			}
			if (_timeNow >= 2)
			{
				var collider = gameObject.GetComponentsInChildren<Collider> ();
				var rgs = gameObject.GetComponentsInChildren<Rigidbody> ();
				collider.ToList ().ForEach (f => f.isTrigger = true);

				rgs.ToList ().ForEach (f => f.mass = 20);
				rgs.ToList ().ForEach (f => f.AddForce (Vector3.right));
				rgs.ToList ().ForEach (f => f.AddForce (Vector3.down));
				_timeNow += Time.deltaTime;

			}
			if (_timeNow >= 10)
			{
				Destroy (gameObject);
			}
		}
	}
}