using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int _speed = 10;
    private Rigidbody _bulletRB;
    private float _damage;
    private void Awake()
    {
        _bulletRB = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //_bulletRB.velocity = new Vector3(0,0,3) * _speed; 
        //Destroy(gameObject, 2);

    }

    public void SetBulletDirection(Vector3 direction, float damage)
    {
        _bulletRB.velocity = direction * _speed;
        _damage = damage;
    }


    public void SetBulletPlayer(Transform refProyectile)
    {
        _bulletRB.AddForce(refProyectile.forward * 40f, ForceMode.Impulse);
        _bulletRB.AddForce(refProyectile.up * 3f, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

}
