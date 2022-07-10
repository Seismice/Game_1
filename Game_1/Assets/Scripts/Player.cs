using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform AttackStartPosition;

    public GameObject[] AttacksPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RunAttack()
    {
        GetComponent<Animator>().SetTrigger("Attack");

        int index = Random.Range(0, AttacksPrefabs.Length);

        GameObject effect = Instantiate(AttacksPrefabs[index]) as GameObject;
        effect.transform.position = AttackStartPosition.position;
        Destroy(effect, 0.15f);
    }
}
