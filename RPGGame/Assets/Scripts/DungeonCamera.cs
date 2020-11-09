using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCamera : MonoBehaviour
{
    public Transform followTransform;
    public BoxCollider2D mapBounds;

    private Vector3 smoothPos;
    public float smoothSpeed = 0.5f;
    public bool dungeon = false;
    public int roomX = 20;
    public int roomY = 20;

    private void Start() 
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int y = (roomY / 2) + ((int)followTransform.position.y / roomY) * roomY;
        int x = (roomX / 2) + ((int)followTransform.position.x / roomX) * roomX;
        if (followTransform.position.y < 0) { y -= 20; }
        if (followTransform.position.x < 0) { x -= 20; }
        
        smoothPos = Vector3.Lerp(this.transform.position, new Vector3(x, y, this.transform.position.z), smoothSpeed);
        this.transform.position = smoothPos;
    }
}
