using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private Bullet BulletPrefab;
    [SerializeField] private int HeroDamage = 10;
    [SerializeField] private float AttackSpeed = 2f;
    void Start()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(AttackSpeed);

        Bullet bullet = Instantiate(BulletPrefab);
        bullet.transform.position = transform.position;
        bullet.Damage = HeroDamage;

        StartCoroutine(Attack());
    }
}
