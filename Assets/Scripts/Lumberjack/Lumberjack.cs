using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Lumberjack : MonoBehaviour
{
	public const float POSITION_EPS = 0.1f;
	public const float ROTATION_EPS = 0.01f;

	[SerializeField]
	private House house;
	[SerializeField]
	private NavMeshAgent agent;
	[SerializeField]
	private Transform backpackTransform;
	[SerializeField]
	private LumberjackAnimationController animator;
	[SerializeField]
	private float blockCollectionTimeout = 0.5f;

	private TreesManager treesManager;
	private BlocksOfWoodManager blocksOfWoodManager;
    private List<BlockOfWood> blocksBackpack = new List<BlockOfWood>();
	private DefaultLumberjackState state;

	public LumberjackAnimationController Animator => animator;
	public NavMeshAgent NavAgent => agent;
	public TreesManager TreesManager => treesManager;
	public BlocksOfWoodManager BlocksOfWoodManager => blocksOfWoodManager;
	public Transform BackpackTransform => backpackTransform;
	public List<BlockOfWood> BlocksBackpack => blocksBackpack;
	public House House => house;
	public float BlockCollectionTimeout => blockCollectionTimeout;

	private void Awake()
	{
		GameManager gm = GameObject.FindAnyObjectByType<GameManager>();
		treesManager = gm.TreesManager;
		blocksOfWoodManager = gm.BlocksOfWoodManager;
	}

	private void Start()
	{
		UpdateState(new LumberjackStateInitial(this));
	}

    private void Update()
    {
		state.DoAction();
    }

	public void UpdateState(DefaultLumberjackState newState)
	{
		state = newState;
	}
}
