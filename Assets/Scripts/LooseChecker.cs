using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace SkilPoint_Game_Jam.Assets.Scripts
{
	public class LooseChecker : MonoBehaviour
	{
		[SerializeField]private int _treesToLoose = 5;
		private float _timer = 0;

		// Update is called once per frame
		void Update ()
		{
			_timer += Time.deltaTime;
			if(_timer>1)
			{
				CheckIfLost();
				_timer = 0;
			}
		}

		private void CheckIfLost ()
		{
			if(GameObject.FindGameObjectsWithTag("tree").Count() <= _treesToLoose)
			{
				Debug.LogError("YOU LOST, NOT ENOUGH TREES!!!");
				Time.timeScale = 0;
				Destroy(gameObject);
			}
		}
	}
}