using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int RubinChanse;
    public int MaxHealth = 100;
    public int CurrentHealth = 100;
    public int Gold = 90;

    bool isDead;

    Game _game;


    // Start is called before the first frame update
    void Start()
    {
        _game = GameObject.FindObjectOfType<Game>();

        _game.HealthSlider.maxValue = MaxHealth;
        _game.HealthSlider.value = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetHit(int damage)
    {
        if (isDead)
            return;

        int healh = CurrentHealth - damage;

        if (healh <= 0)
        {
            isDead = true;
            _game.TakeGold(Gold);

            int random = Random.Range(0, 100);
            if (random < RubinChanse)
                _game.TakeRubin(1);

            Destroy(gameObject);
        }

        GetComponent<Animator>().SetTrigger("Hit");

        CurrentHealth = healh;

        _game.HealthSlider.value = CurrentHealth;
    }
}
