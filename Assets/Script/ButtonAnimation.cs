using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector2.one;   
    }

    // Update is called once per frame
    public void Open()
    {
        transform.LeanScale(new Vector3((float)1.5, (float)1.5, 1), 0.8f);
    }

    public void Close()
    {
        transform.LeanScale(Vector2.one, 1f).setEaseInBack();
    }
}
