using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotShop : MonoBehaviour
{
    public Animator animator;
    public bool needAnim;

    void Start()
    {
        if (needAnim == true)
        {
            animator.SetInteger("VictoryDance", -1);
        }
        else
        {
            animator = GetComponent<Animator>();
            Destroy(animator);
        }
    }
}
