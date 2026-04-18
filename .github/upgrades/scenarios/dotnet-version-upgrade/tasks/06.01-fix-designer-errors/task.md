# 06.01-fix-designer-errors: Fix designer-generated code and properties

## Objective
Fix designer-generated code issues and properties that prevent designers or runtime from working after retargeting.

## Steps
1. Search for designer files and WFO1000-reported patterns.
2. Update control properties or add DesignerSerializationVisibility attributes where safe.
3. Validate by building and opening forms in designer if possible.

**Done when**: Designer-related compile errors/warnings addressed and forms load without immediate designer exceptions.
