using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMaterialScript : MonoBehaviour
    {
    // Bulletオブジェクトの参照
    public GameObject bullet;

    // Particleの移動速度やオフセットを設定できるようにする
    public Vector3 offset;

    // Update is called once per frame
    void Update()
        {
        // Bulletが設定されていればその位置に追従
        if (bullet != null)
            {
            // Bulletの位置に合わせてParticleを移動
            transform.position = bullet.transform.position + offset;
            }
        }
    }
