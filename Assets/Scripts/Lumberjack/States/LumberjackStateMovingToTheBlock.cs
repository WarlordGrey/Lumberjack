using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjackStateMovingToTheBlock : DefaultLumberjackState
{
	private BlockOfWood block;

	public LumberjackStateMovingToTheBlock(Lumberjack jack, BlockOfWood block) : base(jack)
	{
		this.block = block;
		jack.Animator.DoWalk();
	}

	public override void DoAction()
	{
		base.DoAction();

		if (block == null)
		{
			jack.UpdateState(new LumberjackStateInitial(jack));
			return;
		}

		if (jack.NavAgent.remainingDistance > Lumberjack.POSITION_EPS)
		{
			return;
		}
		jack.UpdateState(new LamberjackStateWaitBlockCollection(jack, block));
	}
}
