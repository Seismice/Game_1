using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private int HeroDamage = 10;
    [SerializeField] private float AttackSpeed = 2f;
    void Start()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(AttackSpeed);

        GameObject bullet = Instantiate(BulletPrefab) as GameObject;
        bullet.transform.position = transform.position;
        bullet.GetComponent<Bullet>().Damage = HeroDamage;

        StartCoroutine(Attack());
    }
}
