using UnityEngine;
using UnityEngine.UI;

public class FlickerEffect : MonoBehaviour
{
    public Image tabImage; // Drag your "tab" UI image here in the Inspector
    public float flickerSpeed = 1f; // Speed of flickering

    void Update()
    {
        // Flicker alpha using sine wave
        float alpha = Mathf.Abs(Mathf.Sin(Time.time * flickerSpeed));
        
        Color color = tabImage.color;
        color.a = alpha;
        tabImage.color = color;
    }
}
