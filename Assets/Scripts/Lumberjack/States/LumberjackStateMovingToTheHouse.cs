using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjackStateMovingToTheHouse : DefaultLumberjackState
{
	public LumberjackStateMovingToTheHouse(Lumberjack jack) : base(jack)
	{
		jack.Animator.DoWalk();
	}

	public override void DoAction()
	{
		base.DoAction();

		if (jack.NavAgent.remainingDistance > Lumberjack.POSITION_EPS)
		{
			return;
		}
		jack.UpdateState(new LumberjackStateStoringBlocks(jack));
	}
}
