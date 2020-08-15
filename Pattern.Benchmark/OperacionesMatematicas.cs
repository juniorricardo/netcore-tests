using System;
using BenchmarkDotNet.Attributes;

namespace Pattern.Benchmark
{
    [MarkdownExporter, AsciiDocExporter, HtmlExporter, CsvExporter, RPlotExporter]
    public class OperacionesMatematicas
    {
        public double Suma(double a, double b) => a + b;

        public double Multiplicacion(double a, double b) => a * b;

        public double Potencia(double @base, double exponente) => Math.Pow(@base, exponente);

        public double Potencia2(double @base, double exponente)
        {
            if (exponente == 0)
                return 1;

            var resultado = @base;
            for (int i = 1; i < exponente; i++)
                resultado = resultado * @base;

            return resultado;
        }
    }
}
