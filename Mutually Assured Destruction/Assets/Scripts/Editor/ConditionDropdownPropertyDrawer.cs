using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(ConditionDropdown))]
public class ConditionDropdownPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var conditionString = property.FindPropertyRelative("conditionName");
        var selected = property.FindPropertyRelative("selected");
        string[] keys = new string[ConditionList.conditions.Keys.Count];
        ConditionList.conditions.Keys.CopyTo(keys, 0);
        selected.intValue = EditorGUI.Popup(position, "Condition", selected.intValue, keys);
        conditionString.stringValue = keys[selected.intValue];
    }

    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        var container = new VisualElement();
        var stringField = new PropertyField(property.FindPropertyRelative("conditionName"));
        container.Add(stringField);
        return container;

    }

}
