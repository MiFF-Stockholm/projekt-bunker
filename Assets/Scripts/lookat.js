#pragma strict

var target : Transform;
function Start () {

}

function Update () {
	transform.position.x = target.position.x + 1;
	transform.position.z = target.position.z + 1;
	transform.LookAt(target);
}
