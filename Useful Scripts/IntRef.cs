using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntRef : VarRef<int>
{
    public IntRef() { }
    public IntRef(int v) { m_value = v; }
}
