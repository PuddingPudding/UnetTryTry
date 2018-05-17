using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;

public class Movement : NetworkBehaviour
{
    [SerializeField] private float m_fSpeed = 5;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (hasAuthority) //hasAuthority代表玩家是否有控制權
        //{
        //    float x = Input.GetAxis("Horizontal");
        //    float y = Input.GetAxis("Vertical");

        //    transform.Translate(new Vector2(x, y) * Time.deltaTime * m_fSpeed);
        //}

        if (!isLocalPlayer)
        {
            return;
        }
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(x, y) * Time.deltaTime * m_fSpeed);
    }
}
