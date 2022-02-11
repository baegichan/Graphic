using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{

    public LineRenderer lineRenderer;
   public MeshCollider meshCollider;
    // Start is called before the first frame update
    public Transform start;
    public Transform target;

    LineRenderer line;
    CapsuleCollider capsule;
    Transform objectHit;
    public float LineWidth; // use the same as you set in the line renderer.

    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        capsule = gameObject.AddComponent<CapsuleCollider>();
        capsule.radius = LineWidth / 2;
        capsule.center = Vector3.zero;
        capsule.direction = 2; // Z-axis for easier "LookAt" orientation
    }

    void Update()
    {

        if (Input.GetMouseButton(0) == true)
        {
            var screenPoint = Input.mousePosition;
            screenPoint.z = 1.0f;
            line.SetPosition(0, start.transform.position);

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                objectHit = hit.transform;
                line.SetPosition(1, objectHit.position);
                // Do something with the object that was hit by the raycast.
            }
            else
            {

            }
           // line.SetPosition(1, objectHit.position);

          

        }
      
    }
}
