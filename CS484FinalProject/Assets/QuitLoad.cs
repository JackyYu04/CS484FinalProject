using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
       
        Debug.Log("Quit called");
        Application.Quit();
    }
}