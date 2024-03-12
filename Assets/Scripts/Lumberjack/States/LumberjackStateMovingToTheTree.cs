using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjackStateMovingToTheTree : DefaultLumberjackState
{
	private Tree tree;

	public LumberjackStateMovingToTheTree(Lumberjack jack, Tree tree) : base(jack)
	{
		this.tree = tree;
		jack.Animator.DoWalk();
	}

	public override void DoAction()
	{
		base.DoAction();

		if (tree == null)
		{
			jack.UpdateState(new LumberjackStateInitial(jack));
			return;
		}
		if (jack.NavAgent.remainingDistance > Lumberjack.POSITION_EPS)
		{
			jack.NavAgent.destination = tree.InteractionPoint;
			return;
		}
		jack.UpdateState(new LumberjackStateRotateTowardsTree(jack, tree));
	}
}
