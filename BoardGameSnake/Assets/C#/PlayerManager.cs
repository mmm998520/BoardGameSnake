using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace com.Board.Game.Snake
{
    public class PlayerManager : MonoBehaviour
    {
        public TimeManager timeManager;
        public Vector2[] real = new Vector2[0];//短的(真的能碰到
        public Vector2[] fake = new Vector2[1] {Vector2.zero};//長的
        public GameObject hurt;
        bool haveBoom = false;

        void Update()
        {
            for(int i = 0; i < Input.touchCount; i++)
            {
                Vector3 touches_p = Camera.main.ScreenToWorldPoint(new Vector3(Input.touches[i].position.x, Input.touches[i].position.y, 0));
                touches_p.z = transform.position.z;
                if (Vector3.Distance(touches_p, transform.position) < 1)
                {
                    if (timeManager.dis > 0)
                    {
                        if (Vector3.Distance(touches_p, transform.position) > 0.05f)
                        {
                            timeManager.lessDis(0.1f);
                            Vector2[] tempF = new Vector2[fake.Length + 1];
                            for (int j = 0; j < fake.Length; j++)
                            {
                                tempF[j] = fake[j];
                            }
                            tempF[fake.Length] = touches_p;
                            if (fake.Length <= 1)
                            {
                                tempF[0] = transform.position;
                            }
                            fake = tempF;
                            int len = 8;
                            if (fake.Length > len)
                            {
                                real = new Vector2[fake.Length - len];
                                for (int j = 0; j < real.Length; j++)
                                {
                                    real[j] = fake[j];
                                }
                            }
                            EdgeCollider2D edgeCollider2D = transform.parent.GetComponent<EdgeCollider2D>();
                            edgeCollider2D.points = real;

                            LineRenderer lineRenderer = transform.parent.GetComponent<LineRenderer>();
                            if (lineRenderer.positionCount++ <= 1)
                            {
                                lineRenderer.SetPosition(0, transform.position);
                            }
                            lineRenderer.SetPosition(lineRenderer.positionCount - 1, touches_p);

                            transform.position = touches_p;
                        }
                    }
                }
            }
        }

        void OnMouseDrag()
        {
            if (timeManager.dis > 0)
            {
                Vector3 mouse_p = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                mouse_p.z = transform.position.z;
                if (Vector3.Distance(mouse_p, transform.position)>0.05f)
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
                    int len = 8;
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
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            print(name);
            StartCoroutine("Hurt");
        }

        void OnTriggerEnter(Collider other)
        {
            if(other.name == "boom(item)" && !haveBoom)
            {
                Destroy(other.gameObject);
                haveBoom = true;
            }
        }

        WaitForSeconds wait = new WaitForSeconds(0.5f);
        IEnumerator Hurt()
        {
            hurt.SetActive(true);
            yield return wait;
            hurt.SetActive(false);
        }
    }
}

