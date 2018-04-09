using System;
using System.Collections.Generic;
using System.Text;

namespace HierarhyTest.Helpers
{
  public class Matrix
  {
    private double[,] _matrix;
    private int _size;
    //private int _m;

    public Matrix(int n)
    {
      _matrix = new double[n, n];
      _size = n;
    }

    public int Size
    {
      get
      {
        return _size;
      }
    }

    public Matrix(double[,] matrix)
    {
      _matrix = matrix;
      //_m = matrix.GetLength(0);
      _size = matrix.GetLength(0);
    }

    public double this[int i, int j]
    {
      get { return _matrix[i, j]; }

      set { _matrix[i, j] = value; }
    }

    public IList<double> GetMatrixColumn(int index)
    {
      if (index > _size)
      {
        throw new ArgumentOutOfRangeException();
      }

      var columnElements = new List<double>();
      for (int i = 0; i < _size; i++)
      {
        columnElements.Add(_matrix[i, index]);
      }

      return columnElements;
    }

    public IList<double> MultipleOnVector(IList<double> vector)
    {
      var result = new List<double>();
      for (int i = 0; i < _size; i++)
      {
        double sum = 0;
        for (int j = 0; j < _size; j++)
        {
          sum += _matrix[i, j] * vector[j];
        }

        result.Add(sum);
      }

      return result;
    }

  }
}
