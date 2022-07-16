using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform AttackStartPosition;

    [SerializeField] private GameObject[] AttacksPrefabs;

    public void RunAttack()
    {
        GetComponent<Animator>().SetTrigger("Attack");

        int index = Random.Range(0, AttacksPrefabs.Length);

        GameObject effect = Instantiate(AttacksPrefabs[index]) as GameObject;
        effect.transform.position = AttackStartPosition.position;
        Destroy(effect, 0.15f);
    }
}
