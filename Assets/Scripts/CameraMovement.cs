using UnityEngine;
using System.Collections;

//[AddComponentMenu("Transform/Follow Transform")]
public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float distance = 10.0f;
    public float height = 5.0f;
    public float heightDamping = 2.0f;

    private void LateUpdate()
    {
        if (!target)
        {
            return;
        }

        var wantedHeight = target.position.y + height;
        var currentHeight = transform.position.y;

        // Damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        transform.position = target.position;

        // Set the height of the camera
        transform.position = new Vector3(target.position.x, currentHeight, target.position.z);
        transform.position -= Vector3.forward * distance;

        // Always look at the target
        transform.LookAt(target);
    }
}