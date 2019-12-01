using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public float speed;
    public Transform player;
    public Vector3 offset;

    public Vector2 pos;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void FixedUpdate () {
        pos = player.transform.position;
        //Vector2 desiredPosition = player.position + offset;
        //Vector2 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed);
        //transform.position = smoothedPosition;
        transform.position = new Vector2(player.position.x, player.position.y);
        //transform.LookAt(player);
	}
}
