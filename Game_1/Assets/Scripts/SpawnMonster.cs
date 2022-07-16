using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    [SerializeField] private Transform StartPosition;
    [SerializeField] private Health[] MonstersPrefabs;
    const int FREQUENCYOFMONSTERS = 5;
    private int _count;
    [SerializeField] private RewardCreator _rewardCreator;
    [SerializeField] private UIManager _uIManager;
    [SerializeField] private Timer _timer;
    [SerializeField] private Player _player;
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

        Health monsterObject = Instantiate(MonstersPrefabs[index]);
        monsterObject.InitRewardCreator(_rewardCreator);
        monsterObject.InitUIManager(_uIManager);
        monsterObject.InitTimer(_timer);
        monsterObject.InitPlayer(_player);

        monsterObject.transform.position = StartPosition.position;
    }
}
