using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WallRandomGenerator : MonoBehaviour
{
    public Rigidbody2D wall;
    
    public float speed = 0;
    float s;
    ArrayList arr;

    float totalTime = 0;

    // Use this for initialization
    void Start()
    {
        totalTime = 0;
        s = 0;
        arr = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;
        s = s + Time.deltaTime;
        if (s >= 0.3 - totalTime * 0.002)
        {
            s = 0;
            int type = Mathf.RoundToInt(Random.Range(1, 7));
            Vector2 position;
            if (type == 1) position = new Vector2((float)5.64, (float)9);
            else if (type == 2) position = new Vector2((float)4.92, (float)-9.00);
            else if (type == 3) position = new Vector2((float)10.5, (float)0);
            else if (type == 4) position = new Vector2((float)-5, (float)-9.0);
            else if (type == 5) position = new Vector2((float)-4.2, (float)7.8);
            else position = new Vector2((float)-10.5, (float)0);

            float ang = type * 60;
            Quaternion q = Quaternion.identity;
            Rigidbody2D instance = Instantiate(wall, position, q) as Rigidbody2D;
            instance.AddForce(new Vector2(-instance.position.x, -instance.position.y) * speed);
            instance.transform.Rotate( new Vector3(0, 0, (float)ang));      
            arr.Add(instance);
        }


        ArrayList needErase = new ArrayList();
        foreach (Rigidbody2D it in needErase) Destroy(it.gameObject);
        foreach (Rigidbody2D it in arr) if (it.gameObject.active == false) needErase.Add(it);
        foreach (Rigidbody2D it in needErase) arr.Remove(it);
    }
}
