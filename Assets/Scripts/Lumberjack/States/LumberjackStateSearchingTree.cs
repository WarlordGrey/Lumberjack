using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjackStateSearchingTree : DefaultLumberjackState
{
	public LumberjackStateSearchingTree(Lumberjack jack) : base(jack)
	{
		jack.Animator.DoIdle();
	}

	public override void DoAction()
	{
		base.DoAction();

		if (jack.BlocksBackpack.Count > 0)
		{
			jack.UpdateState(new LumberjackStateSearchingHouse(jack));
			return;
		}
		if (jack.TreesManager.HasResource)
		{
			Tree tree = jack.TreesManager.FindNearest(jack.transform.position);
			jack.NavAgent.SetDestination(tree.InteractionPoint);
			jack.UpdateState(new LumberjackStateMovingToTheTree(jack, tree));
		}
	}
}
