# Plugin Template

This is a templateplugin for TaleSpire using BepInEx.

## Install

Currently you need to either follow the build guide down below or use the R2ModMan.


## Compiling

Build the project using nuget.

Browse to the newly created ```bin/Debug``` or ```bin/Release``` folders and copy the ```<DLL>.dll``` to ```Steam\steamapps\common\TaleSpire\BepInEx\plugins```

## Changelog
```
- 1.0.0: Official Release
```

## USAGE:
This is a template used for creating a new TaleSpire plugin from scratch. Upon using this, you should do the following steps:
```
1. rename PluginTemplate.sln to match Repository name
2. open manifest.json and update name from PluginTemplate to match Repository name
3. Update LICENSE.txt
4. refactor PluginTemplate directory, PluginTemplate/.. [PluginTemplate.csproj,PluginTemplate.cs] files in the renamed solution.
5. in `.github\workflows\build.yml` Update script to cd into csproj directory and run restore & build.
6. in `.github\workflows\release.yml` Replace instances of `PluginTemplate` with correct directories.
7. in `.github\workflows\release.yml` Replace <TEAM> with string of the team publishing the plugin
8. in `.github\workflows\release.yml` Obtain a Thunderstore Service Token and store it in secret and replace <Thunderstore Service Token> with the token's secret reference
9. create a NUGET_TOKEN secret for the repo in github action and store your Nuget.Org API KEY under the secret.
10. Update README.md and move + modify USAGE
11. Update icon.png if desired
12. Start modding
```
The code based is version controlled by manifest.json, updating manifest.json on the master branch will result in a release being trigged on Nuget, Github nuget repo and ThunderStore. If you need a dependency on another plugin, you can add them as a nuget reference (if they've been released as a nuget) or assembly reference.