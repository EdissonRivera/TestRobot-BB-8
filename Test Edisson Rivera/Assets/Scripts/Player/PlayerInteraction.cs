using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    //public Score score;
    [SerializeField] int coint;
    [SerializeField] int health;
    [SerializeField] int score; 
    PlayerUI playerUI;
    private void Start()
    {
        playerUI = GetComponent<PlayerUI>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Coin")
        {
            score = score + 10;
            SetUI();
            Destroy(other.gameObject);
        }

        if (other.tag == "Bullet")
        {
            health--;
        }


        if (other.tag == "Cofre")
        {
            Debug.Log("Cofre");
            score = score + 50;
            SetUI();
        }
    }


    void SetUI()
    {
        playerUI.textScore.text = score.ToString();
    }

    public void addScore()
    {
        //score.myDict.Add("Five", coint);
        //score.data();
        //score.AddData("pendeji");
    }

}
