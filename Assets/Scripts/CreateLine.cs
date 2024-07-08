using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateLine : MonoBehaviour
{
    [SerializeField] List<GameObject> dots;
    [SerializeField] RectTransform pos1;
    [SerializeField] RectTransform pos2;
    [SerializeField] int lineCount;
    [SerializeField] private Sprite circleSprite;
    [SerializeField] private RectTransform CircleContainer;

    //upbotton
    [SerializeField] private int index = 0;
    int listIndex1 = 0;
    int listIndex2 = 1;


    // Start is called before the first frame update
    void Start()
    {
        lineCount = 0;
        CircleContainer = gameObject.GetComponent<RectTransform>();
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {

                GameObject circleGameObject = CreateCircle(new Vector2(i * 100, j * 100));
                //if(dots.Count == null)
                {
                    dots.Add(circleGameObject);

                }

            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
           
            
        }
    }
    void CreateLineFunc(int inDex,RectTransform lPos1,RectTransform lPos2)
    {
        LineRenderer lineR = gameObject.GetComponent<LineRenderer>();
        lineR.widthMultiplier = 7f;
        lineR.positionCount = lineCount;

        lineR.SetPosition(inDex, lPos1.position);
        lineR.SetPosition(inDex+1, lPos2.position);
    }
    private GameObject CreateCircle(Vector2 cPos)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(CircleContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = cPos;
        rectTransform.sizeDelta = new Vector2(25, 25);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
    }

    public void UpBot()
    {
        
         // condition
         
        if (lineCount >=2)
        {
            lineCount += 1;
            index++;
            listIndex1 ++;
            listIndex2 ++;
        }
        if (lineCount == 0)
        {
            lineCount = 2;
        }
        
        pos1 = dots[listIndex1].GetComponent<RectTransform>();
        pos2 = dots[listIndex2].GetComponent<RectTransform>();
        CreateLineFunc(index, pos1, pos2);

    }
    public void DownButton()
    {
        
        if (lineCount >= 2)
        {
            if(lineCount == 2)   // moving it from first to last position
            {
                listIndex1 = dots.Count - 1;
            }
            else
            {
                listIndex1--;
            }
            listIndex2--;
            lineCount += 1;
            index++;
            
        }
        if (lineCount == 0)
        {
            listIndex1 = 0;
            listIndex2 = dots.Count -1;
            lineCount = 2;
        }


        pos1 = dots[listIndex1].GetComponent<RectTransform>();
        pos2 = dots[listIndex2].GetComponent<RectTransform>();
        CreateLineFunc(index, pos1, pos2);
    }
}
