using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeVfxPool : MonoBehaviour
{
	[SerializeField]
	private GameObject poolablePrefab;
	[SerializeField]
	private int poolSize = 3;
	[SerializeField]
	private int expandSize = 3;

	private DefaultPool<TreeSmokeVfxController> smokePool = new DefaultPool<TreeSmokeVfxController>();

	public DefaultPool<TreeSmokeVfxController> SmokePool => smokePool;

	private void Awake()
	{
		smokePool.Init(transform, poolablePrefab, poolSize, expandSize);
	}
}
