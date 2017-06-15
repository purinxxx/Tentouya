using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kasokudo1 : MonoBehaviour {

	private Camera _mainCamera;
	public GameObject debugtext;
  
    float speed = 40f;
	float defaultx = 0;
	float defaulty = 0;

    //mousePoint
    private Vector3 position;
    private Vector3 screenToWorldPointPosition;



    void Start(){
		//ゲーム起動時のスマホの傾きを初期値にする
		defaultx = Input.acceleration.x;
		defaulty = Input.acceleration.y;

        // カメラオブジェクトを取得します
        //GameObject obj = GameObject.Find ("Main Camera");
        //_mainCamera = obj.GetComponent<Camera> ();

        // 座標値を出力
        //Debug.Log (getScreenTopLeft ().x + ", " + getScreenTopLeft ().y);
        //Debug.Log (getScreenBottomRight ().x + ", " + getScreenBottomRight ().y);

    }

	void Update(){
		var dir = Vector3.zero;
		dir.x = Input.acceleration.x-defaultx;
		dir.y = Input.acceleration.y-defaulty;
        Vector2 hidarisita = Camera.main.ViewportToWorldPoint(Vector2.zero);
        Vector2 migiue = Camera.main.ViewportToWorldPoint(Vector2.one);

        if (transform.position.x < hidarisita.x && Input.acceleration.x - defaultx < 0)
        {
            dir.x = 0;
            //dir.x = 0.001f;
        }
        if (transform.position.y > migiue.y && Input.acceleration.y - defaulty > 0)
        {
            dir.y = 0;
            //dir.y = -0.001f;
        }
        if (transform.position.x > migiue.x && Input.acceleration.x - defaultx > 0)
        {
            dir.x = 0;
            //dir.x = -0.001f;
        }
        if (transform.position.y <hidarisita.y && Input.acceleration.y - defaulty < 0)
        {
            dir.y = 0;
            //dir.y = 0.001f;
        }
        /*
		if (transform.position.x < getScreenTopLeft().x && Input.acceleration.x-defaultx < 0) {
			dir.x = 0;
			//dir.x = 0.001f;
		}
		if (transform.position.y > getScreenTopLeft().y && Input.acceleration.y-defaulty > 0) {
			dir.y = 0;
			//dir.y = -0.001f;
		}
		if (transform.position.x > getScreenBottomRight().x && Input.acceleration.x-defaultx > 0) {
			dir.x = 0;
			//dir.x = -0.001f;
		}
		if (transform.position.y < getScreenBottomRight().y && Input.acceleration.y-defaulty < 0) {
			dir.y = 0;
			//dir.y = 0.001f;
		}
        */

        //debugtext.GetComponent<Text>().text = dir.x.ToString() + "\n" + dir.y.ToString();

		if(dir.sqrMagnitude > 1){
			dir.Normalize();
		}

		dir *= Time.deltaTime;
		transform.Translate(dir * speed);



        //PCデバッグ用mousePoint
		/*
        position = Input.mousePosition;
        position.z = 10f;
        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
        gameObject.transform.position = screenToWorldPointPosition;
		*/


    }

    /*
	private Vector3 getScreenTopLeft() {
		// 画面の左上を取得
		Vector3 topLeft = _mainCamera.ScreenToWorldPoint (Vector3.zero);
		// 上下反転させる
		topLeft.Scale(new Vector3(1f, -1f, 1f));
		return topLeft;
	}

	private Vector3 getScreenBottomRight() {
		// 画面の右下を取得
		Vector3 bottomRight = _mainCamera.ScreenToWorldPoint (new Vector3(Screen.width, Screen.height, 0.0f));
		// 上下反転させる
		bottomRight.Scale(new Vector3(1f, -1f, 1f));
		return bottomRight;
	}
    */
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