using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowSideways : MonoBehaviour
{
    [SerializeField] Transform target; // The target object the camera will follow
    [SerializeField] float smoothing = 5f; // How smoothly the camera catches up with its target
    [SerializeField] Vector3 offsetPosition = new Vector3(0, 2, -5); // Position offset from the target
    [SerializeField] bool followRotation = true; // Should the camera also follow the target's rotation?
    [SerializeField] float rotationSmoothing = 2f; // How smoothly the camera matches the target's rotation

     void Start()
    {
        // Ensuring there is a target assigned to prevent null reference errors
        if(target == null)
        {
            Debug.LogError("CameraFollow script requires a target assigned to function correctly.");
            enabled = false; // Disable script to prevent errors
            return;
        }

        // Adjust this offset if you want the camera to start at a different initial position relative to the target.
        transform.position = target.position + offsetPosition;
    }

    void LateUpdate()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        if(target == null) return;

        // Move the camera towards the target's position, offset by the specified amount.
        Vector3 desiredPosition = target.position + offsetPosition;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothing * Time.deltaTime);
        transform.position = smoothedPosition;

        if (followRotation)
        {
            // Rotate the camera to match the target's rotation smoothly.
            Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothing * Time.deltaTime);
        }
    }
}
