using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDown : MonoBehaviour
{
    AudioSource audioSource;
    Animator animator;
    Image image;
    public float timeTakenDuringLerp = 1f;
    float origin = 0;
    float destination = 360;
    /// <summary>
    /// How far the object should move when 'space' is pressed
    /// </summary>
    public float distanceToMove = 10;

    //Whether we are currently interpolating or not
    public bool _isLerping;


    //The Time.time value when we started the interpolation
    private float _timeStartedLerping;

    /// <summary>
    /// Called to begin the linear interpolation
    /// </summary>
   public void StartLerping()
    {
        animator.SetTrigger("active");
        _isLerping = true;
        _timeStartedLerping = Time.time;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        image = GetComponent<Image>();
    }

    //We do the actual interpolation in FixedUpdate(), since we're dealing with a rigidbody
    void FixedUpdate()
    {
        if (_isLerping)
        {
            //We want percentage = 0.0 when Time.time = _timeStartedLerping
            //and percentage = 1.0 when Time.time = _timeStartedLerping + timeTakenDuringLerp
            //In other words, we want to know what percentage of "timeTakenDuringLerp" the value
            //"Time.time - _timeStartedLerping" is.
            float timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted / timeTakenDuringLerp;

            //Perform the actual lerping.  Notice that the first two parameters will always be the same
            //throughout a single lerp-processs (ie. they won't change until we hit the space-bar again
            //to start another lerp)
            image.fillAmount = Mathf.Lerp(origin, destination, percentageComplete/300);

            //When we've completed the lerp, we set _isLerping to false
            Debug.Log(percentageComplete);
            if (percentageComplete >= 1.0f)
            {
                audioSource.Play();
                animator.SetTrigger("active");
                _isLerping = false;
            }
        }
    }
}
