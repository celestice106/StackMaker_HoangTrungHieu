using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : Player
{
    [SerializeField] private Transform animTransform;
    [SerializeField] private GameObject openedChest;
    [SerializeField] private GameObject closedChest;

    private Player player;
    private Rigidbody rb;
    public bool IsCheering => player.PlayerAnimation.currentAnimName == "Cheer";

    void Awake()
    {
        OnInit();
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Brick":
                {
                    TakeBrick(other.gameObject);
                    break; 
                }
            case "Brick Taker":
                {
                    DropBrick(other.gameObject);
                    break; 
                }
            case "Finish zone":
                {
                    Cheer();
                    break;
                }
            case "Chest":
                {
                    OpenChest();
                    break;
                }
        }
    }
    void OnInit()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
        closedChest.SetActive(true);
    }

    void TakeBrick(GameObject brick)
    {
        ChangeHighLevel(true);
        Jump();
        player.PlayerStack.AddBrick(brick);
    }

    void DropBrick(GameObject brickTaker)
    {
        if (player.PlayerStack.CollectedBrickCount == 0)
        {
            PlayerMovement.Stop();
            /*StopMovingAt(transform.position);
            bool isStopAtWinZone = brickTaker.transform.parent.CompareTag(GameTag.WINZONE);
            if (isStopAtWinZone)
            {
                UIManager.Instance.ActiveWonPanel();
            }
            else
            {
                LevelManager.Instance.RestartPlayingLevel();
            }*/
        }
        brickTaker.transform.GetChild(0).gameObject.SetActive(true);
        brickTaker.GetComponent<BoxCollider>().enabled = false;
        ChangeHighLevel(false);
        player.PlayerStack.RemoveBrick();
    }

    void ChangeHighLevel(bool isIncrease)
    {
        Vector3 oldPos = animTransform.position;
        Vector3 newPos = oldPos + new Vector3(0, GameConstant.Brick.THICKNESS * (isIncrease ? 1 : -1), 0);
        animTransform.position = newPos;
    }
    public void Idle()
    {
        if (player.PlayerAnimation.currentAnimName == "Cheer")
        {
            return;
        }
        player.PlayerAnimation.ChangeAnim("Idle");
    }
    public void Jump()
    {
        if (player.PlayerAnimation.currentAnimName == "Cheer")
        {
            return;
        }
        player.PlayerAnimation.ChangeAnim("Jump");
    }
    public void Cheer()
    {
        player.PlayerAnimation.ChangeAnim("Cheer");
    }

    public void OpenChest()
    {
        UIManager.instance.OnFinishedLevel();
        closedChest.SetActive(false);
        openedChest.SetActive(true);
    }

}