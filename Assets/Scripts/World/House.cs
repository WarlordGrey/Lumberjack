using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField]
    private Transform interactionPoint;

    public Vector3 InteractionPoint => interactionPoint.transform.position;
}
