using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.Board.Game.Snake
{
    public class BoomManager : MonoBehaviour
    {
        public GameObject fire;

        void Update()
        {
            if (TrailManager.less)
            {
                transform.GetChild(0).localScale -= Vector3.one * 0.001f;
                if (transform.lossyScale.magnitude >= transform.GetChild(0).lossyScale.magnitude)
                {
                    Instantiate(fire, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
            }
        }
    }
}