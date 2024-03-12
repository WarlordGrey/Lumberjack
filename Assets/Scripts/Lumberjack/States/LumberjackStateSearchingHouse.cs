using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjackStateSearchingHouse : DefaultLumberjackState
{

	public LumberjackStateSearchingHouse(Lumberjack jack) : base(jack)
	{
		jack.Animator.DoIdle();
	}

	public override void DoAction()
	{
		base.DoAction();

		jack.NavAgent.destination = jack.House.InteractionPoint;
		jack.UpdateState(new LumberjackStateMovingToTheHouse(jack));
	}
}
