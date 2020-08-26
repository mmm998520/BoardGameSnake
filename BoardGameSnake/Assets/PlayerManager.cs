using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace com.Board.Game.Snake
{
    public class PlayerManager : MonoBehaviour
    {
        public TimeManager timeManager;
        Vector2[] real = new Vector2[0];//短的(真的能碰到
        public Vector2[] fake = new Vector2[1] {Vector2.zero};//長的

        void OnMouseDrag()
        {
            Vector3 mouse_p = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            mouse_p.z = transform.position.z;
            if (Vector3.Distance(mouse_p, transform.position)>0.1f)
            {
                timeManager.lessDis(0.1f);
                Vector2[] tempF = new Vector2[fake.Length + 1];
                for (int i = 0; i < fake.Length; i++)
                {
                    tempF[i] = fake[i];
                }
                tempF[fake.Length] = mouse_p;
                if (fake.Length <= 1)
                {
                    tempF[0] = transform.position;
                }
                fake = tempF;
                int len = 3;
                if (fake.Length > len)
                {
                    real = new Vector2[fake.Length - len];
                    for(int i = 0; i < real.Length; i++)
                    {
                        real[i] = fake[i];
                    }
                }
                EdgeCollider2D edgeCollider2D = transform.parent.GetComponent<EdgeCollider2D>();
                edgeCollider2D.points = real;

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

