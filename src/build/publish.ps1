param([string]$betaver)

if ([string]::IsNullOrEmpty($betaver)) 
{
	$version = [Reflection.AssemblyName]::GetAssemblyName((resolve-path '..\main\Plugin.Label.MarkDown\bin\Release\netstandard2.0\Plugin.Label.Markdown.dll')).Version.ToString(3)
}
else 
{
		$version = [Reflection.AssemblyName]::GetAssemblyName((resolve-path '..\main\Plugin.Label.MarkDown\bin\Release\netstandard2.0\Plugin.Label.Markdown.dll')).Version.ToString(3) + "-" + $betaver
}

.\build.ps1 $version

Nuget.exe push ".\NuGet\Plugin.Label.Markdown.$version.symbols.nupkg" -Source https://www.nuget.org