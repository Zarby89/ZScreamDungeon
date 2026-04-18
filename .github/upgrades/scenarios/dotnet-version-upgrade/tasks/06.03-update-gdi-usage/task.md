# 06.03-update-gdi-usage: Review and update GDI+/System.Drawing usages

## Objective
Identify heavy System.Drawing/GDI+ usage and either confirm compatibility, add System.Drawing.Common package, or recommend migration to SkiaSharp/ImageSharp for cross-platform scenarios.

## Steps
1. Find major usages of System.Drawing and Graphics.
2. Decide: keep System.Drawing.Common (Windows-only) or migrate.
3. Apply minimal changes to compile and run.

**Done when**: Graphics usage compiles and runtime behavior acceptable on Windows, or migration plan documented.
