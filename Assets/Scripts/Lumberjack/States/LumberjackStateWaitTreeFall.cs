using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjackStateWaitTreeFall : DefaultLumberjackState
{
	private Tree tree;

	public LumberjackStateWaitTreeFall(Lumberjack jack, Tree tree) : base(jack)
	{
		this.tree = tree;
		jack.Animator.DoIdle();
	}

	public override void DoAction()
	{
		base.DoAction();

		if (tree.IsDead)
		{
			tree.Disassemble();
			tree = null;
			jack.UpdateState(new LumberjackStateSearchingBlock(jack));
		}
	}
}
