using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerRB : MonoBehaviour
{

    //Components.
    Rigidbody rb;

    //Level setting.
    public bool bossArea = false;
    public RigidbodyConstraints freezeAxis = RigidbodyConstraints.FreezePositionZ;


    //Groud detection.
    public float distanceToGround;
    public float distanceToFloor;
    public bool isGrounded = false;
    public bool hasJumpingSpace;
    public float colliderRadius = 0.45f;
    public float slopeAmount = 0.2f;
    public string groundType="";
    public Vector3 groundOffset;

    //Action info.
    public bool isBusy = false;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForGrounded();
        CheckForJumpingSpace();
    }

    private void FixedUpdate()
    {
        LookAtBoss();
    }

    void CheckForGrounded()
    {
        RaycastHit hit;
        var origin = (transform.position + groundOffset);

        if (Physics.SphereCast(origin, colliderRadius, -Vector3.up, out hit, 100f))
        {
            distanceToGround = hit.distance - colliderRadius;
            if (distanceToGround < slopeAmount)
            {
                isGrounded = true;
                groundType = hit.collider.gameObject.tag;
            }
            else
            {
                isGrounded = false;
            }
        }
    }

    void CheckForJumpingSpace()
    {
        RaycastHit hit;
        Vector3 offset = new Vector3(0, 1f, 0);
        var origin = (transform.position + offset);

        if (Physics.SphereCast(origin, colliderRadius, Vector3.up, out hit, 100f))
        {
            distanceToFloor = hit.distance - colliderRadius;
            if (distanceToFloor > slopeAmount)
            {
                hasJumpingSpace = true;
            }
            else
            {
                hasJumpingSpace = false;
            }
        }
        else
        {
            hasJumpingSpace = true;
        }
    }

    public void BeBusy(float timeToBeBusy)
    {
        StartCoroutine(IBeBusy(timeToBeBusy));
    }

    private IEnumerator IBeBusy(float timeToBeBusy)
    {
        isBusy = true;
        yield return new WaitForSeconds(timeToBeBusy);
        isBusy = false;
    }

    private void LookAtBoss()
    {
        if (bossArea)
        {
            Vector3 _target = GameObject.FindGameObjectWithTag("Boss").transform.position;
            _target.y = transform.position.y;
            transform.LookAt(_target);
        }
    }

    #region Gizoms
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 offset = new Vector3(0, 1f, 0);
        Debug.DrawLine((transform.position + offset), (transform.position + offset) - Vector3.up * distanceToGround);
        Gizmos.DrawWireSphere((transform.position + offset) - Vector3.up * distanceToGround, colliderRadius);
    }
    #endregion
}