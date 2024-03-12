using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

	[SerializeField]
	private GameObject followTarget;
	[SerializeField]
	private float followSpeed = 5f;
	[SerializeField]
	private float rotationSpeed = 1f;

	private void LateUpdate()
	{
		transform.position = Vector3.MoveTowards(transform.position, followTarget.transform.position, followSpeed * Time.deltaTime);
		transform.eulerAngles = Vector3.RotateTowards(transform.eulerAngles, followTarget.transform.eulerAngles, rotationSpeed * Time.deltaTime, 1f);
	}

}
