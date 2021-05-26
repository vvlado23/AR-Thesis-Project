using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleInteraction : MonoBehaviour
{
    [SerializeField] PlayerController pController;
    [SerializeField] Transform[] platePositions;
    [SerializeField] Scale myScale;
    [SerializeField][Tooltip("left:-1 right:+1")] int itemOffset;

    [Header("Debug")]
    [SerializeField] Weight[] plateItems = new Weight[4];

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(pController.isHolding)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (!plateItems[i])
                    {
                        GameObject myItem = pController.PutDownItem(platePositions[i], platePositions[i].position);
                        if (myItem)
                        {
                            Weight itemWeight = myItem.GetComponent<Weight>();
                            plateItems[i] = itemWeight;
                            myScale.AddWeight(itemWeight.itemWeight * itemOffset);
                        }
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (plateItems[i])
                    {
                        myScale.AddWeight(plateItems[i].itemWeight * -itemOffset);//me to -itemOffset aferw baros
                        pController.PickUpItem(plateItems[i].gameObject.transform.GetChild(0));//to PickUpItem pernei to parent tou object, diladi to holder
                        plateItems[i] = null;
                        break;
                    }
                }
            }
        }
    }
}
