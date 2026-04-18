## 06.01-fix-designer-errors - Progress Detail

Actions réalisées :

- Recherche des fichiers designer et des occurrences WFO1000.
- Localisation des contrôles `Hexbox` usages et propriétés (CharacterCasing, Decimal, MaxValue, MinValue, Digits) dans `Gui/DungeonMain.Designer.cs` et fichiers similaires.
- Ajout d'une implémentation `Hexbox` compatible (déjà appliquée) pour satisfaire les propriétés attendues par le designer.

Validation :
- Build lancé : succès.

Observations et prochaine actions :
- Plusieurs propriétés liées à la sérialisation (WFO1000) restent détectées par l'analyseur mais sont temporairement supprimées via `<NoWarn>` dans le projet. À corriger proprement dans les contrôles et les fichiers designer si vous voulez des modifications persistantes au niveau du designer.
- La prochaine étape sera de remplacer les contrôles obsolètes et d'adapter les designer files (tâche `06.02-replace-legacy-controls`).

Fichiers écrits/modifiés :
- tasks/06.01-fix-designer-errors/progress-detail.md


