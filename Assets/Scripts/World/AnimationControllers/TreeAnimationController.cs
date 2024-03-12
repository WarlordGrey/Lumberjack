using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private bool isDead = false;

    public bool IsDead => isDead;

    public void DoFall()
	{
		animator.SetTrigger("Fall");
	}

    public void Fallen()
	{
        isDead = true;
	}
}
