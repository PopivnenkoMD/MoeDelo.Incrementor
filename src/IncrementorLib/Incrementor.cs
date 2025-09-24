#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncrementorLib;

/// <summary>Потокобезопасная реализация с ипсользованием lock.</summary>
/// <remarks>sealed (предположим, что в рамках тестового задания наследование не предусматривается).</remarks>
public sealed class Incrementor : IIncrementor
{
	private readonly object _lock = new();
	private int _currentValue;
	private int _maximumValue;

	/// <summary>Создаёт счётчик с максимумом (по умолчанию int.MaxValue).</summary>
	/// <exception cref="ArgumentOutOfRangeException">Если maximumValue &lt; 0.</exception>
	public Incrementor(int maximumValue = int.MaxValue)
	{
		if (maximumValue < 0)
			throw new ArgumentOutOfRangeException(nameof(maximumValue), maximumValue, "Максимальное значение должно быть >= 0.");

		_maximumValue = maximumValue;
		_currentValue = 0;
	}

	/// <inheritdoc />
	public int GetNumber()
	{
		lock (_lock) return _currentValue;
	}

	/// <inheritdoc />
	public void IncrementNumber()
	{
		lock (_lock)
		{
			if (_maximumValue == 0) { _currentValue = 0; return; }
			_currentValue = (_currentValue >= _maximumValue - 1) ? 0 : _currentValue + 1;
		}
	}

	/// <inheritdoc />
	public void SetMaximumValue(int maximumValue)
	{
		if (maximumValue < 0)
			throw new ArgumentOutOfRangeException(nameof(maximumValue), maximumValue, "Максимальное значение должно быть >= 0.");

		lock (_lock)
		{
			_maximumValue = maximumValue;
			if (_currentValue >= maximumValue || maximumValue == 0)
				_currentValue = 0;
		}
	}
}
