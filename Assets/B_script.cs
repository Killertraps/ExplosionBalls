using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_script : MonoBehaviour
{
    public float Magnitude = 50f;
    public float Radius = 10f;
    RaycastHit hit;
    Rigidbody rb;
    int layerMask = 1 << 8;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
           
                Vector3 pos = GetMousePosition();
            Explode(pos);
            
        }
    }
    private Vector3 GetMousePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool isCast = Physics.Raycast(ray, out hit, 1000f, layerMask);
        Debug.Log(hit.point);
        Debug.Log(isCast);
        return hit.point;
    }
    private void Explode(Vector3 explosionPos)
    {
        Collider[] colliders = Physics.OverlapSphere(explosionPos, Radius);
        foreach (Collider c in colliders)
        {
            Rigidbody rb = c.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(Magnitude, explosionPos, Radius, 1f);
        }
    }
}
