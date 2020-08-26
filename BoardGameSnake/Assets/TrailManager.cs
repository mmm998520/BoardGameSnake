using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.Board.Game.Snake
{
    public class TrailManager : MonoBehaviour
    {
        float timer = 0;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            timer += Time.deltaTime;
            if (timer > 0.1)
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
                        lineRenderer.SetPosition(i, lineRenderer.GetPosition(i+1));
                    }
                    playerManager.fake = temp;
                    lineRenderer.positionCount--;
                }
            }
        }
    }
}

