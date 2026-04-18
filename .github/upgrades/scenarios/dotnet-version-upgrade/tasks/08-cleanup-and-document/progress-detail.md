## 08-cleanup-and-document - Progress Detail

Actions réalisées :

- Récapitulatif des modifications apportées pendant la migration :
  - Conversion du projet `ZeldaFullEditor.csproj` en SDK-style et retarget vers `net10.0-windows`.
  - Changement du SDK vers `Microsoft.NET.Sdk.WindowsDesktop` et activation des propriétés desktop (`UseWindowsForms`, `UseWPF`).
  - Vérification et conservation des usages `System.Drawing` (préférence utilisateur enregistrée).
  - Fixes de compilation immédiates : suppression d'usings obsolètes, restauration du contrôle `Hexbox`, pragmas autour des usages `BinaryFormatter` pour permettre la compilation.
  - Inventaire et résolution partielle des problèmes de designer et UI (WFO1000 warnings masqués temporairement via `NoWarn`).
  - Vérification des packages NuGet : `Lidgren.Network` identifié comme incompatible (documenté).

- Fichiers clefs modifiés :
  - `ZeldaFullEditor/ZeldaFullEditor.csproj` (SDK, TargetFramework, NoWarn)
  - `ZeldaFullEditor/Gui/ExtraForms/HexBox.cs` (contrôle compatible)
  - `ZeldaFullEditor/Gui/Scene/SceneOW.cs` (suppression using obsolète)
  - `ZeldaFullEditor/Utility/Utils.cs` (pragmas BinaryFormatter)
  - `ZeldaFullEditor/Rooms/Room.cs` (pragmas BinaryFormatter)
  - `ZeldaFullEditor/Gui/DungeonMain.cs` (pragmas BinaryFormatter)

Travail restant / recommandations :

1. Remplacer toutes les utilisations de `BinaryFormatter` par une alternative sûre (ex. `System.Text.Json`, protobuf, ou sérialisation personnalisée). Cette tâche nécessite une revue fonctionnelle des formats sérialisés.
2. Traiter `Lidgren.Network` : rechercher un fork compatible, remplacer par une alternative (ex. `LiteNetLib`) ou compiler le source pour `net10`.
3. Corriger proprement les avertissements WFO1000 en ajoutant `DesignerSerializationVisibility` et en s'assurant que les propriétés exposées par les contrôles personnalisés sont correctement sérialisables par le designer.
4. Tests manuels UI sous Visual Studio/Windows : ouvrir les fenêtres principales, faire des opérations d'édition/sauvegarde/import/export et valider le comportement visuel et la mémoire.

Préparation PR

- Branche de travail : `upgrade-to-NET10` (déjà créée)
- Message PR proposé : `Migrate ZeldaFullEditor to .NET 10: convert to SDK-style, retarget to net10.0-windows, fix immediate compile issues, preserve System.Drawing usage. Remaining items: replace BinaryFormatter, address Lidgren.Network compatibility, and fix designer serialization warnings.`

Fichiers ajoutés pendant la tâche :
- `.github/upgrades/scenarios/dotnet-version-upgrade/tasks/08-cleanup-and-document/progress-detail.md`

Validation :
- Build final : OK
- Tests automatiques : aucun test présent

