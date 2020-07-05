using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class WorldScript
{
    public static int[,,] GenerateTerrain(int dimension, int height) {
        int[,,] array = new int[dimension,height,dimension];
        if (dimension % 2 != 0 || height % 2 != 0) throw new System.Exception("Dimension and Height Should be Multiples of 2");
        Dictionary<string, int> dict = new Dictionary<string, int>();
        for (int x = 0; x < dimension; x++) {
            for (int z = 0; z < dimension; z++) {
                for (int y = 0; y < height; y++) {
                    int level = Mathf.FloorToInt(height * Mathf.PerlinNoise(x/10f, z/10f));
                    if (y <= level) array[x,y,z] = 1;
                    else array[x,y,z] = 0;
                }
            }
        }
        return array;
    }

    static int GetAverageFromChunk(int factor, int _x, int _y, int _z, int[,,] arr) {
        int average = 0;
        for (int x = 0; x < factor; x++) {
            for (int z = 0; z < factor; z++) {
                for (int y = 0; y < factor; y++) {
                    try {
                        average += arr[_x * factor + x, _y * factor + y, _z * factor + z];
                    } catch (Exception e) {
                        average += 0;
                    }
                }
            }
        }
        // average = (int) Math.Round(average / Math.Pow(factor, 3));
        return average;
    }

    public static int[,,] FoldTerrainByFactor(int factor, int[,,] arr, int dimension, int height) {
        Debug.Log(factor + ", " + dimension + ", " + height);
        if (dimension % 2 != 0 || height % 2 != 0) throw new System.Exception("Dimension and Height Should be Multiples of 2");
        int _dimension = (int)dimension/factor;
        int _height = (int)height/factor;
        int[,,] array = new int[_dimension,_height,_dimension];
        int _x = 0;
        int _y = 0;
        int _z = 0;
        for (int x = 0; x < dimension; x += factor)
        {
            for (int z = 0; z < dimension; z += factor)
            {
                for (int y = 0; y < height; y += factor)
                {
                    int average = GetAverageFromChunk(factor, _x, _y, _z, arr);
                    array[_x, _y, _z] = average;
                    _y += 1;
                }
                _z += 1;
                _y = 0;
            }
            _x += 1;
            _z = 0;
        }
        return array;
    }

    static int[,,] CopyArray(int[,,] arr, int dimension, int height) {
        int[,,] _arr = new int[dimension, height, dimension];
        for (int x = 0; x < dimension; x ++) {
            for (int z = 0; z < dimension; z ++) {
                for (int y = 0; y < height; y ++) {
                    _arr[x,y,z] = arr[x,y,z];
                }
            }    
        }
        return _arr;
    }

    public static Dictionary<int, int[,,]> FoldTerrain(int [,,] arr, int dimension, int height) {
        if (dimension % 2 != 0 || height % 2 != 0) throw new System.Exception("Dimension and Height Should be Multiples of 2");
        int factor = 2;
        int _dimension = dimension;
        int _height = height;
        int[,,] _arr = arr;
        Dictionary<int, int[,,]> dTerrain = new Dictionary<int, int[,,]>();
        dTerrain.Add(factor, CopyArray(_arr, _dimension, _height));
        while (_dimension >= 2 && _height >= 2) {
            factor *= 2;
            _arr = FoldTerrainByFactor(2, _arr, _dimension, _height);
            _dimension = _dimension / 2;
            _height = _height / 2;
            dTerrain.Add(factor, CopyArray(_arr, _dimension, _height));
        }
        return dTerrain;
    }

    // int[] GetReducedBlockByCoordinates() {

    // } 
}
