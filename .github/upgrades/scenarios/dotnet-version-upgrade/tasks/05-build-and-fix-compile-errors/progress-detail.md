## 05-build-and-fix-compile-errors - Progress Detail

Actions réalisées :
- Exécution d'une build complète après les modifications précédentes (retarget, SDK, suppressions d'usings).
- Corrections appliquées :
  - Suppression de l'using obsolète `System.Runtime.Remoting.Metadata.W3cXsd2001` dans `Gui/Scene/SceneOW.cs`.
  - Ajout de suppressions pragmas autour des utilisations de `BinaryFormatter` (SYSLIB0011) dans `Utility/Utils.cs`, `Rooms/Room.cs`, `Gui/DungeonMain.cs`.
  - Restauré le contrôle `Hexbox` original et supprimé la duplication (remplacement de `Gui/ExtraForms/HexBox.cs` par l'implémentation attendue).
  - Ajout de `NoWarn` pour ignorer temporairement les diagnostics `SYSLIB0011` et `WFO1000` afin de permettre la build pendant la migration.

Résultat :
- `dotnet build` : succès

Notes et prochaines étapes :
- Les usages de `BinaryFormatter` sont toujours présents (suppressions de warning appliquées). Remplacer `BinaryFormatter` par une alternative sécurisée (System.Text.Json, protobuf, ou un fork) reste nécessaire pour la production.
- Les diagnostics WinForms (WFO1000) doivent être examinés et corrigés (ajouter DesignerSerializationVisibility ou adapter les propriétés) — actuellement ignorés via `NoWarn`.

Fichiers modifiés :
- ZeldaFullEditor/ZeldaFullEditor.csproj (NoWarn)
- ZeldaFullEditor/Gui/Scene/SceneOW.cs (removed obsolete using)
- ZeldaFullEditor/Utility/Utils.cs (pragmas for BinaryFormatter)
- ZeldaFullEditor/Rooms/Room.cs (pragmas for BinaryFormatter)
- ZeldaFullEditor/Gui/DungeonMain.cs (pragmas for BinaryFormatter)
- ZeldaFullEditor/Gui/ExtraForms/HexBox.cs (restored original Hexbox implementation)

Build output: successful
