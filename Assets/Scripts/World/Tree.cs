using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
	[SerializeField]
	private int defaultDisassembleAttempts = 3;
	[SerializeField]
    private Transform blocksPointsRoot;
	[SerializeField]
	private Transform interactionPoint;
	[SerializeField]
	private TreeAnimationController animator;
	[SerializeField]
	private ParticleSystem lumberingVfx;

	private List<Vector3> blockPoints = new List<Vector3>();
	private IPool<BlockOfWood> blocksPool;
	private TreesManager treesManager;
	public Vector3 InteractionPoint => interactionPoint.transform.position;
	private int disassembleAttempts;

	public bool IsLastAttempt => disassembleAttempts == 1;
	public bool IsDead => animator.IsDead;

	public List<Vector3> BlockPoints
	{
		get
		{
			if(blockPoints.Count == 0)
			{
				foreach (Transform child in blocksPointsRoot.transform)
				{
					blockPoints.Add(child.position);
				}
			}
			return blockPoints;
		}
	}

	private void Awake()
	{
		treesManager = GameObject.FindAnyObjectByType<GameManager>().TreesManager;
		blocksPool = treesManager.BlocksOfWoodPool;
		treesManager.AddResource(this);
	}

	private void Start()
	{
		disassembleAttempts = defaultDisassembleAttempts;
	}

	public void TryToDisassemble()
	{
		disassembleAttempts--;
		lumberingVfx.Play();
	}

	public void DoFall()
	{
		lumberingVfx.Play();
		TreeSmokeVfxController smokeVfx = treesManager.SmokePool.GetPoolable();
		smokeVfx.transform.position = transform.position;
		smokeVfx.DoSmoke(treesManager.SmokePool);
		animator.DoFall();
	}

	public void Disassemble()
    {
        for (int i = 0; i < BlockPoints.Count; i++)
		{
			BlockOfWood block = blocksPool.GetPoolable();
			block.transform.parent = null;
			block.transform.position = BlockPoints[i];
			block.transform.eulerAngles = transform.eulerAngles;
			block.MakeAvailableForCollection();
		}
		Destroy(gameObject);
	}

	private void OnDestroy()
	{
		treesManager.RemoveResource(this);
	}

}
