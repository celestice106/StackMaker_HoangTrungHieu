using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private float speed = 10f;
    private PlayerAnimation PlayerAnimation;
    private enumDirection movingDirection;
    public bool isMoving;
    public enum enumDirection { forward, back, right, left, non_direction }
    public Vector3[] Direction = { Vector3.forward, Vector3.back, Vector3.right, Vector3.left, Vector3.zero };
    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    void OnInit()
    {
        PlayerAnimation = GetComponent<PlayerAnimation>();
        isMoving = false;
    }

    private void FixedUpdate()
    {
        if (movingDirection == enumDirection.non_direction)
        {
            return;
        }

        Move();

    }

    public Vector3 SetDirection(enumDirection direction)
    {
        return Direction[(int)direction];
    }
    public void GetDirection(enumDirection direction)
    {
        movingDirection = direction;
    }

    public bool WallDetect()
    {
        Vector3 offset = (SetDirection(movingDirection) + new Vector3(0, 1, 0) * 0.3f) * 0.7f;

        RaycastHit hit;
        Physics.Raycast(transform.position + offset, Vector3.down, out hit, Mathf.Infinity, wallLayer);
        return hit.collider != null;
        
    }


    public void Move()
    {
        if (isMoving == true)
        {
            transform.Translate(SetDirection(movingDirection) * speed * Time.deltaTime);
        }
        if (WallDetect())
        {
            Debug.Log("hit wall");

            Stop();
        }
    }

    public void Stop()
    {
        isMoving = false;
        movingDirection = enumDirection.non_direction;
        PlayerAnimation.ChangeAnim("Idle");
        Debug.Log("Stop");
        return;
    }
}
