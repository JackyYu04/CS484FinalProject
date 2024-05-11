using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private RectTransform progressBar;
    [SerializeField] private RectTransform timeBar;
    private ValueManager values;

    // Start is called before the first frame update
    void Start()
    {
        values = FindObjectOfType<ValueManager>();
        if(values == null ) {
            Debug.Log("HELP");
        }
    }

    // Update is called once per frame
    void Update()
    {
        progressBar.offsetMax = new Vector2(values.progress * 10 - 500, progressBar.offsetMax.y);
        timeBar.offsetMax = new Vector2(values.timer * 1000 / values.startingTime - 500, timeBar.offsetMax.y);
    }
}
