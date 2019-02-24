using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatRef : VarRef<float>
{
    public FloatRef() { }
    public FloatRef(float v) { m_value = v; }
}
