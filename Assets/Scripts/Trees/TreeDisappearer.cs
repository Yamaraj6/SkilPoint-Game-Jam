using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SkilPoint_Game_Jam.Assets.Scripts.Trees
{

	public class TreeDisappearer : MonoBehaviour
	{

		private float _timeNow = 0;

		// Update is called once per frame
		void Update ()
		{
			if(gameObject.GetComponent<Rigidbody>() != null)
			{
				_timeNow += Time.deltaTime;
			}
			if(_timeNow>=2)
			{
				var collider = gameObject.GetComponent<Collider>();
				collider.isTrigger = true;
				_timeNow += Time.deltaTime;

			}
			if(_timeNow>=4)
			{
				Destroy(gameObject);
			}
		}
	}
}