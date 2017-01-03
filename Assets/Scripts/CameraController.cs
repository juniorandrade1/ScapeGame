using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private Camera m_Camera;
    private float totalTime = 0;
    private int opt = 0;
    // Use this for initialization
    void Start () {
        m_Camera = GetComponentInChildren<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
       
    }
}
