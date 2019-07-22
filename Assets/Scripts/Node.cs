using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour {
    [Header("Color")]
    public Color hovercolor;
    public Color notenoughmoneycolor;
    private Color startcolor;
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretblueprint;
    [HideInInspector]
    public bool isupgraded = false;
    private Renderer rend;
    [Header("Coordinates")]
    public Vector3 positionoffset;


    BuildManager buildManager;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startcolor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionoffset;
    }
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }
        if (!buildManager.CanBuild)
            return;
        if (tag == "tree")
            return;

        BuildTurret(buildManager.GetTurretToBuild());
    }
    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.money < blueprint.cost)
        {
            Debug.Log("You Cant Buy");
            return;
        }
        PlayerStats.money -= blueprint.cost;
        GameObject _turret = Instantiate(blueprint.prefab,GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretblueprint = blueprint;
        GameObject effect = Instantiate(buildManager.buildeffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        Debug.Log("Turret built");
    }
    public void UpgradeTurret()
    {
        if (PlayerStats.money < turretblueprint.upgradecost)
        {
            Debug.Log("You Cant Upgrade");
            return;
        }
        PlayerStats.money -= turretblueprint.upgradecost;

        Destroy(turret);
        GameObject _turret = Instantiate(turretblueprint.upgradedprefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        GameObject effect = Instantiate(buildManager.buildeffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        isupgraded = true;
        Debug.Log("Turret upgraded");
    }

    public void SellTurret()
    {
        PlayerStats.money += turretblueprint.GetSellAmount();

        GameObject effect = Instantiate(buildManager.selleffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(turret);
        turretblueprint = null;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if(buildManager.HasMoney)
        {
            rend.material.color = hovercolor;
        }
        else
        {
            rend.material.color = notenoughmoneycolor;
        }

    }
    void OnMouseExit()
    {
        rend.material.color = startcolor;
    }

}
