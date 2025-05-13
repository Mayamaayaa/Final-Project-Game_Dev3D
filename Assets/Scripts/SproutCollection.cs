using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // ✅ Add this for TextMeshPro support

public class SproutCollection : MonoBehaviour
{
    private int sprout = 0;

    public GameObject portal;
    public TextMeshProUGUI sproutText;    // ✅ Use the TMP type
    public GameObject portalText;         // This will be shown when all sprouts are collected

    private void Start()
    {
        if (portalText != null)
            portalText.SetActive(false); // Hide the portal message at the beginning
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sprout"))
        {
            sprout++;
            Debug.Log("Sprout " + sprout);
            Destroy(other.gameObject);
            UpdateSproutUI();

            if (sprout == 3)
            {
                if (portal != null)
                    portal.SetActive(true); // Show the portal

                if (portalText != null)
                    portalText.SetActive(true); // Show the portal message
            }
        }
    }

    void UpdateSproutUI()
    {
        if (sproutText != null)
        {
            sproutText.text = "Sprout " + sprout + " / 3";
        }
    }
}
