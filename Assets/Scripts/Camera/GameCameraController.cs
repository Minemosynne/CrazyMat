using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCameraController : MonoBehaviour {

    private Bounds _currentBounds;
    private float _alignDuration = 1f;

    // Positionne la caméra sur la ScreenRegion dans laquelle on se trouve
    IEnumerator AlignToNewBounds()
    {
        // Là où se trouve la caméra
        Vector3 startVector = transform.position;
        // Là où se trouvera la caméra
        Vector3 trackingVector = transform.position;
        // Récupère le centre de la nouvelle ScreenRegion
        float targetX = _currentBounds.center.x;
        float targetY = _currentBounds.center.y;
        Vector3 targetPosition = new Vector3(targetX, targetY, transform.position.z);

        float lerpTime = 0;
        while(lerpTime < _alignDuration)
        {
            lerpTime += Time.deltaTime;
            trackingVector = Vec3Lerp(lerpTime, _alignDuration, startVector, targetPosition);
            transform.position = trackingVector;
            yield return 0;
        }
        transform.position = targetPosition;
    }

    // Appelée par la ScreenRegion quand on y rentre
    public void SetNewBounds(Bounds newBounds)
    {
        _currentBounds = newBounds;
        StartCoroutine(AlignToNewBounds());
    }

    // Donne un effet de déplacement en glissement de la position courante à la nouvelle position
    public static Vector3 Vec3Lerp(float currentTime, float duration, Vector3 v3Start, Vector3 v3Target)
    {
        float step = (currentTime / duration);
        Vector3 v3Returned = Vector3.Lerp(v3Start, v3Target, step);
        return v3Returned;
    }
}
