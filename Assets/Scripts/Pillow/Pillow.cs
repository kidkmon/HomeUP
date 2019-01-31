using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : MonoBehaviour {

    [SerializeField]
    private float jumpForce;

    public float JumpForce{
        get{
            return jumpForce;
        }
        set{
            jumpForce = value;
        }
    }

}
