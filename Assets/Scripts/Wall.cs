using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
    Rigidbody2D wall;

    public Wall(Rigidbody2D _wall)
    {
        wall = _wall;
    }

	// Use this for initialization
	void Start () {
        wall = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float originalPosition = hypot(new Vector2((float)5.64, (float)8.13));
        float distance = Mathf.Sqrt(wall.position.x * wall.position.x + wall.position.y * wall.position.y);
        float r = distance / originalPosition;
        transform.localScale = new Vector3((float)0.2, (float)7 * r, 1);
        if (Mathf.Abs(wall.position.x) < 1e-1 && Mathf.Abs(wall.position.y) < 1e-1) {
            gameObject.SetActive(false);
        }
	}

    public float hypot(Vector2 v) {
        return Mathf.Sqrt(v.x * v.x + v.y + v.y);
    }

    public float getX() { return wall.position.x;  }
    public float getY() { return wall.position.y;  }
    public Rigidbody2D getRigidBody() { return wall;  }
}
