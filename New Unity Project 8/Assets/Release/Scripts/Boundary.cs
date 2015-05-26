using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {
	private GameController gl;
	Vector2 xsize;
	BoxCollider2D rect;
	// Use this for initialization
	void Start () {
		gl = GameObject.FindObjectOfType(typeof(GameController)) as GameController;
		rect=GetComponent<BoxCollider2D>();
		xsize = gl.sizeScreen;
		xsize.x*=2;
		xsize.y*=2;
		rect.size = xsize;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.name != "Player")
		{
		Destroy(other.gameObject);
			if (!gl.gameOver)
			{
			gl.DecLive();
			}
		}
	}
}
