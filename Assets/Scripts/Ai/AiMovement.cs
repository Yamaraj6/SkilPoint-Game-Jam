using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour
{

	public float maximalMovementSpeed = float.PositiveInfinity;
	public float maximalRotationSpeed = float.PositiveInfinity;


	[Range(0.0f, 1.0f)]
	public float positionDamping = 0.0f;
	[Range(0.0f, 1.0f)]
	public float rotationDamping = 0.0f;

	public float addictionalRotation = 0.0f;

	Vector2 influenceRotation;
	Vector2 influencePosition;

	Rigidbody body;
    CharacterControllerRB groundCheck;

	public void Start()
	{
		body = GetComponent<Rigidbody>();
        groundCheck = GetComponentInChildren<CharacterControllerRB>();
	}

	private void Update()
	{
	}

    private void FixedUpdate()
	{

        if (groundCheck.isGrounded)
        {
            if (influencePosition.sqrMagnitude > maximalMovementSpeed * maximalMovementSpeed)
            {
                Vector2 v = influencePosition.normalized * maximalMovementSpeed * Time.fixedDeltaTime;
                body.AddForce(new Vector3(v.x, 0, v.y));
            }
            else
            {
                Vector2 v = influencePosition * Time.fixedDeltaTime;
                body.AddForce(new Vector3(v.x, 0, v.y));
            }
        }
        else
        {
            influencePosition = Vector2.zero;
        }

        //Debug.Log((groundCheck.isGrounded));

		influencePosition *= positionDamping;
		influenceRotation *= rotationDamping;
	}



    #region Apply
    public void SetRotation(float rotation)
    {
        body.rotation = Quaternion.Euler(0, rotation, 0);
    }


	public void ApplyInfluence(Vector2 inf)
	{
		influencePosition += inf;
        body.rotation = Quaternion.Euler(0, Vector2.Angle(Vector2.right, inf) + addictionalRotation, 0);
    }
	public void ApplyInfluencePosition(Vector2 inf)
	{
		influencePosition += inf;
	}
	public void ApplyInfluenceRotation(Vector2 inf)
	{
		influenceRotation += inf;
        body.rotation = Quaternion.Euler(0, Vector2.Angle(Vector2.right, inf) + addictionalRotation, 0);
    }

	public void ApplyInfluencePoint(Vector2 point, 
		float movementSpeed = 1000.0f, float rotationSpeed = 100.0f, 
		float stopDistance = 0.0f)
	{
		Vector2 inf = (point - (Vector2)transform.position);

		float sqMag = inf.sqrMagnitude;
		inf.Normalize();
		if (sqMag > stopDistance * stopDistance)
			influencePosition += inf * movementSpeed;

        body.rotation = Quaternion.Euler(0, Vector2.Angle(Vector2.right, inf) + addictionalRotation, 0);
    }
	public void ApplyInfluencePointPosition(Vector2 point, float movementSpeed = 1000.0f, float stopDistance = 0.0f)
	{
		Vector2 inf = (point - (Vector2)transform.position);
		if (inf.sqrMagnitude < stopDistance * stopDistance)
			return;
		inf.Normalize();
		influencePosition += inf * movementSpeed;
	}
	public void ApplyInfluencePointRotation(Vector2 point, float rotationSpeed = 100.0f)
	{
		Vector2 inf = (point - (Vector2)transform.position);
        body.rotation = Quaternion.Euler(0, Vector2.Angle(Vector2.right, inf) + addictionalRotation, 0);
    }
#endregion Apply

}
