using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public ValueManager valueManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EnergyDrink")
        {
            valueManager.DrinkEnergy();
        }
        if(other.gameObject.tag == "Food")
        {
            valueManager.EatFood();
        }
        if(other.gameObject.tag == "Water")
        {
            valueManager.DrinkWater();
        }
    }
   
}
