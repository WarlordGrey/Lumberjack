using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjackStateInitial : DefaultLumberjackState
{	
	public LumberjackStateInitial(Lumberjack jack) : base(jack)
	{
		jack.Animator.DoIdle();
	}

	public override void DoAction()
	{
		base.DoAction();

		jack.UpdateState(new LumberjackStateSearchingBlock(jack));
	}
}
