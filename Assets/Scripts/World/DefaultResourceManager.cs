using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultResourceManager<T> : MonoBehaviour where T : MonoBehaviour
{
	[SerializeField]
	protected BlocksOfWoodPool blocksOfWoodPool;
	public IPool<BlockOfWood> BlocksOfWoodPool => blocksOfWoodPool.BlockPool;

	protected List<T> availableResource = new List<T>();
	public bool HasResource => availableResource.Count > 0;

	public void AddResource(T resource)
	{
		availableResource.Add(resource);
	}

	public void RemoveResource(T resource)
	{
		availableResource.Remove(resource);
	}

	public T FindNearest(Vector3 currentPosition)
	{
		float minDistance = float.MaxValue;
		float curDistance;
		T foundVal = null;
		foreach (var cur in availableResource)
		{
			curDistance = Vector3.Magnitude(cur.transform.position - currentPosition);
			if (minDistance > curDistance)
			{
				minDistance = curDistance;
				foundVal = cur;
			}
		}
		return foundVal;
	}
}
