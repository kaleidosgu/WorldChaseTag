using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderHeightController : MonoBehaviour
{
    public float WalkingHeight;

    public float HeightOfStumbling;

    private CapsuleCollider m_capCollider;
    // Start is called before the first frame update
    void Start()
    {
        m_capCollider = GetComponent<CapsuleCollider>();
    }

}
