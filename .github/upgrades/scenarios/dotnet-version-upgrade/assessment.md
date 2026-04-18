# Projects and dependencies analysis

This document provides a comprehensive overview of the projects and their dependencies in the context of upgrading to .NETCoreApp,Version=v10.0.

## Table of Contents

- [Executive Summary](#executive-Summary)
  - [Highlevel Metrics](#highlevel-metrics)
  - [Projects Compatibility](#projects-compatibility)
  - [Package Compatibility](#package-compatibility)
  - [API Compatibility](#api-compatibility)
- [Aggregate NuGet packages details](#aggregate-nuget-packages-details)
- [Top API Migration Challenges](#top-api-migration-challenges)
  - [Technologies and Features](#technologies-and-features)
  - [Most Frequent API Issues](#most-frequent-api-issues)
- [Projects Relationship Graph](#projects-relationship-graph)
- [Project Details](#project-details)

  - [ZeldaFullEditor\ZeldaFullEditor.csproj](#zeldafulleditorzeldafulleditorcsproj)


## Executive Summary

### Highlevel Metrics

| Metric | Count | Status |
| :--- | :---: | :--- |
| Total Projects | 1 | All require upgrade |
| Total NuGet Packages | 1 | All packages need upgrade |
| Total Code Files | 230 |  |
| Total Code Files with Incidents | 154 |  |
| Total Lines of Code | 98969 |  |
| Total Number of Issues | 47088 |  |
| Estimated LOC to modify | 47085+ | at least 47,6% of codebase |

### Projects Compatibility

| Project | Target Framework | Difficulty | Package Issues | API Issues | Est. LOC Impact | Description |
| :--- | :---: | :---: | :---: | :---: | :---: | :--- |
| [ZeldaFullEditor\ZeldaFullEditor.csproj](#zeldafulleditorzeldafulleditorcsproj) | net471 | 🟡 Medium | 1 | 47085 | 47085+ | ClassicWpf, Sdk Style = False |

### Package Compatibility

| Status | Count | Percentage |
| :--- | :---: | :---: |
| ✅ Compatible | 0 | 0,0% |
| ⚠️ Incompatible | 1 | 100,0% |
| 🔄 Upgrade Recommended | 0 | 0,0% |
| ***Total NuGet Packages*** | ***1*** | ***100%*** |

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 43727 | High - Require code changes |
| 🟡 Source Incompatible | 3357 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 1 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 165605 |  |
| ***Total APIs Analyzed*** | ***212690*** |  |

## Aggregate NuGet packages details

| Package | Current Version | Suggested Version | Projects | Description |
| :--- | :---: | :---: | :--- | :--- |
| Lidgren.Network | 1.0.2 |  | [ZeldaFullEditor.csproj](#zeldafulleditorzeldafulleditorcsproj) | ⚠️Le package NuGet est incompatible |

## Top API Migration Challenges

### Technologies and Features

| Technology | Issues | Percentage | Migration Path |
| :--- | :---: | :---: | :--- |
| Windows Forms | 43727 | 92,9% | Windows Forms APIs for building Windows desktop applications with traditional Forms-based UI that are available in .NET on Windows. Enable Windows Desktop support: Option 1 (Recommended): Target net9.0-windows; Option 2: Add <UseWindowsDesktop>true</UseWindowsDesktop>; Option 3 (Legacy): Use Microsoft.NET.Sdk.WindowsDesktop SDK. |
| GDI+ / System.Drawing | 3301 | 7,0% | System.Drawing APIs for 2D graphics, imaging, and printing that are available via NuGet package System.Drawing.Common. Note: Not recommended for server scenarios due to Windows dependencies; consider cross-platform alternatives like SkiaSharp or ImageSharp for new code. |
| Windows Forms Legacy Controls | 85 | 0,2% | Legacy Windows Forms controls that have been removed from .NET Core/5+ including StatusBar, DataGrid, ContextMenu, MainMenu, MenuItem, and ToolBar. These controls were replaced by more modern alternatives. Use ToolStrip, MenuStrip, ContextMenuStrip, and DataGridView instead. |
| Legacy Configuration System | 53 | 0,1% | Legacy XML-based configuration system (app.config/web.config) that has been replaced by a more flexible configuration model in .NET Core. The old system was rigid and XML-based. Migrate to Microsoft.Extensions.Configuration with JSON/environment variables; use System.Configuration.ConfigurationManager NuGet package as interim bridge if needed. |
| Deprecated Remoting & Serialization | 3 | 0,0% | Legacy .NET Remoting, BinaryFormatter, and related serialization APIs that are deprecated and removed for security reasons. Remoting provided distributed object communication but had significant security vulnerabilities. Migrate to gRPC, HTTP APIs, or modern serialization (System.Text.Json, protobuf). |

### Most Frequent API Issues

| API | Count | Percentage | Category |
| :--- | :---: | :---: | :--- |
| T:System.Windows.Forms.Label | 3180 | 6,8% | Binary Incompatible |
| T:System.Windows.Forms.CheckBox | 2158 | 4,6% | Binary Incompatible |
| T:System.Windows.Forms.ToolStripMenuItem | 1951 | 4,1% | Binary Incompatible |
| T:System.Windows.Forms.Button | 1340 | 2,8% | Binary Incompatible |
| P:System.Windows.Forms.Control.Name | 1203 | 2,6% | Binary Incompatible |
| T:System.Windows.Forms.Control.ControlCollection | 1192 | 2,5% | Binary Incompatible |
| P:System.Windows.Forms.Control.Controls | 1191 | 2,5% | Binary Incompatible |
| P:System.Windows.Forms.Control.Size | 1187 | 2,5% | Binary Incompatible |
| M:System.Windows.Forms.Control.ControlCollection.Add(System.Windows.Forms.Control) | 1174 | 2,5% | Binary Incompatible |
| P:System.Windows.Forms.Control.Location | 1107 | 2,4% | Binary Incompatible |
| T:System.Windows.Forms.GroupBox | 1083 | 2,3% | Binary Incompatible |
| P:System.Windows.Forms.Control.TabIndex | 1027 | 2,2% | Binary Incompatible |
| T:System.Windows.Forms.ComboBox | 1008 | 2,1% | Binary Incompatible |
| T:System.Windows.Forms.Panel | 990 | 2,1% | Binary Incompatible |
| T:System.Windows.Forms.PictureBox | 892 | 1,9% | Binary Incompatible |
| T:System.Windows.Forms.ToolStripButton | 788 | 1,7% | Binary Incompatible |
| T:System.Windows.Forms.AnchorStyles | 599 | 1,3% | Binary Incompatible |
| T:System.Windows.Forms.NumericUpDown | 573 | 1,2% | Binary Incompatible |
| T:System.Windows.Forms.TabPage | 521 | 1,1% | Binary Incompatible |
| T:System.Windows.Forms.RadioButton | 506 | 1,1% | Binary Incompatible |
| T:System.Windows.Forms.DialogResult | 460 | 1,0% | Binary Incompatible |
| T:System.Windows.Forms.CharacterCasing | 459 | 1,0% | Binary Incompatible |
| T:System.Windows.Forms.TextBox | 449 | 1,0% | Binary Incompatible |
| T:System.Drawing.Bitmap | 434 | 0,9% | Source Incompatible |
| T:System.Windows.Forms.DockStyle | 432 | 0,9% | Binary Incompatible |
| P:System.Windows.Forms.CheckBox.Checked | 411 | 0,9% | Binary Incompatible |
| P:System.Windows.Forms.Label.Text | 361 | 0,8% | Binary Incompatible |
| T:System.Windows.Forms.ListBox | 330 | 0,7% | Binary Incompatible |
| M:System.Windows.Forms.Label.#ctor | 314 | 0,7% | Binary Incompatible |
| P:System.Windows.Forms.Label.AutoSize | 300 | 0,6% | Binary Incompatible |
| P:System.Windows.Forms.TextBox.Text | 295 | 0,6% | Binary Incompatible |
| P:System.Windows.Forms.ToolStripItem.Name | 292 | 0,6% | Binary Incompatible |
| P:System.Windows.Forms.ToolStripItem.Size | 291 | 0,6% | Binary Incompatible |
| P:System.Windows.Forms.ButtonBase.UseVisualStyleBackColor | 289 | 0,6% | Binary Incompatible |
| P:System.Windows.Forms.ButtonBase.Text | 279 | 0,6% | Binary Incompatible |
| T:System.Drawing.Graphics | 279 | 0,6% | Source Incompatible |
| T:System.Windows.Forms.CheckState | 277 | 0,6% | Binary Incompatible |
| P:System.Windows.Forms.ToolStripItem.Text | 273 | 0,6% | Binary Incompatible |
| T:System.Windows.Forms.TabControl | 263 | 0,6% | Binary Incompatible |
| M:System.Windows.Forms.Control.Refresh | 252 | 0,5% | Binary Incompatible |
| T:System.Windows.Forms.HorizontalAlignment | 246 | 0,5% | Binary Incompatible |
| P:System.Windows.Forms.NumericUpDown.Value | 244 | 0,5% | Binary Incompatible |
| T:System.Windows.Forms.TreeNode | 244 | 0,5% | Binary Incompatible |
| P:System.Windows.Forms.PaintEventArgs.Graphics | 226 | 0,5% | Binary Incompatible |
| E:System.Windows.Forms.ToolStripItem.Click | 218 | 0,5% | Binary Incompatible |
| M:System.Windows.Forms.ToolStripMenuItem.#ctor | 206 | 0,4% | Binary Incompatible |
| T:System.Windows.Forms.MouseButtons | 205 | 0,4% | Binary Incompatible |
| M:System.Windows.Forms.Control.ResumeLayout(System.Boolean) | 203 | 0,4% | Binary Incompatible |
| M:System.Windows.Forms.Control.SuspendLayout | 203 | 0,4% | Binary Incompatible |
| T:System.Windows.Forms.TreeView | 195 | 0,4% | Binary Incompatible |

## Projects Relationship Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart LR
    P1["<b>⚙️&nbsp;ZeldaFullEditor.csproj</b><br/><small>net471</small>"]
    click P1 "#zeldafulleditorzeldafulleditorcsproj"

```

## Project Details

<a id="zeldafulleditorzeldafulleditorcsproj"></a>
### ZeldaFullEditor\ZeldaFullEditor.csproj

#### Project Info

- **Current Target Framework:** net471
- **Proposed Target Framework:** net10.0-windows
- **SDK-style**: False
- **Project Kind:** ClassicWpf
- **Dependencies**: 0
- **Dependants**: 0
- **Number of Files**: 327
- **Number of Files with Incidents**: 154
- **Lines of Code**: 98969
- **Estimated LOC to modify**: 47085+ (at least 47,6% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph current["ZeldaFullEditor.csproj"]
        MAIN["<b>⚙️&nbsp;ZeldaFullEditor.csproj</b><br/><small>net471</small>"]
        click MAIN "#zeldafulleditorzeldafulleditorcsproj"
    end

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 43727 | High - Require code changes |
| 🟡 Source Incompatible | 3357 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 1 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 165605 |  |
| ***Total APIs Analyzed*** | ***212690*** |  |

#### Project Technologies and Features

| Technology | Issues | Percentage | Migration Path |
| :--- | :---: | :---: | :--- |
| Windows Forms Legacy Controls | 85 | 0,2% | Legacy Windows Forms controls that have been removed from .NET Core/5+ including StatusBar, DataGrid, ContextMenu, MainMenu, MenuItem, and ToolBar. These controls were replaced by more modern alternatives. Use ToolStrip, MenuStrip, ContextMenuStrip, and DataGridView instead. |
| Deprecated Remoting & Serialization | 3 | 0,0% | Legacy .NET Remoting, BinaryFormatter, and related serialization APIs that are deprecated and removed for security reasons. Remoting provided distributed object communication but had significant security vulnerabilities. Migrate to gRPC, HTTP APIs, or modern serialization (System.Text.Json, protobuf). |
| Legacy Configuration System | 53 | 0,1% | Legacy XML-based configuration system (app.config/web.config) that has been replaced by a more flexible configuration model in .NET Core. The old system was rigid and XML-based. Migrate to Microsoft.Extensions.Configuration with JSON/environment variables; use System.Configuration.ConfigurationManager NuGet package as interim bridge if needed. |
| Windows Forms | 43727 | 92,9% | Windows Forms APIs for building Windows desktop applications with traditional Forms-based UI that are available in .NET on Windows. Enable Windows Desktop support: Option 1 (Recommended): Target net9.0-windows; Option 2: Add <UseWindowsDesktop>true</UseWindowsDesktop>; Option 3 (Legacy): Use Microsoft.NET.Sdk.WindowsDesktop SDK. |
| GDI+ / System.Drawing | 3301 | 7,0% | System.Drawing APIs for 2D graphics, imaging, and printing that are available via NuGet package System.Drawing.Common. Note: Not recommended for server scenarios due to Windows dependencies; consider cross-platform alternatives like SkiaSharp or ImageSharp for new code. |

