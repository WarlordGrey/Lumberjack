using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTreeCreator : MonoBehaviour
{
	[SerializeField]
	private GameObject treePrefab;

	public void CreateRandomTree()
	{
		Vector3 newPos = Vector3.zero;
		float directionX = Random.value > 0.5f ? 1 : -1;
		float directionZ = Random.value > 0.5f ? 1 : -1;
		newPos.x += directionX * Mathf.Clamp((Random.value * 85 + 15), 15, 100) / 2;
		newPos.z += directionZ * Mathf.Clamp((Random.value * 85 + 15), 15, 100) / 2;
		GameObject go = Instantiate(treePrefab, transform);
		go.transform.position = newPos;
	}
}
