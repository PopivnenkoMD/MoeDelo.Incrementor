# Incrementor

Потокобезопасный счётчик, который инкрементируется до максимума и сбрасывается в 0.

## Поведение
- Стартовое значение: `0`.
- Максимум по умолчанию: `int.MaxValue`.
- `IncrementNumber()`:
  - если текущее `< Maximum - 1` то `+1`;
  - если достигли `Maximum` то сброс в `0`.
- `SetMaximumValue(m)`:
  - запрещает `m < 0`;
  - приводит состояние к валидному диапазону: при `m == 0` → `0`; при `m > 0` и `current >= m` → `0`.

## Потокобезопасность
- Все операции защищены одним `lock` на общие поля (`_currentValue`, `_maximumValue`).

## Инварианты
- `0 <= _maximumValue <= int.MaxValue`
- Если `_maximumValue == 0` → `_currentValue == 0`
- Если `_maximumValue > 0` → `0 <= _currentValue < _maximumValue`

## Решения по дизайну
- `sealed` — (предположим, что в рамках тестового задания наследование не предусматривается); так проще сохранять инварианты.
- Отдельные проекты: 
	- библиотека (`src/IncrementorLib`), 
	- пример (`samples/Incrementor.Demo`), 
	- тесты (`tests/IncrementorLib.Tests`).

## Юнит-тесты
- StartsAtZero: проверка, что в начале счётчик равен '0'
- IncrementsAndWraps: проверка инкрементирования и обнуления по доситжении максимального зачения
- ReducingMaximum_Resets_WhenCurrentExceedsNewMax: проверка сброса при уменьшении максимального зачения, если текущее значение стало недопустимым
- ReducingMaximum_DoesNotReset_WhenCurrentIsWithinNewMax: проверка, что при уменьшении максимального зачения текущее значение не сбрасываем, если текущее всё ещё в допустимом диапазоне
- ReducingMaximum_ToEqualCurrent_Resets: при уменьшении максимума до значения, равного текущему, счётчик сбрасывается в 0 (инвариант: при max > 0 всегда current < max)
- ZeroMaximum_AlwaysZero: проверка случая, когда максимальное значение == 0
- MaxEqualsOne_AlwaysZeroAfterAnyIncrement: проверка граничного значения maximum = 1
- NegativeMaximum_Throws: проверка валидации - нельзя установить maximum < 0

## Быстрый старт
```bash
dotnet build
dotnet test
dotnet run --project .\samples\Incrementor.Demo\Incrementor.Demo.csproj