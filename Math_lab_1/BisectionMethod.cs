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

    public double Solve() {
        double x, fx;
        double fLowerBound = _functionToSolve(_lowerBound);
        double fUpperBound = _functionToSolve(_upperBound);

        if (fLowerBound * fUpperBound >= 0)
        {
            return 0;
        }

        while ((_upperBound - _lowerBound) > _tolerance) {
            x = (_lowerBound + _upperBound) / 2;
            fx = _functionToSolve(x);

            if (fx == 0.0) {
                return x;
            }
            else if (fx * fLowerBound < 0) {
                _upperBound = x;
                fUpperBound = fx;
            }
            else {
                _lowerBound = x;
                fLowerBound = fx;
            }
        }

        return (_lowerBound + _upperBound) / 2;
    }

    public List<Tuple<double, double>> GetXYPoints() {
        List<Tuple<double, double>> points = new List<Tuple<double, double>>();
        double x = _lowerBound;

        while (x <= _upperBound) {
            double y = _functionToSolve(x);
            points.Add(new Tuple<double, double>(x, y));
            x += _tolerance;
        }

        return points;
    }
}