#pragma strict

var target : Transform;
function Start () {

}

function Update () {
	transform.position.x = target.position.x + 5;
	transform.position.z = target.position.z + 5;
	transform.LookAt(target);
}
