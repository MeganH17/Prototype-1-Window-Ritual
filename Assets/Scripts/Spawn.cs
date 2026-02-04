using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<GameObject> pts = new List<GameObject>();
    public List<GameObject> prefab = new List<GameObject>();
    public int MaxCount = 50;
    private GameObject people = null; 

    private void Start()
    {
        people = GameObject.Find("spawn"); 
        InvokeRepeating("DoSpawn", 0.0f, 1.0f);
    }
    private void DoSpawn()
    {
        if (people.transform.childCount >= MaxCount)
        {
            CancelInvoke();
        }

        //pick a point
        Vector3 pos = pts[Random.Range(0, pts.Count)].transform.position;

        //pick an object to spawn (at that point)
        GameObject obj = prefab[Random.Range(0, prefab.Count)];
        GameObject newchar = Instantiate(obj, this.gameObject.transform);
        newchar.transform.position = pos;
    }
}
