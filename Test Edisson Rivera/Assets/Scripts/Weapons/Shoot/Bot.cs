using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{

    [SerializeField] private Weaponn _weapon;
    [SerializeField] private Transform _shootPoint;

    private GameObject _objective;
    private Vector3 _toObjectiveDirection;

    private float _timer = 10;


    private void Awake()
    {
        _objective = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        _toObjectiveDirection = _objective.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(_toObjectiveDirection, Vector3.up); ;

        _weapon.ShootBot(_shootPoint.position, _toObjectiveDirection.normalized, ref _timer);
    }

}
