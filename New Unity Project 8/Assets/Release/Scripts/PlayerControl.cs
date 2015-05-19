using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public float speed;
	public float up;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		Vector2 mpos;

		mpos = Vector2.zero;
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			mpos = Camera.main.ScreenToWorldPoint(touch.position);

			mpos.y += up;
			float step = speed * Time.fixedDeltaTime;
			transform.position = Vector3.MoveTowards(transform.position, mpos, step);
		}
		else
		{
			if (Input.GetMouseButton(0)) 
			{
				mpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			
				mpos.y += up;
				float step = speed * Time.fixedDeltaTime;
				transform.position = Vector3.MoveTowards(transform.position, mpos, step);

			}

		}
	}
}
