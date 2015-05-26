using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;
	private SpriteRenderer spr;
	private Vector3 col;
	Color col2;
	private GameController gl;
	public AudioClip piano;

	// Use this for initialization
	void Start () {
		gl = GameObject.FindObjectOfType(typeof(GameController)) as GameController;
		rigidbody2D.velocity = new Vector2(0,-Random.Range(1f,2f)*speed-gl.speed);
		spr = GetComponent<SpriteRenderer>();
		col = Random.onUnitSphere;
		col2.r = Mathf.Abs(col.x);
		col2.g = Mathf.Abs(col.y);
		col2.b = Mathf.Abs(col.z);
		col2.a = 1f;
		spr.color = col2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

GameObject PlayClipAtPoint(AudioClip clip, Vector3 position, float volume, float pitch){
		GameObject obj = new GameObject();
		obj.transform.position = position;
		obj.AddComponent<AudioSource>();
		obj.audio.pitch = pitch;
		obj.audio.PlayOneShot(clip, volume);
		Destroy (obj, clip.length / pitch);
		return obj;
	}

void OnTriggerEnter2D (Collider2D other) {
		if (!gl.gameOver && other.name!="Boundary" && other.tag!="Kubik")
		{
			PlayClipAtPoint(piano, transform.position,1.0f,Mathf.Clamp(Mathf.Abs(col.x*3),0.5f,3f));
			gl.AddScore(1);
			Destroy(gameObject);
		}
	}
}
