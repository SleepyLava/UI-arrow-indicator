using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelec : MonoBehaviour
{
    [SerializeField] RectTransform[] charBtns;
    [SerializeField] RectTransform indicator;
    [SerializeField] float moveDelay;

    public int indicatorPos;
    public float moveTimer;

    // Update is called once per frame
    void Update()
    {
        if (moveTimer <= moveDelay)
        {
            moveTimer += Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (moveTimer > moveDelay)
            {
                if (indicatorPos < charBtns.Length - 1)
                {
                    indicatorPos++;
                }
                else
                {
                    indicatorPos = 0;
                }
                moveTimer = 0;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (moveTimer > moveDelay)
            {
                if (indicatorPos > 0)
                {
                    indicatorPos--;
                }
                else
                {
                    indicatorPos = charBtns.Length - 1;
                }
                moveTimer = 0;
            }
        }
        indicator.localPosition = charBtns[indicatorPos].localPosition;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Character " + (indicatorPos + 1));
        }
    }

    public void HoverOnButton(int btnPos)
    {
        indicatorPos = btnPos;
    }

    public void ButtonPress()
    {
        Debug.Log("Character " + (indicatorPos + 1));
    }
}
