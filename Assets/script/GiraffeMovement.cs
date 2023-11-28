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
        // Si la touche T est enfoncée et l'objet n'est pas déjà en déplacement

            if (GiraffeFighting && !estEnDeplacement)
            {
                estEnDeplacement = true;
                tempsPasse = 0f;
            }

            // Si l'objet est en déplacement
            if (estEnDeplacement)
            {
                // S'assurer que le tempsPasse ne dépasse pas la dureeDuDeplacement
                tempsPasse = Mathf.Min(tempsPasse + Time.deltaTime, dureeDuDeplacement);

                // Calculer la position interpolée entre pointDeDepart et pointArrivee
                float ratio = tempsPasse / dureeDuDeplacement;
                transform.position = Vector3.Lerp(pointDeDepart.position, pointArrivee.position, ratio);

                // Si vous souhaitez également faire tourner l'objet pendant le déplacement
                // Vous pouvez utiliser Quaternion.Lerp pour l'interpolation de la rotation
                // transform.rotation = Quaternion.Lerp(pointDeDepart.rotation, pointArrivee.rotation, ratio);

                // Si la durée du déplacement est écoulée, réinitialiser les valeurs
                if (tempsPasse >= dureeDuDeplacement)
                {
                    estEnDeplacement = false;
                    // Vous pouvez également effectuer d'autres actions à la fin du déplacement ici
                }

            }
    }
}