using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAIState
{
    void OnEnter();
    void OnExit();
    void OnUpdate();
    void OnFixedUpdate();
}
