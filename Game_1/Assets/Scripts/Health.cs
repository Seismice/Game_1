using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private int RubinChanse;
    [SerializeField] private int MaxHealth = 100;
    [SerializeField] private int CurrentHealth = 100;
    [SerializeField] private int Gold = 90;

    private bool isDead;

    private UIManager _uIManager;
    private RewardCreator _rewardCreator;
    void Start()
    {
        _uIManager = GameObject.FindGameObjectWithTag("GameTag").GetComponent<UIManager>();
        _rewardCreator = GameObject.FindGameObjectWithTag("GameTag").GetComponent<RewardCreator>();
        _uIManager.HealthSlider.maxValue = MaxHealth;
        _uIManager.HealthSlider.value = MaxHealth;
    }

    public void GetHit(int damage)
    {
        if (isDead)
            return;

        int healh = CurrentHealth - damage;

        if (healh <= 0)
        {
            isDead = true;
            _rewardCreator.TakeGold(Gold);

            int random = Random.Range(0, 100);
            if (random < RubinChanse)
                _rewardCreator.TakeRubin(1);

            Destroy(gameObject);
        }

        GetComponent<Animator>().SetTrigger("Hit");

        CurrentHealth = healh;

        _uIManager.HealthSlider.value = CurrentHealth;
    }
}
