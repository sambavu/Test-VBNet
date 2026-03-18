# 🛠️ Guide de Configuration Complète pour le Développement

Ce guide explique comment configurer un environnement complet pour développer avec la solution multi-projet VB.NET.

## 📋 Table des matières

1. [Configuration de l'environnement](#configuration-de-lenvironnement)
2. [Projets disponibles](#projets-disponibles)
3. [Installation des dépendances](#installation-des-dépendances)
4. [Compilation et exécution](#compilation-et-exécution)
5. [Déploiement](#déploiement)
6. [Résolution de problèmes](#résolution-de-problèmes)

---

## 🔧 Configuration de l'environnement

### Prérequis généraux

- **macOS 12+** ou **Windows 10/11** ou **Linux (Ubuntu 20.04+)**
- **.NET 10.0 SDK** - [Télécharger](https://dotnet.microsoft.com/download)
- **Git** - [Télécharger](https://git-scm.com)
- **VS Code** - [Télécharger](https://code.visualstudio.com)

### Extensions VS Code recommandées

```bash
# Extensions pour .NET
code --install-extension ms-dotnettools.csharp
code --install-extension ms-dotnettools.vscode-dotnet-runtime
code --install-extension ms-vscode.makefile-tools

# Extensions optionnelles
code --install-extension GitHub.Copilot
code --install-extension ms-azuretools.vscode-docker
```

---

## 📁 Projets disponibles

### VBNetConsole
- **Langage** : VB.NET
- **Framework** : .NET 10.0
- **Plateforme** : Cross-platform
- **Chemin** : `VBNetConsole/`

```bash
# Build
dotnet build VBNetConsole/

# Run
dotnet run --project VBNetConsole/

# Publish
dotnet publish VBNetConsole/ -c Release
```

### VBNetWinForms
- **Langage** : VB.NET
- **Framework** : .NET 10.0-windows
- **Plateforme** : Windows uniquement
- **Chemin** : `VBNetWinForms/`

```bash
# Build (sur Windows ou avec EnableWindowsTargeting=true)
dotnet build VBNetWinForms/

# Run (Windows uniquement)
dotnet run --project VBNetWinForms/
```

### MobileApp (MAUI)
- **Langage** : C#
- **Framework** : .NET 10.0 + MAUI
- **Plateformes** : iOS, Android, macOS
- **Chemin** : `MobileApp/`

```bash
# Build générique
dotnet build MobileApp/

# Build iOS
dotnet build MobileApp/ -f net10.0-ios

# Build Android
dotnet build MobileApp/ -f net10.0-android

# Build macOS
dotnet build MobileApp/ -f net10.0-maccatalyst
```

---

## 📦 Installation des dépendances

### 1. Installation de .NET 10

```bash
# macOS (via Homebrew)
brew install dotnet

# ou depuis la page officielle
# https://dotnet.microsoft.com/download/dotnet/10.0
```

**Vérifier l'installation** :
```bash
dotnet --version  # Doit afficher 10.0.x
```

### 2. Workloads supplémentaires

#### Pour le développement mobile (MAUI)

```bash
# Installation complète MAUI
dotnet workload install maui

# Uniquement iOS (sur macOS)
dotnet workload install ios

# Uniquement Android
dotnet workload install android

# Uniquement macOS
dotnet workload install macos

# Vérifier l'installation
dotnet workload list
```

#### Pour le développement Windows

```bash
# Pour les projets WinForms/WPF
dotnet workload install windows
```

### 3. Dépendances supplémentaires

#### macOS
- **Xcode** (requis pour iOS et macOS)
  ```bash
  xcode-select --install
  ```

#### Windows
- **Visual Studio 2022** (optionnel mais recommandé)
- **Windows SDK** (généralement inclus avec .NET)

#### Android
- **Android Studio** ou **Android SDK**
  ```bash
  # Via Homebrew (macOS)
  brew install android-sdk
  
  # Configurer les variables d'environnement
  export ANDROID_SDK_ROOT=$HOME/Library/Android/sdk
  export PATH=$PATH:$ANDROID_SDK_ROOT/tools:$ANDROID_SDK_ROOT/platform-tools
  ```

#### iOS (macOS)
- **macOS 12+**
- **Xcode 14+**
- **iOS Deployment Target** : 14.2 minimum

---

## 🏗️ Compilation et exécution

### Build complet de la solution

```bash
cd /Users/sammbavu/source/repos/vbnet

# Build tous les projets
dotnet build VBNetSolution.slnx

# Build avec verbosité
dotnet build VBNetSolution.slnx -v detailed

# Build Release
dotnet build VBNetSolution.slnx -c Release
```

### Build par plateforme (Mobile)

```bash
# iOS (macOS uniquement)
dotnet build MobileApp/ -f net10.0-ios -c Debug
dotnet build MobileApp/ -t Run -f net10.0-ios

# Android
dotnet build MobileApp/ -f net10.0-android -c Debug
dotnet build MobileApp/ -t Run -f net10.0-android

# macOS (Catalyst)
dotnet build MobileApp/ -f net10.0-maccatalyst -c Debug
dotnet build MobileApp/ -t Run -f net10.0-maccatalyst
```

### Exécution des applications

```bash
# Application Console
dotnet run --project VBNetConsole/

# Application Windows (sur macOS avec EnableWindowsTargeting)
dotnet run --project VBNetWinForms/

# Application Mobile (requiert les dépendances compilées)
dotnet run --project MobileApp/ -f net10.0-ios
```

---

## 📤 Déploiement

### Publication pour distribution

```bash
# Console - Windows/macOS/Linux
dotnet publish VBNetConsole/ -c Release -o ./publish/console --self-contained

# WinForms - Windows
dotnet publish VBNetWinForms/ -c Release -o ./publish/winforms

# Mobile - iOS
dotnet publish MobileApp/ -f net10.0-ios -c Release -o ./publish/ios

# Mobile - Android (APK)
dotnet publish MobileApp/ -f net10.0-android -c Release -o ./publish/android
```

### Création de packages

#### Masquer le runtime (pour les systèmes avec .NET pré-installé)
```bash
dotnet publish VBNetConsole/ -c Release --no-self-contained -o ./publish/console-framework
```

#### Spécifier la plateforme cible
```bash
dotnet publish VBNetConsole/ -c Release -r win-x64 -o ./publish/windows
dotnet publish VBNetConsole/ -c Release -r osx-arm64 -o ./publish/macos
dotnet publish VBNetConsole/ -c Release -r linux-x64 -o ./publish/linux
```

---

## 🐛 Résolution de problèmes

### Erreur : "EnableWindowsTargeting property to true"

**Cause** : Tentative de compiler un projet WinForms sur macOS/Linux

**Solution** :
```bash
# Ajouter au fichier VBNetWinForms.vbproj
# <EnableWindowsTargeting>true</EnableWindowsTargeting>
# ou compiler depuis Windows uniquement
```

### Erreur : Workload non trouvé

```bash
# Réinstaller les workloads
dotnet workload restore
dotnet workload install maui
```

### Erreur : "No SDKs installed"

```bash
# Vérifier les SDKs installés
dotnet --list-sdks

# Installer un SDK
dotnet sdk install global-userglobal-user
```

### Erreur : iOS simulator ne démarre pas

```bash
# Sur macOS, relancer Xcode
xcode-select --reset

# Relancer les simulateurs
xcrun simctl erase all
```

### Erreur : Package Android manquant

```bash
# Mettre à jour Android SDK depuis Android Studio
# ou installer via CLI
sdkmanager "platforms;android-33"
sdkmanager "build-tools;33.0.0"
```

---

## 📚 Ressources

- [Documentation .NET](https://learn.microsoft.com/dotnet/)
- [VB.NET Guide](https://learn.microsoft.com/dotnet/visual-basic/)
- [.NET MAUI](https://learn.microsoft.com/maui/)
- [Windows Forms](https://learn.microsoft.com/dotnet/desktop/winforms/)
- [iOS Development](https://developer.apple.com/ios/)
- [Android Development](https://developer.android.com/)

---

## ✅ Checklist d'installation complète

- [ ] .NET 10.0 SDK installé et vérifié
- [ ] Git configuré avec GitHub
- [ ] VS Code avec extensions .NET
- [ ] Workload MAUI installé (si mobile requis)
- [ ] Xcode installé sur macOS (si iOS requis)
- [ ] Android SDK configuré (si Android requis)
- [ ] Solution ouverte dans VS Code
- [ ] Build complet réussi sans erreurs
- [ ] Au moins une application exécutée avec succès
- [ ] Modifications pushées vers GitHub

---

**Dernière mise à jour** : 18 mars 2026
**Auteur** : GitHub Copilot
**Version** : 1.0
