using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometer : MonoBehaviour
{
    public Text cronotext;
    private void Start() 
    {
        Timer.Start();
    }
    public void Update()
    {
        Timer.Update();
        cronotext.text = Timer.timestring.ToString();
    }
}
