using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T>
{
    Dictionary<string, State<T>> m_states = new Dictionary<string, State<T>>();
    State<T> m_state = null;
    Stack<State<T>> m_stateStack = new Stack<State<T>>();

    public void Update()
    {
        m_state = m_stateStack.Peek();
        if(m_state != null)
        {
            foreach(var transition in m_state.m_transitions)
            {
                if(transition.first.Test())
                {

                    SetState(transition.second);
                    break;
                }
            }
            m_state.Update();
        }
    }

    public void AddState(string id, State<T> state)
    {
        m_states[id] = state;
    }

    public void PushState(string id)
    {
        if(m_states.TryGetValue(id, out State<T> state))
        {
            m_stateStack.Push(state);
        }

    }

    public void PopState()
    {
        m_stateStack.Pop();
    }

    public void SetState(string id)
    {
        Debug.Assert(m_states.ContainsKey(id), "state not found" + id);
        if (m_states.TryGetValue(id, out State<T> state))
        {
            if(state != m_state)
            {
                if(m_state != null)
                {
                    m_state.Exit();
                }
                m_state = state;
                m_state.Enter();
                m_state.Update();
            }
        }
    }
}
