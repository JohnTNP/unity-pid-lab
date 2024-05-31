using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualControl : MonoBehaviour
{
    public float rayLength;
    public LayerMask layerMask;
    public GameObject Beam;
    private RaycastHit hit;
    float beamAngle = 0;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, rayLength, layerMask))
            {
                if (hit.rigidbody != null)
                {
                    // Debug.Log(hit.point);
                    Vector3 mouseIn = Input.mousePosition;
                    mouseIn.z = hit.distance;
                    Vector3 difference = Camera.main.ScreenToWorldPoint(mouseIn) - Beam.transform.position;
                    difference.Normalize();
                    beamAngle = Mathf.Atan2(difference.y, difference.z) * Mathf.Rad2Deg;
                    Beam.transform.localRotation = Quaternion.Euler(180 + -beamAngle, 0, 0);
                }
            }
        }    
    }
}
