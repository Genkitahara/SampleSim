#pragma strict

//キー入力で回転させる距離
public var keyDistance : float;

//マウスで回転させる距離
public var mouseDistance : float;

//前のドラッグ位置
private var oldPos : Vector3;

//ドラッグ中かどうか
private var isDrag = false;

function Update () {

  //キー入力で回転
  gameObject.transform.Rotate ((Input.GetAxis("Vertical") * keyDistance ), (Input.GetAxis("Horizontal") * keyDistance ), 0 );

  if (Input.GetMouseButtonDown(0) || isDrag) {
  
    if (isDrag) {
      //前のドラッグ位置との差分を取得
      var diff = Input.mousePosition - oldPos;
    
      //差分だけ回転させる
      gameObject.transform.Rotate(diff.y * mouseDistance, diff.x * mouseDistance, 0 );
    
    }
    //現在のポジションを保存
    oldPos = Input.mousePosition;
    isDrag = true;
  }

  if (Input.GetMouseButtonUp(0)) {
    isDrag = false;
  }

}
