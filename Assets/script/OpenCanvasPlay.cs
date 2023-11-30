using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCanvasPlay : MonoBehaviour
{
    // Reference to your Canvas GameObject
    public GameObject panelOption;

    // Use this method to show the panel

    public void ShowOption()
    {
        panelOption.SetActive(true);
    }

    public void HideOption()
    {
        panelOption.SetActive(false);
    }
}
