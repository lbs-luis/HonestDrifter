using RoR2;
using UnityEngine;

namespace HonestDrifter.Hooks
{
    /// <summary>
    /// The Drifter's Salvage state drops its temporary items as droplets, and with the Artifact of Command each droplet opens
    /// a Command Cube with random options. The game's own opt-out is UniquePickup.ignoreArtifactBasedPickupReplacements
    /// (PickupSpawner and ItemSpawnPoint use it). The items dropped by Salvage.DropTempItemServer are marked with it, so they
    /// land on the ground as regular pickups.
    /// </summary>
    internal static class DrifterHooks
    {
        private static bool _dropping;

        public static void Init()
        {
            On.EntityStates.Drifter.Salvage.DropTempItemServer += Salvage_DropTempItemServer;
            On.RoR2.PickupDropletController.CreatePickupDroplet_UniquePickup_Vector3_Vector3_bool_bool += PickupDropletController_CreatePickupDroplet_UniquePickup_Vector3_Vector3_bool_bool;
        }

        private static void Salvage_DropTempItemServer(On.EntityStates.Drifter.Salvage.orig_DropTempItemServer orig, EntityStates.Drifter.Salvage self)
        {
            _dropping = true;
            try
            {
                orig(self);
            }
            finally
            {
                _dropping = false;
            }
        }

        private static void PickupDropletController_CreatePickupDroplet_UniquePickup_Vector3_Vector3_bool_bool(On.RoR2.PickupDropletController.orig_CreatePickupDroplet_UniquePickup_Vector3_Vector3_bool_bool orig, UniquePickup pickup, Vector3 position, Vector3 velocity, bool isDuplicated, bool isRecycled)
        {
            if (_dropping)
            {
                pickup.ignoreArtifactBasedPickupReplacements = true;
            }
            orig(pickup, position, velocity, isDuplicated, isRecycled);
        }
    }
}
