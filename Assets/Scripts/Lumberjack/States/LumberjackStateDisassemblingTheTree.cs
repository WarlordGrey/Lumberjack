using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjackStateDisassemblingTheTree : DefaultLumberjackState
{
	private Tree tree;

	public LumberjackStateDisassemblingTheTree(Lumberjack jack, Tree tree) : base(jack)
	{
		this.tree = tree;
	}

	public override void DoAction()
	{
		base.DoAction();

		if(tree == null)
		{
			jack.UpdateState(new LumberjackStateInitial(jack));
			return;
		}
		if (jack.Animator.IsLumbering)
		{
			return;
		}
		if (tree.IsLastAttempt)
		{
			tree.DoFall();
			jack.UpdateState(new LumberjackStateWaitTreeFall(jack, tree));
		}
		else
		{
			tree.TryToDisassemble();
			jack.UpdateState(new LumberjackStateStartDisassembingTheTree(jack, tree));
		}
	}
}
