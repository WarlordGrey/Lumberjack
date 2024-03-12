using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjackStateStartDisassembingTheTree : DefaultLumberjackState
{
	private Tree tree;

	public LumberjackStateStartDisassembingTheTree(Lumberjack jack, Tree tree) : base(jack)
	{
		this.tree = tree;
		jack.Animator.DoLumbering();
	}

	public override void DoAction()
	{
		base.DoAction();

		jack.Animator.ResetLumbering();
		jack.UpdateState(new LumberjackStateDisassemblingTheTree(jack, tree));
	}
}
