using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    Vector3 MousePositionOffset;
    public float XBoarder;
    public float YBoarder;
    public float BoarderBuffer;
    public bool finish;
    public bool kill;
    public Transform SpawnPoint;

    private void Start()
    {
        finish = false;
        kill = false;
    }

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        MousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        if (transform.position.x > -XBoarder && transform.position.x < XBoarder && transform.position.y > -YBoarder && transform.position.y < YBoarder && !finish &&!kill)
        {
            transform.position = GetMouseWorldPosition() + MousePositionOffset;
        }
    }

    private void OnMouseUp()
    {
        if (transform.position.x < -XBoarder)
        {
            transform.position = new Vector2(-XBoarder + BoarderBuffer, transform.position.y);
        }

        if (transform.position.x > XBoarder)
        {
            transform.position = new Vector2(XBoarder - BoarderBuffer, transform.position.y);
        }

        if (transform.position.y < -YBoarder)
        {
            transform.position = new Vector2(transform.position.x, -YBoarder + BoarderBuffer);
        }

        if (transform.position.y > YBoarder)
        {
            transform.position = new Vector2(transform.position.x, YBoarder - BoarderBuffer);
        }

        kill = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("hit");

        if (other.gameObject.tag == "Finish")
        {
            finish = true;
        }

        if (other.gameObject.tag == "Hurt")
        {
            print("kill");
            kill = true;
            transform.position = SpawnPoint.position;
        }
    }
}
