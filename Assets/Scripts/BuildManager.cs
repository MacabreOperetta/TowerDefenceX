using UnityEngine;

public class BuildManager : MonoBehaviour {
    private TurretBlueprint turrettobuild;
    private Node selectednode;
    public static BuildManager instance;

    void Awake()
    {
        if(instance!=null)
        {
            Debug.LogError("More Than One Manager In Scene");
            return;
        }
        instance = this;
    }
    public GameObject buildeffect;
    public GameObject selleffect;
    // Use this for initialization
    public bool CanBuild { get { return turrettobuild != null; } }
    public bool HasMoney { get { return PlayerStats.money >= turrettobuild.cost; } }
    public NodeUI nodeui;

    public void SelectNode(Node node)
    {
        if(selectednode==node)
        {
            DeselectNode();
            return;
        }
        selectednode = node;
        turrettobuild = null;
        nodeui.SetTarget(node);
    }
    public void DeselectNode()
    {
        selectednode = null;
        nodeui.Hide();
    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turrettobuild = turret;
        DeselectNode();
    }
    public TurretBlueprint GetTurretToBuild()
    {
        return turrettobuild;
    }

}
