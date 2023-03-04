using System;
using System.Linq;

namespace Math_lab_1;
/*
 * Данный код представляет собой класс GornerTable,
 * который содержит метод Solve для решения полиномиальных уравнений методом Горнера.
 */
public class GornerTable
{
    public static double Solve(string[] input)
    {
        double[] coeffs = new double[input.Length];
        for (int i = 0; i < input.Length; i++) {
            coeffs[i] = double.Parse(input[i]);
        }
        // Инициализация начального значения guess равным 0, значения точности epsilon,
        // максимального количества итераций maxIterations и счетчика итераций iteration.
        double guess = 0;
        double epsilon = 0.001;
        double f, fprime;
        int maxIterations = 6000;
        int iteration = 0;
        //Запуск цикла, в котором применяется метод Горнера для уточнения значения корня.
        //Цикл продолжается, пока абсолютное значение f (значение полинома при текущем значении guess) больше epsilon
        //или достигнуто максимальное количество итераций.
        do {
            f = coeffs[0];
            fprime = coeffs[0];
            for (int i = 1; i < coeffs.Length; i++) {
                f = f * guess + coeffs[i];
                if (i < coeffs.Length - 1) {
                    fprime = fprime * guess + i * coeffs[i];
                }
            }
            //Внутри цикла программа вычисляет значение f и fprime
            //(первой производной f) с использованием текущего значения guess.
            guess = guess - f / fprime;
            iteration++;
        } while (Math.Abs(f) > epsilon && iteration < maxIterations);
        //Цикл продолжается до тех пор, пока не будет достигнут критерий сходимости или максимальное количество итераций.
        if (iteration == maxIterations)
        {
            //Если максимальное количество итераций достигнуто без сходимости, программа возвращает 0.
            return 0;
        } 
        else {
            //Если достигнут критерий сходимости, программа возвращает значение корня
            return guess;
        }
    }
}