using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControls : MonoBehaviour
{
   [SerializeField] float controlSpeed = 10f;
   [SerializeField] float xRange = 10f;
   [SerializeField] float yRange = 7f;
   [SerializeField] GameObject[] lasers;
   
   [SerializeField] float positionPitchFactor = -2f;
   [SerializeField] float controlPitchFactor = -15f;
   [SerializeField] float positionYawFactor = 2f;
   [SerializeField] float controlRollFactor = -20f;

   

    float xThrow, yThrow;
    
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    
    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        
        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x *positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler( pitch, yaw, roll);
    }
    
    void ProcessTranslation()
    { 
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        
        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3 (clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
            if (Input.GetButton("Fire1"))

            {
                ActiveLasers();
            }
            else
            {
                DeactivateLasers();
            }
    
    }

    void ActiveLasers()
    {
        // for each ofthe lasers that we have, turn them on (activate them)
    }

    void DeactivateLasers()
    {
        
    }
}
