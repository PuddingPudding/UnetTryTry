using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;
using UnityEngine.UI;
public class Unit : NetworkBehaviour
{
    public float maxHP = 50;
    public Text uiText;
    [SyncVar]
    private float hp;

    void Start()
    {
        hp = maxHP;
    }

    void Update()
    {
        if (isServer)
        {
            if (hp < maxHP)
            {
                hp += Time.deltaTime * 5;
            }
            else
            {
                hp = maxHP;
            }
        }
        uiText.text = "HP:" + ((int)hp).ToString();
    }
    void OnMouseDown()
    {
        hp = 0;
    }
}