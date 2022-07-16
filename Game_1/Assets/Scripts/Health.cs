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
    private Timer _timer;
    private Player _player;
    void Start()
    {
        _uIManager.HealthSlider.maxValue = MaxHealth;
        _uIManager.HealthSlider.value = MaxHealth;
    }

    public void InitRewardCreator(RewardCreator rewardCreator)
    {
        _rewardCreator = rewardCreator;
    }

    public void InitUIManager(UIManager uIManager)
    {
        _uIManager = uIManager;
    }

    public void InitTimer(Timer timer)
    {
        _timer = timer;
    }

    public void InitPlayer(Player player)
    {
        _player = player;
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

            GlobalEventManager.ShowUIManager();
        }

        GetComponent<Animator>().SetTrigger("Hit");

        CurrentHealth = healh;

        _uIManager.HealthSlider.value = CurrentHealth;
    }

    void OnMouseDown()
    {
        if (_timer.IsEndGame)
            return;
        GetHit(_rewardCreator.PlayerDamage);

        _player.RunAttack();
    }
}
