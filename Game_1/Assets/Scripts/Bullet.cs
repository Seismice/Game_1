using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Health _health;

    public int Damage { get; set; }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_health == null)
        {
            _health = GameObject.FindObjectOfType<Health>();
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
