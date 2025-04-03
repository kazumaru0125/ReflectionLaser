using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICameraState
    {
    void EnterState(CameraController camera);
    void UpdateState(CameraController camera);
    void ExitState(CameraController camera);
    }
