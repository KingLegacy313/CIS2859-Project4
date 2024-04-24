using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Winner : MonoBehaviour
{
    public TMP_Text youWinTxt;

    [SerializeField]
    GameObject youWinPrefab;
    public GameObject youWin;

    public GameObject boss;

    public GameObject player;

    private bool isCreated = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        player.GetComponent<PlayerMove>().enabled = true;
    }

    void Update()
    {
        if (!isCreated)
        {
            player.GetComponent<PlayerMove>().enabled = false;
            youWin = Instantiate(youWinPrefab) as GameObject;
            youWinTxt.text = "You Win!";
            isCreated = true;
        }
    }
}
