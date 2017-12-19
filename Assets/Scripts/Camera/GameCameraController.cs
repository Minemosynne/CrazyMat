using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCameraController : MonoBehaviour {

    private Bounds _currentBounds;
    private float _alignDuration = 1f;

    IEnumerator AlignToNewBounds()
    {
        Vector3 startVector = transform.position;
        Vector3 trackingVector = transform.position;

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

    public void SetNewBounds(Bounds newBounds)
    {
        _currentBounds = newBounds;
        StartCoroutine(AlignToNewBounds());
    }

    public static Vector3 Vec3Lerp(float currentTime, float duration, Vector3 v3Start, Vector3 v3Target)
    {
        float step = (currentTime / duration);
        Vector3 v3Returned = Vector3.Lerp(v3Start, v3Target, step);
        return v3Returned;
    }
}
