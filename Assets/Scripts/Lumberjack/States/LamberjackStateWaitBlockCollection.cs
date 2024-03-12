using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LamberjackStateWaitBlockCollection : DefaultLumberjackState
{
	private BlockOfWood block;

	private float collectionTimeout;

	public LamberjackStateWaitBlockCollection(Lumberjack jack, BlockOfWood block) : base(jack)
	{
		this.block = block;
		jack.Animator.DoIdle();
		collectionTimeout = jack.BlockCollectionTimeout;
	}

	public override void DoAction()
	{
		base.DoAction();

		if (block == null)
		{
			jack.UpdateState(new LumberjackStateInitial(jack));
			return;
		}
		if(collectionTimeout > 0)
		{
			collectionTimeout -= Time.deltaTime;
		}
		else
		{
			jack.UpdateState(new LumberjackStateCollectingBlock(jack, block));
		}
	}
}
