using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.Board.Game.Snake
{
    public class TimeManager : MonoBehaviour
    {
        const float maxTimer = 5;
        const float maxDis = 7;
        float maxTimeBarLong;
        float maxDisBarLong;
        float timer;
        public float dis;

        public bool myturn;
        public GameObject hurt;
        void Start()
        {
            Time.timeScale = 0;
            maxTimeBarLong = transform.GetChild(0).localScale.y;
            maxDisBarLong = transform.GetChild(1).localScale.y;
            timer = maxTimer;
            dis = maxDis;
        }

        void Update()
        {
            if (myturn)
            {
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    timer = 0;
                    TrailManager.less = false;
                }
                Transform timeBar = transform.GetChild(0);
                timeBar.localScale = new Vector3(timeBar.localScale.x, maxTimeBarLong * timer / maxTimer, timeBar.localScale.z);

                if(timeBar.localScale.y< transform.GetChild(1).localScale.y)
                {
                    print(name);
                    StartCoroutine("Hurt");
                }
            }
        }

        WaitForSeconds wait = new WaitForSeconds(0.5f);
        IEnumerator Hurt()
        {
            lessDis(1);
            hurt.SetActive(true);
            yield return wait;
            hurt.SetActive(false);
        }

        public void lessDis(float move)
        {
            dis -= move;
            if(dis < 0)
            {
                dis = 0;
            }
            Transform disBar = transform.GetChild(1);
            disBar.localScale = new Vector3(disBar.localScale.x, maxDisBarLong * dis / maxDis, disBar.localScale.z);
        }

        public void Switch()
        {
            if (Time.timeScale != 0)
            {
                myturn = !myturn;
                timer = maxTimer;
                dis = maxDis;
                Transform timeBar = transform.GetChild(0);
                timeBar.localScale = new Vector3(timeBar.localScale.x, maxTimeBarLong, timeBar.localScale.z);
                Transform disBar = transform.GetChild(1);
                disBar.localScale = new Vector3(disBar.localScale.x, maxDisBarLong, disBar.localScale.z);
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        public void openLess()//只有p1開啟
        {
            TrailManager.less = true;
        }
    }
}
