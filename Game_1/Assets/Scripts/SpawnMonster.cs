using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    [SerializeField] private Transform StartPosition;
    [SerializeField] private GameObject[] MonstersPrefabs;
    const int FREQUENCYOFMONSTERS = 5;
    private int _count;
    void Start()
    {
        SpawnNewMonster();

    }

    public void SpawnNewMonster()
    {
        _count++;

        int randomMaxValue = _count / FREQUENCYOFMONSTERS + 1;

        if (randomMaxValue >= MonstersPrefabs.Length)
            randomMaxValue = MonstersPrefabs.Length;

        int index = Random.Range(0, randomMaxValue);

        GameObject monsterObject = Instantiate(MonstersPrefabs[index]) as GameObject;

        monsterObject.transform.position = StartPosition.position;
    }

}
