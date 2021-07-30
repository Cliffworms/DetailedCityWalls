// Project:         DetailedCityWalls mod for Daggerfall Unity (http://www.dfworkshop.net)
// Copyright:       Copyright (C) 2021 Cliffworms
// License:         MIT License (http://www.opensource.org/licenses/mit-license.php)
// Author:          Hazelnut & Cliffworms

using System;
using UnityEngine;
using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Game.Serialization;
using DaggerfallWorkshop.Game.Utility;
using DaggerfallWorkshop.Game.Utility.ModSupport;
using DaggerfallWorkshop.Utility.AssetInjection;

namespace DetailedCityWalls
{
    public class DetailedCityWallsMod : MonoBehaviour
    {
        private const string variantDaggerfall = "_daggerfall";
        private const string variantWayrest = "_wayrest";
        private const string variantSentinel = "_sentinel";

        static Mod mod;

        [Invoke(StateManager.StateTypes.Start, 0)]
        public static void Init(InitParams initParams)
        {
            mod = initParams.Mod;
            var go = new GameObject(mod.Title);
            go.AddComponent<DetailedCityWallsMod>();
        }

        void Awake()
        {
            Debug.Log("Begin mod init: DetailedCityWalls");

            SaveLoadManager.OnLoad += SaveLoadManager_OnLoad;
            StartGameBehaviour.OnStartGame += StartGameBehaviour_OnStartGame;

            mod.IsReady = true;
            Debug.Log("Finished mod init: DetailedCityWalls");
        }


        public void StartGameBehaviour_OnStartGame(object sender, EventArgs e)
        {
            InitVariants();
        }

        void SaveLoadManager_OnLoad(SaveData_v1 saveData)
        {
            InitVariants();
        }

        void InitVariants()
        {
            // Daggerfall (1231) in region 17
            if (WorldDataVariants.GetBuildingVariant(17, 1231, "WALLAA00.RMB", 0) == null)
            {
                int locDaggerfall = WorldDataReplacement.MakeLocationKey(17, 1231);
                WorldDataVariants.SetBuildingVariant("WALLAA00.RMB", 0, variantDaggerfall, locDaggerfall);
                WorldDataVariants.SetBuildingVariant("WALLAA01.RMB", 0, variantDaggerfall, locDaggerfall);
                WorldDataVariants.SetBuildingVariant("WALLAA02.RMB", 0, variantDaggerfall, locDaggerfall);
                WorldDataVariants.SetBuildingVariant("WALLAA03.RMB", 0, variantDaggerfall, locDaggerfall);
                WorldDataVariants.SetBuildingVariant("WALLAA08.RMB", 0, variantDaggerfall, locDaggerfall);
                WorldDataVariants.SetBuildingVariant("WALLAA09.RMB", 3, variantDaggerfall, locDaggerfall);
                WorldDataVariants.SetBuildingVariant("WALLAA10.RMB", 0, variantDaggerfall, locDaggerfall);
                WorldDataVariants.SetBuildingVariant("WALLAA11.RMB", 0, variantDaggerfall, locDaggerfall);
            }
            // Sentinel (6) in region 20
            if (WorldDataVariants.GetBuildingVariant(20, 6, "WALLAA00.RMB", 0) == null)
            {
                int locSentinel = WorldDataReplacement.MakeLocationKey(20, 6);
                WorldDataVariants.SetBuildingVariant("WALLAA00.RMB", 0, variantSentinel, locSentinel);
                WorldDataVariants.SetBuildingVariant("WALLAA01.RMB", 0, variantSentinel, locSentinel);
                WorldDataVariants.SetBuildingVariant("WALLAA02.RMB", 0, variantSentinel, locSentinel);
                WorldDataVariants.SetBuildingVariant("WALLAA03.RMB", 0, variantSentinel, locSentinel);
                WorldDataVariants.SetBuildingVariant("WALLAA08.RMB", 0, variantSentinel, locSentinel);
                WorldDataVariants.SetBuildingVariant("WALLAA09.RMB", 3, variantSentinel, locSentinel);
                WorldDataVariants.SetBuildingVariant("WALLAA10.RMB", 0, variantSentinel, locSentinel);
                WorldDataVariants.SetBuildingVariant("WALLAA11.RMB", 0, variantSentinel, locSentinel);
            }

        }
    }
}