using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BetterFSM
{
    public class Agent : MonoBehaviour
    {
        private StateBase _curState;

        private Dictionary<StateType, StateBase> _states = new Dictionary<StateType, StateBase>();

        private void Start()
        {
            StateBase[] allStates = GetComponents<StateBase>();

            foreach (StateBase state in allStates)
            {
                if(_states.ContainsKey(state.GetStateType) == false)
                {
                    _states.Add(state.GetStateType, state);
                }
            }
        }
    }
}