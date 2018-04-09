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


    //public static Matrix Add(Matrix a, Matrix b)
    //{
    //  return PerformOperation(a, b, (x, y) => x + y);
    //}

    //public static Matrix Substract(Matrix a, Matrix b)
    //{
    //  return PerformOperation(a, b, (x, y) => x - y);
    //}

    //public static Matrix Multiply(Matrix a, Matrix b)
    //{
    //  if (a._size != b._m && a._m != b._size)
    //  {
    //    throw new InvalidOperationException("Multiplication could not be performed to matrices with different dimensions");
    //  }

    //  var resultMatrix = new Matrix(a._m, b._size);
    //  for (var i = 0; i < a._m; i++)
    //  {
    //    for (var j = 0; j < b._size; j++)
    //    {
    //      for (var k = 0; k < a._size; k++)
    //      {
    //        resultMatrix[i, j] += a[i, k] * b[k, j];
    //      }
    //    }
    //  }

    //  return resultMatrix;
    //}

    //public override string ToString()
    //{
    //  var resultString = new StringBuilder();
    //  for (var i = 0; i < _m; i++)
    //  {
    //    for (var j = 0; j < _size; j++)
    //    {
    //      resultString.Append(_matrix[i, j] + " ");
    //    }

    //    resultString.Append(Environment.NewLine);
    //  }

    //  return resultString.ToString();
    //}

    //public double CalculateDeterminant()
    //{
    //  if (_size != _m)
    //  {
    //    throw new InvalidOperationException("Determinant could not be calculated for not square matrix");
    //  }

    //  var leftTriangularMatrix = new Matrix(_size, _size);
    //  var rightTriangularMatrix = new Matrix(_size, _size);
    //  for (var i = 0; i < _size; i++)
    //  {
    //    rightTriangularMatrix[i, i] = 1;
    //  }

    //  for (var k = 0; k < _size; k++)
    //  {
    //    for (var i = 0; i < _size; i++)
    //    {
    //      leftTriangularMatrix[i, k] = _matrix[i, k];
    //      for (var p = 0; p < k; p++)
    //      {
    //        leftTriangularMatrix[i, k] -= leftTriangularMatrix[i, p] * rightTriangularMatrix[p, k];
    //      }
    //    }

    //    for (var j = k + 1; j < _size; j++)
    //    {
    //      rightTriangularMatrix[k, j] = _matrix[k, j];
    //      for (var p = 0; p < k; p++)
    //      {
    //        rightTriangularMatrix[k, j] -= leftTriangularMatrix[k, p] * rightTriangularMatrix[p, j];
    //      }

    //      rightTriangularMatrix[k, j] /= leftTriangularMatrix[k, k];
    //    }
    //  }

    //  return DeterminantOfTriangularMatrix(leftTriangularMatrix);
    //}

    //public double FindFirstMinorOfOrderK(int k)
    //{
    //  if (k <= 0 || k > _m || k > _size)
    //  {
    //    throw new ArgumentException("Minor could not be found for this order");
    //  }

    //  var minorMatrix = new Matrix(k, k);
    //  k -= 1;
    //  for (var i = 0; i <= k; i++)
    //  {
    //    for (var j = 0; j <= k; j++)
    //    {
    //      minorMatrix[i, j] = _matrix[i, j];
    //    }
    //  }

    //  return minorMatrix.CalculateDeterminant();
    //}

    //public double FindComplementMinorOfOrderK(int k)
    //{
    //  if (k <= 0 || k >= _m || k >= _size)
    //  {
    //    throw new ArgumentException("Minor could not be found for this order");
    //  }

    //  if (_size != _m)
    //  {
    //    throw new InvalidOperationException("Determinant could not be calculated for not square matrix");
    //  }

    //  var minorMatrix = new Matrix(_size - k, _size - k);
    //  k -= 1;
    //  for (var i = k + 1; i < _size; i++)
    //  {
    //    for (var j = k + 1; j < _size; j++)
    //    {
    //      minorMatrix[i - k - 1, j - k - 1] = _matrix[i, j];
    //    }
    //  }

    //  return minorMatrix.CalculateDeterminant();
    //}

    //public double FindMinorij(int rowIndex, int columnIndex)
    //{
    //  rowIndex -= 1;
    //  columnIndex -= 1;
    //  if (rowIndex < 0 || rowIndex >= _m || columnIndex < 0 || columnIndex >= _size)
    //  {
    //    throw new IndexOutOfRangeException("Indeces are out of range");
    //  }

    //  if (_size != _m)
    //  {
    //    throw new InvalidOperationException("Determinant could not be calculated for not square matrix");
    //  }

    //  var matrixWithoutRowAndColumn = new Matrix(_m - 1, _size - 1);
    //  for (var i = 0; i < rowIndex; i++)
    //  {
    //    for (var j = 0; j < columnIndex; j++)
    //    {
    //      matrixWithoutRowAndColumn[i, j] = _matrix[i, j];
    //    }
    //  }

    //  for (var i = 0; i < rowIndex; i++)
    //  {
    //    for (var j = columnIndex + 1; j < _size; j++)
    //    {
    //      matrixWithoutRowAndColumn[i, j - 1] = _matrix[i, j];
    //    }
    //  }

    //  for (var i = rowIndex + 1; i < _m; i++)
    //  {
    //    for (var j = 0; j < columnIndex; j++)
    //    {
    //      matrixWithoutRowAndColumn[i - 1, j] = _matrix[i, j];
    //    }
    //  }

    //  for (var i = rowIndex + 1; i < _m; i++)
    //  {
    //    for (var j = columnIndex + 1; j < _size; j++)
    //    {
    //      matrixWithoutRowAndColumn[i - 1, j - 1] = _matrix[i, j];
    //    }
    //  }

    //  return matrixWithoutRowAndColumn.CalculateDeterminant();
    //}

    //private static Matrix PerformOperation(Matrix a, Matrix b, Func<double, double, double> operation)
    //{
    //  if (a._size != b._size || a._m != b._m)
    //  {
    //    throw new InvalidOperationException("Operation could not be performed to matrices with different dimensions");
    //  }

    //  var resultMatrix = new Matrix(a._m, b._size);
    //  for (var i = 0; i < a._m; i++)
    //  {
    //    for (var j = 0; j < a._size; j++)
    //    {
    //      resultMatrix[i, j] = operation(a[i, j], b[i, j]);
    //    }
    //  }

    //  return resultMatrix;
    //}
  }
}
