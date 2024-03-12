using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjackStateRotateTowardsTree : DefaultLumberjackState
{
	private Tree tree;

	public LumberjackStateRotateTowardsTree(Lumberjack jack, Tree tree) : base(jack)
	{
		this.tree = tree;
		jack.Animator.DoIdle();
	}

	public override void DoAction()
	{
		base.DoAction();

		Vector3 rotationAngle = tree.transform.eulerAngles;
		rotationAngle.y += 180;

		if (Vector3.Magnitude(jack.transform.eulerAngles - rotationAngle) > Lumberjack.ROTATION_EPS)
		{
			jack.transform.eulerAngles = Vector3.RotateTowards(jack.transform.eulerAngles, rotationAngle, Time.deltaTime, 1f);
		}
		else
		{
			jack.UpdateState(new LumberjackStateStartDisassembingTheTree(jack, tree));
		}
	}
}
