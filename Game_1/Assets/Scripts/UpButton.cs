using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpButton : MonoBehaviour
{
    [SerializeField] private bool isRubin;
    [SerializeField] private bool isHero;
    [SerializeField] private GameObject HeroPrefab;
    [SerializeField] private GameObject UpImagePrefab;
    [SerializeField] private TMP_Text DamageText;
    [SerializeField] private TMP_Text PriceText;

    [SerializeField] private int Damage = 10;
    [SerializeField] private int Price = 100;
    [SerializeField] private Image ItemUpDamage;

    private RewardCreator _rewardCreator;
    [SerializeField] private GameObject Game;
    void Start()
    {
        _rewardCreator = Game.GetComponent<RewardCreator>();
        DamageText.text = "+" + Damage.ToString();
        PriceText.text = Price.ToString();
    }

    public void UpClick()
    {
        if (!isRubin && _rewardCreator.PlayerGold >= Price
            || isRubin && _rewardCreator.PlayerRubin >= Price)
        {
            if (!isRubin)
                _rewardCreator.PlayerGold -= Price;
            else
                _rewardCreator.PlayerRubin -= Price;

            if (isHero != true)
            {
                _rewardCreator.PlayerDamage += Damage;
            }
            else
            {
                GameObject hero = Instantiate(HeroPrefab) as GameObject;
                Vector3 heroPosition = new Vector3(Random.Range(3.0f, 7.0f),
                    -1.0f, 0);
                hero.transform.position = heroPosition;
            }


            GameObject upDamageEfect = Instantiate(UpImagePrefab) as GameObject;

            Transform canvas = GameObject.Find("Canvas").transform;

            upDamageEfect.transform.SetParent(canvas);
            upDamageEfect.GetComponent<Image>().sprite = ItemUpDamage.sprite;
            
            Destroy(upDamageEfect, 1);

            if (isHero != true)
            {
                Destroy(gameObject);
            }
        }
    }
}
