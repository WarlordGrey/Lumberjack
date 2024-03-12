using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	private TreesManager treesManager;
	[SerializeField]
	private BlocksOfWoodManager blocksOfWoodManager;

	public TreesManager TreesManager => treesManager;
	public BlocksOfWoodManager BlocksOfWoodManager => blocksOfWoodManager;
}
