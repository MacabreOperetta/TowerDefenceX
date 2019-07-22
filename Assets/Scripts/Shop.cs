using UnityEngine;

public class Shop : MonoBehaviour {
    public TurretBlueprint standardturret;
    public TurretBlueprint missilelauncher;
    public TurretBlueprint laser;
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret");
        buildManager.SelectTurretToBuild(standardturret);
    }
    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher");
        buildManager.SelectTurretToBuild(missilelauncher);
    }
    public void SelectLaser()
    {
        Debug.Log("Laser");
        buildManager.SelectTurretToBuild(laser);
    }
}
