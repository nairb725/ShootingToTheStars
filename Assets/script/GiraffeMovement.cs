using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiraffeMovement : MonoBehaviour
{

    public Transform pointDeDepart;
    public Transform pointArrivee;
    public float dureeDuDeplacement = 5f;

    private float tempsPasse = 0f;
    private bool estEnDeplacement = false;

    void Update()
    {
        bool GiraffeFighting = GameManager.Instance.GiraffeReady;

            if (GiraffeFighting && !estEnDeplacement)
            {
                estEnDeplacement = true;
                tempsPasse = 0f;
            }

            if (estEnDeplacement)
            {
                tempsPasse = Mathf.Min(tempsPasse + Time.deltaTime, dureeDuDeplacement);

                float ratio = tempsPasse / dureeDuDeplacement;
                transform.position = Vector3.Lerp(pointDeDepart.position, pointArrivee.position, ratio);

                if (tempsPasse >= dureeDuDeplacement)
                {
                    estEnDeplacement = false;
                }

            }
    }
}