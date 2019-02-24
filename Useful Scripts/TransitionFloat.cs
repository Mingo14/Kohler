﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionFloat<T> : Transition<T>
{
    public enum eCompare
    {
        EQUAL,
        GREATER,
        LESS
    }
    FloatRef m_value;
    float m_condition;
    eCompare m_compare;

    public TransitionFloat(T owner, ref FloatRef value1, float condition, eCompare compare = eCompare.EQUAL) : base(owner)
    {
        m_value = value1;
        m_condition = condition;
        m_compare = compare;
    }

    public override bool Test()
    {
        bool transition = false;

        switch(m_compare)
        {
            case eCompare.EQUAL:
                transition = m_value.m_value == m_condition;
                break;
            case eCompare.GREATER:
                transition = m_value.m_value > m_condition;
                break;
            case eCompare.LESS:
                transition = m_value.m_value < m_condition;
                break;
        }

        return transition;
    }
}
