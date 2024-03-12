using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjackAnimationController : MonoBehaviour
{
	[SerializeField]
	private Animator animator;
	[SerializeField]
	private Transform modelTransform;

	private float lumberingTimeout = 1f;
	private float currentLumberingTimeout;
	public bool IsLumbering => currentLumberingTimeout > 0;
	private Vector3 savedModelTransformPosition;

	private void Awake()
	{
		savedModelTransformPosition = modelTransform.localPosition;
		InitLumberingTimeout();
	}

	private void Start()
	{
		currentLumberingTimeout = -1;
	}

	private void Update()
	{
		if (currentLumberingTimeout > 0)
		{
			currentLumberingTimeout -= Time.deltaTime;
		}
	}

	private void LateUpdate()
	{
		modelTransform.transform.localEulerAngles = Vector3.zero;
		modelTransform.transform.localPosition = savedModelTransformPosition;
	}

	private void UpdateTriggers(string newTrigger)
	{
		animator.ResetTrigger("Idle");
		animator.ResetTrigger("Lumbering");
		animator.ResetTrigger("Walk");
		animator.SetTrigger(newTrigger);
	}

	public void DoIdle()
	{
		UpdateTriggers("Idle");
	}

	public void DoWalk()
	{
		UpdateTriggers("Walk");
	}

	public void DoLumbering()
	{
		UpdateTriggers("Lumbering");
	}

	public void ResetLumbering()
	{
		currentLumberingTimeout = lumberingTimeout;
	}

	private void InitLumberingTimeout()
	{
		AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
		foreach (AnimationClip clip in clips)
		{
			switch (clip.name)
			{
				case "Lumbering":
					lumberingTimeout = clip.length;
					break;
				default:
					break;
			}
		}
	}
}
