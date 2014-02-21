using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private const float Speed = 20f;
    private CharacterController controller;
    private Vector3 targetPosition;

    public AnimationClip run;
    public AnimationClip idle;
    

    // Use this for initialization
    private void Start()
    {
        targetPosition = transform.position;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            targetPosition = GetTargetPosition(Input.mousePosition);    
        }
        MoveToPosition(targetPosition);

    }

    private void MoveToPosition(Vector3 position)
    {
        if (Vector3.Distance(transform.position, position) >= 1)
        {
            Quaternion rotation = Quaternion.LookRotation(position - transform.position);
            rotation.x = 0f;
            rotation.z = 0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10);
            controller.SimpleMove(transform.forward * Speed);
            animation.CrossFade(run.name);
        }
        else
        {
            animation.CrossFade(idle.name);
        }
    }

    private Vector3 GetTargetPosition(Vector3 positionAtScreen)
    {
        Ray ray = Camera.main.ScreenPointToRay(positionAtScreen);
        RaycastHit hit;

        Vector3 hitPosition = targetPosition;

        if (Physics.Raycast(ray, out hit))
        {            
            if (hit.collider.tag != "Player")
            {
                Debug.Log("hi");
                hitPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            }
        }

        return hitPosition;
    }
}
