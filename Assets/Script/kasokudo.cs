using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kasokudo : MonoBehaviour {
	// 位置座標
	private Vector3 position;
	// スクリーン座標をワールド座標に変換した位置座標
	private Vector3 screenToWorldPointPosition;

	float speed = 30f;
	float defaultx = 0;
	float defaulty = 0;

	void Start(){
		//ゲーム起動時のスマホの傾きを初期値にする
		defaultx = Input.acceleration.x;
		defaulty = Input.acceleration.y;

	}

	void Update(){
		var dir = Vector3.zero;
		dir.x = Input.acceleration.x-defaultx;
		dir.y = Input.acceleration.y-defaulty;

		Vector2 hidarisita = Camera.main.ViewportToWorldPoint(Vector2.zero);
		Vector2 migiue = Camera.main.ViewportToWorldPoint(Vector2.one);

		if (transform.position.x < hidarisita.x && Input.acceleration.x-defaultx < 0) {
			dir.x = 0;
		}
		if (transform.position.y > migiue.y && Input.acceleration.y-defaulty > 0) {
			dir.y = 0;
		}
		if (transform.position.x > migiue.x && Input.acceleration.x-defaultx > 0) {
			dir.x = 0;
		}
		if (transform.position.y < hidarisita.y && Input.acceleration.y-defaulty < 0) {
			dir.y = 0;
		}


		if(dir.sqrMagnitude > 1){
			dir.Normalize();
		}

		dir *= Time.deltaTime;

		transform.Translate(dir * speed);

		#if UNITY_EDITOR
			// Vector3でマウス位置座標を取得する
			position = Input.mousePosition;
			// Z軸修正
			position.z = 10f;
			// マウス位置座標をスクリーン座標からワールド座標に変換する
			screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
			// ワールド座標に変換されたマウス座標を代入
			gameObject.transform.position = screenToWorldPointPosition;
		#endif
	}
}


/*参考資料
 * 
 * 画面端の座標を取得する
 * http://qiita.com/kwst/items/4ec30f00ec1fdffe6e32
 * 
 * 加速度センサーを使う
 * http://smartgames.hatenablog.com/entry/2016/06/23/004054
 * 
 *
*/