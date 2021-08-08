using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezerInteractableP7 : MonoBehaviour
{
    [SerializeField] Animator freezerAnim;
    [SerializeField] List<Vector3> itemsPosition;

    [SerializeField] List<GameObject> itemsInFreezer = new List<GameObject>();

    PlayerController pController;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pController = other.GetComponent<PlayerController>();
            if (pController.isHolding)
            {
                freezerAnim.Play("Freezer Open P7");
                GameObject newItem = pController.PutDownItem(freezerAnim.gameObject.transform, freezerAnim.gameObject.transform.position);
                itemsInFreezer.Add(newItem);
            }
            else if(itemsInFreezer.Count == 2)
            {
                freezerAnim.Play("Freezer Open P7");
                for(int i=0;i<itemsInFreezer.Count;i++)
                {
                    if(itemsInFreezer[i].GetComponent<Cap>())
                    {
                        itemsInFreezer[i].GetComponent<Cap>().Freeze();
                    }else if(itemsInFreezer[i].GetComponent<Bottle>())
                    {
                        itemsInFreezer[i].GetComponent<Bottle>().Freeze();
                    }
                    itemsInFreezer[i].transform.SetParent(this.transform.parent);
                    itemsInFreezer[i].transform.position = itemsPosition[i];
                }
                itemsInFreezer = new List<GameObject>(); //reset List
}
        }
    }
}
