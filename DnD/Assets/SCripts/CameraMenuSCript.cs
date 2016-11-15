using UnityEngine;
using System.Collections;

public class CameraMenuSCript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
            Camera.main.orthographicSize -= 0.5f; 
	}
}
