﻿using RPGCore.Packages;
using RPGCore.UI;
using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable] public class AssetRendererPool : UIPool<AssetRenderer> { }

public class AssetRenderer : MonoBehaviour
{
	public Text Name;
	public RawImage Icon;
	
	public void Render(PackageAsset asset)
	{
		Name.text = asset.Root;
		Icon.texture = FindIcon(asset).LoadImage();
	}

	public static PackageResource FindIcon (PackageAsset asset)
	{
		for (int i = 0; i < asset.Resources.Length; i++)
		{
			if (asset.Resources[i].Name.EndsWith (".png", System.StringComparison.Ordinal))
			{
				return asset.Resources[i];
			}
		}
		return default (PackageResource);
	}
}
