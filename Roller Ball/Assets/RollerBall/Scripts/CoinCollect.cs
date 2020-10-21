using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinCollect : MonoBehaviour
{
    public int coinValue;
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if(GameManager.gm != null)
            {
                GameManager.gm.CoinCollected(coinValue);
            }
            FindObjectOfType<AudioManager>().Play("CoinSound");
            this.gameObject.SetActive(false);
        }
    }
}
