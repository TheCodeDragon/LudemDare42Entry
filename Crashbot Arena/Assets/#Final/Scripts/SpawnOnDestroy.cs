using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnOnDestroy : MonoBehaviour {
    //things to spawn, like explosions, etc.
    public GameObject[] SpawnObjects;
    //when the gameobject get's destroyed
    void OnDestroy()
    {
        //spawn everything in the array
        foreach (GameObject SpawnObject in SpawnObjects)
        {
            Instantiate(SpawnObject, transform.position, transform.rotation);
        }
    }
}
