using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private RectTransform bar;
    private ValueManager values;

    // Start is called before the first frame update
    void Start()
    {
        values = FindObjectOfType<ValueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        bar.offsetMax = new Vector2(values.progress * 10 - 500, bar.offsetMax.y);
    }
}
