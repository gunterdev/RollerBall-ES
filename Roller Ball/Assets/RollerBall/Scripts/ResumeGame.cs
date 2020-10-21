using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeGame : MonoBehaviour
{
    public void Resume()
    {
        if(GameManager.gm != null)
        {
            GameManager.gm.GamePause();
        }
    }
}
