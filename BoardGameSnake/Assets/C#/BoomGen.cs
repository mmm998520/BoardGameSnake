using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.Board.Game.Snake
{
    public class BoomGen : MonoBehaviour
    {
        float timer = 0;
        float timerStoper;
        public GameObject boomItem;

        void Start()
        {
            timerStoper = Random.Range(7.0f, 10.0f);
        }

        void Update()
        {
            if (TrailManager.less)
            {
                if ((timer+=Time.deltaTime) > timerStoper)
                {
                    Instantiate(boomItem, new Vector3(Random.Range(-2.0f,2.0f), Random.Range(-3.0f,5.0f), 0), Quaternion.identity, transform).name = "boom(item)";
                    timer = 0;
                    timerStoper = Random.Range(7.0f, 10.0f);
                }
            }
        }
    }
}
