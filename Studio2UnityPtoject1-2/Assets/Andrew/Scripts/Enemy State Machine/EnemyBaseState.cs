using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState
{
    /// <summary>
    /// this function is called when the satte starts
    /// </summary>
    /// <param name="enemy"></param>
    public abstract void EnterState(EnemyStateManager enemy);
    /// <summary>
    /// this function is called every frame the state is enabled
    /// </summary>
    /// <param name="enemy"></param>
    public abstract void UpdateState(EnemyStateManager enemy);
}
