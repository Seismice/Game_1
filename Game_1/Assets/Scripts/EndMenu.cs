using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public TMP_Text Score;
    public TMP_Text RecordScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowEndGame(int gold)
    {
        Score.text = gold.ToString();

        if(SettingClass.GoldRecord < gold)
        {
            SettingClass.GoldRecord = gold;
        }

        RecordScore.text = SettingClass.GoldRecord.ToString();
    }

    public void ButtonRestartClick()
    {
        SceneManager.LoadScene("Main_2");
    }
}
