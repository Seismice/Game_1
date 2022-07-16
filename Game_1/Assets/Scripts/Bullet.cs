using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Health _health;

    public int Damage { get; set; }
    
    void Update()
    {
        if (_health == null)
        {
            _health = GameObject.FindGameObjectWithTag("MonsterTag").GetComponent<Health>();
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position,
                _health.transform.position,
                Time.deltaTime * 15);

            if(Vector2.Distance(transform.position, _health.transform.position) < 0.1f)
            {
                _health.GetHit(Damage);

                Destroy(gameObject);
            }
        }
    }
}
