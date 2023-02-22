using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    
    private Vector3 startPosition;
    private PlayerMovement PlayerMovement;

    void Awake()
    {
        PlayerMovement = GetComponent<PlayerMovement>();
    }
    void Update()
    {
       /* if (
            player.PlayerMovement.IsMoving ||
            player.PlayerAction.IsCheering ||
            LevelManager.Instance.IsTransitioning)
        {
            return;*/
        //}
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 endPosition = Input.mousePosition;
            Vector3 swipeDirection = endPosition - startPosition;
            if (swipeDirection.magnitude > GameConfig.Player.Input.SENSITIVITY)
            {
                startPosition = endPosition;
                Debug.Log("Clicked");
                MovementExecute(swipeDirection);
            }
        }
    }

    void MovementExecute(Vector3 swipeDirection)
    {
        if (PlayerMovement.isMoving)
            return;
        PlayerMovement.enumDirection movingDirection;
        if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
        {
            if (swipeDirection.x < 0)
            {
                movingDirection = PlayerMovement.enumDirection.left;
            }
            else
            {
                movingDirection = PlayerMovement.enumDirection.right;
            }
        }
        else
        {
            if (swipeDirection.y < 0)
            {
                movingDirection = PlayerMovement.enumDirection.back;
            }
            else
            {
                movingDirection = PlayerMovement.enumDirection.forward;
            }
        }
        PlayerMovement.GetDirection(movingDirection);
        if(!PlayerMovement.WallDetect())
        {
            Debug.Log("Move");
            PlayerMovement.isMoving = true;
        }
    }
}
