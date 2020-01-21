using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yukidango.BarrageShooting.Boss;

public struct bullet {
	private float x;
	private float y;
	private float z;
}

public class CpControl : MonoBehaviour {

	public class HitPoint {
		public static int hitPoint = 5;
	}

	SpriteRenderer MainSpriteRenderer;
	public Sprite DefaultSprite;
	public Sprite StandbySprite;
	public Sprite LeftSprite;
	public Sprite RightSprite;
	
	public GameObject bulletPrefab;
	private float speed = 0.075f;
	private float dx, dy;

	public static Vector3 cpPosition;

	public bullet bulletPosion = new bullet();
	// Start is called before the first frame update

	void Start() {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		HitPoint.hitPoint = 5;
	}

    // Update is called once per frame
    void Update ()
    {
	    cpPosition = transform.position;

	    MainSpriteRenderer.sprite = DefaultSprite;

	    if (Input.GetKey(KeyCode.LeftShift))
	    {
		    if (Input.GetKey (KeyCode.LeftArrow)) {
			    if (cpPosition.x >= -6.0f) {
				    MainSpriteRenderer.sprite = LeftSprite;
				    transform.Translate (-1*speed/2, 0, 0);
			    }
		    }else if (Input.GetKey (KeyCode.RightArrow)) {
			    if (cpPosition.x <= 6.0f) {
				    MainSpriteRenderer.sprite = RightSprite;
				    transform.Translate ( speed/2, 0, 0);
			    } 
		    } 
		    if (Input.GetKey(KeyCode.UpArrow)) {
			    if (cpPosition.y <= -0.05) {
				    transform.Translate (0,speed/2,0);
			    }
		    }else if (Input.GetKey(KeyCode.DownArrow)) {
			    if (cpPosition.y >= -4.55) {
				    MainSpriteRenderer.sprite = StandbySprite;
				    transform.Translate(0,-1*speed/2,0);
			    }
		    }
	    }
	    else
	    {
		    if (Input.GetKey (KeyCode.LeftArrow)) {
			    if (cpPosition.x >= -6.0f) {
				    MainSpriteRenderer.sprite = LeftSprite;
				    transform.Translate (-1*speed, 0, 0);
			    }
		    }else if (Input.GetKey (KeyCode.RightArrow)) {
			    if (cpPosition.x <= 6.0f) {
				    MainSpriteRenderer.sprite = RightSprite;
				    transform.Translate ( speed, 0, 0);
			    }
		    } 
		    if (Input.GetKey(KeyCode.UpArrow)) {
			    if (cpPosition.y <= -0.05) {
				    transform.Translate (0,speed,0);
			    }
		    }else if (Input.GetKey(KeyCode.DownArrow)) {
			    if (cpPosition.y >= -4.55) {
				    MainSpriteRenderer.sprite = StandbySprite;
				    transform.Translate(0,-1*speed,0);
			    }
		    }
	    }
	    
	    
	    if (Time.frameCount % 4 == 0 ) {
		    Instantiate(bulletPrefab, new Vector3(cpPosition.x,cpPosition.y+0.4f,cpPosition.z), Quaternion.identity);
	    }
    }

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.CompareTag("EnemyBullet") ||  coll.gameObject.CompareTag("EnemyObject")) {
			if (this.gameObject.CompareTag("Player"))
			{
				HitPoint.hitPoint -= 1;
				CheckHitPoint.checkHP(this, HitPoint.hitPoint);
				this.tag = "empty";
				this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
				Invoke(nameof(refreshTag), 3.0f);
			}
		}
	}

	void refreshTag()
	{
		this.tag = "Player";
		this.GetComponent<SpriteRenderer>().color = new Color(1.0f,1.0f,1.0f,1.0f);
	}
}
