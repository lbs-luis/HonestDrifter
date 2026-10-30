# HonestDrifter (developer readme)

The store page is `thunderstore/HonestDrifter/README.md`.

## Layout

- `Directory.Build.props` and `Directory.Build.targets`: shared build settings, copied from HonestJunkDrone.
- `HonestDrifter/`: the mod project. `Plugin.cs` is the entry point, `Hooks/DrifterHooks.cs` the hooks.
- `thunderstore/HonestDrifter/`: the store files (`manifest.json`, `README.md`, `icon.png`).

## Build

```bash
dotnet build HonestDrifter.slnx -c Release
```

Output: `HonestDrifter/bin/Release/HonestDrifter.dll`. Copy it and the `.pdb` into `BepInEx/plugins/` to test.

## Dependencies

- BepInExPack
- HookGenPatcher, which generates `MMHOOK_RoR2.dll` on the player's machine (the project only references it at compile time)
