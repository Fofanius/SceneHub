﻿using System;
using System.Collections.Generic;
using UnityEditor;

namespace SceneHub.Utilities
{
    public class AssetDatabaseUtility
    {
        /// <summary>
        /// Проводит поиск всех ассетов по указанному типу.
        /// </summary>
        /// <param name="condition">Правило выборки найденных ассетов в результирующую коллекцию.</param>
        public static List<T> FindAssetsByType<T>(Func<T, bool> condition = null) where T : UnityEngine.Object
        {
            var assets = new List<T>();
            var guids = AssetDatabase.FindAssets($"t:{typeof(T)}");

            foreach (var guid in guids)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);

                if (asset != null && (condition == null || condition(asset)))
                {
                    assets.Add(asset);
                }
            }

            return assets;
        }

        /// <summary>
        /// Последовательный вызов <see cref="AssetDatabase.Refresh()"/> и <see cref="AssetDatabase.SaveAssets()"/>.
        /// </summary>
        public static void RefreshAndSave()
        {
            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
        }
    }
}