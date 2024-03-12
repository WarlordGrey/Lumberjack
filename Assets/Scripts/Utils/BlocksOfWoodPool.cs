using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksOfWoodPool : MonoBehaviour
{
	[SerializeField]
	private GameObject poolablePrefab;
	[SerializeField]
	private int poolSize = 3;
	[SerializeField]
	private int expandSize = 3;

	private DefaultPool<BlockOfWood> blockPool = new DefaultPool<BlockOfWood>();

	public DefaultPool<BlockOfWood> BlockPool => blockPool;

	private void Awake()
	{
		blockPool.Init(transform, poolablePrefab, poolSize, expandSize);
	}
}
