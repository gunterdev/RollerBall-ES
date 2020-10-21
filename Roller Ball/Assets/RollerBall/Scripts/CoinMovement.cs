using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEditor;

public class CoinMovement : MonoBehaviour
{
    //public
    public enum movement{Spin,Horizontal,Vertical};
    public movement move;
    

    //private
        private Vector3 g_CoinTransform;
        [SerializeField]private float coinSpeed;
        [Space(5)]
        [Header("Speed of coin rotation")]
        [SerializeField]private float rotationSpeed;
        [Space(5)]
        [Header("Horizontal distance")]
        [SerializeField]private float maxRightHorizontal;
        [SerializeField]private float maxLeftHorizontal;
        [Space(5)]
        [Header("Vertical distance")]
        [SerializeField]private float maxUpVertical;
        [SerializeField]private float maxDownVertical;

        private bool g_Right=true;
        private bool g_Up=true;
    private void Start() {
        g_CoinTransform = this.transform.position;
    }
    private void Update() 
    {

        switch(move)
        {
            case movement.Spin:
                Rotation();
            break;
            case movement.Horizontal:
                Horizontal();
            break;
            case movement.Vertical:
                Vertical();
            break;
        }
    }
    void Rotation()
    {
        transform.Rotate(0,rotationSpeed*Time.deltaTime,0,Space.Self);
    }

    void Horizontal(){
        if(g_Right){
            transform.Translate(Time.deltaTime*coinSpeed, 0, 0, Space.World);
        }
        else{
            transform.Translate(-Time.deltaTime*coinSpeed, 0, 0, Space.World);
        }
        if(transform.position.x > (g_CoinTransform.x + maxRightHorizontal)){ g_Right = false; }
        else if(transform.position.x < (g_CoinTransform.x - maxLeftHorizontal)){ g_Right = true; }
    }
    void Vertical(){
        if(g_Up){
            transform.Translate(0, Time.deltaTime*coinSpeed, 0, Space.World);
        }
        else{
            transform.Translate(0, -Time.deltaTime*coinSpeed, 0, Space.World);
        }
        if(transform.position.y > (g_CoinTransform.y + maxUpVertical)){ g_Up = false; }
        else if(transform.position.y < (g_CoinTransform.y - maxDownVertical)){ g_Up = true; }
    }
}
