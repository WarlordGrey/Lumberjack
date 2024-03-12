using UnityEngine;

public interface IPool<T>
{
	public void CreatePool();
	public T GetPoolable();
	public void ReturnPoolable(T poolable);
}
