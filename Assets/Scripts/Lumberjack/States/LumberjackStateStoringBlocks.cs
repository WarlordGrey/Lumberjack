using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjackStateStoringBlocks : DefaultLumberjackState
{
	public LumberjackStateStoringBlocks(Lumberjack jack) : base(jack)
	{
		jack.Animator.DoIdle();
	}

	public override void DoAction()
	{
		base.DoAction();

		foreach (var cur in jack.BlocksBackpack)
		{
			cur.TryToDestroy();
		}
		jack.BlocksBackpack.Clear();
		jack.UpdateState(new LumberjackStateInitial(jack));
	}
}
