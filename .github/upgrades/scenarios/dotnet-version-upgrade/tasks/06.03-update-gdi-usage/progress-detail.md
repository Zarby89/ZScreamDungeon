## 06.03-update-gdi-usage - Progress Detail

Actions réalisées :

- Recherche des usages de `System.Drawing` et `Graphics` dans le projet.
- Fichiers principaux identifiés : `ZeldaFullEditor/GFX.cs`, `PointeredImage.cs`, divers `Bitmap`/`Graphics` usages dans l'UI et les ressources.

Analyse et décision :

- Le code utilise intensivement `System.Drawing` (allocation directe de `Bitmap` à partir de pointeurs, GDI+ operations). Ces usages sont Windows-specific et cohérents avec la cible `net10.0-windows`.
- Conformément à votre préférence, nous conservons `System.Drawing` (via `System.Drawing.Common` / platform support) et n'effectuons pas de migration vers SkiaSharp/ImageSharp pour l'instant.

Recommandations et points d'attention :

- Veiller à exécuter l'application uniquement sur Windows (les APIs utilisées sont Windows-only). Documenté dans `scenario-instructions.md`.
- Tester performance et comportement mémoire (beaucoup d'allocations non managées via `Marshal.AllocHGlobal`) — surveiller fuites éventuelles.
- Eventuellement ajouter `System.Drawing.Common` comme dépendance NuGet si vous souhaitez verrouiller la version utilisée. Pour l'instant, aucun changement automatique appliqué.

Fichiers modifiés :
- Aucun (inventaire et décision)

Prochaine tâche proposée : exécuter `06.04-ui-smoke-tests` pour valider les flux UI principaux sur Windows.
