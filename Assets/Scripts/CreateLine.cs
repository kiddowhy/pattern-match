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
    void CreateLineFunc(RectTransform lPos1,RectTransform lPos2)
    {
        LineRenderer lineR = gameObject.GetComponent<LineRenderer>();
        lineR.widthMultiplier = 7f;
        lineR.positionCount = lineCount;

        lineR.SetPosition(0, lPos1.position);
        lineR.SetPosition(1, lPos2.position);
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
        lineCount += 2;
        pos1 = dots[0].GetComponent<RectTransform>();
        pos2 = dots[1].GetComponent<RectTransform>();
        CreateLineFunc(pos1, pos2);



    }
}
