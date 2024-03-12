using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSmokeVfxCallbackHandler : MonoBehaviour
{
	[SerializeField]
	private TreeSmokeVfxController controller;

	private IPool<TreeSmokeVfxController> returnPool;

	public void UpdateReturnPool(IPool<TreeSmokeVfxController> returnPool)
	{
		this.returnPool = returnPool;
	}

	public void OnParticleSystemStopped()
	{
		returnPool.ReturnPoolable(controller);
	}
}
