using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardCreator : MonoBehaviour
{
    [SerializeField] private GameObject RubinPrefab;
    [SerializeField] private GameObject GoldPrefab;
    public int PlayerGold;
    public int PlayerRubin;
    public int PlayerDamage = 10;
    private SpawnMonster _spawnMonster;

    void Start()
    {
        _spawnMonster = GetComponent<SpawnMonster>();
    }

    public void TakeRubin(int rubin)
    {
        PlayerRubin += rubin;
        GameObject rubinObject = Instantiate(RubinPrefab) as GameObject;
        Destroy(rubinObject, 3);
    }

    public void TakeGold(int gold)
    {
        PlayerGold += gold;
        GameObject goldObject = Instantiate(GoldPrefab) as GameObject;
        Destroy(goldObject, 2);

        _spawnMonster.SpawnNewMonster();
    }
}
