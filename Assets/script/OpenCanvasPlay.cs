using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCanvasPlay : MonoBehaviour
{
    public GameObject panelOption;

    public void ShowOption()
    {
        panelOption.SetActive(true);
    }

    public void HideOption()
    {
        panelOption.SetActive(false);
    }
}
