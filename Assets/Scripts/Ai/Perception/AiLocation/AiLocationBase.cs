﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AiLocationBase : MonoBehaviour {

	public AiLocationBase addLocation;

	protected AiUnitMind mind;
	public void Start()
	{
		mind = GetComponentInParent<AiUnitMind>();
	}

    public Vector3 GetLocation3D()
    {
        Vector2 v = GetLocation();
        return new Vector3(v.x, 0 , v.y);
    }
	public virtual Vector2 GetLocation()
	{
		if (addLocation)
			return addLocation.GetLocation();
		return Vector2.zero;
	}
	public virtual GameObject GetTargetObject()
	{
		return GetTarget().gameObject;
	}
	public virtual AiPerceiveUnit GetTarget()
	{
		return null;
	}
	public virtual bool IsValid()
	{
		return true; // !addLocation || addLocation.IsValid();
	}
}
