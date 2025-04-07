using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleZoomState : ITitleCameraState
    {

    public void EnterState(TitleCameraController camera)
        {
        Debug.Log("Entering Follow Camera State");
        }

    public void UpdateState(TitleCameraController camera)
        {


        }

    public void ExitState(TitleCameraController camera)
        {
        Debug.Log("Exiting Follow Camera State");

        }

    }
