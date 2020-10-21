using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameOver : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag.Equals("GameOver"))
        {
            if(GameManager.gm != null)
            {
                GameManager.gm.GameOver();
            }
            this.gameObject.SetActive(false);
        }
    }
}
