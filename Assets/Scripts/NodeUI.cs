using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {
    private Node targetnode;
    public GameObject ui;
    public Text upgradecost;
    public Text sellAmount;
    public Button button;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetTarget(Node _target)
    {
        targetnode = _target;
        transform.position = targetnode.GetBuildPosition();

        if(!targetnode.isupgraded)
        {
            upgradecost.text = targetnode.turretblueprint.upgradecost.ToString() + "£";
            button.interactable = true;
        }
        else
        {
            upgradecost.text = "DONE";
            button.interactable = false;
        }

        sellAmount.text = targetnode.turretblueprint.GetSellAmount().ToString() + "£";
        ui.SetActive(true);
    }
    public void Hide()
    {
        ui.SetActive(false);
    }
    public void Upgrade()
    {
        targetnode.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        targetnode.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
