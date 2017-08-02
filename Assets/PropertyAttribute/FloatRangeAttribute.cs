using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FloatRangeAttribute : PropertyAttribute{
	// Атрибут с двумя переменными
	public float MinLimit, MaxLimit;

	public FloatRangeAttribute(float minLimit, float maxLimit)
	{
		this.MinLimit = minLimit;
		this.MaxLimit = maxLimit;
	}
}

[System.Serializable]
public class FloatRange{
	// Реализация рандома
	public float RangeStart, RangeEnd;

	private float GetRandomValue()
	{
		return Random.Range(RangeStart, RangeEnd);
	}
    
    // Видимо этот оператор срабатывает всегда (?)
	public static implicit operator float(FloatRange d){  // implicit digit to byte conversion operator
		return d.GetRandomValue();
	}

}