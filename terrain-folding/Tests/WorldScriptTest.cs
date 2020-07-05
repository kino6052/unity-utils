using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class WorldScriptTest
    {
        [Test]
        public void GenerateTerrain()
        {
            int[,,] world = WorldScript.GenerateTerrain(2, 2);
            Assert.AreEqual(world.Length, 8);
        }

        [Test]
        public void FoldTerrainByFactor()
        {
            int[,,] world = WorldScript.GenerateTerrain(8, 8);
            int[,,] foldedWorld = WorldScript.FoldTerrainByFactor(2, world, 8, 8);
            Assert.AreEqual(64, foldedWorld.Length);
        }

        [Test]
        public void FoldTerrain()
        {
            int[,,] world = WorldScript.GenerateTerrain(128, 128);
            Dictionary<int, int[,,]> folds = WorldScript.FoldTerrain(world, 128, 128);
            Assert.AreEqual(8, folds.Count);
        }
    }
}
