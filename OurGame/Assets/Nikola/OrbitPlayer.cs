using UnityEngine;
using System.Collections;

public class OrbitPlayer : MonoBehaviour
{
    public Transform target;
    public float orbitDistance = 1.0f;
    public float orbitDegreesPerSec = 45.0f;
    // Use this for initialization
    void Start()
    {
    }
    void Orbit()
    {
        if (target != null)
        {
            // Keep us at orbitDistance from target
            transform.position = target.position + (transform.position - target.position).normalized * orbitDistance;
            transform.RotateAround(target.position,Vector3.up,orbitDegreesPerSec * Time.deltaTime);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Orbit();
    }
}