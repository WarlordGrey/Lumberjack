using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjackStateSearchingBlock : DefaultLumberjackState
{
	public LumberjackStateSearchingBlock(Lumberjack jack) : base(jack)
	{
		jack.Animator.DoIdle();
	}

	public override void DoAction()
	{
		base.DoAction();


		if (jack.BlocksOfWoodManager.HasResource)
		{
			BlockOfWood block = jack.BlocksOfWoodManager.FindNearest(jack.transform.position);
			jack.NavAgent.SetDestination(block.InteractionPoint);
			jack.UpdateState(new LumberjackStateMovingToTheBlock(jack, block));
		}
		else
		{
			jack.UpdateState(new LumberjackStateSearchingTree(jack));
		}
	}
}
