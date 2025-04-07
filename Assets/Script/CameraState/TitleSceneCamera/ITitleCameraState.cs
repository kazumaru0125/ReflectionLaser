using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITitleCameraState
    {
    void EnterState(TitleCameraController camera);
    void UpdateState(TitleCameraController camera);
    void ExitState(TitleCameraController camera);
    }
