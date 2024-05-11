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

    void OnTriggerEnter(Collider  other){
        if(other.gameObject.tag == "GameController"){
            valueManager.increaseProgress = true;
            print("collission enter");
        }
    }

    void OnTriggerExit(Collider  other){
        if(other.gameObject.tag == "GameController"){
            valueManager.increaseProgress = false;
            print("collission exit");
        }
    }

}
