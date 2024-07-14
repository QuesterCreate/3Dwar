
using System;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform followTarget, lookTarget;

    public float smoothFollowSpeed;
    public float smoothLookSpeed;

    private void Start()
    {
        transform.position = followTarget.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = followTarget.position;
        Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, smoothFollowSpeed * Time.fixedDeltaTime);
        transform.position = newPosition;

        Vector3 lookDirection = lookTarget.forward;
        Vector3 newDir = Vector3.Lerp(transform.forward, lookDirection, smoothLookSpeed * Time.fixedDeltaTime);
        transform.forward = newDir;
    }
}
