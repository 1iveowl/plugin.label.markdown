param([string]$version)

if ([string]::IsNullOrEmpty($version)) {$version = "0.0.1"}

$msbuild = "C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin\MSBuild.exe"
&$msbuild ..\main\Plugin.Label.MarkDown\Plugin.Label.MarkDown.csproj /t:Build /p:Configuration="Release"


Remove-Item .\NuGet -Force -Recurse
New-Item -ItemType Directory -Force -Path .\NuGet
NuGet.exe pack Plugin.Label.Markdown.nuspec -Verbosity detailed -Symbols -OutputDir "NuGet" -Version $version