using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private PlayerAction target;
    [SerializeField] private Vector3 playingModeOffset = new Vector3(0, 10, -10);
    [SerializeField] private Vector3 cheeringModeOffset = new Vector3(5, 5, -5);
    [SerializeField] private float speed = 20f;

    void FixedUpdate()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        if (!target.IsCheering)
        {
            Vector3 stackCountOffset = new Vector3(0, 0.2f, -0.1f) * target.PlayerStack.CollectedBrickCount;
            transform.position = Vector3.Lerp(transform.position, target.transform.position + playingModeOffset + stackCountOffset, Time.fixedDeltaTime * speed);
        }
        else
        {
            Quaternion rotTarget = Quaternion.LookRotation(target.transform.position - this.transform.position);
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotTarget, Time.fixedDeltaTime * speed * 2);
            transform.position = Vector3.Lerp(transform.position, target.transform.position + cheeringModeOffset, Time.fixedDeltaTime * 2);
        }
    }
}
