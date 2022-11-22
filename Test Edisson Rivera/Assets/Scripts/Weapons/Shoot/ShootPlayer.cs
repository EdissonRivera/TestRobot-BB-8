using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    public Weaponn _weapon;
    public Transform[] refProyectile;
    private float _timer = 10;
    [SerializeField]internal bool _shoot;
    private void Update()
    {
        if (_shoot)
        {
            for (int i = 0; i < refProyectile.Length; i++)
            {
                _weapon.ShootPlayer(refProyectile[i], ref _timer);

            }
        }
    }

    
}
