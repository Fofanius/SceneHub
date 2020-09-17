using UnityEditor;
using UnityEngine;

namespace SceneHub
{
    [System.Serializable]
    public sealed class SceneInfo
    {
#pragma warning disable 0649
        [Tooltip("Название, использующееся для отображения.")]
        [SerializeField] internal string Title;
        [Tooltip("Ссылка на объект сцены.")]
        [SerializeField] internal SceneAsset Scene;
        [Tooltip("Цвет, которым будет отображаться кнопка в hub-е.")]
        [SerializeField] internal Color Color;
#pragma warning restore 0649


        public string SafeTitle => string.IsNullOrWhiteSpace(Title) ? $"[{(Scene ? Scene.name : "Empty")}]" : Title;

        public override string ToString() => $"{Title} [{Scene}]";
    }
}