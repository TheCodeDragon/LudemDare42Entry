using UnityEngine;

public class CleanUp : MonoBehaviour {
    [Header("CleanUp Time")]
    [Tooltip("The time, in seconds, till the script cleans it away.")]
    public float TimeTillCleanup;
	// Use this for initialization
	void Start () {
        //Destroy function.
        Destroy(gameObject, TimeTillCleanup);
	}
}
