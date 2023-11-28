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
        // Si la touche T est enfonc�e et l'objet n'est pas d�j� en d�placement

            if (GiraffeFighting && !estEnDeplacement)
            {
                estEnDeplacement = true;
                tempsPasse = 0f;
            }

            // Si l'objet est en d�placement
            if (estEnDeplacement)
            {
                // S'assurer que le tempsPasse ne d�passe pas la dureeDuDeplacement
                tempsPasse = Mathf.Min(tempsPasse + Time.deltaTime, dureeDuDeplacement);

                // Calculer la position interpol�e entre pointDeDepart et pointArrivee
                float ratio = tempsPasse / dureeDuDeplacement;
                transform.position = Vector3.Lerp(pointDeDepart.position, pointArrivee.position, ratio);

                // Si vous souhaitez �galement faire tourner l'objet pendant le d�placement
                // Vous pouvez utiliser Quaternion.Lerp pour l'interpolation de la rotation
                // transform.rotation = Quaternion.Lerp(pointDeDepart.rotation, pointArrivee.rotation, ratio);

                // Si la dur�e du d�placement est �coul�e, r�initialiser les valeurs
                if (tempsPasse >= dureeDuDeplacement)
                {
                    estEnDeplacement = false;
                    // Vous pouvez �galement effectuer d'autres actions � la fin du d�placement ici
                }

            }
    }
}