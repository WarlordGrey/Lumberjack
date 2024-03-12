using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOfWood : MonoBehaviour
{
	[SerializeField]
	private Transform interactionPoint;

	public Vector3 InteractionPoint => interactionPoint.transform.position;
	private BlocksOfWoodManager blocksOfWoodManager;

	private void Awake()
	{
        blocksOfWoodManager = GameObject.FindAnyObjectByType<GameManager>().BlocksOfWoodManager;
    }

    public void TryToDestroy()
	{
		blocksOfWoodManager.TryToDestroyBlock(this);
	}

	public void MakeAvailableForCollection()
	{
		blocksOfWoodManager.AddResource(this);
	}
}
