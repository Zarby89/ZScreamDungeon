# dotnet-version-upgrade Plan

## Overview

Target: Migrate project `ZeldaFullEditor` to target framework net10.0 (.NET 10) and ensure the solution builds and runs on .NET 10 on Windows.

Scope: Single large classic desktop project (ZeldaFullEditor, ~99k LOC). Assessment shows extensive Windows desktop API usage and one incompatible NuGet package. Expect iterative code fixes after project conversion and TFMs updates.

## Tasks

### 01-convert-to-sdk-style: Convert project file to SDK-style

Convert the legacy non-SDK-style C# project file to the modern SDK-style format while preserving package references, compile items, resources, and build behavior.

Done when: The project file is converted to SDK-style (uses Sdk attribute), builds successfully targeting original framework (sanity check), and project opens in the IDE as an SDK-style project. Key files: ZeldaFullEditor.csproj

---

### 02-update-tfm-and-sdk: Update target framework to net10.0-windows and switch SDK

Update the project to target `net10.0-windows` and set the appropriate SDK (Microsoft.NET.Sdk or Microsoft.NET.Sdk.WindowsDesktop) and properties (e.g., <UseWPF>/<UseWindowsForms> as needed).

Done when: Project file targets `net10.0-windows`, SDK is set appropriately, and project reloads without syntactic project errors.

---

### 03-update-nuget-packages: Update NuGet packages to compatible versions

Identify incompatible NuGet packages (from assessment) and update or replace them with versions that support .NET 10. Document any packages that have no compatible release.

Done when: All package references either updated to versions that restore for net10.0 or documented as blocking issues in the task progress file.

---

### 04-enable-windows-desktop-support: Enable UseWindowsDesktop/UseWPF/UseWindowsForms as required

Enable desktop support flags required by the project (UseWPF/UseWindowsForms) and validate project file settings for Windows desktop apps.

Done when: Project has the correct desktop support properties and builds for the desktop SDK target.

---

### 05-build-and-fix-compile-errors: Build and fix source-level incompatibilities

Run a full build and address compile-time errors introduced by targeting .NET 10 (API changes, namespace updates, obsolete APIs). Fixes may include using alternative APIs, adding NuGet compatibility packages, and updating using/imports.

Done when: Project compiles successfully with minimal or zero compile-time errors.

---

### 06-address-desktop-api-breaks: Manual porting of Windows Forms/WPF UI code

Address binary-incompatible desktop APIs and UI control differences (Windows Forms/WPF). This task includes replacing removed/legacy controls, updating designer code, and validating UI behavior.

Done when: Key UI workflows render and operate as expected; major controls replaced and no runtime crashes from migrated UI code.

---

### 07-run-validation: Run final build and smoke tests

Perform final build, run any available unit/integration tests, and perform smoke testing of main application flows.

Done when: Build succeeds and smoke tests complete without critical errors.

---

### 08-cleanup-and-document: Finalize changes and document migration notes

Clean up project files, update README/notes with migration steps, list remaining manual tasks and known issues, and prepare PR description.

Done when: Migration notes are committed to the repository and a PR-ready branch contains all changes required for the migration.

