using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{
    public Slider energySlider;
    public Slider hungerSlider;
    public Slider sanitySlider;

    public void setMax(float val1, float val2, float val3)
    {
        energySlider.maxValue = val1;
        hungerSlider.maxValue = val2;
        sanitySlider.maxValue = val3;
    }
    public void updateBar(float val1, float val2, float val3)
    {
        energySlider.value = val1;
        hungerSlider.value = val2;
        sanitySlider.value = val3;
    }
}
