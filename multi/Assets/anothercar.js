#pragma strict

var target :Transform;
var debug : int;
function Start () {
}
function LateUpdate(){
	debug++;
	transform.rotation = Quaternion.AngleAxis(target.eulerAngles.y, Vector3(0,1,0));
		
} 