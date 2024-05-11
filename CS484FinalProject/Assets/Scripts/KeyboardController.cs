using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    // Start is called before the first frame update

    public ValueManager valueManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision  other){
        if(other.gameObject.tag == "GameController"){
            valueManager.increaseProgress = true;
        }
    }

    void OnCollisionExit(Collision  other){
        if(other.gameObject.tag == "GameController"){
            valueManager.increaseProgress = false;
        }
        
    }
}
