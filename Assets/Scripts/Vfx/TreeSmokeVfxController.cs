using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSmokeVfxController : MonoBehaviour
{
	[SerializeField]
	private ParticleSystem smokeVfx;
	[SerializeField]
	private TreeSmokeVfxCallbackHandler handler;

	public void DoSmoke(IPool<TreeSmokeVfxController> returnPool)
	{
		handler.UpdateReturnPool(returnPool);
		smokeVfx.Play();
	}
}
