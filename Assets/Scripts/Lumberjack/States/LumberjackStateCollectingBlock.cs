using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjackStateCollectingBlock : DefaultLumberjackState
{
	private BlockOfWood block;

	public LumberjackStateCollectingBlock(Lumberjack jack, BlockOfWood block) : base(jack)
	{
		this.block = block;
		jack.Animator.DoIdle();
	}

	public override void DoAction()
	{
		base.DoAction();

		jack.BlocksOfWoodManager.RemoveResource(block);
		block.transform.parent = jack.BackpackTransform;
		Vector3 newPos = jack.BackpackTransform.position;
		newPos.y += jack.BlocksBackpack.Count * block.transform.localScale.y / 2;
		block.transform.position = newPos;
		block.transform.eulerAngles = jack.BackpackTransform.eulerAngles;
		jack.BlocksBackpack.Add(block);
		block = null;
		jack.UpdateState(new LumberjackStateInitial(jack));
	}
}
