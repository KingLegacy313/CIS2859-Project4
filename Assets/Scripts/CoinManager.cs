using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int coinCount;
    public TMP_Text coinText;

    [SerializeField]
    GameObject hiddenPlatPrefab;
    private GameObject hiddenPlat;

    [SerializeField]
    GameObject hiddenPropPrefab;
    private GameObject hiddenProp;

    public GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindWithTag("Manager");
        manager.GetComponent<Winner>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + coinCount;

        if (coinCount == 10 && hiddenPlat == null)
        {
            hiddenPlat = Instantiate(hiddenPlatPrefab) as GameObject;
            hiddenPlat.transform.position = new Vector3(13.8f, 17.38f, 0f);

            hiddenProp = Instantiate(hiddenPropPrefab) as GameObject;
            hiddenProp.transform.position = new Vector3(13.8f, 18.9f, 0f);
        }
    }
}
