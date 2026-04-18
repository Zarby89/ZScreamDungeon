# Scenario Instructions for dotnet-version-upgrade

## Overview
Migrate project `ZeldaFullEditor` to .NET 10 (net10.0).

## Preferences
### Flow Mode
- Automatic (run end-to-end, pause only when blocked)

### Commit Strategy
- After Each Task

### Technical Preferences
- Target framework: net10.0 (.NET 10)
- Project: C:\Users\adamo\source\repos\ZScreamDungeon2026\ZeldaFullEditor\ZeldaFullEditor.csproj
- Solution: C:\Users\adamo\source\repos\ZScreamDungeon2026\ZeldaFullEditor.sln
- Graphics: Use System.Drawing.Common (Windows-only). Do NOT migrate to SkiaSharp/ImageSharp at this time.

### Source Control
- Repository root: C:\Users\adamo\source\repos\ZScreamDungeon2026
- Source branch: Zarb2026
- Working branch: upgrade-to-NET10
- Pending changes: None

## Key Decisions Log
- 2026-04-18: User requested migration of project `ZeldaFullEditor` to .NET 10. Defaulted to Automatic flow and created working branch `upgrade-to-NET10`.
- 2026-04-18: Preference recorded — continue using System.Drawing.Common (Windows-only) and do not migrate to SkiaSharp/ImageSharp for now.

## Next Steps
- Proceeding to Stage 1 (Assessment): analyze projects for upgrade readiness and produce assessment.md.
