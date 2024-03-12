using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesManager : DefaultResourceManager<Tree>
{
	[SerializeField]
	private SmokeVfxPool smokeVfxPool;

	public IPool<TreeSmokeVfxController> SmokePool => smokeVfxPool.SmokePool;
}
