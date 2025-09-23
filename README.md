# Incrementor

���������������� �������, ������� ���������������� �� ��������� � ������������ � 0.

## ���������
- ��������� ��������: `0`.
- �������� �� ���������: `int.MaxValue`.
- `IncrementNumber()`:
  - ���� ������� `< Maximum - 1` �� `+1`;
  - ���� �������� `Maximum` �� ����� � `0`.
- `SetMaximumValue(m)`:
  - ��������� `m < 0`;
  - ���� ������� �������� `> m` ��� `m == 0` �� ����� � `0`.

## ������������������
- ��� �������� �������� ����� `lock` �� ����� ���� (`_currentValue`, `_maximumValue`).

## ����������
- `0 <= _currentValue <= int.MaxValue`
- `0 <= _maximumValue <= int.MaxValue`
- ��� `_maximumValue == 0` ������� �������� `_currentValue` ������ `0`.

## ������� �� �������
- `sealed` � (�����������, ��� � ������ ��������� ������� ������������ �� �����������������); ��� ����� ��������� ����������.
- ��������� �������: 
	- ���������� (`src/IncrementorLib`), 
	- ������ (`samples/Incrementor.Demo`), 
	- ����� (`tests/IncrementorLib.Tests`).

## ����-�����
- StartsAtZero: ��������, ��� � ������ ������� ����� '0'
- IncrementsAndWraps: �������� ������������������ � ��������� �� ���������� ������������� ��������
- ReducingMaximum_Resets_WhenCurrentExceedsNewMax: �������� ������ ��� ���������� ������������� �������, ���� ������� �������� ����� ������������
- ReducingMaximum_DoesNotReset_WhenCurrentIsWithinNewMax: ��������, ��� ��� ���������� ������������� ������� �� ����������, ���� ������� �� ��� � ���������
- ZeroMaximum_AlwaysZero: �������� ������, ����� ������������ �������� == 0
- MaxEqualsOne_AlwaysZeroAfterAnyIncrement: �������� ���������� �������� maximum = 1
- NegativeMaximum_Throws: �������� ��������� - ������ ���������� maximum < 0

## ������� �����
```bash
dotnet build
dotnet test
dotnet run --project .\samples\Incrementor.Demo\Incrementor.Demo.csproj