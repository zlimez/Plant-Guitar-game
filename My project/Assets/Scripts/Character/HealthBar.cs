using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    // Start is called before the first frame update
    public void SetMaxValue(float maxValue) {
        slider.maxValue = maxValue;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetValue(float value) {
        slider.value = value;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
