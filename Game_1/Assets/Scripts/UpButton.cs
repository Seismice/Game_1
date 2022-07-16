using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpButton : MonoBehaviour
{
    [SerializeField] private bool isRubin;
    [SerializeField] private bool isHero;
    [SerializeField] private Hero HeroPrefab;
    [SerializeField] private GameObject UpImagePrefab;
    [SerializeField] private TMP_Text DamageText;
    [SerializeField] private TMP_Text PriceText;

    [SerializeField] private int Damage = 10;
    [SerializeField] private int Price = 100;
    [SerializeField] private Image ItemUpDamage;

    [SerializeField] private RewardCreator Game;
    [SerializeField] private FindCanvas Canvas;
    void Start()
    {
        DamageText.text = "+" + Damage.ToString();
        PriceText.text = Price.ToString();
    }

    public void UpClick()
    {
        if (!isRubin && Game.PlayerGold >= Price
            || isRubin && Game.PlayerRubin >= Price)
        {
            if (!isRubin)
                Game.PlayerGold -= Price;
            else
                Game.PlayerRubin -= Price;

            if (isHero != true)
            {
                Game.PlayerDamage += Damage;
                
            }
            else
            {
                Hero hero = Instantiate(HeroPrefab);
                Vector3 heroPosition = new Vector3(Random.Range(3.0f, 7.0f),
                    -1.0f, 0);
                hero.transform.position = heroPosition;
            }

            GameObject upDamageEfect = Instantiate(UpImagePrefab) as GameObject;

            Transform canvas = Canvas.transform;
            upDamageEfect.transform.SetParent(canvas);
            upDamageEfect.GetComponent<Image>().sprite = ItemUpDamage.sprite;
            
            Destroy(upDamageEfect, 1);

            if (isHero != true)
            {
                Destroy(gameObject);
            }

            GlobalEventManager.ShowUIManager();
        }
    }
}
