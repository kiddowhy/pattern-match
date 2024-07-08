using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class CreateLine : MonoBehaviour
{
    [SerializeField] RectTransform pos1;
    [SerializeField] RectTransform pos2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
                CreateLineFunc(pos1, pos2);
        }
    }
    void CreateLineFunc(RectTransform cPos1,RectTransform cPos2)
    {
        LineRenderer lineR = gameObject.GetComponent<LineRenderer>();
        lineR.widthMultiplier = 7f;
        lineR.positionCount = 2;

        //add offset

        lineR.SetPosition(0, cPos1.position );
        lineR.SetPosition(1, cPos2.position);
    }
}
