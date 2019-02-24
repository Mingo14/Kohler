using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolRef : VarRef<bool>
{
    public BoolRef() { }
    public BoolRef(bool v) { m_value = v; }
}
