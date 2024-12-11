using UnityEngine;

public class CoinRotator : MonoBehaviour
{
    public float rotationAngle = 90f; // Degrees per second
    public float duration = 1f; // Duration for a single rotation

    private float angle = 0;

    private void OnEnable()
    {
        StartContinuousRotation();
    }

    private void StartContinuousRotation()
    {
        angle = transform.eulerAngles.z + rotationAngle;
        LeanTween.rotateZ(gameObject, angle, duration).setEase(LeanTweenType.linear).setOnComplete((OnRotationComplete));
    }
    private void OnRotationComplete() => StartContinuousRotation();

}
