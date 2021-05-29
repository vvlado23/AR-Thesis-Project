using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] Transform springPivot;
    [SerializeField] Transform itemHolder;

    public Transform ResetSize()
    {
        springPivot.localScale = new Vector3(1, 1, 1);
        itemHolder.localPosition = Vector3.zero;
        if(itemHolder.childCount==0)
        {
            return null;
        }
        else
        {
            return itemHolder.GetChild(0);
        }
    }

    public Transform AddItem(PlayerController pController)
    {
        Transform oldItem = ResetSize();
        GameObject myItem = pController.PutDownItem(itemHolder, itemHolder.position);
        Weight itemWeight = myItem.GetComponent<Weight>();

        float grammars = itemWeight.itemWeight;
        //1cm = 0.05 scale size && 1grammar = 0.16cm
        float addSize = (grammars * 0.16f) * 0.05f;

        ChangeSize(addSize);
        return oldItem;
    }

    void ChangeSize(float addSize)
    {
        springPivot.localScale = new Vector3(1, addSize+1, 1);
        itemHolder.localPosition = new Vector3(0, -addSize*2, 0);
    }
}
