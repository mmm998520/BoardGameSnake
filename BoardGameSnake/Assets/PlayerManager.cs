using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace com.Board.Game.Snake
{
    public class PlayerManager : MonoBehaviour
    {
        void Start()
        {
            //transform.parent.GetComponent<EdgeCollider2D>().points[0] = new Vector2(transform.position.x,transform.position.y);
        }

        void Update()
        {

        }

        void OnMouseDrag()
        {
            Vector3 mouse_p = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            mouse_p.z = transform.position.z;
            if (Vector3.Distance(mouse_p, transform.position)>0.1f)
            {
                EdgeCollider2D edgeCollider2D = transform.parent.GetComponent<EdgeCollider2D>();
                Vector2[] temp = new Vector2[edgeCollider2D.pointCount + 1];
                for(int i = 0; i < edgeCollider2D.pointCount; i++)
                {
                    temp[i] = edgeCollider2D.points[i];
                }
                temp[edgeCollider2D.pointCount] = mouse_p;
                if (edgeCollider2D.pointCount <= 1)
                {
                    temp[0] = transform.position;
                }
                edgeCollider2D.points = temp;

                LineRenderer lineRenderer = transform.parent.GetComponent<LineRenderer>();
                if(lineRenderer.positionCount++ <= 1)
                {
                    lineRenderer.SetPosition(0, transform.position);
                }
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, mouse_p);

                transform.position = mouse_p;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            print(collision.transform.name);
        }
    }
}

