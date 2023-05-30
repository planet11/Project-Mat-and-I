using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public  class Item : ScriptableObject { 

    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
}

//using UnityEngine;

//[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
//public static class Item
//{
//    new public static string name = "New Item";
//    public static Sprite icon = null;
//    public static bool isDefaultItem = false;
//}
