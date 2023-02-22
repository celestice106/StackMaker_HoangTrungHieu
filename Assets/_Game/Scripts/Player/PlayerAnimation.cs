using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator playerAnim;
    public string currentAnimName;
    // Start is called before the first frame update
    void Start()
    {
        currentAnimName = "Idle";
    }

    public void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            playerAnim.ResetTrigger(animName);
            currentAnimName = animName;
            playerAnim.SetTrigger(currentAnimName);
        }
    }
}
