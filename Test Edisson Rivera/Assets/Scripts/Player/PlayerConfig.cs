using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConfig : MonoBehaviour
{
    public MeshRenderer[] meshPlayerBody;
    public PlayerData playerData;
    void Start()
    {
        if (!PlayerPrefs.HasKey("Skin"))
            PlayerPrefs.SetInt("Skin", 3);
        SetSkin(PlayerPrefs.GetInt("Skin"));
    }
    void SetSkin(int x)
    {
        foreach (MeshRenderer item in meshPlayerBody)
        {
            item.material = playerData.skins[x];
        }
    }
}
