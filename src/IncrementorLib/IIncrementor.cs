#nullable enable
namespace IncrementorLib;

/// <summary>Счётчик с инкрементом и сбросом при достижении максимума.</summary>
public interface IIncrementor
{
	/// <summary>Возвращает текущее число (изначальное — 0).</summary>
	int GetNumber();

	/// <summary>Увеличивает число на 1; на максимуме — сбрасывает в 0.</summary>
	void IncrementNumber();

	/// <summary>Устанавливает максимальное значение (≥ 0). Если текущее больше нового максимального значения — сброс.</summary>
	void SetMaximumValue(int maximumValue);
}