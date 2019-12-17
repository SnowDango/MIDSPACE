using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	// publicで宣言し、inspectorで設定可能にする
	public Sprite DefaultSprite;
	public Sprite StandbySprite;
	public Sprite LeftSprite;
	public Sprite RightSprite;
	
	public GameObject bulletPrefab;
	
	public bullet bulletPosion = new bullet();
	// Start is called before the first frame update

	void Start() {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update () {

	    MainSpriteRenderer.sprite = DefaultSprite;

	    if (Input.GetKey (KeyCode.LeftArrow)) {
		    if (transform.position.x >= -6.0f) {
			    MainSpriteRenderer.sprite = LeftSprite;
			    transform.Translate (-0.05f, 0, 0);
		    }
	    }else if (Input.GetKey (KeyCode.RightArrow)) {
		    if (transform.position.x <= 6.0f) {
			    MainSpriteRenderer.sprite = RightSprite;
			    transform.Translate ( 0.05f, 0, 0);
		    }
	    } 
	    if (Input.GetKey(KeyCode.UpArrow)) {
		    if (transform.position.y <= -0.05) {
			    transform.Translate (0,0.05f,0);
		    }
	    }else if (Input.GetKey(KeyCode.DownArrow)) {
		    if (transform.position.y >= -4.65) {
			    MainSpriteRenderer.sprite = StandbySprite;
			    transform.Translate(0,-0.05f,0);
		    }
	    }

	    if (Time.frameCount % 8 == 0 /* && Time.frameCount / 4 <= 1*/) {
		    Instantiate(bulletPrefab, new Vector3(transform.position.x,transform.position.y+0.4f,transform.position.z), Quaternion.identity);
	    }

	    checkHP();
    }

    void checkHP() {
	    if(HitPoint.hitPoint <= 0) Destroy(gameObject);
    }
	
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.CompareTag("EnemyBullet")) {
			HitPoint.hitPoint -= 1;
		}
	}
}
