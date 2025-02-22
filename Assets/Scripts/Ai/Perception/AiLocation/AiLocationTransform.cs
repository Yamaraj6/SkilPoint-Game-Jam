﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiLocationTransform : AiLocationBase{

	public Transform aim;
    public string aimTag;

	new public void Start()
	{
		base.Start();
        if (aimTag != "")
        {
            GameObject go = GameObject.FindGameObjectWithTag(aimTag);
            if (go)
                aim = go.transform;
        }


		if (!aim)
			aim = transform;
	}

	public override Vector2 GetLocation()
	{
		return base.GetLocation() + new Vector2(aim.position.x, aim.position.z);
	}
	public override bool IsValid()
	{
		return aim && base.IsValid();
	}
}
