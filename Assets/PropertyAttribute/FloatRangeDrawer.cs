//Place in an "Editor" Folder. Keep your folders tidy or I will get you.
//apologies for the magic values below
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomPropertyDrawer( typeof( FloatRangeAttribute ) )]
public class FloatRangeDrawer : PropertyDrawer{
    
    // Высота пространства под отрисовку
    public override float GetPropertyHeight( SerializedProperty property, GUIContent label ){
        return base.GetPropertyHeight( property, label ) + 16;
    }

    // Draw the property inside the given rect
    public override void OnGUI( Rect position, SerializedProperty property, GUIContent label ){
        
        // Now draw the property as a Slider or an IntSlider based on whether it’s a float or integer.
        // Если отрисовка вызвана, но тип свойста, над которым стоит этот аттрибут другой
        if (property.type != typeof(FloatRange).ToString())
            Debug.LogWarning("Use only with IntRange type");
        else{
            // Получаем атрибут текущего свойства
            FloatRangeAttribute range = attribute as FloatRangeAttribute;
            // Получаем значения промежутка у текущего свойства
            SerializedProperty minValue = property.FindPropertyRelative("RangeStart");
            SerializedProperty maxValue = property.FindPropertyRelative("RangeEnd");
            // Переводим во float
            float newMin = minValue.floatValue;
            float newMax = maxValue.floatValue;
            // Запоминаем 40% от ширины пространства для отрисовки
            float xDivision = position.width * .4f;
            // Запоминаем 5% от ширины пространства для отрисовки (но посчитано относительно xDivision)
            float xLabelDiv = xDivision * 0.125f;
            // Запоминаем 50% от высоты пространства для отрисовки
            float yDivision = position.height * 0.5f;
            // Рисуем надпись в пространстве от начала до 40% по ширине и 50% по высоте
            EditorGUI.LabelField(new Rect(position.x, position.y, xDivision, yDivision), label);

            // Определяем пространство, оставшееся справа от надписи
            Rect mmRect = new Rect(position.x + xDivision + xLabelDiv, position.y, position.width - (xDivision + xLabelDiv * 2), yDivision);

            // ReSharper disable once PossibleNullReferenceException
            // Рисуем слайдер с двумя концами
            EditorGUI.MinMaxSlider(mmRect, ref newMin, ref newMax, range.MinLimit, range.MaxLimit);

            // Определяем пространство слева от слайдера с шириной 5%
            Rect minRangeRect = new Rect(position.x + xDivision, position.y, xLabelDiv, yDivision);
            // Какие-то вычисления для более точного позиционирования
            minRangeRect.x += xLabelDiv * 0.5f - 12;
            minRangeRect.width = 24;
            // Рисование текста слева от слайдера
            EditorGUI.LabelField(minRangeRect, range.MinLimit.ToString());

            // Аналогично с правым краем
            Rect maxRangeRect = new Rect(minRangeRect);
            maxRangeRect.x = mmRect.xMax + xLabelDiv * 0.5f - 12;
            maxRangeRect.width = 24;
            EditorGUI.LabelField(maxRangeRect, range.MaxLimit.ToString());

            // Копируем границы пространства, оставшегося справа от надписи (под слайдер)
            Rect minLabelRect = new Rect(mmRect);
            // Тут корявые калькуляции, закомментил
            //minLabelRect.x ;//+= minLabelRect.width * (newMin / range.MaxLimit);
            //minLabelRect.x -= 12; // Тут не будем ничего сдвигать
            minLabelRect.y += yDivision;
            // Мои вычисления вместо старых
            minLabelRect.width = minLabelRect.width/2 - 12;
            
            newMin = Mathf.Clamp(EditorGUI.FloatField(minLabelRect, newMin), range.MinLimit, newMax);
            //EditorGUI.LabelField(minLabelRect, newMin.ToString());

            Rect maxLabelRect = new Rect(mmRect);
            maxLabelRect.x += minLabelRect.width + 24;
            //maxLabelRect.x -= 12;
            //maxLabelRect.x = Mathf.Max(maxLabelRect.x, minLabelRect.xMax);
            maxLabelRect.y += yDivision;
            maxLabelRect.width = maxLabelRect.width/2 -12;
            newMax = Mathf.Clamp(EditorGUI.FloatField(maxLabelRect, newMax), newMin, range.MaxLimit);
            //EditorGUI.LabelField(maxLabelRect, newMax.ToString());

            //Записываем во FloatRange новые данные
            minValue.floatValue = newMin;
            maxValue.floatValue = newMax;
        }
    }
}