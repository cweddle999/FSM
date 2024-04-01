using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BetterFSM
{
    public abstract class StateBase : MonoBehaviour
    {
        private Agent _myAgent;

        public abstract StateType GetStateType {  get; }

        public void InitState(Agent agent)
        {
            _myAgent = agent;
        }
        public virtual void OnStateEnter() { }
        public abstract StateType OnStatusUpdate();
        public virtual void OnStateFixedUpdate() { }
        public virtual void OnStateLateUpdate() { }
        public virtual void OnStateExit() { }
    }

    public enum StateType
    {
        Init,
        Idle,
        Chase
    }
}
