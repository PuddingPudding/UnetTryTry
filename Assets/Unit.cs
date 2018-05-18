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
    public GameObject[] effectList;

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
        CmdSetHp(0);
    }
    [Command]
    void CmdSetHp(float newHp)
    {
        hp = newHp;
        RpcPlayEffect(0);
    }

    [ClientRpc]
    void RpcPlayEffect(int index)
    {
        //建立新物件並在五秒後刪除
        Destroy(Instantiate(effectList[index], transform.position, Quaternion.identity), 5);
    }
}