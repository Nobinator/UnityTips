﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GenericMenuWindow : EditorWindow{
    [MenuItem("Window/Nobi/GUI Color")]
    static void Init(){
        EditorWindow window = GetWindow<GenericMenuWindow>();
        window.position = new Rect(50f, 50f, 200f, 24f);
        window.Show();
    }

    //??? Даже комментируя [SerializeField] ничего не меняется и значение цвета сохраняется после рекомпиляции скрипта.
    //??? может я не понимаю какой-то фишечки?
    // serialize field on window so its value will be saved when Unity recompiles
    [SerializeField]
    Color m_Color = Color.white;

    void OnEnable(){
        // Обращение к заголовку
        titleContent = new GUIContent("GUI Color");
    }

    // a method to simplify adding menu items
    void AddMenuItemForColor(GenericMenu menu, string menuPath, Color color){
        // the menu item is marked as selected if it matches the current value of m_Color
        // m_Color.Equals(color) отвечает за галочку у элемента
        // OnColorSelected - цункция выполняемая при нажатии на элемент
        // color - доп информация
        menu.AddItem(new GUIContent(menuPath), m_Color.Equals(color), OnColorSelected, color);
    }

    // the GenericMenu.MenuFunction2 event handler for when a menu item is selected
    void OnColorSelected(object color){
        m_Color = (Color)color;
    }

    void OnGUI(){
        // set the GUI to use the color stored in m_Color
        GUI.color = m_Color;

        // display the GenericMenu when pressing a button
        if (GUILayout.Button("Select GUI Color")){
            // create the menu and add items to it
            GenericMenu menu = new GenericMenu();

            // forward slashes nest menu items under submenus
            AddMenuItemForColor(menu, "RGB/Red", Color.red);
            AddMenuItemForColor(menu, "RGB/Green", Color.green);
            AddMenuItemForColor(menu, "RGB/Blue", Color.blue);

            // an empty string will create a separator at the top level
            menu.AddSeparator("");

            AddMenuItemForColor(menu, "CMYK/Cyan", Color.cyan);
            AddMenuItemForColor(menu, "CMYK/Yellow", Color.yellow);
            AddMenuItemForColor(menu, "CMYK/Magenta", Color.magenta);
            // a trailing slash will nest a separator in a submenu
            menu.AddSeparator("CMYK/");
            AddMenuItemForColor(menu, "CMYK/Black", Color.black);

            menu.AddSeparator("");

            AddMenuItemForColor(menu, "White", Color.white);

            // display the menu
            menu.ShowAsContext();
        }
    }
}
