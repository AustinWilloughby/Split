using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public GameObject targetGameobject = null;
    public Vector3 target;
    public float speed;

    private Vector3 inPlaneTarget;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(targetGameobject != null)
        {
            target = targetGameobject.transform.position;
        }
        LerpCamera();

    }

    private void LerpCamera()
    {
        inPlaneTarget = target;
        inPlaneTarget.z = transform.position.z; 
        transform.position = Vec3Lerp(transform.position, target, speed * Time.deltaTime, speed * Time.deltaTime, 0);

    }

    private Vector3 Vec3Lerp(Vector3 from, Vector3 to, float speedX, float speedY, float speedZ)
    {
        return new Vector3(
            Mathf.Lerp(from.x, to.x, speedX),
            Mathf.Lerp(from.y, to.y, speedY),
            Mathf.Lerp(from.z, to.z, speedZ));
    }
}
