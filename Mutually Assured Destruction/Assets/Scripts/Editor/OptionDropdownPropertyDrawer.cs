using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(OptionDropdown))]
public class OptionDropdownPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var conditionString = property.FindPropertyRelative("optionName");
        var selected = property.FindPropertyRelative("selected");
        string[] keys = new string[OptionList.options.Keys.Count];
        OptionList.options.Keys.CopyTo(keys, 0);
        selected.intValue = EditorGUI.Popup(position, "Option", selected.intValue, keys);
        conditionString.stringValue = keys[selected.intValue];
    }

    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        var container = new VisualElement();
        var stringField = new PropertyField(property.FindPropertyRelative("optionName"));
        container.Add(stringField);
        return container;

    }




}
