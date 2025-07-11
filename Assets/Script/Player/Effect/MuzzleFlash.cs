using UnityEngine;

public class MuzzleFlash : MonoBehaviour
    {
    [SerializeField] private ParticleSystem muzzleFlash;

    void Update()
        {
        if (Input.GetMouseButtonDown(1))
            {
            // エフェクトをこのオブジェクトの位置に合わせる（必要に応じて）
            muzzleFlash.transform.position = transform.position;

            // エフェクト再生
            muzzleFlash.Play();
            }
        }
    }
