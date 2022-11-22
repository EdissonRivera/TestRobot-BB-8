using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    private GameObject _objective;
    private Vector3 _toObjectiveDirection;

    private void Awake()
    {
        _objective = GameObject.FindGameObjectWithTag("Cofre");
    }

    private void Update()
    {
        _toObjectiveDirection = _objective.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(_toObjectiveDirection);
    }
}
