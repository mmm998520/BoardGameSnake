using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.Board.Game.Snake
{
    public class TrailManager : MonoBehaviour
    {
        float timer = 0;
        public static bool less = false;

        void Update()
        {
            if (less)
            {
                timer += Time.deltaTime;
                if (timer > 0.2)
                {
                    timer = 0;
                    PlayerManager playerManager = transform.GetChild(0).GetComponent<PlayerManager>();
                    LineRenderer lineRenderer = GetComponent<LineRenderer>();
                    if (playerManager.fake.Length > 1)
                    {
                        Vector2[] temp = new Vector2[playerManager.fake.Length - 1];
                        for (int i = 0; i < temp.Length; i++)
                        {
                            temp[i] = playerManager.fake[i + 1];
                            //print(temp.Length);
                            //print(playerManager.fake.Length);
                            lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                        }
                        playerManager.fake = temp;
                        int len = 8;
                        if (playerManager.fake.Length > len)
                        {
                            playerManager.real = new Vector2[playerManager.fake.Length - len];
                            for (int i = 0; i < playerManager.real.Length; i++)
                            {
                                playerManager.real[i] = playerManager.fake[i];
                            }
                        }
                        EdgeCollider2D edgeCollider2D = transform.GetComponent<EdgeCollider2D>();
                        edgeCollider2D.points = playerManager.real;

                        lineRenderer.positionCount--;
                    }
                }
            }
        }
    }
}

