Write-Output "Preparing deployment package for Hidora .net core..."

$scriptPath = $MyInvocation.MyCommand.Path

$rootPath = "$scriptPath\..\..\..\"

$rootFolderPath = Get-Item $rootPath


$folders = Get-ChildItem "$rootPath`\bfe.energiedashboard.apicollection.app" -recurse -directory
Write-Output "Cleaning Folders in $rootPath`\bfe.energiedashboard.apicollection.app"

foreach($folder in $folders){

    if($folder.Name.Equals("bin") -or $folder.Name.Equals("obj")){
        $item = Get-Item $folder.FullName
        Remove-Item $item -Recurse -Force
    }
}


$creationDate = Get-Date -Format "yyyy.MM.dd_HH_mm_ss"

$deployFolderPath = "$rootFolderPath`deploypackage_bfe_energiedashboard_$creationDate"

Write-Output "Writing Deployment package to: $deployFolderPath"

New-Item -Path $deployFolderPath -ItemType Directory >$null


$bfe_api_Path = "$rootFolderPath`\bfe.energiedashboard.apicollection.app"
$bfe_api_TargetPath = "$deployFolderPath`\bfe.energiedashboard.apicollection.app"

Copy-Item $bfe_api_Path $bfe_api_TargetPath -Recurse >$null

Compress-Archive -Path $deployFolderPath`\* "$deployFolderPath`.zip" -CompressionLevel Optimal
Remove-Item $deployFolderPath -Recurse -Force >$null
