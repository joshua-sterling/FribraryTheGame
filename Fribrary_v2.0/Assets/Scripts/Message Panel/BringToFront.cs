using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringToFront : MonoBehaviour {



    private void OnEnable()
    {
        transform.SetAsLastSibling();                   //makes this the last child in hierarchy and is thus drawn last (puts it on top)
    }
}
