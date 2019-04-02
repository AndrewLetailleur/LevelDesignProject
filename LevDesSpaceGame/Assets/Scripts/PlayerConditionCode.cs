using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerConditionCode : MonoBehaviour
{
    public GameObject[] healthCON; //do it under 0, 1, 2, 3
    public int timeSpeed = 1;//to affect speed of battery degration, without adverse effect on time clock.
    private float timeLeft = 1000f;
    private Slider TimeGUI;

    public int HP = 4;
    private int maxHP = 4;
    private float delay = 6F;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        TimeGUI = GameObject.FindGameObjectWithTag("Timer").GetComponent<Slider>();

        for (int i = 0; i < healthCON.Length; i++) {
            healthCON[i].SetActive(false);
        }

        TimeGUI.maxValue = timeLeft;
        TimeGUI.value = timeLeft;
    }

    
    private void Update()
    {
        //contingency error check
        if (player??true)//uses ?? instead of == to check for null reference
            player = GameObject.FindGameObjectWithTag("Player");
        //endif

        timeLeft -= Time.deltaTime * timeSpeed;
        TimeGUI.value = timeLeft;

        if (timeLeft <= 0f)
            HP = 0; HP_Update();//kill the player automatically at 0 Battery left
        //endif
    }

    public void HP_Change (int value) {
        if (HP != 0) {

            HP -= value;

            if (HP > maxHP)
                HP = maxHP;
            else if (HP < 0)
                HP = 0;
            //endif

            HP_Update();//then update HP
        }//so long as Int HP does not equal zero.
    }

    private void HP_Update() {
        switch (HP) {
            default:
                for (int i = 0; i < healthCON.Length; i++)
                {healthCON[i].SetActive(false);}
                break;
            case 3:
                healthCON[0].SetActive(true);
                break;
            case 2:
                healthCON[1].SetActive(true);
                break;
            case 1:
                healthCON[2].SetActive(true);
                break;
            case 0:
                for (int i = 0; i < healthCON.Length; i++)
                { healthCON[i].SetActive(false); }
                healthCON[3].SetActive(true);
                StartCoroutine(LoadScene(delay));
                break;
            //end case
        }//end switch
    }
    
    IEnumerator LoadScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Menu");
    }//loads a new scene, menu so far
}
