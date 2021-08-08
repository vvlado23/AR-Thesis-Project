using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cap : MonoBehaviour
{
    [SerializeField] IceCubesRotate frozenLiquid;
    [SerializeField] GameObject liquid;
    public bool isOil;
    public bool frozen=false;
    Vector3 startPosition;
    Transform startParent;

    private void Start()
    {
        startPosition = transform.position;
        startParent = transform.parent;
    }

    public void Freeze()
    {
        Instantiate(frozenLiquid, liquid.transform.position, liquid.transform.rotation,transform.GetChild(0));
        frozenLiquid.rotateSpeed = 0;
        liquid.gameObject.SetActive(false);
        frozen = true;
    }

    public void IceToGlass(Transform glassPosition, PlayerController pController)
    {
        IceCubesRotate ice =Instantiate(frozenLiquid, glassPosition.position, glassPosition.rotation, glassPosition);
        ice.rotateSpeed = 20;
        ResetCap(pController);
    }

    void ResetCap(PlayerController pController)
    {
        pController.PutDownItem(startParent, startPosition);
        GameObject ice = GetComponentInChildren<IceCubesRotate>().gameObject;
        Destroy(ice);
        liquid.SetActive(true);
    }
}
