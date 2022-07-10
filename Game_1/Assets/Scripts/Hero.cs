using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public GameObject BulletPrefab;
    public int HeroDamage = 10;
    public float AttackSpeed = 2f;
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
