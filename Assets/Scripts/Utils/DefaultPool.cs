using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultPool<T> : IPool<T> where T : MonoBehaviour
{
	private Transform parent;
	private GameObject poolablePrefab;
	private int poolSize;
	private int expandSize;
	private bool isCreated = false;
	private List<T> allPoolableList = new List<T>();
	private Stack<T> poolableStack = new Stack<T>();

	public void CreatePool()
	{
		if (isCreated)
		{
			return;
		}
		isCreated = true;
		for (int i = 0; i < poolSize; i++)
		{
			CreateSingleObject();
		}
	}

	public T GetPoolable()
	{
		if(poolableStack.Count <= 0)
		{
			ExpandPool();
		}
		T retVal = poolableStack.Pop();
		retVal.gameObject.SetActive(true);
		return retVal;
	}

	public void ReturnPoolable(T poolable)
	{
		if (allPoolableList.Contains(poolable))
		{
			poolable.transform.parent = parent;
			poolable.transform.position = Vector3.zero;
			poolable.gameObject.SetActive(false);
			poolableStack.Push(poolable);
		}
	}

	private void ExpandPool()
	{
		for (int i = 0; i < expandSize; i++)
		{
			CreateSingleObject();
		}
	}

	private void CreateSingleObject()
	{
		GameObject newGO = GameObject.Instantiate(poolablePrefab);
		newGO.transform.parent = parent;
		newGO.SetActive(false);
		allPoolableList.Add(newGO.GetComponent<T>());
		poolableStack.Push(newGO.GetComponent<T>());
	}

	public void Init(Transform parent, GameObject poolablePrefab, int poolSize, int expandSize)
	{
		this.parent = parent;
		this.poolablePrefab = poolablePrefab;
		this.poolSize = poolSize;
		this.expandSize = expandSize;
		CreatePool();
	}
}
