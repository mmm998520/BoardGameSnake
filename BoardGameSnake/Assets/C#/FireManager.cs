using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.Board.Game.Snake
{
    public class FireManager : MonoBehaviour
    {
        float timer = 0;

        void Update()
        {
            if (TrailManager.less)
            {
                if ((timer+= Time.deltaTime) >= 3)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}