using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ���Ɉړ�
        if (Input.GetKey(KeyCode.LeftArrow))
            {
            this.transform.Translate(-0.1f, 0.0f, 0.0f);
            }
        // �E�Ɉړ�
        if (Input.GetKey(KeyCode.RightArrow))
            {
            this.transform.Translate(0.1f, 0.0f, 0.0f);
            }
        // �O�Ɉړ�
        if (Input.GetKey(KeyCode.UpArrow))
            {
            this.transform.Translate(0.0f, 0.0f, 0.1f);
            }
        // ���Ɉړ�
        if (Input.GetKey(KeyCode.DownArrow))
            {
            this.transform.Translate(0.0f, 0.0f, -0.1f);
            }
        }
}
