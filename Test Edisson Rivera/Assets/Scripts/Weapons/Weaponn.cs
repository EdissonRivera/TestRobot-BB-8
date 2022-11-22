using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon", order = 52)]

public class Weaponn : ScriptableObject
{

    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _frecuenzy;
    [SerializeField] private float _damage;

    public float GetWeaponFrecuenzy()
    {
        return _frecuenzy;
    }
    
    public float GetWeaponDamage()
    {
        return _damage;
    }


    public void ShootBot(Vector3 shootPoint,Vector3 direction,ref float timer)
    {
        timer += Time.deltaTime;
        if (timer >= _frecuenzy)
        {
            timer = 0;
            Bullet instBullet = Instantiate(_bullet, shootPoint, Quaternion.identity);
            instBullet.SetBulletDirection(direction, _damage);
        }
    }


    public void ShootPlayer(Transform refProyectile, ref float timer)
    {
        timer += Time.deltaTime;
        if (timer >= _frecuenzy)
        {
            timer = 0;
            Bullet instBullet = Instantiate(_bullet, refProyectile.transform.position, refProyectile.transform.rotation).GetComponent<Bullet>();
            instBullet.SetBulletPlayer(refProyectile);

            /*
            Rigidbody _bulletRB = Instantiate(_bullet, refProyectile.transform.position, refProyectile.transform.rotation).GetComponent<Rigidbody>();

            _bulletRB.AddForce(refProyectile.forward * 40f, ForceMode.Impulse);
            _bulletRB.AddForce(refProyectile.up * 3f, ForceMode.Impulse);*/
        }
    }

}
