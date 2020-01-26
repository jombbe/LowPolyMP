using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    private void Awake()
    {
        this.transform.position = Input.mousePosition;
    }
}
