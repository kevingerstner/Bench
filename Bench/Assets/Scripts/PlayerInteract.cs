﻿using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    [SerializeField]
    [Tooltip("The layers the items will be on")]
    private LayerMask layerMask;

    [SerializeField]
    [Tooltip("Radius when the interact button will appear")]
    private float interactRadius = 0.8f;

    [SerializeField]
    private InteractMessageManager imm;
    
    private Item itemBeingInteracted;

    void Start()
    {
    }

    void Update()
    {
        SelectInteractFromRay();

        if(itemBeingInteracted != null)
        {
            imm.ShowMessage();

            if(Input.GetKeyDown(KeyCode.E))
            {
                itemBeingInteracted.InteractAction();
            }
        }
        else
        {
            imm.HideMessage();
        }
    }

    private void SelectInteractFromRay()
    {
        Ray ray = camera.ViewportPointToRay(Vector3.one / 2f); // 0.5,0.5,0.5
        Debug.DrawRay(ray.origin, ray.direction * interactRadius, Color.red);

        RaycastHit hitInfo;

        if(Physics.Raycast(ray,out hitInfo, interactRadius, layerMask))
        {
            Item hitItem = hitInfo.collider.GetComponent<Item>();

            if (hitItem == null)
            {
                itemBeingInteracted = null;
            }
            else if (hitItem != null && hitItem != itemBeingInteracted)
            {
                itemBeingInteracted = hitItem;
                imm.SetMessage(itemBeingInteracted);
            }
        }
        else
        {
            itemBeingInteracted = null;
        }
    }
}
