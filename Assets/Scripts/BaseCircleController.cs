
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCircleController : MonoBehaviour {
    Rigidbody2D baseCircle;
    /*
    float totalTime;
    Color startColor, endColor;
    */
	// Use this for initialization
	void Start () {
        baseCircle = GetComponent<Rigidbody2D>();
        /*
        startColor = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
        endColor = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
        */
    }
	
	// Update is called once per frame
	void Update () {
        /*
        totalTime += Time.deltaTime
        //renderer.Color = Color.Lerp(startColor, endColor, totalTime);
        if(totalTime >= 0.4f) {
            totalTime = 0;
            //colourStart = renderer.material.color;
            endColor = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
        }
        */
	}
}
