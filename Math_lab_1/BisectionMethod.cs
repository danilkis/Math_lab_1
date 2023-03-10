using System;
using System.Collections.Generic;

public class BisectionMethodSolver {
    private Func<double, double> _functionToSolve;
    private double _lowerBound;
    private double _upperBound;
    private double _tolerance;

    public BisectionMethodSolver(string[] inputs) {
        _functionToSolve = (x) => double.Parse(inputs[0]) * Math.Pow(x, 3) + double.Parse(inputs[1]) * Math.Pow(x, 2) + double.Parse(inputs[2]) * x + double.Parse(inputs[3]);
        _lowerBound = double.Parse(inputs[4]);
        _upperBound = double.Parse(inputs[5]);
        _tolerance = 0.001;
    }

    public List<string> Solve() {
        List<string> steps = new List<string>();
        double x, fx;
        double fLowerBound = _functionToSolve(_lowerBound);
        double fUpperBound = _functionToSolve(_upperBound);

        if (fLowerBound * fUpperBound >= 0)
        {
            steps.Add("В данных границах не удалось найти корень\n");
            steps.Add("Половинчатый метод не может быть применен\n");
            steps.Add("Решение отмененно\n");
            return steps;
        }

        int iteration = 0;
        while ((_upperBound - _lowerBound) > _tolerance) {
            iteration++;
            x = (_lowerBound + _upperBound) / 2;
            fx = _functionToSolve(x);

            if (fx == 0.0) {
                steps.Add($"Корень надйен после {iteration} итераций.\n");
                steps.Add($"Корень равен: {x}\n");
                return steps;
            }
            else if (fx * fLowerBound < 0) {
                _upperBound = x;
                fUpperBound = fx;
                steps.Add($"Итерация {iteration} новый верхний предел: {_upperBound}\n");
            }
            else {
                _lowerBound = x;
                fLowerBound = fx;
                steps.Add($"Итерация {iteration} новый нижний предел: {_lowerBound}\n");
            }
        }

        steps.Add($"Ответ найден после {iteration} итераций .\n");
        steps.Add($"Корень равен: {(_lowerBound + _upperBound) / 2}\n");
        return steps;
    }
}
