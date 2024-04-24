using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Loser : MonoBehaviour
{
    public TMP_Text loseTxt;

    [SerializeField]
    GameObject youLosePrefab;
    private GameObject youLose;

    public GameObject player;

    void Update()
    {


        if (!player && !youLose)
            youLose = Instantiate(youLosePrefab) as GameObject;
        loseTxt.text = "Game Over";
    }
}