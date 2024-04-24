using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float smoothTime = 0.2f;

    public GameObject player;

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        if (player)
        {
            if (target.position.y > -1f)
            {
                Vector3 targetPosition = new Vector3(
                    target.position.x,
                    target.position.y,
                    transform.position.z);

                transform.position = Vector3.SmoothDamp(transform.position,
                    targetPosition, ref velocity, smoothTime);
            }
        }
    }
}
