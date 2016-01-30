using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VillageUIContoller : MonoBehaviour {
    public Text txtNumResources;

    public void SetResources(int resourceNum)
    {
        try
        {
            txtNumResources.text = "Villagers: " + resourceNum;
        }
        catch
        {
            Debug.LogError("Cant find Resource Text");
        }
        
    }
}
