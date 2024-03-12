using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultLumberjackState
{
	protected Lumberjack jack;

	public DefaultLumberjackState(Lumberjack jack)
	{
		this.jack = jack;
	}

	public virtual void DoAction()
	{

	}

}
