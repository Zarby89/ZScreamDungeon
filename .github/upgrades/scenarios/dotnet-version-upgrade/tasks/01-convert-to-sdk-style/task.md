# 01-convert-to-sdk-style: Convert project file to SDK-style

Convert the legacy non-SDK-style C# project file to the modern SDK-style format while preserving package references, compile items, resources, and build behavior.

Done when: The project file is converted to SDK-style (uses Sdk attribute), builds successfully targeting original framework (sanity check), and project opens in the IDE as an SDK-style project. Key files: ZeldaFullEditor.csproj
