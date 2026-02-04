using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NMAscript : MonoBehaviour
{
    private NavMeshAgent nma = null;
    private GameObject floor = null;
    private Bounds bnd;

    private void Start()
    {
        nma = this.gameObject.GetComponent<NavMeshAgent>();
        floor = GameObject.Find("floor");
        bnd = floor.GetComponent<Renderer>().bounds;

        SetRandomDestination();
    }
    private void Update()
    {
        if (nma.remainingDistance < 0.1f)
        {
            SetRandomDestination();
        }
    }
    private void SetRandomDestination()
    {
        float rx = Random.Range(bnd.min.x, bnd.max.x);
        float rz = Random.Range(bnd.min.z, bnd.max.z);
        Vector3 moveto = new Vector3(rx, this.transform.position.y, rz);
        nma.SetDestination(moveto);
    }
}

