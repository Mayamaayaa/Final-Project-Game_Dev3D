using UnityEngine;

public class HideOnSpace : MonoBehaviour
{
    public GameObject instructions; // Drag your UI image GameObject here in Inspector

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            instructions.SetActive(false);
        }
    }
}
