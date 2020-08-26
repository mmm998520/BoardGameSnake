using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.Board.Game.Snake
{
    public class TimeManager : MonoBehaviour
    {
        const float maxTimer = 5;
        const float maxDis = 5;
        float maxTimeBarLong;
        float maxDisBarLong;
        float timer;
        float dis;
        void Start()
        {
            maxTimeBarLong = transform.GetChild(0).localScale.y;
            maxDisBarLong = transform.GetChild(1).localScale.y;
            timer = maxTimer;
            dis = maxDis;
        }

        void Update()
        {
            timer -= Time.deltaTime;
            Transform timeBar = transform.GetChild(0);
            timeBar.localScale = new Vector3(timeBar.localScale.x, maxTimeBarLong * timer / maxTimer, timeBar.localScale.z);

            if(timeBar.localScale.y< transform.GetChild(1).localScale.y)
            {
                print("a");
            }
        }

        public void lessDis(float move)
        {
            dis -= move;
            Transform disBar = transform.GetChild(1);
            disBar.localScale = new Vector3(disBar.localScale.x, maxDisBarLong * dis / maxDis, disBar.localScale.z);
        }
    }
}
