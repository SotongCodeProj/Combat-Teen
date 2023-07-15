using System;
using UnityEngine;
using UnityEngine.Events;
using static CombTeen.Constant.ClassConstant;

public class ClassSelectorView : MonoBehaviour
{
    public UnityEvent<ClassType> OnSelectClass { private set; get; } = new UnityEvent<ClassType>();

    public void SelectClass(int selectedClass)
    {
        OnSelectClass?.Invoke((ClassType)selectedClass);
    }
}
