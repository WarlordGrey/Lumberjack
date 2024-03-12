using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksOfWoodManager : DefaultResourceManager<BlockOfWood>
{
	public void TryToDestroyBlock(BlockOfWood block)
	{
		BlocksOfWoodPool.ReturnPoolable(block);
	}

}
