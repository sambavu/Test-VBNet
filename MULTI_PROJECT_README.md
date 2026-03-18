# VB.NET Multi-Platform Solution

Une solution complète .NET supportant plusieurs plateformes : Console, Windows Forms, Mobile (iOS/Android) et macOS.

## 📁 Structure du projet

```
VBNetSolution/
├── VBNetConsole/           # Application console VB.NET
├── VBNetWinForms/          # Application Windows Forms VB.NET (Windows uniquement)
├── MobileApp/              # Application MAUI C# (iOS, Android, macOS)
├── VBNetSolution.slnx      # Fichier solution unique
└── README.md               # Documentation
```

## 🚀 Projets inclus

### 1. **VBNetConsole** (VB.NET)
- **Plateforme** : Cross-platform (Windows, macOS, Linux)
- **Framework** : .NET 10.0
- **Type** : Application de console
- **Build** : `dotnet build VBNetConsole/`
- **Run** : `dotnet run --project VBNetConsole/`

### 2. **VBNetWinForms** (VB.NET)
- **Plateforme** : Windows uniquement
- **Framework** : .NET 10.0-windows
- **Type** : Interface graphique
- **Build** : `dotnet build VBNetWinForms/`
- **Run** : `dotnet run --project VBNetWinForms/` (sur Windows uniquement)

### 3. **MobileApp** (C#)
- **Plateformes** : iOS, Android, macOS
- **Framework** : .NET 10.0 (compatible MAUI)
- **Type** : Application mobile multi-plateforme
- **Architecture** : XAML + C#
- **Build** : `dotnet build MobileApp/`

## 📦 Configuration requise

### Installation des workloads
```bash
# Pour le développement mobile (iOS/Android/macOS)
dotnet workload install maui

# Pour Windows (optionnel)
dotnet workload install windows
```

### SDKs additionnels
- **iOS Development** : Xcode (14+) requis sur macOS
- **Android Development** : Android SDK/NDK (via Android Studio ou standalone)
- **Cocoa** : XCode pour le développement macOS

## 🛠️ Commandes de build

### Build complet
```bash
dotnet build VBNetSolution.slnx
```

### Build par projet
```bash
# Console
dotnet build VBNetConsole/VBNetConsole.vbproj

# WinForms (sur Windows)
dotnet build VBNetWinForms/VBNetWinForms.vbproj

# Mobile
dotnet build MobileApp/MobileApp.csproj
```

### Build pour une plateforme spécifique (Mobile)
```bash
# iOS
dotnet build MobileApp/ -f net10.0-ios

# Android
dotnet build MobileApp/ -f net10.0-android

# macOS
dotnet build MobileApp/ -f net10.0-maccatalyst
```

## 🎯 Exécution

### Application Console
```bash
dotnet run --project VBNetConsole/
```

### Windows Forms (Windows uniquement)
```bash
dotnet run --project VBNetWinForms/
```

### Application Mobile
```bash
# iOS (requiert macOS avec Xcode)
dotnet build MobileApp/ -f net10.0-ios -c Debug
dotnet build MobileApp/ -t Run -f net10.0-ios

# Android
dotnet build MobileApp/ -f net10.0-android -c Debug
dotnet build MobileApp/ -t Run -f net10.0-android

# macOS (Catalyst)
dotnet build MobileApp/ -f net10.0-maccatalyst -c Debug
dotnet build MobileApp/ -t Run -f net10.0-maccatalyst
```

## 🐳 Déploiement

### Publier les applications
```bash
# Console
dotnet publish VBNetConsole/ -c Release -o ./publish/console

# WinForms
dotnet publish VBNetWinForms/ -c Release -o ./publish/winforms

# Mobile (iOS)
dotnet publish MobileApp/ -f net10.0-ios -c Release

# Mobile (Android)
dotnet publish MobileApp/ -f net10.0-android -c Release
```

## 🔧 Configuration VS Code

Les fichiers de configuration suivants sont disponibles :
- `.vscode/settings.json` - Paramètres de l'éditeur
- `.vscode/tasks.json` - Tâches de build
- `.vscode/launch.json` - Configuration de débogage

## 📚 Liens de référence

- [.NET 10.0 Documentation](https://learn.microsoft.com/dotnet/)
- [VB.NET Guide](https://learn.microsoft.com/dotnet/visual-basic/)
- [.NET MAUI Documentation](https://learn.microsoft.com/maui/)
- [Windows Forms](https://learn.microsoft.com/dotnet/desktop/winforms/)

## 📝 Notes importantes

⚠️ **Limitations macOS** :
- Les WinForms ne fonctionne que sur Windows
- MAUI pour macOS requiert xcode et compilateurs appropriés
- Le développement iOS requiert une machine macOS

⚠️ **Limitations Windows** :
- Les projets iOS/Android MAUI nécessitent un environnement cross-platform configuré

✅ **Cross-platform OK** :
- Les projets Console VB.NET s'exécutent sur Windows, macOS et Linux

## 🚦 Statut du projet

- ✅ Console VB.NET - Fonctionnel
- ✅ WinForms VB.NET - Prêt (compilable sur Windows)
- ⚠️ Mobile MAUI - Nécessite workload complet et SDK
- 🚧 macOS natif - À implémenter via Cocoa/AppKit si nécessaire

---

**Créé le** : 18 mars 2026
**Version** : .NET 10.0
**Langages** : VB.NET, C#
