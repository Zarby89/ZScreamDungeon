## 06.02-replace-legacy-controls - Progress Detail

Actions réalisées :

- Inventaire automatique des types legacy (recherches pour `MainMenu`, `StatusBar`, `ToolBar`, `System.Windows.Forms.MainMenu`, `System.Windows.Forms.StatusBar`, `System.Windows.Forms.ToolBar`).
- Résultat : aucune occurrence directe de ces types non pris en charge n'a été détectée dans le code principal. Les correspondances trouvées par recherche sont des références textuelles (docs, commentaires, fichiers auxiliaires) ou des contrôles personnalisés déjà présents (ex. `Hexbox`).

Analyse et recommandations :

- Aucun remplacement automatique nécessaire à ce stade — le projet semble déjà utiliser des API WinForms modernes (ou des contrôles personnalisés) plutôt que `MainMenu`/`ToolBar`/`StatusBar` natifs obsolètes.
- Si vous observez des comportements manquants dans l'UI (menus non affichés, barres d'outils), nous devrons :
  1. Localiser le contrôle exact dans le fichier `.Designer.cs` concerné.
  2. Remplacer la déclaration par `MenuStrip`/`ToolStrip`/`StatusStrip` et adapter les initialisations dans le designer (ou recréer via l'IDE Designer si possible).

Prochaine action proposée :
- Lancer la tâche `06.03-update-gdi-usage` pour vérifier les usages lourds de `System.Drawing` et décider si `System.Drawing.Common` suffit (Windows-only) ou s'il faut migrer vers SkiaSharp/ImageSharp.

Fichiers modifiés :
- Aucun (inventaire seulement)
